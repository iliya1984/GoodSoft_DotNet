using System;
using System.Threading;
using System.Threading.Tasks;
using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Entities.Consumers;
using GS.Messaging.Entities.Interfaces;
using GS.Messaging.Interfaces;
using Microsoft.Extensions.Hosting;

namespace GS.Messaging.Consumers
{
    public abstract class ConsumptionService : BackgroundService
    {
        private ConsumerSettings _settings;
        private IConsumerFactory _factory;
        private Lazy<IConsumer> _consumer;

        public ConsumptionService(IConsumerFactory factory)
        {
            _factory = factory;

            _consumer = new Lazy<IConsumer>(() =>
            {
                if(_settings == null)
                {
                    _settings = new ConsumerSettings();
                }

                return _factory.CreateConsumer(_settings);
            }
            , true);
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                await ExecuteServiceAsync(new ConsumptionRequest 
                { 
                    CancellationToken = cancellationToken
                });
            }
            catch(Exception ex)
            {
                //TODO: log error
            }
        }
        
        protected abstract Task ExecuteServiceAsync(IConsumptionRequest request);
    }
}