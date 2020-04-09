using System;
using System.Linq;
using System.Threading.Tasks;
using GS.Logging.Entities;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Modules;
using GS.Logging.Entities.Requests;
using GS.Logging.Entities.Responses;
using GS.Logging.Entities.Settings;
using GS.Logging.Repositories.Interfaces;
using GS.Logging.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GS.Logging.Services
{
    public class LoggingService : ILoggingService
    {
        private ILoggingRepository _repository;
        private IConfiguration _configuration;

        public LoggingService(ILoggingRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public void Intialize(LoggingSettings settings, LoggingModule module = null)
        {
            var target = _configuration.GetTarget();

            if (target != null)
            {
                target.Format = ELogs.TargetFormat.Text;
                target.Group = ELogs.TargetGroup.File;

                if (module != null)
                {
                    var moduleName = module.Name;
                    var moduleLayer = module.Layer.Group.ToString();
                    var fileName = $"{moduleName}{moduleLayer}";
                    target.FileName = fileName;
                }

                _repository.Targets.Add(target);
            }


            _repository.Initialize(settings);
        }

        public async Task<ILoggingResponse> WriteExceptionAsync(Exception exception, object data = null)
        {
            var response = new LoggingResponse();

            try
            {
                await _repository.LogExceptionAsync(exception, data);
                response.RecordsLogged = 1;

            }
            catch (Exception ex)
            {
                await _repository.LogExceptionAsync(ex);
                response.IsError = true;
            }
            return response;
        }

        public async Task<ILoggingResponse> WriteErrorAsync(ErrorLoggingRequest request)
        {
            var response = new LoggingResponse();

            try
            {
                await _repository.LogErrorAsync(request.ErrorMessage, request.ErrorStackTrace, request.Data);
                response.RecordsLogged = 1;

            }
            catch (Exception ex)
            {
                await _repository.LogExceptionAsync(ex);
                response.IsError = true;
            }
            return response;
        }

        public async Task<ILoggingResponse> WriteErrorAsync(string errorMessage, string errorStackTrace = null, object data = null)
        {
            var response = new LoggingResponse();

            try
            {
                await _repository.LogErrorAsync(errorMessage, errorStackTrace, data);
                response.RecordsLogged = 1;

            }
            catch (Exception ex)
            {
                await _repository.LogExceptionAsync(ex);
                response.IsError = true;
            }
            return response;
        }
    }
}