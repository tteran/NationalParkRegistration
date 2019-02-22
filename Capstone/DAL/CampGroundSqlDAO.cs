using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class CampGroundSqlDAO : ICampGroundDAO
    {
        private string connectionString;

        private string SQL_ViewCampgrounds = "SELECT * FROM campground WHERE park_id = @park_id;";
        private string SQL_ViewCampground = "SELECT * FROM campground WHERE campground_id = @campground_id;";
        public CampGroundSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<CampGround> ViewCampgrounds(int parkId)
        {
            List<CampGround> campGrounds = new List<CampGround>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_ViewCampgrounds, conn);
                    cmd.Parameters.AddWithValue("@park_id", parkId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        CampGround camp = ConvertReaderToCampground(reader);
                        campGrounds.Add(camp);
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Could not load campgrounds.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return campGrounds;
        }
        public CampGround ViewCampground(int campGroundId)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_ViewCampground, conn);
                    cmd.Parameters.AddWithValue("@campground_id", campGroundId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        CampGround camp = ConvertReaderToCampground(reader);
                        return camp;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Could not load campgrounds.");
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private CampGround ConvertReaderToCampground(SqlDataReader reader)
        {
            CampGround camp = new CampGround();

            camp.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            camp.ParkId = Convert.ToInt32(reader["park_id"]);
            camp.Name = Convert.ToString(reader["name"]);
            camp.OpenFrom = Convert.ToInt32(reader["open_from_mm"]);
            camp.OpenTo = Convert.ToInt32(reader["open_to_mm"]);
            camp.DailyFee = Convert.ToDecimal(reader["daily_fee"]);

            return camp;
        }
    }
}
