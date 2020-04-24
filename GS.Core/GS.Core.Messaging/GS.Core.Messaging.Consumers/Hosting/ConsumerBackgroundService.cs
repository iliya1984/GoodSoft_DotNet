using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Consumers;
using GS.Core.Messaging.Entities.Interfaces;
using Microsoft.Extensions.Hosting;
using NLog;

namespace GS.Core.Messaging.Consumers.Hosting
{
    public abstract class ConsumerBackgroundService : BackgroundService
    {
        protected IConsumerFactory ConsumerFactory { get; private set; }
        protected ICoreLogger Logger { get; private set; }


        public ConsumerBackgroundService(IConsumerFactory factory, ICoreLoggerFactory logFactory)
        {
            ConsumerFactory = factory;
            Logger = logFactory.GetLoggerForType<ConsumerBackgroundService>();
            
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
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected abstract Task ExecuteServiceAsync(IConsumptionRequest request);
    }
}