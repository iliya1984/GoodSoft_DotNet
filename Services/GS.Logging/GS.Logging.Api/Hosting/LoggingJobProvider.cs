using System;
using System.Collections.Generic;
using System.Linq;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Entities.Common;
using GS.Logging.Api.Interfaces;
using GS.Logging.Entities;
using GS.Logging.Entities.Settings;
using Microsoft.Extensions.Configuration;

namespace GS.Logging.Api.Hosting
{
    internal class LoggingJobProvider : ILoggingJobProvider
    {
        private IConfiguration _configuration;
        private ICoreLogger _logger;

        public LoggingJobProvider(IConfiguration configuration, ICoreLoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _logger = loggerFactory.GetLoggerForType<LoggingJobProvider>();
        }

        public LoggingJob Lookup(ELogs.LoggingJob jobType)
        {
            try
            {
                return getAllJobs().FirstOrDefault(job => job.JobType ==  jobType);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        private List<LoggingJob> getAllJobs()
        {
            try
            {
                var jobs = new List<LoggingJob>();
                
                var consumeTimeOut = _configuration.GetValue<int>("LoggingSettings:JobSettings:ConsumeTimeOut");
                if(consumeTimeOut == 0)
                {
                    consumeTimeOut = 30;
                }
                
                var jobsSection = _configuration.GetSection("LoggingSettings:JobSettings:Jobs");
                foreach(var jobSection in jobsSection.GetChildren())
                {
                    var job = extractJob(jobSection);
                    job.ConsumeTimeout = consumeTimeOut;
                    jobs.Add(job);
                }

                return jobs;
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return new List<LoggingJob>();
            }
        }

        private LoggingJob extractJob(IConfigurationSection section)
        {
            var jobName = section.GetValue<string>("Name");
            ELogs.LoggingJob jobType = ELogs.LoggingJob.None;

            if(string.IsNullOrEmpty(jobName))
            {
                _logger.Error("Error: Unable to create logging JOB, job name was not found");
                return null;
            }
            if(false == Enum.TryParse<ELogs.LoggingJob>(jobName, true, out jobType))
            {
                _logger.Error($"Error: Unable to create logging JOB, failed to parse job name {jobName}");
                return null;
            }

            var job = new LoggingJob();
            job.JobName = jobName;
            job.JobType = jobType;

            foreach(var jobItemSection in section.GetSection("Items").GetChildren())
            {
                var jobItem = extractJobItem(jobItemSection);
                if(jobItem != null)
                {
                    job.Items.Add(jobItem);
                }
            }

            if(false == job.Items.Any())
            {
                _logger.Error($"Error: Unable to create logging JOB, failed to load job items");
                return null;
            }

            return job;
        }

        private LoggingJobItem extractJobItem(IConfigurationSection section)
        {
            var jobItem = new LoggingJobItem();

            jobItem.Name = section.GetValue<string>("Name");

            string severity = section.GetValue<string>("Severity");
            ELogs.Severity jobSeverity = ELogs.Severity.None;

            if(string.IsNullOrEmpty(severity))
            {
                _logger.Error("Error: Unable to create logging JOB ITEM, job item severity was not found");
                return null;
            }
            if(false == Enum.TryParse<ELogs.Severity>(severity, true, out jobSeverity))
            {
                _logger.Error($"Error: Unable to create logging JOB ITEM, failed to parse job item severity {severity}");
                return null;
            }

            jobItem.Severity = jobSeverity;

            jobItem.Topic = new Topic();
            jobItem.Topic.Id = section.GetValue<string>("Topic:Id");
            jobItem.Topic.Name = section.GetValue<string>("Topic:Name");

            return jobItem;
        }
    }
}