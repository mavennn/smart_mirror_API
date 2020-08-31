using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMirror.Domain;
using SmartMirror.Domain.Repositories;
using StructureMap;
using StructureMap.Pipeline;

namespace SmartMirror.DependencyResolution
{
    public class SMBasedRegistry : Registry
    {
        public SMBasedRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<IUnitOfWork>();
                scan.WithDefaultConventions();
                scan.With(new ControllerConvention());
            });

            For<IUnitOfWork>().LifecycleIs(Lifecycles.Container).Use<UnitOfWork>().Ctor<SmartMirrorDbContext>().Is<SmartMirrorDbContext>();
        }
    }
}
