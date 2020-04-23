using System;
using Autofac;
using GS.Core.Logging.Entities;
using GS.Core.Logging.Interfaces;
using GS.Core.Logging.Loggers;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;

namespace GS.Core.Logging.DI
{
    public class CoreLoggingDIModule : Module
    {
        private LogFactory _loggerFactory;
        private ILogger _logger;
        private IConfiguration _configuration;

        public CoreLoggingDIModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override void Load(ContainerBuilder builder)
        {
            string loggingSettingsFile = _configuration["CoreSettings:Logging:ConfigFile"];

            _loggerFactory = NLogBuilder.ConfigureNLog(loggingSettingsFile);
            _logger = _loggerFactory.GetCurrentClassLogger();

            builder
                .Register(c =>
                {
                    return new CoreLoggerConfigurationManager(_configuration);
                })
                .As<ICoreLoggerConfigurationManager>();

            builder
                .Register(c =>
               {
                   try
                   {
                       Func<LoggingSettings, ICoreLogger> innerFactory = (loggingSettings) =>
                            {
                                switch (loggingSettings.LoggerType)
                                {
                                    case ECoreLogging.LoggerType.NLog:
                                    default:
                                        return new NLogLogger(_loggerFactory, loggingSettings);
                                }
                            };
                       var configurationManager = c.Resolve<ICoreLoggerConfigurationManager>();

                       return new CoreLoggerFactory(innerFactory, configurationManager, _loggerFactory);
                   }
                   catch (Exception ex)
                   {
                       _logger.Error(ex);
                       throw;
                   }
               })
                .As<ICoreLoggerFactory>();

        }
    }
}