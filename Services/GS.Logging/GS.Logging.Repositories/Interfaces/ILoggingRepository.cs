using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Logging.Entities.Settings;

namespace GS.Logging.Repositories.Interfaces
{
    public interface ILoggingRepository
    {
        void Initialize(RepositorySettings settings);

        Task LogInfoAsync(string textMessage, object data = null);
        Task LogWarningAsync(string textMessage, object data = null);
        Task LogErrorAsync(string errorMessage, string errorStackTrace = null, object data = null);
        Task LogExceptionAsync(Exception exception, object data = null);
    }
}