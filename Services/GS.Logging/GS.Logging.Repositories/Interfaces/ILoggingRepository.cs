using System;
using System.Threading.Tasks;

namespace GS.Logging.Repositories.Interfaces
{
    public interface ILoggingRepository
    {
        Task LogInfoAsync(string textMessage, object data = null);
        Task LogWarningAsync(string textMessage, object data = null);
        Task LogErrorAsync(string errorMessage, string errorStackTrace = null, object data = null);
        Task LogExceptionAsync(Exception exception, object data = null);
    }
}