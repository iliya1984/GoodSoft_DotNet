using System.Threading;
using System.Threading.Tasks;
using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Entities.Consumers;
using Microsoft.Extensions.Hosting;

namespace GS.Messaging.Consumers
{
    public abstract class ConsumptionService : BackgroundService
    {
        private readonly ConsumerSettings _settings;
        private readonly IConsumerFactory _factory;

        public ConsumptionService(IConsumerFactory factory)
        {
            _factory = factory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}