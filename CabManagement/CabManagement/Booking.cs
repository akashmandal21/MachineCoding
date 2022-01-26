namespace CabManagement
{
    public class Booking
    {
        static int uniqueId = 0;
        int bookingId;
        string cabNumber;
        public Booking(string cabNumber)
        {
            this.bookingId = GetBookingId();
            this.cabNumber = cabNumber;
        }
        int GetBookingId()
        {
            return uniqueId++;
        }
        public string GetCabNumber()
        {
            return cabNumber;
        }
    }
}