using System.Threading.Tasks;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Logging.Entities;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Messages;
using GS.Logging.Entities.Settings;

namespace GS.Logging.Api.Hosting
{
    public class LoggingBackgroundService : AbsLoggingBackgroundService
    {
        public LoggingBackgroundService(LoggingServiceToolkit toolkit) : base(toolkit, ELogs.LoggingJob.GeneralLogging) { }

        protected override void ExecuteJob(IConsumer consumer, LoggingJob job)
        {
             Logger.Trace("Consuming log record message from message queue");
            var timeOut = job.ConsumeTimeout * 1000;
            var result = consumer.Consume<LogMessage>(timeOut);
            
            if (result != null && result.Value != null && result.Value.Module != null)
            {
                var logMessage = result.Value;
                var metadata = logMessage.LoggerMetadata;

                var servie = ServiceFactory.CreateService(metadata, logMessage.Module);
                
                var severity = logMessage.Severity;
                var text = logMessage.Text;
                var data = logMessage.Data;

                 Logger.Trace("Handling log record message that was read from queue");
                ILoggingResponse response = null;
                switch(severity)
                {
                    case ELogs.Severity.Info:
                        response = servie.WriteInfo(text, data);
                        break;
                    case ELogs.Severity.Warning:
                        response = servie.WriteWarning(text, data);
                        break;
                    default:
                        Logger.Error($"Error: Failued to write log record to log, invalid severity {severity}");
                        break;
                }
            }
        }
    }
}