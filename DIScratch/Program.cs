using System;
using DIScratch.DependencyInjection;

namespace DIScratch
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new DiServiceCollection();
            
            // services.RegisterTransient<RandomGuidGenerator>();
            services.RegisterTransient<ISomeService, SomeService>();

            var container = services.GetContainer();

            var serviceFirst = container.GetContainerService<ISomeService>();
            var serviceSecond = container.GetContainerService<ISomeService>();
            
            serviceFirst.PrintSomething();
            serviceSecond.PrintSomething();
        }
    }
}