using GS.Core.BLL.Interfaces.Services;
using GS.Logging.Client.Interfaces;

namespace GS.Core.BLL.Services
{
    public abstract class BLLService: IService
    {
        protected ILoggingClient Logger {get; private set;}

        public BLLService(ILoggingFactory loggingFactory)
        {
            Logger = loggingFactory.GetAsyncLoggerByType(GetType());
        }
    }
}