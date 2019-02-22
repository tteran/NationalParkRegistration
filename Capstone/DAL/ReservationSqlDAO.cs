using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ReservationSqlDAO : IReservationDAO
    {
        private string connectionString;

        private string SQL_CreateReservation = @"INSERT INTO reservation (site_id, name, from_date, to_date, create_date) 
                                                VALUES(@siteIdChoice, @reservationName, @arrivalDate, @departureDate);";

        public ReservationSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int CreateReservation(Reservation reservation, DateTime arrivalDate, DateTime departureDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CreateReservation, conn);
                    cmd.Parameters.AddWithValue
                }
            }

            catch (SqlException ex)
            {

            }



        }
    }
}
