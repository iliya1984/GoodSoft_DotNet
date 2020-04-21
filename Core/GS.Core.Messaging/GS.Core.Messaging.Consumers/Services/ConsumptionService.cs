using System;
using System.Threading;
using System.Threading.Tasks;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities.Consumers;
using GS.Core.Messaging.Entities.Interfaces;
using Microsoft.Extensions.Hosting;
using NLog;

namespace GS.Core.Messaging.Consumers.Services
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