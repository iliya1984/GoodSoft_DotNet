using System;
using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
using GS.Logging.Entities.Requests;
using GS.Logging.Entities.Responses;
using GS.Logging.Entities.Settings;
using GS.Logging.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GS.Logging.Api.Controllers
{
    [ApiController]
    [Route("api/errors")]
    public class ErrorLogsController : ControllerBase
    {
        private ILoggingServiceFactory _serviceFactory;
        private ILoggingService _service;
        private IConfiguration _configuration;
        private ICoreLogger _logger;

        public ErrorLogsController(ILoggingServiceFactory serviceFactory, IConfiguration configuration, ICoreLoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _logger = loggerFactory.GetLoggerForType<ErrorLogsController>();
        }

        public string Test()
        {
            return "Test Success";
        }

        [HttpPost]
        public IActionResult Post(ErrorLoggingRequest request)
        {
            try
            {
                var metadata = new LoggerMetadata();
                metadata.LoggerName = "Default";
                
                
                _service = _serviceFactory.CreateService(metadata, request.Module);

                var response = _service.WriteError(request);
                return new JsonResult(response);
            } 
            catch(Exception ex)
            {
                _logger.Error(ex);
                return new StatusCodeResult(500);
            }
        }
    }
}