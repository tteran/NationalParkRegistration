using Capstone.DAL;
using Capstone.Models;
using ProjectOrganizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenuCLI
    {
        private IParkDAO parkDAO;
        private ICampGroundDAO campGroundDAO;
        private ICampSiteDAO campSiteDAO;
        private IReservationDAO reservationDAO;

        private int parkId;

        public MainMenuCLI(IParkDAO parkDAO, ICampGroundDAO campGroundDAO, ICampSiteDAO campSiteDAO, IReservationDAO reservationDAO)
        {
            this.parkDAO = parkDAO;
            this.campGroundDAO = campGroundDAO;
            this.campSiteDAO = campSiteDAO;
            this.reservationDAO = reservationDAO;
        }

        public void RunMenuCLI()
        {
            PrintHeader();
            Menu();

            while (true)
            {
                const string Command_ListAvailableParks = "1";
                const string Command_Quit = "Q";

                string command = Console.ReadLine();

                Console.Clear();

                switch (command.ToLower())
                {
                    case Command_ListAvailableParks:
                        ListAvailableParks();
                        GetParkDetail();
                        break;

                    case Command_Quit:
                        Console.WriteLine("Thank you for using the park registry program.");
                        return;
                        //TODO - Fix quit.

                    default:
                        Console.WriteLine("The command provided was not a valid command, please try again.");
                        break;
                }


            }
        }

        private void ListAvailableParks()
        {
            IList<Park> parks = parkDAO.ListAvailableParks();

            Console.WriteLine();
            Console.WriteLine("Printing all parks in the registry");

            foreach (Park park in parks)
            {
                Console.WriteLine($"({park.ParkId.ToString()}) - {park.Name.PadLeft(5)}");
            }

        }

        public void ParkDetailsRun()
        {
            while (true)
            {
                string command = Console.ReadLine();

                const string Command_ListArcadia = "1";
                const string Command_ListArches = "2";
                const string Command_ListCuyahoga = "3";
                const string Command_Quit = "Q";

                switch (command.ToLower())
                {
                    case Command_ListArcadia:
                        GetParkDetail();
                        break;

                    case Command_ListArches:
                        GetParkDetail();
                        break;

                    case Command_ListCuyahoga:
                        GetParkDetail();
                        break;

                    case Command_Quit:
                        Console.WriteLine("Thanks for using park registry program.");
                        return;
                        //TODO - Fix quit.

                    default:
                        Console.WriteLine("The command provided was not valid. Try again loser.");
                        break;
                }
            }
        }

        private void GetParkDetail()
        {
            this.parkId = CLIHelper.GetInteger("Please choose a park for more details: ");
            IList<Park> parks = parkDAO.GetParkDetail(this.parkId);

            Console.Clear();

            foreach (Park detail in parks)
            {
                Console.WriteLine($"{detail.Name} National Park");
                Console.WriteLine($"Location: {detail.Location}");
                Console.WriteLine($"Established: {detail.EstablishDate}");
                Console.WriteLine($"Area: {detail.Area}");
                Console.WriteLine($"Annual Visitors: {detail.Visitors}");
                Console.WriteLine();
                Console.WriteLine($"{detail.Description}");
                Console.WriteLine();
                Console.WriteLine();

                CampgroundCommandMenu();
            }
        }

        private void CampgroundCommandMenu()
        {
            Console.WriteLine("Select a Command");
            Console.WriteLine("(1) - View Campgrounds");
            Console.WriteLine("(2) - Search for Reservation");
            Console.WriteLine("(3) - Return to Previous Screen");
            string choice = Console.ReadLine();

            switch(choice.ToString())
            {
                case ("1"):
                    ViewCampground();
                    break;

                case ("2"):
                    //SearchForReservation();
                    break;

                case ("3"):
                    Menu();
                    break;

                default:
                    Console.WriteLine("Invalid entry. Please try again.");
                    CampgroundCommandMenu();
                    break;               
            }
        }

        private void ViewCampground()
        {
            IList<CampGround> campGrounds = campGroundDAO.ViewCampground(this.parkId);
            
            Console.WriteLine("             Name         Open            Close           Daily Fee");
            Console.WriteLine();

            foreach (CampGround camp in campGrounds)
            {
                Console.WriteLine($"{camp.CampgroundId}\t{camp.Name}\t{new DateTime(2001, camp.OpenFrom, 1).ToString("MMMM")}\t\t{new DateTime(2001, camp.OpenTo, 1).ToString("MMMM")}\t\t{camp.DailyFee:C2}");
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine(@"                       __,--'\");
            Console.WriteLine(@"                 __,--'    :. \.");
            Console.WriteLine(@"            _,--'              \`.");
            Console.WriteLine(@"          / | \        `:        \  `/");
            Console.WriteLine(@"         / '|  \        `:.       \ ");
            Console.WriteLine(@"        / , |   \                  \           ");
            Console.WriteLine(@"       /    |:   \              `:. \              ");
            Console.WriteLine(@"      /| '  |     \ :.           _,-'`.");
            Console.WriteLine(@"    \' |,  / \   ` \ `:.     _,-'_|    `/");
            Console.WriteLine(@"       '._;   \ .   \   `_,-'_,-'");
            Console.WriteLine(@"     \'    `- .\_   |\,-'_,-'");
            Console.WriteLine(@"                 `--|_,`'");
            Console.WriteLine(@"                         `/");
            Console.WriteLine("WELCOME TO USA Camp Registry!!!");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void Menu()
        {
            Console.WriteLine("(1) - Show list of all PARKS.");
            Console.WriteLine("(Q) - QUIT");
        }
    }
}
