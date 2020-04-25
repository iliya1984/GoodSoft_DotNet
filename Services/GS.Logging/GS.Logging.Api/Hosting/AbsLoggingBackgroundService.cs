using System;
using System.Threading;
using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Consumers.Hosting;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities.Interfaces;
using GS.Logging.Api.Interfaces;
using GS.Logging.Entities;
using GS.Logging.Entities.Settings;
using GS.Logging.Services.Interfaces;

namespace GS.Logging.Api.Hosting
{
    public abstract class AbsLoggingBackgroundService : ConsumerBackgroundService
    {
        protected ELogs.LoggingJob JobType { get; private set; }
        protected ILoggingJobProvider JobProvider { get; private set; }
        protected ILoggingServiceFactory ServiceFactory { get; private set; }
        private readonly Timer _jobLookupFailureTimer;

        protected AbsLoggingBackgroundService(LoggingServiceToolkit toolkit, ELogs.LoggingJob jobType) : base(toolkit.ConsumerFactory, toolkit.LoggerFactory)
        {
            JobProvider = toolkit.JobProvider;
            ServiceFactory = toolkit.ServiceFactory;
            JobType = jobType;


        }

        protected override async Task ExecuteServiceAsync(IConsumptionRequest request)
        {
            try
            {
                LoggingJob job = GetLoggingJob();
                if (job == null)
                {
                    //TODO: Handle critical error      
                }
                else
                {
                    using (var consumer = ConsumerFactory.CreateConsumer())
                    {
                        subscribeToJob(consumer, job);

                        while (false == request.CancellationToken.IsCancellationRequested)
                        {
                            await ExecuteJob(consumer, job);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        protected abstract Task ExecuteJob(IConsumer consumer, LoggingJob job);

        private LoggingJob GetLoggingJob()
        {
            if (JobType == ELogs.LoggingJob.None)
            {
                Logger.Error("Error: Unable to load logging job, job type is NULL");
                return null;
            }

            var job = JobProvider.Lookup(JobType);
            if (job == null)
            {
                Logger.Error("Error: Unable to load logging job, job lookup FAILURE");
                return null;
            }

            return job;
        }

        private static void subscribeToJob(IConsumer consumer, LoggingJob job)
        {
            foreach(var jobItem in job.Items)
            {
                var topic = jobItem.Topic;
                consumer.Subscribe(topic);
            }
        }
    }
}