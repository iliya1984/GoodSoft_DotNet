namespace GS.Logging.Entities
{
    public class ELogs
    {
        public enum Severity
        {
            None,
            Info,
            Diagnostics,
            Warning,
            Error
        }

        public enum Layer
        {
            None, 
            Api,
            DataLayer,
            BusinessLayer,
            Repository,
            Client,
            ApiTest,
            ClientTest
        }

        public enum TargetGroup
        {
            None,
            File,
            Database
        }

        public enum TargetFormat
        {
            None,
            Text,
            Xml,
            Json
        }

        public enum LoggingJob
        {
            None,
            GeneralLogging,
            ErrorLogging
        }
    }
}