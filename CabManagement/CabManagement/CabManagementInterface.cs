using System;
using System.Collections.Generic;

namespace CabManagement
{
    public interface CabManagementInterface
    {
        void AddRider(string userName, string phoneNumber, string countryCode);
        void AddDriver(string userName, string phoneNumber, string countryCode);
        void AddCabs(string cabNumber, int Latitude, int Longitude);
        void BookCab(int userId, int Latitude, int Longitude);
        void EndRide(int userId, string cabNumber);
        void GetBookingHistory(int userId);
        void UpdateCabLocation(int Latitude, int Longitude, string cabNumber);
    }
}
