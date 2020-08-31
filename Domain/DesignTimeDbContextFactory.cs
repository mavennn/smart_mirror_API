using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SmartMirror.Domain
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SmartMirrorDbContext>
    {
        public SmartMirrorDbContext CreateDbContext(string[] argc)
        {
            return new SmartMirrorDbContext(new DbContextOptions<SmartMirrorDbContext>());
        }
    }
}
