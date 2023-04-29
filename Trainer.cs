namespace mis_221_pa_5_resmith16
{
    public class Trainer
    {
        static private int count;
        
        private int id;
        private string name;
        private string address;
        private string email;

        private string status;

        public Trainer()
        {
        }

        //Your constructor is setting the components of your whole trainer
        public Trainer(int id, string name, string address, string email){
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
        }

        public void SetID(int id){
            this.id = id;
        }

        public int GetID(){
            return id;
        }

        public void SetName(string name){
            this.name = name;
        }

        public string GetName(){
            return name;
        }

        public void SetAdd(string address){
            this.address = address;
        }

        public string GetAdd(){
            return address;
        }

        public void SetEmail(string email){
            this.email = email;
        }

        public string GetEmail(){
            return email;
        }

        public void SetStatus(string status){
            this.status = status;
        }

        public string GetStatus(){
            return status;
        }

        public static void SetCount(int count){
            Trainer.count = count;
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
            return $"{id} {name} {address} {email}";
        }

        public string ToFile(){
            return $"{this.id}#{this.name}#{this.address}#{this.email}#{this.status}";
        }

    }
}