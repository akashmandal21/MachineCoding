using System;
namespace BuilderPattern
{
    public class Phone
    {
        private string os;
        private int ram;
        private string processor;
        private double screenSize;
        private int battery;

        public Phone(PhoneBuilder pb) 
        {
            this.os = pb.os;
            this.ram = pb.ram;
            this.processor = pb.processor;
            this.screenSize = pb.screenSize;
            this.battery = pb.battery;
        }
    }
}
