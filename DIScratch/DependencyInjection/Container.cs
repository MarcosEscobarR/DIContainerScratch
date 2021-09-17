using System;
using System.Collections.Generic;
using System.Linq;

namespace DIScratch.DependencyInjection
{
    public class Container
    {
        private List<ServiceDescriptor> _serviceDescriptors;
        public Container(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public T GetContainerService<T>()
        {
            var descriptor = _serviceDescriptors
                .SingleOrDefault(d => d.ServiceType == typeof(T));

            if (descriptor is null)
                throw new Exception($"Service of type {typeof(T).Name} doesn't exist into container");
            
            if (descriptor.Implementation is not null)
                return (T)descriptor.Implementation;

            var implementation = (T)Activator.CreateInstance( descriptor.ImplementationType ?? descriptor.ServiceType);
            if (descriptor.Lifetime == ServiceLifetime.Singleton)
                descriptor.Implementation = implementation;

            return implementation;
        }
    }
}