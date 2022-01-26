namespace FoodKart
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string phoneNumber { get; set; }
        public string areaCode { get; set; }
        static int uniqueId = 0;

        public User(string userName, string phoneNumber, string area)
        {
            this.userName = userName;
            this.phoneNumber = phoneNumber;
            this.areaCode = area;
            this.userId = getUniqueId();
        }

        private int getUniqueId()
        {
            return ++uniqueId;
        }
    }
}