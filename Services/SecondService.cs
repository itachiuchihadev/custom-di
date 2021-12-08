using System;

namespace DIWorks
{
    public class SecondService
    {
        int _random;
        public SecondService()
        {
            _random = new Random().Next();
        }
        public void Print(){
            Console.WriteLine($"Second Service is Called. {_random}");
        }
    }
}