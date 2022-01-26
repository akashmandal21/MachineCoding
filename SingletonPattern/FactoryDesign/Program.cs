 using System;

namespace FactoryDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            OSFactory os = new OSFactory(); //do this instead of OS obj = new Android(); 
            OSInterface obj = os.getInstance("Open"); //leaving it for factory to decide on the basis of input
            obj.spec();
        }
    }
}
