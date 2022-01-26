using System;
namespace FactoryDesign
{
    public class OSFactory
    {
        public OSInterface getInstance(string str)
        {
            if(str=="Open")
            {
                return new Android();
            }
            else
            {
                return new IOS();
            }
        }
    }
}
