using System;
using System.Threading;
using System.Threading.Tasks;
using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Entities.Consumers;
using GS.Messaging.Entities.Interfaces;
using GS.Messaging.Interfaces;
using Microsoft.Extensions.Hosting;
using NLog;

namespace GS.Messaging.Consumers
{
    public abstract class ConsumptionService : BackgroundService
    {
        private ConsumerSettings _settings;
        private IConsumerFactory _factory;
        private Lazy<IConsumer> _consumer;
        protected ILogger Logger { get; private set;}

        public ConsumptionService(IConsumerFactory factory, LogFactory logFactory)
        {
            _factory = factory;
            Logger = logFactory.GetCurrentClassLogger();

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
                Logger.Error(ex);
            }
        }
        
        protected abstract Task ExecuteServiceAsync(IConsumptionRequest request);
    }
}