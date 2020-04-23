using System;
using GS.Core.Logging.Entities;

namespace GS.Core.Logging.Interfaces
{
    public interface ICoreLoggerFactory
    {
         ICoreLogger GetLogger(LoggingSettings settings = null);
         ICoreLogger GetLoggerForType(Type type, LoggingSettings settings = null);
         ICoreLogger GetLoggerForType<T>(LoggingSettings settings = null);
    }
}