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
        ILoggingResponse WriteInfo(string text, object data = null);
        ILoggingResponse WriteWarning(string text, object data = null);
        ILoggingResponse WriteError(string errorMessage, string errorStackTrace = null, object data = null);
        ILoggingResponse WriteError(ErrorLoggingRequest request);
    }
}