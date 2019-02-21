using Capstone.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
//using ProjectOrganizer.DAL;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("Project");

            IParkDAO parkDAO = new ParkSqlDAO(connectionString);
            ICampGroundDAO campGroundDAO = new CampGroundSqlDAO(connectionString);
            ICampSiteDAO campSiteDAO = new CampSiteSqlDAO(connectionString);
            IReservationDAO reservationDAO = new ReservationSqlDAO(connectionString);

            CampGroundMenuCLI camp = new CampGroundMenuCLI(parkDAO, campGroundDAO, campSiteDAO, reservationDAO);
            camp.RunMenuCLI();
        }
    }
}
