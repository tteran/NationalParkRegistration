using ProjectOrganizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class ParkDetailMenu
    {
        public void Run()
        {
            //Console.WriteLine("Please choose a park for more details or Q for quit.");
            int parkId = CLIHelper.GetInteger("Choose a park for more details.");
            string quitButton = CLIHelper.GetString("QUIT");

            while (true)
            {
                if (parkId == 1)
                {

                }
                if (parkId == 2)
                {

                }
                if (parkId == 3)
                {

                }

                else
                {
                    MainMenuCLI main = new MainMenuCLI();
                    main.RunMenuCLI();

                }
            }

        }

    }
}
