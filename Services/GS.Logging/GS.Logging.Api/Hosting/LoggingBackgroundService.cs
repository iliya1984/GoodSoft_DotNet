using System;
using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Consumers.Hosting;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Interfaces;
using GS.Logging.Entities;
using GS.Logging.Entities.Messages;
using GS.Logging.Entities.Records;
using GS.Logging.Entities.Settings;
using GS.Logging.Services.Interfaces;

namespace GS.Logging.Api.Hosting
{
    public class LoggingBackgroundService : ConsumerBackgroundService
    {
        private ILoggingServiceFactory _serviceFactory;

        public LoggingBackgroundService(ILoggingServiceFactory serviceFactory, IConsumerFactory factory, ICoreLoggerFactory logFactory) : base(factory, logFactory)
        {
            _serviceFactory = serviceFactory;
        }

        protected override async Task ExecuteServiceAsync(IConsumptionRequest request)
        {
            try
            {
                using(var consumer = ConsumerFactory.CreateConsumer())
                {
                    consumer.Subscribe(new Topic{ Id = "1", Name="error-logs" });

                    while(false == request.CancellationToken.IsCancellationRequested)
                    {
                        var result = consumer.Consume<LoggingMessage>(30000);

                        if(result == null)
                        {
                            var settings = new LoggingSettings();
                            settings.LoggerName = "Default";

                            var module = result.Value.Module;
                            var severity = result.Value.Severity;
                            var servie = _serviceFactory.CreateService(settings, module);

                            switch(severity)
                            {
                                case ELogs.Severity.Error:

                                    var errorRecord = (ErrorRecord)result.Value.Record;
                                    var response = await servie.WriteErrorAsync(errorRecord.Message, errorRecord.StackTrace, errorRecord.Data);
                                    break;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}