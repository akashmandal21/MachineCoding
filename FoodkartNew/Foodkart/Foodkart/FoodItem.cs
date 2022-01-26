namespace FoodKart
{
    public class FoodItem
    {
        public string itemName;
        public double itemPrice;
        public int itemQuantity;

        public FoodItem(string itemName, double itemPrice, int itemQuantity)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.itemQuantity = itemQuantity;
        }
        public FoodItem(int itemQuantity)
        {
            this.itemQuantity = this.itemQuantity + itemQuantity;
        }
    }
}