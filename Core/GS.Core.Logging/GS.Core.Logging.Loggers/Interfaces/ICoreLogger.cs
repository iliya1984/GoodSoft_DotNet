using System;

namespace GS.Core.Logging.Loggers.Interfaces
{
      public interface ICoreLogger
    {
         void Error(string errorMessage, string stackTrace = "", object data = null);
         void Exception(Exception exception, object data = null);
         void Info(string text, object data = null);
         void Warning(string warningMessage, object data = null);
    }
}