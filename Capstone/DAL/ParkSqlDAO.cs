using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString;

        private string SQL_ParkDetail = "SELECT * FROM park WHERE park_id = @park_id;";

        public ParkSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Park> ListAvailableParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM park;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Park prk = ConvertReaderToPark(reader);
                        parks.Add(prk);
                    }

                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error listing all the parks");
                Console.WriteLine(ex.Message);
                throw;
            }

            return parks;

        }

        public IList<Park> GetParkDetail(int parkId)
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_ParkDetail, conn);
                    cmd.Parameters.AddWithValue("@park_id", parkId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Park prk = ConvertReaderToPark(reader);
                        parks.Add(prk);
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error reading the database");
                Console.WriteLine(ex.Message);
                throw;
            }

            return parks;
        }


        public IList<Park> ListArcadia()
        {
            List<Park> arcadiaDetails = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE park_id = 1;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park prk = ConvertReaderToPark(reader);
                        arcadiaDetails.Add(prk);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error listing information about Arcadia.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return arcadiaDetails;

        }

        private Park ConvertReaderToPark(SqlDataReader reader)
        {
            Park park = new Park();
            park.ParkId = Convert.ToInt32(reader["park_id"]);
            park.Name = Convert.ToString(reader["name"]);
            park.Location = Convert.ToString(reader["location"]);
            park.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
            park.Area = Convert.ToInt32(reader["area"]);
            park.Visitors = Convert.ToInt32(reader["visitors"]);
            park.Description = Convert.ToString(reader["description"]);

            return park;
        }
    }
}
