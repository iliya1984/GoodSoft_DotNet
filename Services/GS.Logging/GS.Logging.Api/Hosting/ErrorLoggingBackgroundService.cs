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
    public class ErrorLoggingBackgroundService : AbsLoggingBackgroundService
    {
        public ErrorLoggingBackgroundService(LoggingServiceToolkit toolkit) : base(toolkit, ELogs.LoggingJob.ErrorLogging) { }

        protected override void ExecuteJob(IConsumer consumer, LoggingJob job)
        {
            Logger.Trace("Consuming error log message from message queue");
         
            var timeOut = job.ConsumeTimeout * 1000;
            var result = consumer.Consume<ErrorLogMessage>(timeOut);
            
            if (result != null && result.Value != null && result.Value.Module != null)
            {
                Logger.Trace("Handling error message that was read from queue");
                var errorMessage = result.Value;
                var metadata = errorMessage.LoggerMetadata;

                var servie = ServiceFactory.CreateService(metadata, errorMessage.Module);
                
                var severity = errorMessage.Severity;
                var message = errorMessage.Message;
                var stackTrace = errorMessage.StackTrace;
                var data = errorMessage.Data;

                if(severity != ELogs.Severity.Error)
                {
                    Logger.Error($"Error: Failued to write error record to log, invalid severity {severity}");
                }
                else
                {
                    var response =  servie.WriteError(message, stackTrace, data);
                }     
            }
        }
    }
}