namespace mis_221_pa_5_resmith16
{
    public class Listing
    {
        static private int count;
        
        private int listingID;
        private string name;
        private int trainerID;
        private string date;
        private string time;
        private double cost;

        private string availability;
        private string status;

        public Listing()
        {
        }

        public Listing(int listingID, string name, int trainerID, string date, string time, double cost, string availability, string status){
            this.listingID = listingID;
            this.name = name;
            this.trainerID = trainerID;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.availability = availability;
            this.status = status;
        }

        public void SetID(int listingID){
            this.listingID = listingID;
        }

        public int GetID(){
            return listingID;
        }

        public void SetName(string name){
            this.name = name;
        }

        public string GetName(){
            return name;
        }

        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }

        public int GetTrainerID(){
            return trainerID;
        }

        public void SetDate(string date){
            this.date = date;
        }

        public string GetDate(){
            return date;
        }

        public void SetTime(string time){
            this.time = time;
        }

        public string GetTime(){
            return time;
        }

        public void SetCost(double cost){
            this.cost = cost;
        }

        public double GetCost(){
            return cost;
        }

        public void SetAvailability(string availability){
            this.status = availability;
        }

        public string GetAvailability(){
            return availability;
        }

        public void SetStatus(string status){
            this.status = status;
        }

        public string GetStatus(){
            return status;
        }

        public static void SetCount(int count){
            Listing.count = count;
        }

        public static int GetCount(){
            return count;
        }

        public static int IncreaseCount(){
            return count++;
        }

        public static int DecreaseCount(){
            return count--;
        }

        public string ToString(){
            return $"{listingID} {name} {date} {time} {cost} {availability} {status}";
        }

        public string ToFile(){
            return $"{this.listingID}#{this.name}#{this.trainerID}#{this.date}#{this.time}#{this.cost}#{this.availability}#{this.status}";
        }
    }
}