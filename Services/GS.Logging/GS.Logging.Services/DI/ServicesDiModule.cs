using Autofac;
using GS.Logging.Repositories.DI;
using GS.Logging.Services.Interfaces;

namespace GS.Logging.Services.DI
{
    public class ServicesDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoriesDiModule>();
            builder.RegisterType<LoggingService>().As<ILoggingService>();
        }
    }
}