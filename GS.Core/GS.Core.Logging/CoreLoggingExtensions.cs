using Autofac;
using Autofac.Core.Registration;
using GS.Core.Logging.DI;
using Microsoft.Extensions.Configuration;

namespace GS.Core.Logging
{
    public static class CoreLoggingExtensions
    {
        public static IModuleRegistrar RegisterCoreLoggingModule(this ContainerBuilder builder, IConfiguration configuration)
        {
            if(builder != null)
            {
                return builder.RegisterModule(new CoreLoggingDIModule(configuration));
            }

            return null;
        }
    }
}