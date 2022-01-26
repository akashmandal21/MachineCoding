using System.Collections.Generic;
using static CovidTracker.CovidTrackerService;

namespace CovidTracker
{
    internal class Admin : MasterUser
    {
        static int uniqueId = 0;
        int adminId = 0;
        public Admin(string userName, string phoneNumber, string pinCode)
        {
            this.userName = userName;
            this.adminId = getUniqueId();
            this.phoneNumber = phoneNumber;
            this.pinCode = pinCode;
        }
        private int getUniqueId()
        {
            return ++uniqueId;
        }
        public int getAdminId()
        {
            return this.adminId;
        }
        public void UpdateResult(int userId, CovidResult covidResult, Dictionary<int, User> userListMap)
        {
            User user = userListMap[userId];
            user.UpdateCovidStatus(covidResult);
        }
    }
    
}