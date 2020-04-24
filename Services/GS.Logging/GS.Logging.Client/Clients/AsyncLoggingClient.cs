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

        public override async Task ErrorAsync(string errorMessage, string stackTrace, object data = null)
        {
            try
            {
                var key = Guid.NewGuid().ToString();
                var error = new ErrorRecord
                {
                    Message = errorMessage,
                    StackTrace = stackTrace,
                    Data = data
                };

                var cancellationToken = new CancellationToken();
                var topic = Settings.Topics.ErrorTopic;

                using(var producer = createProducer())
                {
                   var result = await producer.ProduceAsync<ErrorRecord>(topic, key, error, cancellationToken);
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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
    }
}