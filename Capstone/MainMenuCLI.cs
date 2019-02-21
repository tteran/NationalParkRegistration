using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenuCLI
    {
        const string Command_ListAvailableParks = "1";
        const string Command_ListArcadia = "1";
        const string Command_Quit = "Q";

        private IParkDAO parkDAO;
        private ICampGroundDAO campGroundDAO;
        private ICampSiteDAO campSiteDAO;
        private IReservationDAO reservationDAO;

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

            while(true)
            {
                string command = Console.ReadLine();

                Console.Clear();

                switch (command.ToLower())
                {
                    case Command_ListAvailableParks:
                        ListAvailableParks();
                        break;

                    case Command_Quit:
                        Console.WriteLine("Thank you for using the park registry program.");
                        return;

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

            foreach(Park park in parks)
            {
                Console.WriteLine($"({park.ParkId.ToString()}) - {park.Name.PadLeft(5)}");
            }
            Console.WriteLine("(Q) - QUIT");
            //ParkDetailMenu parkdetail = new ParkDetailMenu();
            //parkdetail.Run();   

            ParkDetailsRun();
        }

        public void ParkDetailsRun()
        {
            while (true)
            {
                string command = Console.ReadLine();

                Console.Clear();

                switch (command.ToLower())
                {
                    case Command_ListArcadia:
                        ListArcadia();
                        break;

                    case Command_Quit:
                        Console.WriteLine("Thanks for using park registry program.");
                        return;

                    default:
                        Console.WriteLine("The command provided was not valid. Try again loser.");
                        break;
                }
            }
        }

        private void ListArcadia()
        {

            IList<Park> arcadia = parkDAO.ListArcadia();

            foreach (Park arcadiaDeets in arcadia)
            {
               Console.WriteLine($"{arcadiaDeets.Name} National Park");
               Console.WriteLine($"Location: {arcadiaDeets.Location}");
               Console.WriteLine($"Established: {arcadiaDeets.EstablishDate}");
               Console.WriteLine($"Area: {arcadiaDeets.Area}");
               Console.WriteLine($"Annual Visitors: {arcadiaDeets.Visitors}");
               Console.WriteLine();
               Console.WriteLine($"{arcadiaDeets.Description}");
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
