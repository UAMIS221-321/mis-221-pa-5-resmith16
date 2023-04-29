namespace mis_221_pa_5_resmith16
{
    public class BookingUtility
    {
        private  Listing[] listings;
        private Booking[] bookings;
        private Trainer[] trainers;
        string userInput = "";

        public BookingUtility(Listing[] listings, Trainer[] trainers, Booking[] bookings){
            this.listings = listings;
            this.trainers = trainers;
            this.bookings = bookings;
        }

        public void ReadAllListings(){
            Listing.SetCount(0);

            StreamReader inFile = new StreamReader("listings.txt");
            string line = inFile.ReadLine();

                while(line != null){
                string[] temp = line.Split("#");
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], int.Parse(temp[2]), temp[3], temp[4], double.Parse(temp[5]), temp[6], temp[7]);
                Listing.IncreaseCount();
                line = inFile.ReadLine();
                }

            inFile.Close();
        }

        public void ReadAllTrainers(){
            Trainer.SetCount(0);

            StreamReader inFile = new StreamReader("trainers.txt");
            string line = inFile.ReadLine();

                while(line != null){
                    string[] temp = line.Split("#");
                    trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                    Trainer.IncreaseCount();
                    line = inFile.ReadLine();
                }

            inFile.Close();
        }

        public void PrintAllListings(){
            int i = 0;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            for(i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetAvailability() == "Available"){
                    Console.SetCursorPosition(0, i);
                    System.Console.WriteLine(listings[i].GetID());

                    Console.SetCursorPosition(5, i);
                    System.Console.WriteLine(listings[i].GetName());

                    Console.SetCursorPosition(27, i);
                    System.Console.WriteLine(listings[i].GetDate());

                    Console.SetCursorPosition(45, i);
                    System.Console.WriteLine(listings[i].GetTime());

                    Console.SetCursorPosition(65, i);
                    System.Console.WriteLine(listings[i].GetCost());

                    Console.SetCursorPosition(75, i);
                    System.Console.WriteLine(listings[i].GetAvailability());

                    Console.SetCursorPosition(85, i);
                    System.Console.WriteLine(listings[i].GetStatus());
                }
                else if(listings[i].GetAvailability() != "Available"){
                    //Nothing as of rn
                }
            }
            System.Console.WriteLine();
            Console.ResetColor();
        }

        public void BookSession(){
            Booking myBooking = new Booking();
            Listing myListing = new Listing();

            myBooking.SetCustID(Booking.GetCount() + 1);

            Console.Clear();
            ReadAllTrainers();
            PrintAllListings();

            //Look at available listings
            System.Console.WriteLine("Please input the session ID of the session you would like to book:");
            int idInput = int.Parse(Console.ReadLine());
            int foundID = SearchListingID(idInput);

            //Confirming you want to book with specific trainer
            Console.Clear();
            System.Console.Write($"Are you sure you want to book a session with");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write($" {listings[foundID].GetName()}?");
            Console.ResetColor();

            System.Console.WriteLine();
            System.Console.WriteLine("(1) Yes \n(2) No");
            userInput = Console.ReadLine();

            if(userInput == "1"){
                listings[foundID].SetStatus("Booked");
            }
            else if(userInput == "2"){
                return;
            }

            Console.Clear();
            System.Console.WriteLine("Please Enter Customer Name:");
            myBooking.SetCustName(Console.ReadLine());

            Console.Clear();
            System.Console.WriteLine("Please Enter Customer Email:");
            myBooking.SetCustEmail(Console.ReadLine());

            myBooking.SetDate(listings[foundID].GetDate());

            myBooking.SetTrainerName(listings[foundID].GetName());
            string selectedTrainer = listings[foundID].GetName();

            int foundTrainerID = FindTrainerID(selectedTrainer);
            myBooking.SetTrainerID(foundTrainerID);

            myBooking.SetStatus("Booked");
            listings[foundID].SetAvailability("Booked");

            bookings[Booking.GetCount()] = myBooking;
            Booking.IncreaseCount();
        }

        public void CompleteSession(){
            Console.Clear();
            PrintAllListings();

            System.Console.WriteLine("Please input the session ID of the session you would like to complete:");
            int idInput = int.Parse(Console.ReadLine());
            int foundID = SearchListingID(idInput);

            Console.Clear();
            System.Console.Write($"Are you sure you want to complete your session with");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write($" {listings[foundID].GetName()}?");
            Console.ResetColor();

            System.Console.WriteLine();
            System.Console.WriteLine("(1) Yes \n(2) No");
            userInput = Console.ReadLine();

            if(userInput == "1"){
                listings[foundID].SetStatus("Completed");
            }
            else if(userInput == "2"){
                return;
            }

        }

        public void CancelSession(){
            Console.Clear();
            PrintAllListings();

            System.Console.WriteLine("Please input the session ID of the session you would like to cancel:");
            int idInput = int.Parse(Console.ReadLine());
            int foundID = SearchListingID(idInput);

            Console.Clear();
            System.Console.Write($"Are you sure you want to cancel your session with");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write($" {listings[foundID].GetName()}?");
            Console.ResetColor();

            System.Console.WriteLine();
            System.Console.WriteLine("(1) Yes \n(2) No");
            userInput = Console.ReadLine();

            if(userInput == "1"){
                listings[foundID].SetStatus("Cancelled");
            }
            else if(userInput == "2"){
                return;
            }
        }

        public void Save(){
            StreamWriter outFile = new StreamWriter("transactions.txt");
            System.Console.WriteLine(Booking.GetCount());
            
            for(int i = 0; i < Booking.GetCount(); i++){
            outFile.WriteLine(bookings[i].ToFile());
            }

            outFile.Close();
        }  

        public int SearchListingID(int idInput){
            int min = 0;
            int max = Listing.GetCount();

            while(min <= max){
                int mid = (min + max) / 2;

                if(idInput == listings[mid].GetID()){
                    return mid;
                }
                else if(idInput < listings[mid].GetID()){
                    max = mid--;
                }
                else{
                    min = mid++;
                }
            }

            return -1;
        } 

        public int FindTrainerID(string selectedTrainer){
            int i = 0;
            int max = Trainer.GetCount();

            while(i <= max){
                System.Console.WriteLine(selectedTrainer);
                System.Console.WriteLine(trainers[i].GetName());

                if(selectedTrainer == trainers[i].GetName()){
                    return trainers[i].GetID();
                }
                else{
                    i++;
                }
            }

            return -1;
         
        }
    }
}

