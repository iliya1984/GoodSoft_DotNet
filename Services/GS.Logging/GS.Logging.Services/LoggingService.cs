using System;
using System.Linq;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Responses;
using GS.Logging.Repositories.Interfaces;

namespace GS.Logging.Services
{
    public class LoggingService
    {
        private ILoggingRepository _repository;

        public LoggingService(ILoggingRepository repository)
        {
            _repository = repository;
        }

         public ILoggingResponse WriteError(string errorMessage, string errorStackTrace = null, object data = null)
         {
            var response = new LoggingResponse();

            try
             {
               _repository.LogError(errorMessage, errorStackTrace, data);
                response.RecordsLogged = 1;
               
             }
             catch(Exception ex)
             {
                 _repository.LogException(ex);
                response.IsError = true;
             }
             return response;
         }
    }
}