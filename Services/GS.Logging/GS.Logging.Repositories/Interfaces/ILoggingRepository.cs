using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Logging.Entities.Settings;

namespace GS.Logging.Repositories.Interfaces
{
    public interface ILoggingRepository
    {
        void Initialize(RepositorySettings settings);

        void LogInfo(string textMessage, object data = null);
        void LogWarning(string textMessage, object data = null);
        void  LogError(string errorMessage, string errorStackTrace = null, object data = null);
    }
}