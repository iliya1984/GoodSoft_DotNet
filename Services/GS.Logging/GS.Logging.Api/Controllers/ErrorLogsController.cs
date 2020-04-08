using System;
using System.Threading.Tasks;
using GS.Logging.Entities.Requests;
using GS.Logging.Entities.Responses;
using GS.Logging.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GS.Logging.Api.Controllers
{
    [ApiController]
    [Route("api/errors")]
    public class ErrorLogsController : ControllerBase
    {
        private ILoggingService _service;

        public ErrorLogsController(ILoggingService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Post(ErrorLoggingRequest request)
        {
            try
            {
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