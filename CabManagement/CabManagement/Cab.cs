namespace CabManagement
{
    public class Cab
    {
        public string cabNumber;
        public int Latitude;
        public int Longitude;
        public Cab(string cabNumber, int Latitude, int Longitude)
        {
            this.cabNumber = cabNumber;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }
}