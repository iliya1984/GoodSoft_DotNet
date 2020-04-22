namespace GS.Logging.Client.Interfaces
{
    public interface ILoggingFactory
    {
         ILoggingClient GetClient();
    }
}