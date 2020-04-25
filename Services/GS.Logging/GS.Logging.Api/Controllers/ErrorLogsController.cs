using System;
using System.Threading.Tasks;
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

        public ErrorLogsController(ILoggingServiceFactory serviceFactory, IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Post(ErrorLoggingRequest request)
        {
            try
            {
                var metadata = new LoggerMetadata();
                metadata.LoggerName = "Default";
                
                
                _service = _serviceFactory.CreateService(metadata, request.Module);

                var response = await _service.WriteErrorAsync(request);
                return new JsonResult(response);
            } 
            catch(Exception ex)
            {
                await _service.WriteExceptionAsync(ex);
                return new StatusCodeResult(500);
            }
        }
    }
}