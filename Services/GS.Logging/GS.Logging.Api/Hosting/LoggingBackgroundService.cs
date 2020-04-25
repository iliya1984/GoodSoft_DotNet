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

        protected override async Task ExecuteJob(IConsumer consumer, LoggingJob job)
        {
            var timeOut = job.ConsumeTimeout * 1000;
            var result = consumer.Consume<LogMessage>(timeOut);
            
            if (result != null && result.Value != null && result.Value.Module != null)
            {
                var logMessage = result.Value;
                var settings = new LoggingSettings();
                settings.LoggerName = logMessage.LoggerName;

                var servie = ServiceFactory.CreateService(settings, logMessage.Module);
                
                var severity = logMessage.Severity;
                var text = logMessage.Text;
                var data = logMessage.Data;

                ILoggingResponse response = null;
                switch(severity)
                {
                    case ELogs.Severity.Info:
                        response = await servie.WriteInfoAsync(text, data);
                        break;
                    case ELogs.Severity.Warning:
                        response = await servie.WriteWarningAsync(text, data);
                        break;
                    default:
                        Logger.Error($"Error: Failued to write log record to log, invalid severity {severity}");
                        break;
                }
            }
        }
    }
}