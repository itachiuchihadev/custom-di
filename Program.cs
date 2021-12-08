using System;

namespace DIWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var container = new DIContainer();
            container.AddTransient<FirstService>();
            container.AddTransient<ServiceConsumer>();
            container.AddSingleton<SecondService>();
            var dependencyResolver = new DIResolver(container);
            var serviceConsumer1 = dependencyResolver.GetService<ServiceConsumer>();
            serviceConsumer1.Print();
            var serviceConsumer2 = dependencyResolver.GetService<ServiceConsumer>();
            serviceConsumer2.Print();
            var serviceConsumer3 = dependencyResolver.GetService<ServiceConsumer>();
            serviceConsumer3.Print();


        }
    }
}
