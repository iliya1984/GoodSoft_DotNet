using System;
using GS.Logging.Entities;
using GS.Logging.Entities.Modules;

namespace GS.Logging.Client.Interfaces
{
    public interface ILoggingFactory
    {
        ILoggingClient GetAsyncLoggerByType<T>();
        ILoggingClient GetAsyncLoggerByType(Type type);
        ILoggingClient GetLoggerByType<T>();
    }
}