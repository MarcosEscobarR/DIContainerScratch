using System.Collections.Generic;

namespace DIScratch.DependencyInjection
{
    public class DiServiceCollection
    {
        private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();
        public void RegisterSingleton<TService>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton));
        }
        public void RegisterSingleton<TService>(TService implementation)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifetime.Singleton));
        }
        public void RegisterTransient<TService>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));
        }

        public void RegisterTransient<TService, TImplementation>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }

        public Container GetContainer()
        {
            return new(_serviceDescriptors);
        }

      
    }
}