using Autofac;
using Autofac.Core.Registration;
using GS.Core.Messaging.Producers.DI;
using Microsoft.Extensions.Configuration;

namespace GS.Core.Messaging.Producers
{
    public static class ProducerExtensions
    {
        public static IModuleRegistrar RegisterProducersModule(this ContainerBuilder builder, IConfiguration configuration)
        {
            if(builder != null)
            {
                return builder.RegisterModule(new ProducerDIModule(configuration));
            }

            return null;
        }
    }
}