using System;
using System.Collections.Generic;
using System.Linq;

namespace CabManagement
{
    public class CabManagement : CabManagementInterface
    {
        List<User> RiderList = new List<User>();
        List<User> DriverList = new List<User>();
        List<Cab> UnusedCabList = new List<Cab>();
        List<Cab> UsedCabList = new List<Cab>();
        Dictionary<int,List<Booking>> BookingHistory = new Dictionary<int,List<Booking>>();
        public void AddRider(string userName, string phoneNumber, string countryCode)
        {
            User user = new(userName, phoneNumber, countryCode);
            RiderList.Add(user);
        }
        public void AddDriver(string userName, string phoneNumber, string countryCode)
        {
            User user = new(userName, phoneNumber, countryCode);
            DriverList.Add(user);
        }
        public void AddCabs(string cabNumber, int Latitude, int Longitude)
        {
            Cab cab = new(cabNumber, Latitude, Longitude);
            UnusedCabList.Add(cab);
        }
        public void BookCab(int userId, int Latitude, int Longitude)
        {
            bool flag = false;
            for(int i = 0; i < UnusedCabList.Count; i++)
            {
                if(Math.Abs(UnusedCabList[i].Latitude - Latitude) < 5 && Math.Abs(UnusedCabList[i].Longitude - Longitude) < 5)
                {
                    UsedCabList.Add(UnusedCabList[i]);
                    Booking booking = new(UnusedCabList[i].cabNumber);
                    if(!BookingHistory.ContainsKey(userId))
                    {
                        BookingHistory.Add(userId, new List<Booking>());
                    }
                    BookingHistory[userId].Add(booking);
                    Console.WriteLine("Booked cab number is: " + UnusedCabList[i].cabNumber);
                    flag = true;
                    UnusedCabList.Remove(UnusedCabList[i]);
                    break;
                }
            }
            if(!flag)
            {
                Console.WriteLine("Cannot find a cab");
            }
        }
        public void EndRide(int userId, string cabNumber)
        {
            for (int i = 0; i < UsedCabList.Count; i++)
            {
                if(UsedCabList[i].cabNumber == cabNumber)
                {
                    UnusedCabList.Add(UsedCabList[i]);
                    UsedCabList.Remove(UsedCabList[i]);
                }
            }
           // Cab cab = (Cab)UsedCabList.Where(x => x.cabNumber == cabNumber);
            
        }
        public void GetBookingHistory(int userId)
        {
            for(int i=0;i< BookingHistory[userId].Count;i++)
            {
                Console.WriteLine(BookingHistory[userId][i].GetCabNumber());
            }
        }
        public void UpdateCabLocation(int Latitude, int Longitude, string cabNumber)
        {
            for (int i = 0; i < UsedCabList.Count; i++)
            {
                if (UsedCabList[i].cabNumber == cabNumber)
                {
                    UsedCabList[i].Latitude = Latitude;
                    UsedCabList[i].Longitude = Longitude;
                }
            }
            for (int i = 0; i < UnusedCabList.Count; i++)
            {
                if (UnusedCabList[i].cabNumber == cabNumber)
                {
                    UnusedCabList[i].Latitude = Latitude;
                    UnusedCabList[i].Longitude = Longitude;
                }
            }
        }
    }
}
