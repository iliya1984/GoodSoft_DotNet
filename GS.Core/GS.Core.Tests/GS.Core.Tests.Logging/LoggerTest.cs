using System;
using Autofac;
using GS.Core.Logging.DI;
using GS.Core.Logging.Interfaces;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace GS.Core.Tests.Logging
{
    public class LoggerTest
    {
        [Fact]
        public void When_Logging_Error_Get_Success()
        {
            //Arrange
            var logger = createLogger();

            //Act
            logger.Error("Test error");

            //Assert
        }

        [Fact]
        public void When_Logging_Exception_Get_Success()
        {
            //Arrange
            var logger = createLogger();

            //Act
            logger.Exception(new Exception("Test exception"));

            //Assert
        }

        private ICoreLogger createLogger()
        {
            var container = createContainer();
            var loggerFactory = container.Resolve<ICoreLoggerFactory>();
            var logger = loggerFactory.GetLoggerForType<LoggerTest>();
            return logger;
        }

        private IContainer createContainer()
        {
            var configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            var builder = new ContainerBuilder();
            builder.RegisterModule(new CoreLoggingDIModule(configurationRoot));

            return builder.Build();
        }
    }
}
