using Autofac;
using GS.Core.Logging.DI;
using GS.Core.Logging.Interfaces;
using GS.Logging.Repositories.Interfaces;
using GS.Logging.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using NLog.Web;

namespace GS.Logging.Repositories.DI
{
    public class RepositoriesDiModule : Module
    {
        private IConfiguration _configuration;

        public RepositoriesDiModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {         
            var nlogFactory =  NLogBuilder.ConfigureNLog("nlog.config");
            
            builder
                .RegisterModule(new CoreLoggingDIModule(_configuration));
            
            builder
                .Register(c => 
                {
                    var loggerFactory = c.Resolve<ICoreLoggerFactory>();
                    return new NLogLoggingRepository(nlogFactory, loggerFactory);
                })
                .As<ILoggingRepository>();
        }
    }
}