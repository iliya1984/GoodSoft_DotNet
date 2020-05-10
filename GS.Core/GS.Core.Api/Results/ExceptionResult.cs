using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GS.Core.Api.Entities;
using GS.Core.BLL.Entities.Results;
using GS.Core.Entities.ErrorHandling.BusinessErrors;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Results
{
    public class ExceptionResult : IActionResult
    {
        private static string BusinessErrorType = typeof(BusinessError).Name;

        private List<Exception> _exceptions;
        private List<BusinessError> _businessErrors;

        public ExceptionResult(Exception exception)
        {
            _exceptions = new List<Exception>{ exception };
            _businessErrors = new List<BusinessError>();
        }

        public ExceptionResult(BusinessOperationResult result)
        {
            _exceptions = result.Exceptions.Select(e => e.Exception).ToList();
            _businessErrors = result.BusinessErrors;
        }

        public ExceptionResult(List<Exception> exceptions)
        {
            _exceptions = exceptions;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var exceptions = _exceptions.Select(e => toExceptionResponse(e)).ToList();
            var businessErrors = _businessErrors.Select(e => toExceptionResponse(e)).ToList();
            
            var response = new List<ExceptionResponse>();
            response.AddRange(exceptions);
            response.AddRange(businessErrors);

            var objectReulst = new ObjectResult(response);
            objectReulst.StatusCode = (int)HttpStatusCode.InternalServerError;
            await objectReulst.ExecuteResultAsync(context);
        }

        private ExceptionResponse toExceptionResponse(Exception e)
        {
         
            var response = new ExceptionResponse
            {
                ExceptionMessage = e.Message,
                StackTrace = e.StackTrace,
                ExceptionType = e.GetType().Name
            };

            if(e.InnerException != null)
            {
                response.InnerException = toExceptionResponse(e.InnerException);
            }

            return response;
        }

        private ExceptionResponse toExceptionResponse(BusinessError e)
        {
            var response = new ExceptionResponse
            {
                ExceptionMessage = e.Message,
                ExceptionType = BusinessErrorType
            };

            return response;
        }
    }
}