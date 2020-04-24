using Autofac;

namespace GS.Core.Helpers.Helpers.DI
{
    public class ModuleRegistry
    {
        public ContainerBuilder Builder { get; private set; }

        public ModuleRegistry(ContainerBuilder builder)
        {
            Builder = builder;
        }
    }
}