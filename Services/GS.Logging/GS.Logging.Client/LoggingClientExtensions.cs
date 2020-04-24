using Autofac.Core.Registration;
using GS.Core.Helpers.Helpers.DI;
using GS.Logging.Client.DI;
using Microsoft.Extensions.Configuration;
using Autofac;

namespace GS.Logging.Client
{
    public static class LoggingClientExtensions
    {
        public static IModuleRegistrar RegisterLoggingClient(this ModuleRegistry registry, IConfiguration configuration)
        {
            if(registry != null && registry.Builder != null)
            {
                return registry.Builder.RegisterModule(new LoggingClientDIModule(configuration));
            }

            return null;
        }
    }
}