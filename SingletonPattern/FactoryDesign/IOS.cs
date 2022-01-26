using System;
namespace FactoryDesign
{
    public class IOS : OSInterface
    {

        public void spec()
        {
            Console.WriteLine("Closed Source");
        }
    }
}
