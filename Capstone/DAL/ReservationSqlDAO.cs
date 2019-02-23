using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ReservationSqlDAO : IReservationDAO
    {
        private string connectionString;

        private string SQL_CreateReservation = @"INSERT INTO reservation (site_id, name, from_date, to_date) 
                                                VALUES(@siteIdChoice, @reservationName, @arrivalDate, @departureDate);";

        public ReservationSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Creates the reservation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public int CreateReservation(Reservation reservation)
        {
            int reservationId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CreateReservation, conn);
                    cmd.Parameters.AddWithValue("@siteIdChoice", reservation.SiteId);
                    cmd.Parameters.AddWithValue("@reservationName", reservation.Name);
                    cmd.Parameters.AddWithValue("@arrivalDate", reservation.FromDate);
                    cmd.Parameters.AddWithValue("@departureDate", reservation.ToDate);

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT MAX(reservation_id) FROM reservation;", conn);

                    reservationId = Convert.ToInt32(cmd.ExecuteScalar());

                    Console.WriteLine($"The reservation has been made and the confirmation ID is {reservationId}");
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error creating the reservation");
                Console.WriteLine(ex.Message);
                throw;
            }

            return reservationId;

        }
    }
}
