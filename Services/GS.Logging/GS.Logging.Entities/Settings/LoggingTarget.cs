namespace GS.Logging.Entities.Settings
{
    public class LoggingTarget
    {
        public ELogs.TargetGroup Group { get; set;}
        public string Name {get; set;}
        public ELogs.TargetFormat Format {get;set;}
    }
}