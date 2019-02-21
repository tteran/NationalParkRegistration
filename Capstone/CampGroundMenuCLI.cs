using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class CampGroundMenuCLI
    {

        public void RunMenuCLI()
        {
            PrintHeader();
            Menu();
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
            Console.WriteLine("");
        }

        public void Menu()
        {

        }
    }

}
