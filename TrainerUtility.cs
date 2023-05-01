namespace mis_221_pa_5_resmith16
{
    public class TrainerUtility
    {

        //You are going to do all of your Trainer functions within this utility class.
        //Add, Edit, and Delete
        //Build it all here, keep it organized. That's the goal.

        //Wait so... I'm building my method in the class. If I want to use it, I need to say two things.
        //The class it is in, and the method name (Ex. Trainer.SetCount(0))
        //Right? Makes a little more sense than just "Oh yeah it works somehow"
        //Thanks Scott :)
    

        //Set up a Trainer array
        private  Trainer[] trainers; //ohhh this is the trainers array Mattie was talking about
        string userInput = "";

        public TrainerUtility(Trainer[] trainers){
            this.trainers = trainers;
        }

        public void ReadAllTrainers(){
            Trainer.SetCount(0);

            StreamReader inFile = new StreamReader("trainers.txt");
            string line = inFile.ReadLine();

                while(line != null){
                    string[] temp = line.Split("#");
                    trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4]);
                    Trainer.IncreaseCount();
                    line = inFile.ReadLine();
                }

            inFile.Close();
        }

        public void PrintAllTrainers(){
            int j = 1;
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            CategoryHeader();

            for(int i = 0; i < Trainer.GetCount(); i++){
                Console.SetCursorPosition(0, j);
                System.Console.WriteLine(trainers[i].GetID());

                Console.SetCursorPosition(5, j);
                System.Console.WriteLine(trainers[i].GetName());

                Console.SetCursorPosition(27, j);
                System.Console.WriteLine(trainers[i].GetAdd());

                Console.SetCursorPosition(45, j);
                System.Console.WriteLine(trainers[i].GetEmail());

                Console.SetCursorPosition(75, j);
                System.Console.WriteLine(trainers[i].GetStatus());

                j++;
            }
            Console.ResetColor();

            System.Console.WriteLine(); //Just for space between the menu
        }


        //Now build your add, edit, and delete methods
        //Need to build a method for developing your trainer IDs - worry about it later


        public void AddTrainer(){
            Console.Clear();

            Trainer myTrainer = new Trainer();

            myTrainer.SetID(Trainer.GetCount() + 1);

            Console.Clear();
            
            System.Console.WriteLine("Please Enter Trainer Name:");
            myTrainer.SetName(Console.ReadLine());

            Console.Clear();

            System.Console.WriteLine("Please Enter Trainer Address:");
            myTrainer.SetAdd(Console.ReadLine());

            Console.Clear();

            System.Console.WriteLine("Please Enter Trainer Email:");
            myTrainer.SetEmail(Console.ReadLine());

            myTrainer.SetStatus("Current");

            trainers[Trainer.GetCount()] = myTrainer;
            Trainer.IncreaseCount();

        }

        public void EditTrainer(){
            //Create search method that will search trainers by their ID
            //Search method will return found index (trainer[i])
            //Give option to select name, address, or email
            //Change the setter of that menu option to the user's selection - Call it on the end of the trainer that was found (trainer[i].SetName())

            Console.Clear();
            PrintAllTrainers();

            System.Console.WriteLine("Please input the Trainer ID of the Trainer you would like to edit:");
            int idInput = int.Parse(Console.ReadLine());

            int foundID = SearchID(idInput);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(trainers[foundID].ToString());
            Console.ResetColor();

            System.Console.WriteLine(); //For space between trainer and menu

            System.Console.WriteLine("Which element would you like to edit?");
            System.Console.WriteLine();
            System.Console.WriteLine("(1) Trainer Name \n(2) Trainer Address \n(3) Trainer Email \n(4) Return to Main Menu");

            userInput = Console.ReadLine();

            if(userInput == "1"){
                SelectedTrainer(foundID);
                System.Console.WriteLine("Please Enter New Name:");
                trainers[foundID].SetName(Console.ReadLine());
            }
            else if(userInput == "2"){
                SelectedTrainer(foundID);
                System.Console.WriteLine("Please Enter New Address:");
                trainers[foundID].SetAdd(Console.ReadLine());
            }
            else if(userInput == "3"){
                SelectedTrainer(foundID);
                System.Console.WriteLine("Please Enter New Email:");
                trainers[foundID].SetEmail(Console.ReadLine());
            }
            else{
                return;
            }
            
            //HELL YEAH IT WORKS GOOD JOB

        }

        public void DeleteTrainer(){
            //Search method
            //Find trainer you want to delete
            //Soft delete = have field that can be toggled from deleted and current employee
            //Hard delete = difficult, go with soft delete LOL (new array, overwrite your trainers array, decrease count)

            Console.Clear();
            PrintAllTrainers();


            System.Console.WriteLine("Please input the Trainer ID of the Trainer you would like to delete:");
            int idInput = int.Parse(Console.ReadLine());
            int foundID = SearchID(idInput);

            Console.Clear();
            System.Console.Write($"Are you sure you want to delete");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write($" {trainers[foundID].GetName()}?");
            Console.ResetColor();

            System.Console.WriteLine();
            System.Console.WriteLine("(1) Yes \n(2) No");
            userInput = Console.ReadLine();

            if(userInput == "1"){
                trainers[foundID].SetStatus("Deleted");
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
            System.Console.WriteLine("Address");

            Console.SetCursorPosition(45, 0);
            System.Console.WriteLine("Email:");

            Console.SetCursorPosition(75, 0);
            System.Console.WriteLine("Status:");

        }

        public void Save(){
            StreamWriter outFile = new StreamWriter("trainers.txt");
            
            for(int i = 0; i < Trainer.GetCount(); i++){
            outFile.WriteLine(trainers[i].ToFile());
            }

            outFile.Close();
        }       

        public int SearchID(int idInput){
            int min = 0;
            int max = Trainer.GetCount();

            while(min <= max){
                int mid = (min + max) / 2;

                if(idInput == trainers[mid].GetID()){
                    return mid;
                }
                else if(idInput < trainers[mid].GetID()){
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
            System.Console.WriteLine(trainers[foundID].ToString());
            Console.ResetColor();
        }
    }
}