using System;
using Autofac;
using GS.Core.Helpers.Helpers.DI;

namespace GS.Core.Helpers.Extensions
{
    public static class DIExtensions
    {
        public static void Modules(this ContainerBuilder builder, Action<ModuleRegistry> registryMethod)
        {
            if(builder != null)
            {
                var registry = new ModuleRegistry(builder);
                registryMethod.Invoke(registry);
            }

            throw new Exception("Error: Failed to create Module Registry, container builder was not set");
        }
    }
}