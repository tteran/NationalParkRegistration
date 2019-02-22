using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class CampSiteSqlDAO : ICampSiteDAO
    {
        private string connectionString;
        private string SQL_ListOfSites = @"SELECT TOP 5 * FROM site
                                            WHERE site.campground_id = @campgroundId
                                            AND site.site_id NOT IN (SELECT site_id	
					                        FROM reservation			
					                        WHERE from_date < @departureDate AND to_date > @arrivalDate);";

        public CampSiteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<CampSite> SearchReservationRun(int campgroundId, DateTime arrivalDate, DateTime departureDate)
        {
            List<CampSite> sites = new List<CampSite>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_ListOfSites, conn);
                    cmd.Parameters.AddWithValue("@campgroundId", campgroundId);
                    cmd.Parameters.AddWithValue("@arrivalDate", arrivalDate);
                    cmd.Parameters.AddWithValue("@departureDate", departureDate);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CampSite site = ConvertReaderToSite(reader);
                        sites.Add(site);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error listing all the parks");
                Console.WriteLine(ex.Message);
                throw;
            }

            return sites;
        }

        public IList<CampSite> ListOfSites()
        {
            throw new NotImplementedException();
        }

        private CampSite ConvertReaderToSite(SqlDataReader reader)
        {
            CampSite campSite = new CampSite();

            campSite.SiteId = Convert.ToInt32(reader["site_id"]);
            campSite.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            campSite.SiteNumber = Convert.ToInt32(reader["site_number"]);
            campSite.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
            campSite.IsAccessible = Convert.ToInt32(reader["accessible"]);
            campSite.MaxRvLength = Convert.ToInt32(reader["max_rv_length"]);
            campSite.HasUtilties = Convert.ToInt32(reader["utilities"]);

            return campSite;
        }
    }
}
