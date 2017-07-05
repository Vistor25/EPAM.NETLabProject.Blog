using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using DR.DependencyResolver;
using Ninject;

namespace mvcPL.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            var connectionString = ConfigurationManager.ConnectionStrings["BlogDBEntities"].ConnectionString;
            kernel.ConfigurateResolverWeb(connectionString);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}