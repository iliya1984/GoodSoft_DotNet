using Autofac;
using GS.Logging.Repositories.Repositories;
using NLog.Web;

namespace GS.Logging.Repositories.DI
{
    public class RepositoriesDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var nlogFactory =  NLogBuilder.ConfigureNLog("nlog.config");
            builder.Register(c => new NLogLoggingRepository(nlogFactory));
        }
    }
}