using System;
using System.Linq;
using System.Reflection;
using Autofac;
using System.Collections.Generic;
using GS.Core.BLL.Interfaces.Services;
using GS.Core.BLL.Services;

namespace GS.Core.BLL.DI
{
    public class BLLServiceRegistery
    {
        private ContainerBuilder _builder;
        public BLLServiceRegistery(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public void Register()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var repositoryTypes = new List<Type>();
            foreach(var assembly in assemblies)
            {
                foreach(Type type in assembly.GetTypes().Where(t => t.IsAssignableTo<IService>()))
                {
                    repositoryTypes.Add(type);
                }
            }
            
            foreach(var type in repositoryTypes)
            {
                var attribute = type.GetCustomAttribute<BLLServiceRegistrationAttribute>();
                if(attribute != null && attribute.RegisterAsType != null)
                {
                    _builder
                        .RegisterType(type)
                        .As(attribute.RegisterAsType);
                }
            }
        }
    }
}