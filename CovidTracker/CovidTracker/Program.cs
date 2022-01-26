using System;
using System.Collections.Generic;

namespace CovidTracker
{
    class Program
    {
        public static void Main(string[] args)
        {
            CovidTrackerService cts = new CovidTrackerService();
            cts.RegisterUser("Akash","999999999","800001");
            cts.RegisterUser("Saurav", "888888888", "800001");
            cts.RegisterUser("Abhishek", "77777777", "800001");
            cts.RegisterUser("Rahul", "66666666", "800005");
            cts.RegisterUser("Yash", "9999955555", "800005");

            List<string> symp1 = new List<string>();
            symp1.Add("Fever");
            symp1.Add("Cough");
            symp1.Add("Cold");
            cts.SelfAssessment(1, symp1, true, true);


            cts.RegisterAdmin("Vishal","8889994444","801010");
            cts.RegisterAdmin("Vivek", "88994400332", "800100");

            cts.UpdateCovidResult(1,2,CovidTrackerService.CovidResult.POSITIVE);
            cts.UpdateCovidResult(4, 1, CovidTrackerService.CovidResult.NEGATIVE);

            cts.GetZone("800001");
        }
    }
}
