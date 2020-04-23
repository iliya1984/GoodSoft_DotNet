using GS.Logging.Entities;
using GS.Logging.Entities.Modules;

namespace GS.Logging.Client.Interfaces
{
    public interface ILoggingFactory
    {
        ILoggingClient GetAsyncClientByType<T>();
        ILoggingClient GetClientByType<T>();
    }
}