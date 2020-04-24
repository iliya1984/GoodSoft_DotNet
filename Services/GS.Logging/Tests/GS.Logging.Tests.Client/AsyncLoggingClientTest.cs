using System;
using Xunit;
using Autofac;
using GS.Logging.Client.Interfaces;
using GS.Logging.Client.Clients;
using GS.Logging.Entities;
using System.Threading.Tasks;

namespace GS.Logging.Tests.Client
{
    [LoggingTestLoggable]
    public class AsyncLoggingClientTest : LoggingClientTest
    {
        [Fact]
        public async Task When_LoggingError_Get_Success()
        {
            //Arrange
            var contianer = createContainer();
            var loggingFactory = contianer.Resolve<ILoggingFactory>();
            var logger = loggingFactory.GetAsyncClientByType<AsyncLoggingClientTest>();

            //Act
            await logger.ErrorAsync("test error");

            //Assert
            int i = 0;
        }
    }
}
