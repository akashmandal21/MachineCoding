using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodKart
{
    public class FoodkartService
    {
        List<Restaurant> restaurantList = new List<Restaurant>();
        List<User> userList = new List<User>();
        Dictionary<string, List<Restaurant>> areaRestaurantMap = new Dictionary<string, List<Restaurant>>();
        Dictionary<string, Restaurant> restaurantNameMap = new Dictionary<string, Restaurant>();
        Dictionary<int, User> userNameMap = new Dictionary<int, User>();
        public enum sortingCriteria
        {
            RATING,PRICE
        }
        public void Register_user(string userName, string phoneNumber, string area)
        {
            User user = new User(userName,phoneNumber,area);
            userList.Add(user);
            userNameMap[user.userId] = user;
        }
        public void Register_restaurant(string restaurantName, List<string> areaList, string itemName, int itemPrice, int quantity)
        {
            Restaurant ŗestaurant = new(restaurantName, areaList, itemName, itemPrice, quantity);
            restaurantList.Add(ŗestaurant);
            restaurantNameMap.Add(restaurantName, ŗestaurant);
            for(int i=0;i<areaList.Count;i++)
            {
                if (areaRestaurantMap.ContainsKey(areaList[i]))
                {
                    areaRestaurantMap[areaList[i]].Add(ŗestaurant);
                }
                else
                {
                    List<Restaurant> tempRestList = new List<Restaurant>();
                    tempRestList.Add(ŗestaurant);
                    areaRestaurantMap.Add(areaList[i], tempRestList);
                }
            }
            
        }
        public void Update_Quantity(string restaurantName, int quantityToAdd)
        {
            Restaurant restaurant = restaurantNameMap[restaurantName];
            restaurant.updateQuantity(quantityToAdd);
        }
        public void Show_restaurant(sortingCriteria criteria, string areaCode)
        {
            List<Restaurant> restaurantsInArea = new List<Restaurant>();
            if (criteria == sortingCriteria.RATING)
            {
                restaurantsInArea = areaRestaurantMap[areaCode].OrderByDescending(o => o.rating.rating).Where(n => n.food.itemQuantity > 0).ToList();
            }
            else
            {
                restaurantsInArea = areaRestaurantMap[areaCode].OrderBy(o => o.food.itemPrice).Where(n => n.food.itemQuantity > 0).ToList();
            }
            for (int i = 0; i < restaurantsInArea.Count; i++)
            {
                Console.WriteLine(restaurantsInArea[i].restaurantName + " " + restaurantsInArea[i].food.itemName + " " + restaurantsInArea[i].food.itemPrice);
            }
        }
        public void Place_order(string userName, string restaurantName, int quantity, string areaCode)
        {
            Restaurant restaurant = restaurantNameMap[restaurantName];
            restaurant.placeOrder(quantity);
        }
        public void Rate(string restaurantName, int rating)
        {
            Restaurant restaurant = restaurantNameMap[restaurantName];
            restaurant.rateRestaurant(rating);
        }
    }
}
