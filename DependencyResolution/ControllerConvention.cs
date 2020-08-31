using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.TypeRules;
using Microsoft.AspNetCore.Mvc;
using StructureMap.Pipeline;

namespace SmartMirror.DependencyResolution
{
    public class ControllerConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach(var type in types.AllTypes())
            {
                if (type.CanBeCastTo<Controller>() && !type.IsAbstract)
                {
                    registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
                }
            }
        }
    }
}
