namespace mis_221_pa_5_resmith16
{
    public class Booking
    {
        static private int count;
        private int customerID;
        private string customerName;

        private string customerEmail;
        private string date;
        private int trainerID;
        private string trainerName;
        private string status;

        public Booking(){

        }

        public Booking(int customerID, string customerName, string customerEmail, string date, int trainerID, string trainerName, string status){
            this.customerID = customerID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.date = date;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
        }

        public void SetCustID(int customerID){
            this.customerID = customerID;
        }

        public int GetCustID(){
            return customerID;
        }

        public void SetCustName(string customerName){
            this.customerName = customerName;
        }

        public string GetCustName(){
            return customerName;
        }

        public void SetCustEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }

        public string GetCustEmail(){
            return customerEmail;
        }

        public void SetDate(string date){
            this.date = date;
        }

        public string GetDate(){
            return date;
        }

        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }

        public int GetTrainerID(){
            return trainerID;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetTrainerName(){
            return trainerName;
        }

        public void SetStatus(string status){
            this.status = status;
        }

        public string GetStatus(){
            return status;
        }

        public static void SetCount(int count){
            Booking.count = count;
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
            return $"{customerID} {customerName} {customerEmail} {date} {trainerID} {trainerName} {status}";
        }

        public string ToFile(){
            return $"{this.customerID}#{this.customerName}#{this.customerEmail}#{date}#{trainerID}#{trainerName}#{status}#";
        }
    }
}