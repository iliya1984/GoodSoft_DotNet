using System;
using System.Threading.Tasks;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Modules;
using GS.Logging.Entities.Requests;
using GS.Logging.Entities.Settings;

namespace GS.Logging.Services.Interfaces
{
    public interface ILoggingService
    {
        Task<ILoggingResponse> WriteInfoAsync(string text, object data = null);
        Task<ILoggingResponse> WriteWarningAsync(string text, object data = null);
        Task<ILoggingResponse> WriteErrorAsync(string errorMessage, string errorStackTrace = null, object data = null);
        Task<ILoggingResponse> WriteErrorAsync(ErrorLoggingRequest request);
        Task<ILoggingResponse> WriteExceptionAsync(Exception exception, object data = null);
    }
}