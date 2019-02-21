//using Capstone.DAL;
//using Capstone.Models;
//using ProjectOrganizer;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Capstone
//{
//    public class ParkDetailMenu
//    {
//        private IParkDAO parkDAO;

//        public ParkDetailMenu(IParkDAO parkDAO)
//        {
//            this.parkDAO = parkDAO;
//        }

//        public ParkDetailMenu()
//        {
//        }

//        const string Command_ListArcadia = "1";
//        const string Command_Quit = "Q";
  
//        public void Run()
//        {
//            while(true)
//            {
//                string command = Console.ReadLine();

//                Console.Clear();

//                switch(command.ToLower())
//                {
//                    case Command_ListArcadia:
//                        ListArcadia();
//                        break;

//                    case Command_Quit:
//                        Console.WriteLine("Thanks for using park registry program.");
//                        return;

//                    default:
//                        Console.WriteLine("The command provided was not valid. Try again loser.");
//                        break;
//                }
//            }

//            ////Console.WriteLine("Please choose a park for more details or Q for quit.");
//            //string parkId = CLIHelper.GetString("Choose a park for more details.");
//            //string quitButton = CLIHelper.GetString("QUIT");

//            //while (true)
//            //{
//            //    if (parkId == "1")
//            //    {
//            //        ListDetailsAboutArcadia();
//            //    }
//            //    if (parkId == "2")
//            //    {

//            //    }
//            //    if (parkId == "3")
//            //    {

//            //    }      
//            //}
//        }
        

//        private void ListArcadia()
//        {
//            IList<Park> arcadia = parkDAO.ListArcadia();

//            foreach (Park arcadiaDeets in arcadia)
//            {
//                Console.WriteLine($"{arcadiaDeets.Name}\n{arcadiaDeets.Location}\n{arcadiaDeets.EstablishDate}\n{arcadiaDeets.Area}\n{arcadiaDeets.Visitors}\n{arcadiaDeets.Description}");
//            }
//        }
//    }
//}
