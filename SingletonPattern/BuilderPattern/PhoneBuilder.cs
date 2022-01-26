using System;
namespace BuilderPattern
{
    public class PhoneBuilder
    {
        public string os;
        public int ram;
        public string processor;
        public double screenSize;
        public int battery;

        public PhoneBuilder setOs(string os)
        {
            this.os = os;
            return this;
        }
        public PhoneBuilder setRam(int ram)
        {
            this.ram = ram;
            return this;
        }
        public PhoneBuilder setProcessor(string processor)
        {
            this.processor = processor;
            return this;
        }
        public PhoneBuilder setScreenSize(double screenSize)
        {
            this.screenSize = screenSize;
            return this;
        }
        public PhoneBuilder setBattery(int battery)
        {
            this.battery = battery;
            return this;
        }

        public Phone getPhone()
        {
            return new Phone(this);
        }

    }
}
