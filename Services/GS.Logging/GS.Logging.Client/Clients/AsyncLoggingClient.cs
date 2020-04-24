using System;
using System.Threading;
using System.Threading.Tasks;
using GS.Logging.Client.Interfaces;
using GS.Logging.Entities.Records;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Producers;
using GS.Core.Messaging.Producers.Interfaces;
using Microsoft.Extensions.Configuration;
using NLog;
using GS.Core.Logging.Interfaces;
using GS.Logging.Client.Entities;
using GS.Logging.Entities;
using GS.Logging.Entities.Interfaces.Records;
using GS.Logging.Entities.Messages;

namespace GS.Logging.Client.Clients
{
    internal class AsyncLoggingClient : AbsLoggingClient
    {
        private IProducerFactory _producerFactory;
        private Lazy<IProducer> _producer;

        public AsyncLoggingClient(
            ICoreLoggerFactory loggerFactory, IProducerFactory producerFactory, LoggingClientSettings settings)
            : base(loggerFactory, settings)
        {
            _producerFactory = producerFactory;
        }

        public override async Task ErrorAsync(string errorMessage, string stackTrace = null, object data = null)
        {
            try
            {
                
                var error = new ErrorRecord
                {
                    Message = errorMessage,
                    StackTrace = stackTrace,
                    Data = data
                };
               
                var message = createErrorMessage(error);
                message.Severity = ELogs.Severity.Error;

                var cancellationToken = new CancellationToken();
                var topic = Settings.Topics.ErrorTopic;

                using(var producer = createProducer())
                {
                   var result = await producer.ProduceAsync<ErrorLogMessage>(topic, message.Key, message, cancellationToken);
                }    
            }
            catch(Exception ex)
            {
               Logger.Error(ex); 
            }
        }

        public override async Task InfoAsync(string text, object data = null)
        {
             try
            {
                
                var record = new LogRecord(ELogs.Severity.Info)
                {
                    Message = text,
                    Data = data
                };
                var message = createMessage(record);
                message.Severity = ELogs.Severity.Info;

                var cancellationToken = new CancellationToken();
                var topic = Settings.Topics.InfoTopic;

                using(var producer = createProducer())
                {
                   var result = await producer.ProduceAsync<LogMessage>(topic, message.Key, message, cancellationToken);
                }    
            }
            catch(Exception ex)
            {
               Logger.Error(ex); 
            }
        }

        public override async Task WarningAsync(string text, object data = null)
        {
            try
            {
                
                var record = new LogRecord(ELogs.Severity.Warning)
                {
                    Message = text,
                    Data = data
                };

                var message = createMessage(record);
                message.Severity = ELogs.Severity.Warning;

                var cancellationToken = new CancellationToken();
                var topic = Settings.Topics.WarningTopic;

                using(var producer = createProducer())
                {
                   var result = await producer.ProduceAsync<LogMessage>(topic, message.Key, message, cancellationToken);
                }    
            }
            catch(Exception ex)
            {
               Logger.Error(ex); 
            }
        }

        private IProducer createProducer()
        {
            return _producerFactory.CreateProducer();
        }

        private LogMessage createMessage(LogRecord record)
        {
            var message = new LogMessage();
            message.Key = Guid.NewGuid().ToString();
            message.Module = Settings.Module;
            message.Record = record;
            return message;
        }

         private ErrorLogMessage createErrorMessage(ErrorRecord record)
        {
            var message = new ErrorLogMessage();
            message.Key = Guid.NewGuid().ToString();
            message.Module = Settings.Module;
            message.ErrorRecord = record;
            return message;
        }
    }
}