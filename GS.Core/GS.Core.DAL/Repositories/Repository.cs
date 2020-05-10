using GS.Core.DAL.Interfaces.Configuration;
using GS.Core.DAL.Interfaces.Entities;
using GS.Core.DAL.Interfaces.Repositories;
using GS.Logging.Client.Interfaces;

namespace GS.Core.DAL.Repositories
{
    public abstract class Repository : IRepository
    {
        public IDbSettings Settings { get; private set;}
        protected ILoggingClient Logger {get; private set;}

        protected Repository(IConfigurationManager configurationManager, ILoggingFactory loggingFactory)
        {
             Settings = configurationManager.GetSettings();
            Logger = loggingFactory.GetAsyncLoggerByType(GetType()); 
        }
    }
}