using System;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
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
        private LoggingSettings _settings;
        private LoggingModule _module;
        private ILoggingRepository _repository;
        private IConfiguration _configuration;
        private ICoreLogger _logger;

        public LoggingService(LoggingSettings settings, LoggingModule module, IConfiguration configuration, ILoggingRepository repository, ICoreLoggerFactory loggerFactory)
        {
            _repository = repository;
            _settings = settings;
            _module = module;
            _configuration = configuration;

            _logger = loggerFactory.GetLoggerForType<LoggingService>();

            Intialize();
        }

        public void Intialize()
        {
            try
            {
                var target = _configuration.GetTarget();

                if (target != null)
                {
                    target.Format = ELogs.TargetFormat.Text;
                    target.Group = ELogs.TargetGroup.File;

                    if (_module != null)
                    {
                        var moduleName = _module.Name;
                        var moduleLayer = _module.Layer.Group.ToString();
                        var directory = $"{moduleName}{moduleLayer}";
                        target.Directory = directory;
                    }
                    _repository.Targets.Add(target);
                }
                _repository.Initialize(_settings);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
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

        public Task<ILoggingResponse> WriteInfoAsync(string text, object data = null)
        {
            throw new NotImplementedException();
        }

        public Task<ILoggingResponse> WriteWarningAsync(string text, object data = null)
        {
            throw new NotImplementedException();
        }
    }
}