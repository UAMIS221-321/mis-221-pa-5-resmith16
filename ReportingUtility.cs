namespace mis_221_pa_5_resmith16
{
    public class ReportingUtility
    {
        private Trainer[] trainers;
        private Listing[] listings;
        private Booking[] bookings;

        public ReportingUtility(Trainer[] trainers, Listing[] listings, Booking[] bookings){
            this.trainers = trainers;
            this.listings = listings;
            this.bookings = bookings;
        }

        public void ReadAllBookings(){
            Booking.SetCount(0);

            StreamReader inFile = new StreamReader("transactions.txt");
            string line = inFile.ReadLine();

                while(line != null){
                    string[] temp = line.Split("#");
                    bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), int.Parse(temp[5]), temp[6], temp[7
                    ]);
                    Booking.IncreaseCount();
                    line = inFile.ReadLine();
                }

            inFile.Close();
        }

        public void PrintAllBookings(){
            int j = 1;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            CategoryHeader();

            for(int i = 0; i < Booking.GetCount(); i++){
                if(bookings[i].GetStatus() != "Available"){
                    Console.SetCursorPosition(0, j);
                    System.Console.WriteLine(bookings[i].GetCustID());

                    Console.SetCursorPosition(8, j);
                    System.Console.WriteLine(bookings[i].GetCustName());

                    Console.SetCursorPosition(27, j);
                    System.Console.WriteLine(bookings[i].GetCustEmail());

                    Console.SetCursorPosition(55, j);
                    System.Console.WriteLine(bookings[i].GetTrainerName());

                    Console.SetCursorPosition(73, j);
                    System.Console.WriteLine(bookings[i].GetTrainerID());

                    Console.SetCursorPosition(80, j);
                    System.Console.WriteLine(bookings[i].GetStatus());

                    j++;
                }
                else{
                    
                }
            }
            Console.ResetColor();

            System.Console.WriteLine();
        }

        public void IndividualCustomerReport(){
            int i = 0;
            int j = 1;
            
            Console.Clear();

            System.Console.WriteLine("Please Enter the Email of the Customer You'd Like to View:");
            string inputEmail = Console.ReadLine();

            Console.Clear();

            System.Console.WriteLine($"Individual Customer Report for {bookings[i].GetCustName()}");
            System.Console.WriteLine(); //Spacing

            for(i = 0; i < Booking.GetCount(); i++){
                if(inputEmail == bookings[i].GetCustEmail()){
                    Console.SetCursorPosition(0, j);
                    System.Console.WriteLine(bookings[i].GetCustID());

                    Console.SetCursorPosition(5, j);
                    System.Console.WriteLine(bookings[i].GetCustEmail());

                    Console.SetCursorPosition(27, j);
                    System.Console.WriteLine(bookings[i].GetDate());

                    Console.SetCursorPosition(45, j);
                    System.Console.WriteLine(bookings[i].GetCost());

                    Console.SetCursorPosition(65, j);
                    System.Console.WriteLine(bookings[i].GetTrainerID());

                    Console.SetCursorPosition(70, j);
                    System.Console.WriteLine(bookings[i].GetTrainerName());

                    Console.SetCursorPosition(80, j);
                    System.Console.WriteLine(bookings[i].GetTrainerID());

                    Console.SetCursorPosition(85, j);
                    System.Console.WriteLine(bookings[i].GetStatus());

                    j++;
                }
                else{

                }
                
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Where would you like to save this report?");
            string fileDestination = Console.ReadLine();

            SaveIndividualReport(fileDestination, inputEmail);
        }

        public void HistoricalCustomerSessions(){
            Console.Clear();
            System.Console.WriteLine("Sorry, but this is incomplete. My apologies. -Rachel");
            System.Console.WriteLine();
            System.Console.WriteLine("Press Enter to Return to Main Menu");
            Console.ReadKey();
        }

        public void HistoricalRevenueReport(){
            Console.Clear();
            System.Console.WriteLine("Sorry, but this is incomplete. My apologies. -Rachel");
            System.Console.WriteLine();
            System.Console.WriteLine("Press Enter to Return to Main Menu");
            Console.ReadKey();
        }

        public void CategoryHeader(){
            Console.SetCursorPosition(0, 0);
            System.Console.WriteLine("C_ID:");

            Console.SetCursorPosition(8, 0);
            System.Console.WriteLine("Customer Name:");

            Console.SetCursorPosition(27, 0);
            System.Console.WriteLine("Customer Email:");

            Console.SetCursorPosition(55, 0);
            System.Console.WriteLine("Trainer Name:");

            Console.SetCursorPosition(73, 0);
            System.Console.WriteLine("T_ID:");

            Console.SetCursorPosition(80, 0);
            System.Console.WriteLine("Status:");

        }

        public void SortByCustomer(Booking[] bookings){
            //Incomplete
        }

        public void SortByDate(Booking[] bookings){
            //Incomplete
        }

        public void SaveIndividualReport(string fileDestination, string inputEmail){
            StreamWriter outFile = new StreamWriter($"{fileDestination}.txt");
            System.Console.WriteLine(Booking.GetCount());
            
            for(int i = 0; i < Booking.GetCount(); i++){
                if(inputEmail == bookings[i].GetCustEmail()){
                    outFile.WriteLine(bookings[i].ToFile());
                }
            }

            outFile.Close();
        }  
    }
}