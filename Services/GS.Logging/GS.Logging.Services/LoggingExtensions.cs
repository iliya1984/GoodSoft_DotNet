using GS.Logging.Entities;
using GS.Logging.Entities.Settings;
using Microsoft.Extensions.Configuration;

namespace GS.Logging.Services
{
    public static class LoggingExtensions
    {
        public static LoggingTarget GetTarget(this IConfiguration configuration)
        {
            if(configuration == null)
            {
                return null;
            }

            var taregetIdConfig = configuration["LoggingSettings:Target:Id"];
            int targetId = 0;

            if(false == string.IsNullOrEmpty(taregetIdConfig) && int.TryParse(taregetIdConfig, out targetId))
            {
                var target = new LoggingTarget();
                target.Name = configuration["LoggingSettings:Target:Name"];
                target.Directory = configuration["LoggingSettings:Target:Directory"];
                target.FileName = configuration["LoggingSettings:Target:FileName"];
                target.Id = targetId;
                return target;
            }

            return null;
        }
    }
}