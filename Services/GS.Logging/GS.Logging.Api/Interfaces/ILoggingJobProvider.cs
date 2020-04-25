using System.Collections.Generic;
using GS.Logging.Entities;
using GS.Logging.Entities.Settings;

namespace GS.Logging.Api.Interfaces
{
    public interface ILoggingJobProvider
    {
         LoggingJob Lookup(ELogs.LoggingJob jobType);
    }
}