using System;
using GS.Core.Api.Results;
using GS.Core.BLL.Entities.Results;
using GS.Logging.Client.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected ILoggingClient Logger { get; private set;}

        protected ApiController(ILoggingFactory loggingFactory)
        {
            Logger = loggingFactory.GetAsyncLoggerByType(GetType());
        }

        protected ExceptionResult Exception(Exception exception)
        {
            return new ExceptionResult(exception);
        }

         protected ExceptionResult Exception(BusinessOperationResult result)
        {
            return new ExceptionResult(result);
        }
    }
}