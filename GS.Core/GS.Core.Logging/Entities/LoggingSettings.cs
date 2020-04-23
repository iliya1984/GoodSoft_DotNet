namespace GS.Core.Logging.Entities
{
    public class LoggingSettings
    {
        public string LoggerName { get; set; }
        public ECoreLogging.LoggerType LoggerType { get; set; }
        public string FileName { get; set; }

        public LoggingSettings()
        {
            LoggerType = ECoreLogging.LoggerType.NLog;
            LoggerName = "CoreLogger";
        }
    }
}