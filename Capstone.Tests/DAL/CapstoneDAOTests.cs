using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Transactions;

namespace Capstone.Tests
{
    [TestClass]
    public class CapstoneDAOTests
    {
        /// <summary>
        /// The transaction for each test.
        /// </summary>
        private TransactionScope transaction;

        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=npcampground;Trusted_Connection=True;";
        
        /// <summary>
        /// Holds newly generated park ID
        /// </summary>
        protected int ParkId { get; private set; }

        /// <summary>
        /// Holds newly generated campground ID
        /// </summary>
        protected int CampgroundId { get; private set; }

        /// <summary>
        /// Holds newly generated site ID
        /// </summary>
        protected int SiteId { get; private set; }

        /// <summary>
        /// Holds newly generated resevation ID
        /// </summary>
        protected int ReservationId { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            // Begin the transaction
            transaction = new TransactionScope();

            // Get the SQL Script to run
            string sql = File.ReadAllText("test-script.sql");

            // Execute the script
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    this.ParkId = Convert.ToInt32(reader["newParkId"]);
                    this.CampgroundId = Convert.ToInt32(reader["newCampgroundId"]);
                    this.SiteId = Convert.ToInt32(reader["newSiteId"]);
                    this.ReservationId = Convert.ToInt32(reader["newReservationId"]);
                }
            }          
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            // Rollback the transaction.
            transaction.Dispose();
        }

        /// <summary>
        /// Gets the row count for a table.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }
    }
}
