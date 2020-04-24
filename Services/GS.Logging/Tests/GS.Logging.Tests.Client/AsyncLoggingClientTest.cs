using System;
using Xunit;
using Autofac;
using GS.Logging.Client.Interfaces;

namespace GS.Logging.Tests.Client
{
    public class AsyncLoggingClientTest : LoggingClientTest
    {
        [Fact]
        public void When_LoggingError_Get_Success()
        {
            //Arrange
            var contianer = createContainer();
            var loggingFactory = contianer.Resolve<ILoggingFactory>();
            var logger = loggingFactory.GetAsyncClientByType<AsyncLoggingClientTest>();

            //Act
            var task = logger.ErrorAsync("test error");
            task.Wait();

            //Assert
            int i = 0;
        }
    }
}
