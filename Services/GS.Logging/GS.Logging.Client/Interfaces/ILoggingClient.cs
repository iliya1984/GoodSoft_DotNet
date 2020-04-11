using System.Threading.Tasks;

namespace GS.Logging.Client.Interfaces
{
    public interface ILoggingClient
    {
         Task ErrorAsync(string errorMessage, string stackTrace, object data = null);
         Task InfoAsync(string text, object data = null);
         Task WarningAsync(string text, object data = null);
    }
}