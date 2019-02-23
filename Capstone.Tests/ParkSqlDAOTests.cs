using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class ParkSqlDAOTests : CapstoneDAOTests
    {
        [TestMethod]
        public void ListAvailableParksShouldReturn_AllListedParks()
        {
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            IList<Park> parks = dao.ListAvailableParks();
            Assert.AreEqual(1, parks.Count);
        }

        [TestMethod]
        public void SelectedPark_ReturnsDetails()
        {
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            IList<Park> parks = dao.GetParkDetail(ParkId);
            Assert.AreEqual(1, parks.Count);
        }
    }
}
