using Autofac;
using GS.Logging.Repositories.Interfaces;
using GS.Logging.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using NLog.Web;

namespace GS.Logging.Repositories.DI
{
    public class RepositoriesDiModule : Module
    {
        // private IConfiguration _configuration;

        // public RepositoriesDiModule(IConfiguration configuration)
        // {
        //     _configuration = configuration;
        // }


        protected override void Load(ContainerBuilder builder)
        {         
            var nlogFactory =  NLogBuilder.ConfigureNLog("nlog.config");
            builder
                .Register(c => new NLogLoggingRepository(nlogFactory))
                .As<ILoggingRepository>();
        }
    }
}