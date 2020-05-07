using System;
using GS.Core.Logging.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GS.Logging.Api.Controllers
{    
    [ApiController]
    [Route("api/iamalive")]
    public class IamAliveController: ControllerBase
    {
        private ICoreLogger _logger;

         public IamAliveController(ICoreLoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLoggerForType<IamAliveController>();
        }


        [HttpGet]
        public string Get()
        {
            try
            {
                _logger.Trace("Client queried I am alive service. Status = I am alive");
                return "I am alive !";
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return ex.Message;
            }
        }
    }
}