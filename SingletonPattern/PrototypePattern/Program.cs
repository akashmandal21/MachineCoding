using System;
using System.Collections.Generic;

namespace PrototypePattern
{
    class Program
    {
        public static void Main(string[] args)
        {
            Vehicle a = new Vehicle();
            a.insertData();

            Vehicle b = (Vehicle)a.Clone();
            List<string> list = b.getVehicleList();
            
            list.Add("Honda");

            for(int i = 0; i < a.getVehicleList().Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("****");
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
