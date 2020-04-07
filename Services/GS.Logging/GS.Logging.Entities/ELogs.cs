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

        public enum Module
        {
            None,
            Geo,
            Flights
        }

        public enum Layer
        {
            None, 
            Api,
            DataLayer,
            BusinessLayer,
            Repository
        }
    }
}