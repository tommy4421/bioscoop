using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using PartyInvites.Domain.Abstract;
using PartyInvites.Domain.Concrete;
using PartyInvites.Domain.Entities;

namespace PartyInvites.WebUI.Infrastructure {
    public class NinjectDependencyResolver : IDependencyResolver {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() {
            kernel.Bind<IRepository<GuestResponse>>().To<PersistentGPRepository>();
        }
    }
}