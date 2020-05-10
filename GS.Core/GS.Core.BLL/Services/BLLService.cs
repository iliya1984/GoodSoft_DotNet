using GS.Logging.Client.Interfaces;

namespace GS.Core.BLL.Services
{
    public abstract class BLLService
    {
        protected ILoggingClient Logger {get; private set;}

        public BLLService(ILoggingFactory loggingFactory)
        {
            Logger = loggingFactory.GetAsyncLoggerByType(GetType());
        }
    }
}