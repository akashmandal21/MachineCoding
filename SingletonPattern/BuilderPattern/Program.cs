using System;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone p = new PhoneBuilder().setOs("Android").setProcessor("Qualcomm").setBattery(3000).getPhone();
            Console.WriteLine(p.os);
        }
    }
}
