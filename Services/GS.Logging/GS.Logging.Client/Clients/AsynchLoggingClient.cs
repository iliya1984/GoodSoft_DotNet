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

namespace GS.Logging.Client.Clients
{
    public class AsynchLoggingClient : ILoggingClient
    {
        private ILogger _logger;
        private IConfiguration _configuration;
        private ProducerSettings _producerSettings;
        private IProducerFactory _producerFactory;
        private Lazy<IProducer> _producer;
        private Topic _errorTopic { get; set;}

        public AsynchLoggingClient(AsynchLoggingClientArguments arguments)
        {
            _configuration = arguments.Configuration;
            _logger = arguments.LogFactory.GetCurrentClassLogger();
            
            _producerSettings = arguments.ProducerSettings;
            _producerFactory = arguments.ProducerFactory;
            setTopic();
        }

        public async Task ErrorAsync(string errorMessage, string stackTrace, object data = null)
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

                using(var producer = createProducer())
                {
                   var result = await producer.ProduceAsync<ErrorRecord>(_errorTopic, key, error, cancellationToken);
                }    
            }
            catch(Exception ex)
            {
               _logger.Error(ex); 
            }
        }

        public async Task InfoAsync(string text, object data = null)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch(Exception ex)
            {
               _logger.Error(ex); 
            }
        }

        public async Task WarningAsync(string text, object data = null)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch(Exception ex)
            {
               _logger.Error(ex); 
            }
        }

        private IProducer createProducer()
        {
            return _producerFactory.CreateProducer(_producerSettings);
        }

        private void setTopic()
        {
            _errorTopic = new Topic
            {
                Name = _configuration["LoggingSettings:ErrorTopicName"]
            };
        }
    }
}