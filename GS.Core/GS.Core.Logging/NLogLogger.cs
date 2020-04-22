using System;
using GS.Core.Logging.Loggers.Interfaces;

namespace GS.Core.Logging.Loggers
{
    public class NLogLogger : ICoreLogger
    {
        public void Error(string errorMessage, string stackTrace = "", object data = null)
        {
            throw new NotImplementedException();
        }

        public void Exception(Exception exception, object data = null)
        {
            throw new NotImplementedException();
        }

        public void Info(string text, object data = null)
        {
            throw new NotImplementedException();
        }

        public void Warning(string warningMessage, object data = null)
        {
            throw new NotImplementedException();
        }
    }
}