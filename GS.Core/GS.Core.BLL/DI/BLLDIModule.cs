using System;
using Autofac;
using GS.Logging.Client.DI;
using GS.Logging.Client.Interfaces;
using GT.DAL.Configuration;
using GS.Core.DAL.Interfaces.Configuration;
using GS.Core.DAL.Interfaces.Mongo;
using GS.Core.DAL.Mongo;
using Microsoft.Extensions.Configuration;
using GS.Core.DAL.DI;

namespace GS.Core.BLL.DI
{
    public class BLLDIModule : Module
    {
        private IConfiguration _configuration;

        public BLLDIModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new LoggingClientDIModule(_configuration));
            builder.RegisterModule(new DALDIModule(_configuration));

            

         

            var repositoryRegistry = new BLLServiceRegistery(builder);
            repositoryRegistry.Register();
        }
    }
}