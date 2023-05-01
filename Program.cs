//PA 5
using mis_221_pa_5_resmith16;

string menuChoice = GetMenuChoice();
string userInput = "";

Trainer[] trainers = new Trainer[100];
Listing[] listings = new Listing[100];
Booking[] bookings = new Booking[100];

//Menu
while (menuChoice != "5")
{
    Route(menuChoice, userInput, trainers, listings, bookings);
    menuChoice = GetMenuChoice();
}

static string GetMenuChoice(){
    DisplayMenu();
    string menuChoice = Console.ReadLine();

    while (!ValidMenuChoice(menuChoice))
    {
        SayInvalid();

        DisplayMenu();
        menuChoice = Console.ReadLine();
    }

    return menuChoice;
}

static void DisplayMenu(){
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    System.Console.WriteLine(@"
   ________                          _                _______ __                      
  / ____/ /_  ____ _____ ___  ____  (_)___  ____     / ____(_) /_____  ___  __________
 / /   / __ \/ __ `/ __ `__ \/ __ \/ / __ \/ __ \   / /_  / / __/ __ \/ _ \/ ___/ ___/
/ /___/ / / / /_/ / / / / / / /_/ / / /_/ / / / /  / __/ / / /_/ / / /  __(__  |__  ) 
\____/_/ /_/\__,_/_/ /_/ /_/ .___/_/\____/_/ /_/  /_/   /_/\__/_/ /_/\___/____/____/  
                          /_/                                                         
");
    Console.ResetColor();
    System.Console.WriteLine("(1) Trainer Data \n(2) Listing Data \n(3) Booking Data \n(4) Run Reports \n(5) Exit");
}

static bool ValidMenuChoice(string menuChoice){
    if(menuChoice == "1" || menuChoice == "2" || menuChoice == "3" || menuChoice == "4" || menuChoice == "5") {
        return true;
    }
    else return false;

}

static void Route(string menuChoice, string userInput, Trainer[] trainers, Listing[] listings, Booking[] bookings){
    if(menuChoice == "1"){
        TrainerData(trainers);
    }
    else if(menuChoice == "2"){
        ListingData(listings, trainers);
    }
    else if(menuChoice == "3"){
        BookingData(listings, trainers, bookings);
    }
    else if(menuChoice == "4"){
        RunReports(trainers, listings, bookings);
    }
    else if(menuChoice != "5"){
        SayInvalid();
    }
}

static void TrainerData(Trainer[] trainers){
    TrainerUtility utility = new TrainerUtility(trainers);
    
    utility.ReadAllTrainers();
    utility.PrintAllTrainers();

    System.Console.WriteLine("(1) Add Trainer \n(2) Edit Trainer \n(3) Delete Trainer \n(4) Return to Main Menu");
    string userInput = Console.ReadLine();

    if(userInput == "1"){
        utility.AddTrainer();
    }
    else if(userInput == "2"){
        utility.EditTrainer();
    }
    else if(userInput == "3"){
        utility.DeleteTrainer();
    }
    else{
        return;
    }

    utility.Save();
}


static void ListingData(Listing[] listings, Trainer[] trainers){
    ListingUtility utility = new ListingUtility(listings, trainers);
    
    utility.ReadAllListings();
    utility.ReadAllTrainers();
    utility.PrintCurrentListings();

    System.Console.WriteLine("(1) Add Listing \n(2) Edit Listing \n(3) Delete Listing \n(4) Return to Main Menu");
    string userInput = Console.ReadLine();

    if(userInput == "1"){
        utility.AddListing();
    }
    else if(userInput == "2"){
        utility.EditListing();
    }
    else if(userInput == "3"){
        utility.DeleteListing();
    }
    else{
        return;
    }

    utility.Save();
}

static void BookingData(Listing[] listings, Trainer[] trainers, Booking[] bookings){
    BookingUtility utility = new BookingUtility(listings, trainers, bookings);
    
    utility.ReadAllListings();
    utility.PrintAvailableListings();

    System.Console.WriteLine("(1) Book Session\n(2) Complete Session \n(3) Cancel Session \n(4) Return to Main Menu");
    string userInput = Console.ReadLine();

    if(userInput == "1"){
        utility.BookSession();
    }
    if(userInput == "2"){
        utility.CompleteSession();
    }
    if(userInput == "3"){
        utility.CancelSession();
    }
    if(userInput == "4"){
        return;
    }

    utility.Save();
    
}

static void RunReports(Trainer[] trainers, Listing[] listings, Booking[] bookings){
    ReportingUtility utility = new ReportingUtility(trainers, listings, bookings);

    Console.Clear();

    utility.ReadAllBookings();
    utility.PrintAllBookings();

    System.Console.WriteLine("(1) View Individual Customer Sessions \n(2) View Historical Customer Sessions \n(3) View Historical Revenue Report \n(4) Return to Main Menu");
    string userInput = Console.ReadLine();
    
    if(userInput == "1"){
        utility.IndividualCustomerReport();
    }
    if(userInput == "2"){
        utility.HistoricalCustomerSessions();
    }
    if(userInput == "3"){
        utility.HistoricalRevenueReport();
    }
    if(userInput == "4"){
        return;
    }
}

static void SayInvalid(){
    System.Console.WriteLine("Invalid!");
    Thread.Sleep(400);
    Console.Clear();
}