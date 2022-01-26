using System;
using System.Collections.Generic;

namespace FoodKart
{
    public class Restaurant
    {
        public int restaurantId;
        public string restaurantName;
        public List<string> areaList;
        public FoodItem food;
        public Rating rating = new Rating();
        public int totalRatingSum = 0;
        public int rater = 0;
        public static int uniqueId = 0;

        public Restaurant(string restaurantName, List<string> areaList, string itemName, int itemPrice, int quantity)
        {
            this.restaurantId = getUniqueId();
            this.restaurantName = restaurantName;
            this.areaList = areaList;
            FoodItem foodItem = new FoodItem(itemName,itemPrice,quantity);
            this.food = foodItem;
        }

        public void updateQuantity(int quantityToAdd)
        {
            FoodItem foodItem = new FoodItem(quantityToAdd);
        }

        private int getUniqueId()
        {
            return ++uniqueId;
        }

        public void placeOrder(int quantity)
        {
            if(this.food.itemQuantity >= quantity)
            {
                this.food.itemQuantity -= quantity;
                Console.WriteLine("Order Placed");
            }
            else
            {
                Console.WriteLine("Cannot Place Order. Remaining quantity left: " + this.food.itemQuantity);
            }
        }

        public void rateRestaurant(int rating)
        {
            this.totalRatingSum += rating;
            this.rater += 1;
            this.rating.rating = Convert.ToDouble(this.totalRatingSum) / Convert.ToDouble(this.rater);
            Console.WriteLine("Rating is: " + this.rating.rating);
        }
        
    }
}