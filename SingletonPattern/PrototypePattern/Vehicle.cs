using System;
using System.Collections.Generic;

namespace PrototypePattern
{
    public class Vehicle : ICloneable
    {
        private List<string> vehicleList; 
        public Vehicle()
        {
            this.vehicleList = new List<string>();
        }
        public Vehicle(List<string> list)
        {
            this.vehicleList = list;
        }
        public void insertData()
        {
            vehicleList.Add("BMW");
            vehicleList.Add("Skoda");
            vehicleList.Add("Audi");
            vehicleList.Add("Mercedes");
        }
        public List<string> getVehicleList()
        {
            return this.vehicleList;
        }
        public object Clone()
        {
            /* Vehicle v = (Vehicle)this.MemberwiseClone(); 
             return v; */ //Deep cloning(it will create the new object from the existing object and then copying the fields of the current object to the newly created object)
            return MemberwiseClone(); //Shallow cloning (The references in the new object point to the same objects that the references in the original object points to)
        }
     }
}