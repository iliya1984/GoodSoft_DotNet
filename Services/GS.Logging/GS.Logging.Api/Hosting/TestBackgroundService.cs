using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace GS.Logging.Api.Hosting
{
    public class TestBackgroundService : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(() =>
            {

                for(int i = 0; i < 1000000; i++)
                {
                
                }
            });
        }
    }
}