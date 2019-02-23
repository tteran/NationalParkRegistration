using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationSqlDAOTests : CapstoneDAOTests
    {
        [TestMethod]
        public void CreateReservationsTest_should_IncreaseCountBy1()
        {
            ReservationSqlDAO dao = new ReservationSqlDAO(ConnectionString);
            int initalRowCount = GetRowCount("reservation");

            Reservation res = new Reservation()
            {
                SiteId = SiteId,
                Name = "C Sharp Reunion",
                FromDate = Convert.ToDateTime("08-15-2019"),
                ToDate = Convert.ToDateTime("08-20-2019")
            };

            dao.CreateReservation(res);

            int finalRowCount = GetRowCount("reservation");
            Assert.AreEqual(initalRowCount + 1, finalRowCount);

        }
        
        
    }
}
