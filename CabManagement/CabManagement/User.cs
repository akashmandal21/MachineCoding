using System;

namespace CabManagement
{
    internal class User
    {
        string userName;
        string phoneNumber;
        string countryCode;
        int userId;
        static int uniqueId = 0;
        public User(string userName, string phoneNumber, string countryCode)
        {
            this.userId = GetUniqueId();
            this.userName = userName;
            this.phoneNumber = phoneNumber;
            this.countryCode = countryCode;
        }

        private int GetUniqueId()
        {
            return uniqueId++;
        }
    }
}