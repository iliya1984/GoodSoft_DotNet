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
using GS.Logging.Entities.Settings;
using GS.Logging.Entities;
using GS.Logging.Entities.Interfaces.Records;
using GS.Logging.Entities.Messages;
using GS.Logging.Entities.Interfaces;

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

        public override async Task ErrorAsync(string errorMessage, string stackTrace = null, object data = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var message = createErrorMessage(errorMessage, stackTrace, data);
                var topic = Settings.Topics.ErrorTopic;
                var produceCancellationToken = createOrGetCancellationToken(cancellationToken);

                using (var producer = createProducer())
                {
                    var result = await producer.ProduceAsync<ErrorLogMessage>(topic, message.Key, message, produceCancellationToken);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public override async Task InfoAsync(string text, object data = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var message = createMessage(ELogs.Severity.Info, text, data);
                var topic = Settings.Topics.InfoTopic;
                var produceCancellationToken = createOrGetCancellationToken(cancellationToken);

                using (var producer = createProducer())
                {
                    var result = await producer.ProduceAsync<LogMessage>(topic, message.Key, message, produceCancellationToken);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public override async Task WarningAsync(string text, object data = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var message = createMessage(ELogs.Severity.Warning, text, data);
                var topic = Settings.Topics.WarningTopic;
                var produceCancellationToken = createOrGetCancellationToken(cancellationToken);

                using (var producer = createProducer())
                {
                    var result = await producer.ProduceAsync<LogMessage>(topic, message.Key, message, produceCancellationToken);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private IProducer createProducer()
        {
            return _producerFactory.CreateProducer();
        }

        private LogMessage createMessage(ELogs.Severity severity, string text, object data = null)
        {
            var message = new LogMessage();
            setMessageDetails(message, severity, data);
            message.Text = text;
            return message;
        }

        private ErrorLogMessage createErrorMessage(string error, string stackTrace = null, object data = null)
        {
            var message = new ErrorLogMessage();
            setMessageDetails(message, ELogs.Severity.Error, data);
            message.Message = error;
            message.StackTrace = stackTrace;
            return message;
        }

        private void setMessageDetails(AbsLogMessage message, ELogs.Severity severity, object data = null)
        {
            message.Key = Guid.NewGuid().ToString();
            message.Module = Settings.Module;
            message.LoggerMetadata = Settings.LoggerMetadata;
            message.Severity = severity;
            message.Data = data;
        }

        private CancellationToken createOrGetCancellationToken(CancellationToken cancellationToken)
        {
            var token = new CancellationToken();
            if (cancellationToken != null)
            {
                token = cancellationToken;
            }

            return token;
        }
    }
}