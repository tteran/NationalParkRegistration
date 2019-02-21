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
        const string Command_ListAvailableParks = "1";
        const string Command_ListArcadia = "1";
        const string Command_ListArches = "2";
        const string Command_ListCuyahoga = "3";
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
                        break;

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
    
            ParkDetailsRun();
        }

        public void ParkDetailsRun()
        {
            while (true)
            {
                string command = Console.ReadLine();
                
                //Console.Clear();

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

                    default:
                        Console.WriteLine("The command provided was not valid. Try again loser.");
                        break;
                }
            }
        }


        private void GetParkDetail()
        {
            int parkId = CLIHelper.GetInteger("Please choose a park for more details: ");
            IList<Park> parks = parkDAO.GetParkDetail(parkId);

            foreach (Park detail in parks)
            {
               Console.WriteLine($"{detail.Name} National Park");
               Console.WriteLine($"Location: {detail.Location}");
               Console.WriteLine($"Established: {detail.EstablishDate}");
               Console.WriteLine($"Area: {detail.Area}");
               Console.WriteLine($"Annual Visitors: {detail.Visitors}");
               Console.WriteLine();
               Console.WriteLine($"{detail.Description}");
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
