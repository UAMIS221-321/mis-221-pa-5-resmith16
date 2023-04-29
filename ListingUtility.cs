namespace mis_221_pa_5_resmith16
{
    public class ListingUtility
    {
        private  Listing[] listings;
        private Trainer[] trainers;
        string userInput = ""; 

        public ListingUtility(Listing[] listings){
            this.listings = listings;
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

        public void PrintAllListings(){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            for(int i = 0; i < Listing.GetCount(); i++){
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
            Console.ResetColor();

            System.Console.WriteLine(); //Just for space between the menu
        }


        //Now build your add, edit, and delete methods
        //Need to build a method for developing your trainer IDs - worry about it later


        public void AddListing(){
            Console.Clear();

            Listing myListing = new Listing();

            //Entering info (ID and Status are automatically set)
            System.Console.WriteLine("Please Enter Trainer Name:");
            myListing.SetName(Console.ReadLine());

            myListing.SetTrainerID(trainers[0].GetID());

            System.Console.WriteLine("Please Enter Listing Date:");
            myListing.SetDate(Console.ReadLine());

            System.Console.WriteLine("Please Enter Listing Time:");
            myListing.SetTime(Console.ReadLine());

            System.Console.WriteLine("Please Enter Listing Cost:");
            myListing.SetCost(double.Parse(Console.ReadLine()));


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
            System.Console.WriteLine("Please input the Listing ID of the Listing you would like to delete:");
            int idInput = int.Parse(Console.ReadLine());

            int foundID = SearchID(idInput);

            Console.Clear();
            System.Console.Write($"Are you sure you want to delete");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write($" {listings[foundID].GetName()}?");
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

        public void SelectedTrainer(int foundID){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(listings[foundID].ToString());
            Console.ResetColor();
        }
    }
}