using System;
using System.Collections.Generic;
using static FoodKart.FoodkartService;

namespace FoodKart
{
    public class FoodkartTest
    {
        public static void Main(String[] args)
        {
            FoodkartService fk = new FoodkartService();
            fk.Register_user("Akash","7250259003","Sec-137");
            fk.Register_user("Sorov", "9823782368", "Telo");
            fk.Register_user("Abhishek", "7033402301", "Sec-137");
            fk.Register_user("Aniruddh", "9843244553", "Sec-62");

            List<string> l = new List<string>();
            l.Add("Sec-137");
            l.Add("Sec-62");
            List<string> m = new List<string>();
            m.Add("Telo");
            List<string> n = new List<string>();
            n.Add("Sec-137");
            fk.Register_restaurant("Food Court - 1",l , "Dosa", 100, 5);
            fk.Register_restaurant("Food Court - 2", m, "Burger", 120, 3);
            fk.Register_restaurant("Food Court - 3", n, "Pizza", 150, 1);

            fk.Place_order("Akash", "Food Court - 1", 2, "Sec-137");
            fk.Place_order("Abhishek", "Food Court - 1", 2, "Sec-137");
            fk.Place_order("Akash", "Food Court - 1", 2, "Sec-137");

            fk.Rate("Food Court - 1", 3);
            fk.Rate("Food Court - 1", 4);
            fk.Rate("Food Court - 1", 5);
            fk.Rate("Food Court - 3", 5);

            fk.Show_restaurant(sortingCriteria.PRICE,"Sec-137");
            fk.Show_restaurant(sortingCriteria.RATING, "Sec-137");

        }
    }
}
