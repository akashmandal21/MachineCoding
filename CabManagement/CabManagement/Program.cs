using System;

namespace CabManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            CabManagement cm = new CabManagement();
            cm.AddRider("Akash","7250359003","+91");
            cm.AddRider("Deepak", "8609168629", "+91");
            cm.AddRider("Abhishek", "999999999", "+91");
            cm.AddRider("Saurav", "888888888", "+91");
            cm.AddDriver("Abc", "245245624", "+91");
            cm.AddDriver("bggt", "56356356", "+91");
            cm.AddDriver("kljlk", "908798664", "+91");
            cm.AddCabs("UP16",50,60);
            cm.AddCabs("HR26", 70,90);
            cm.AddCabs("DL3C", 100, 80);
            cm.BookCab(1,72,94);
            cm.BookCab(1, 120, 100);
            cm.EndRide(1, "HR26");
            cm.UpdateCabLocation(118,103, "DL3C");
            cm.BookCab(1, 120, 100);
            cm.GetBookingHistory(1);
        }
    }
}
