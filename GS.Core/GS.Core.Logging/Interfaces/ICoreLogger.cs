using System;

namespace GS.Core.Logging.Interfaces
{
      public interface ICoreLogger
    {
         void Error(string errorMessage);
         void Error(Exception exception);
         void Info(string text);
         void Warning(string warningMessage);
    }
}