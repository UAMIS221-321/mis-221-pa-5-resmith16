namespace mis_221_pa_5_resmith16
{
    public class Report
    {
        private Trainer[] trainers;
        private Listing[] listings;
        private Booking[] bookings;

        static private int count;
        private int customerID;
        private string customerName;

        private string customerEmail;
        private string date;
        private int cost;
        private int trainerID;
        private string trainerName;
        private string status;

        public Report()
        {

        }

        public Report(Trainer[] trainers, Listing[] listings, Booking[] bookings){
            this.trainers = trainers;
            this.listings = listings;
            this.bookings = bookings;
        }

        public void SortByCustomer(Booking[] bookings){
            
        }

        public void SortByDate(Booking[] bookings){

        }
    }
}