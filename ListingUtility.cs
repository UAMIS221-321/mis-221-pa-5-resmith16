namespace mis_221_pa_5_resmith16
{
    public class ListingUtility
    {
        private  Listing[] listings;
        private Trainer[] trainers;
        string userInput = ""; 

        public ListingUtility(Listing[] listings, Trainer[] trainers){
            this.listings = listings;
            this.trainers = trainers;
        }

        public void ReadAllListings(){
            Listing.SetCount(0);

            StreamReader inFile = new StreamReader("listings.txt");
            string line = inFile.ReadLine();

                while(line != null){
                    string[] temp = line.Split("#");
                    listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], int.Parse(temp[2]), temp[3], temp[4], int.Parse(temp[5]), temp[6], temp[7]);
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

        public void PrintCurrentListings(){
            int j = 1;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            CategoryHeader();

            for(int i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetStatus() != "Deleted"){
                    Console.SetCursorPosition(0, j);
                    System.Console.WriteLine(listings[i].GetID());

                    Console.SetCursorPosition(5, j);
                    System.Console.WriteLine(listings[i].GetName());

                    Console.SetCursorPosition(27, j);
                    System.Console.WriteLine(listings[i].GetDate());

                    Console.SetCursorPosition(45, j);
                    System.Console.WriteLine(listings[i].GetTime());

                    Console.SetCursorPosition(65, j);
                    System.Console.WriteLine(listings[i].GetCost());

                    Console.SetCursorPosition(75, j);
                    System.Console.WriteLine(listings[i].GetStatus());

                    j++;
                }
                else{
                    //Skip
                }
            }
            Console.ResetColor();

            System.Console.WriteLine(); //Just for space between the menu
        }

        public void PrintAllListings(){
            int j = 1;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            CategoryHeader();

            for(int i = 0; i < Listing.GetCount(); i++){
                Console.SetCursorPosition(0, j);
                System.Console.WriteLine(listings[i].GetID());

                Console.SetCursorPosition(5, j);
                System.Console.WriteLine(listings[i].GetName());

                Console.SetCursorPosition(27, j);
                System.Console.WriteLine(listings[i].GetDate());

                Console.SetCursorPosition(45, j);
                System.Console.WriteLine(listings[i].GetTime());

                Console.SetCursorPosition(65, j);
                System.Console.WriteLine(listings[i].GetCost());

                Console.SetCursorPosition(75, j);
                System.Console.WriteLine(listings[i].GetStatus());

                j++;
            }
            Console.ResetColor();

            System.Console.WriteLine(); //Just for space between the menu
        }

        public void AddListing(){
            Console.Clear();

            Listing myListing = new Listing();

            myListing.SetID(Listing.GetCount() + 1);

            //Entering info (ID and Status are automatically set)
            System.Console.WriteLine("Please Enter Trainer Name:");
            string selectedTrainer = Console.ReadLine();

            Console.Clear();
            
            myListing.SetName(selectedTrainer);

            int foundTrainerID = FindTrainerID(selectedTrainer);
            myListing.SetTrainerID(foundTrainerID);

            Console.Clear();

            System.Console.WriteLine("Please Enter Listing Date:");
            myListing.SetDate(Console.ReadLine());

            Console.Clear();

            System.Console.WriteLine("Please Enter Listing Time:");
            myListing.SetTime(Console.ReadLine());

            Console.Clear();

            System.Console.WriteLine("Please Enter Listing Cost:");
            myListing.SetCost(int.Parse(Console.ReadLine()));

            myListing.SetStatus("Available");


            listings[Listing.GetCount()] = myListing;
            Listing.IncreaseCount();

        }

         public void EditListing(){
            Console.Clear();
            PrintAllListings();

            System.Console.WriteLine("Please input the Trainer ID of the Trainer you would like to edit:");
            int idInput = int.Parse(Console.ReadLine());

            int foundID = SearchID(idInput);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(listings[foundID].ToString());
            Console.ResetColor();

            System.Console.WriteLine(); //For space between trainer and menu

            System.Console.WriteLine("Which element would you like to edit?");
            System.Console.WriteLine();
            System.Console.WriteLine("(1) Trainer Name \n(2) Session Date \n(3) Session Time \n(4) Session Cost \n(5) Return to Main Menu");

            userInput = Console.ReadLine();

            if(userInput == "1"){
                SelectedTrainer(foundID);
                System.Console.WriteLine("Please Enter New Name:");
                listings[foundID].SetName(Console.ReadLine());
            }
            else if(userInput == "2"){
                SelectedTrainer(foundID);
                System.Console.WriteLine("Please Enter New Date:");
                listings[foundID].SetDate(Console.ReadLine());
            }
            else if(userInput == "3"){
                SelectedTrainer(foundID);
                System.Console.WriteLine("Please Enter New Time:");
                listings[foundID].SetTime(Console.ReadLine());
            }
            else if(userInput == "4"){
                SelectedTrainer(foundID);
                System.Console.WriteLine("Please Enter New Cost:");
                listings[foundID].SetCost(int.Parse(Console.ReadLine()));
            }
            else if(userInput == "5"){
                return;
            }
        }

        public void DeleteListing(){
            Console.Clear();
            PrintCurrentListings();
            System.Console.WriteLine("Please input the Listing ID of the Listing you would like to delete:");
            int idInput = int.Parse(Console.ReadLine());

            int foundID = SearchID(idInput);

            Console.Clear();
            System.Console.Write($"Are you sure you want to delete");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine($" {listings[foundID].GetName()}?");
            Console.ResetColor();

            System.Console.WriteLine("(1) Yes \n(2) No");
            userInput = Console.ReadLine();

            if(userInput == "1"){
                listings[foundID].SetStatus("Deleted");
            }
            else if(userInput == "2"){
                return;
            }
        }

        public void CategoryHeader(){
            Console.SetCursorPosition(0, 0);
            System.Console.WriteLine("ID:");

            Console.SetCursorPosition(5, 0);
            System.Console.WriteLine("Trainer Name:");

            Console.SetCursorPosition(27, 0);
            System.Console.WriteLine("Date:");

            Console.SetCursorPosition(45, 0);
            System.Console.WriteLine("Time:");

            Console.SetCursorPosition(65, 0);
            System.Console.WriteLine("Cost:");

            Console.SetCursorPosition(75, 0);
            System.Console.WriteLine("Status:");

        }

        public void Save(){
            StreamWriter outFile = new StreamWriter("listings.txt");
            
            for(int i = 0; i < Listing.GetCount(); i++){
            outFile.WriteLine(listings[i].ToFile());
            }

            outFile.Close();
        }       

        public int SearchID(int idInput){
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
            ReadAllTrainers();
            
            int i = 0;
            int max = Trainer.GetCount();

            while(i <= max){
                if(selectedTrainer == trainers[i].GetName()){
                    return trainers[i].GetID();
                }
                else{
                    i++;
                }
            }

            return -1;
         
        }

        public void SelectedTrainer(int foundID){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(listings[foundID].ToString());
            Console.ResetColor();
        }
    }
}