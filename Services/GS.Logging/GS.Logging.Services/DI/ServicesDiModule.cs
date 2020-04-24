using System;
using Autofac;
using GS.Core.Logging.DI;
using GS.Core.Logging.Interfaces;
using GS.Logging.Entities.Modules;
using GS.Logging.Entities.Settings;
using GS.Logging.Repositories.DI;
using GS.Logging.Repositories.Interfaces;
using GS.Logging.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GS.Logging.Services.DI
{
    public class ServicesDIModule : Module
    {
        private IConfiguration _configuration;

        public ServicesDIModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreLoggingDIModule(_configuration));
            builder.RegisterModule<RepositoriesDiModule>();
            
            builder
                .Register(c =>
                {
                    var loggingFactory = c.Resolve<ICoreLoggerFactory>();
                    try
                    {
                        var repository = c.Resolve<ILoggingRepository>();

                        Func<LoggingSettings, LoggingModule, ILoggingService> factory = (s, m) =>
                            {
                                return new LoggingService(s, m, _configuration, repository, loggingFactory);
                            }; 

                        return new LoggingServiceFactory(factory, loggingFactory);
                    }
                    catch(Exception ex)
                    {
                        loggingFactory.GetLoggerForType<ServicesDIModule>().Error(ex);
                        return null;
                    }
                })
                .As<ILoggingServiceFactory>();
        }
    }
}