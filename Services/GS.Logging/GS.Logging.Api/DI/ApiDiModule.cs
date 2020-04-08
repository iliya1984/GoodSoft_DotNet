using Autofac;
using GS.Logging.Services.DI;

namespace GS.Logging.Api.DI
{
    public class ApiDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServicesDIModule>();
        }
    }
}