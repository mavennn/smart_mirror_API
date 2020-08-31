using StructureMap;

namespace SmartMirror.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c =>
            {
                c.AddRegistry<SMBasedRegistry>();
                c.AddRegistry<DefaultRegistry>();
            });
        }
    }
}
