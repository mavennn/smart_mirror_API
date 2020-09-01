using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StructureMap;
using SmartMirror.Domain;
using SmartMirror.DependencyResolution;

namespace SmartMirror
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SmartMirrorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyMethod()
                .AllowCredentials()
                .SetIsOriginAllowed((host) => true)
                .AllowAnyHeader()
                .AllowAnyOrigin());
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var container = new Container();

            container.Configure(config =>
            {
                config.AddRegistry(new SMBasedRegistry());
                config.AddRegistry(new DefaultRegistry());

                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseMvc(routes =>
                routes.MapRoute(name: "default", template: "{controller}/{action=Index}/{id?}")
            ); ;
        }
    }
}
