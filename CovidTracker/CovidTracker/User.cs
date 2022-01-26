using System.Collections.Generic;
using static CovidTracker.CovidTrackerService;
//interview@barraiser.com
namespace CovidTracker
{
    public class User : MasterUser
    {
        static int uniqueId = 0;
        int userId;
        int riskPercentage;
        List<string> symptoms;
        bool travelHistory;
        bool contactWithCovidPatient;
        bool covidPositive;

        public User(string userName, string phoneNumber, string pinCode)
        {
            this.userName = userName;
            this.userId = getUniqueId();
            this.phoneNumber = phoneNumber;
            this.pinCode = pinCode;
            this.riskPercentage = 0;
            this.symptoms = new List<string>();
            this.travelHistory = false;
            this.contactWithCovidPatient = false;
            this.covidPositive = false;
        }
        private int getUniqueId()
        {
            return ++uniqueId;
        }
        public int getUserId()
        {
            return this.userId;
        }
        public void AddSymptomsForAUser(List<string> symptoms, bool travelHistory, bool contactWithCovidPatient)
        {
            this.travelHistory = travelHistory;
            this.contactWithCovidPatient = contactWithCovidPatient;
            this.symptoms = symptoms;
        }
        public int GetRiskPercentage()
        {
            int riskPercentage = 0;
            if(this.symptoms.Count == 0 && this.travelHistory == false && this.contactWithCovidPatient == false)
            {
                riskPercentage =  5;
            }
            else if(this.symptoms.Count == 1 && (this.travelHistory == true || this.contactWithCovidPatient == true))
            {
                riskPercentage = 50;
            }
            else if (this.symptoms.Count == 2 && (this.travelHistory == true || this.contactWithCovidPatient == true))
            {
                riskPercentage = 75;
            }
            else if (this.symptoms.Count > 2 && (this.travelHistory == true || this.contactWithCovidPatient == true))
            {
                riskPercentage = 95;
            }
            return riskPercentage;
        }
        public void UpdateCovidStatus(CovidResult covidResult)
        {
            if(covidResult == CovidResult.POSITIVE)
            {
                this.covidPositive = true;
            }
            else
            {
                this.covidPositive = false;
            }
        }
        public bool GetCovidStatus()
        {
            return this.covidPositive;
        }
    }
    
}