using System;

namespace DIWorks
{
    public class FirstService
    {
        public SecondService _secondService;
        public FirstService(SecondService secondService)
        {
            _secondService = secondService;
        }
        public void Print(){
            Console.WriteLine("Calling First Service.");
            _secondService.Print();
        }
    }
}