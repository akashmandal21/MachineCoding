using System;
using System.Collections.Generic;

namespace CovidTracker
{
    public class CovidTrackerService
    {
        public enum CovidResult
        {
            POSITIVE,NEGATIVE
        }
        static List<User> userList = new List<User>();
        static List<Admin> adminList = new List<Admin>();
        static Dictionary<int, User> userListMap = new Dictionary<int, User>();
        static Dictionary<int, Admin> adminListMap= new Dictionary<int, Admin>();
        static Dictionary<string,int> covidPositivePinCodeList = new Dictionary<string, int>();

        public void RegisterUser(string userName, string phoneNumber, string pinCode)
        {
            User user = new(userName,phoneNumber,pinCode);

            userList.Add(user);
            int userId = user.getUserId();
            userListMap[userId] = user;
            Console.WriteLine("The registered user Id is: " + userId);
        }
        public void SelfAssessment(int userId, List<string> symptoms,bool travelHistory, bool contactWithCovidPatient)
        {
            User user = userListMap[userId];
            user.AddSymptomsForAUser(symptoms, travelHistory, contactWithCovidPatient);
            int riskPercentage = user.GetRiskPercentage();
            Console.WriteLine("Risk Percentage for UserId " + userId + " : " + riskPercentage + "%");
        }
        public void RegisterAdmin(string userName, string phoneNumber, string pinCode)
        {
            Admin admin = new Admin(userName, phoneNumber, pinCode);
            adminList.Add(admin);
            int adminId = admin.getAdminId();
            adminListMap[adminId] = admin;
            Console.WriteLine("The registered admin Id is: " + adminId);
        }
        public void UpdateCovidResult(int userId, int adminId, CovidResult covidResult)
        {
            Admin admin = adminListMap[adminId];
            admin.UpdateResult(userId,covidResult, userListMap);
            User user = userListMap[userId];
            bool isCovidPositive = user.GetCovidStatus();
         
            if (isCovidPositive)
            {
                if(!covidPositivePinCodeList.ContainsKey(user.pinCode))
                {
                    covidPositivePinCodeList.Add(user.pinCode,1);
                }
                else
                {
                    covidPositivePinCodeList[user.pinCode]++;
                }
                Console.WriteLine("UserId : " + userId + " is Covid Positive.");

            }
            else
            {
                if (!covidPositivePinCodeList.ContainsKey(user.pinCode))
                {
                    covidPositivePinCodeList.Add(user.pinCode, 0);
                }
                else if(covidPositivePinCodeList[user.pinCode] > 0)
                {
                    covidPositivePinCodeList[user.pinCode]--;
                }
                
                Console.WriteLine("UserId : " + userId + " is Covid Negative.");
            }
            
        }
        public void GetZone(string pinCode)
        {
            if(covidPositivePinCodeList[pinCode] == 0)
            {
                Console.WriteLine("Green Zone.");
            }
            else if (covidPositivePinCodeList[pinCode] > 0 && covidPositivePinCodeList[pinCode] < 5)
            {
                Console.WriteLine("Orange Zone.");
            }
            else
            {
                Console.WriteLine("Red Zone.");
            }
        }

    }

}
