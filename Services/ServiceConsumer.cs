using System;

namespace DIWorks
{
    public class ServiceConsumer
    {
        private FirstService _firstService;
        public ServiceConsumer(FirstService firstService)
        {
            _firstService = firstService;
        }

        public void Print(){
            Console.WriteLine("Service Consumer is Called");
            this._firstService.Print();
        }
    }
}