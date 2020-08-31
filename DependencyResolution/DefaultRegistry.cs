using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StructureMap;


namespace SmartMirror.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.AssembliesAndExecutablesFromApplicationBaseDirectory();
                scan.WithDefaultConventions();
                scan.With(new ControllerConvention());
            });
        }
    }
}
