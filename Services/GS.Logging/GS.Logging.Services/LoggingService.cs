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
        private LoggerMetadata _metadata;
        private LoggingModule _module;
        private ILoggingRepository _repository;
        private ICoreLogger _innerLogger;

        public LoggingService(LoggerMetadata metadata, LoggingModule module, ILoggingRepository repository, ICoreLoggerFactory loggerFactory)
        {
            _repository = repository;
            _metadata = metadata;
            _module = module;
            _innerLogger = loggerFactory.GetLoggerForType<LoggingService>();

            initializeRepository();
        }

        public ILoggingResponse WriteError(ErrorLoggingRequest request)
        {
            var response = new LoggingResponse();

            try
            {
                _repository.LogError(request.ErrorMessage, request.ErrorStackTrace, request.Data);
                response.RecordsLogged = 1;

            }
            catch (Exception ex)
            {
                _innerLogger.Error(ex);
                response.IsError = true;
            }
            return response;
        }

        public ILoggingResponse WriteError(string errorMessage, string errorStackTrace = null, object data = null)
        {
            var response = new LoggingResponse();

            try
            {
                _repository.LogError(errorMessage, errorStackTrace, data);
                response.RecordsLogged = 1;

            }
            catch (Exception ex)
            {
                _innerLogger.Error(ex);
                response.IsError = true;
            }
            return response;
        }

        public ILoggingResponse WriteInfo(string text, object data = null)
        {
             var response = new LoggingResponse();

            try
            {
                _repository.LogInfo(text, data);
                response.RecordsLogged = 1;

            }
            catch (Exception ex)
            {
                _innerLogger.Error(ex);
                response.IsError = true;
            }
            return response;
        }

        public ILoggingResponse WriteWarning(string text, object data = null)
        {
             var response = new LoggingResponse();

            try
            {
                _repository.LogWarning(text, data);
                response.RecordsLogged = 1;

            }
            catch (Exception ex)
            {
                _innerLogger.Error(ex);
                response.IsError = true;
            }
            return response;
        }

        private void initializeRepository()
        {
            try
            {
                var settings = new RepositorySettings
                {
                    LoggerName = _metadata.LoggerName
                };
                setDefaultTarget(settings);

                _repository.Initialize(settings);
            }
            catch (Exception ex)
            {
                _innerLogger.Error(ex);
            }
        }

        private void setDefaultTarget(RepositorySettings settings)
        {
            var defaultTarget = new LoggingTarget();
            defaultTarget.Name = "default";
            defaultTarget.Format = ELogs.TargetFormat.Text;
            defaultTarget.Group = ELogs.TargetGroup.File;

            if (_module != null)
            {
                var moduleName = _module.Name;
                var moduleLayer = _module.Layer.Group.ToString();
                var directory = $"{moduleName}{moduleLayer}";
                defaultTarget.Directory = directory;
            }
            settings.Targets.Add(defaultTarget);
        }
    }
}