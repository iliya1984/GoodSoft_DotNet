using Autofac;
using GS.Logging.Services.DI;
using Microsoft.Extensions.Configuration;

namespace GS.Logging.Api.DI
{
    public class ApiDiModule : Module
    {
        private IConfiguration _configuration;

        public ApiDiModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule( new ServicesDIModule(_configuration));
        }
    }
}