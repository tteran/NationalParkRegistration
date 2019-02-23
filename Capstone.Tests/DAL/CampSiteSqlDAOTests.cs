using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class CampSiteSqlDAOTests : CapstoneDAOTests
    {
        [TestMethod]
        public void SearchReservationRun_ReturnsListOfCampsites()
        {
            var arrival = new DateTime(2019, 02, 01);
            var departure = new DateTime(2019, 02, 08);

            CampSiteSqlDAO dao = new CampSiteSqlDAO(ConnectionString);
            IList<CampSite> campSites = dao.SearchReservationRun(CampgroundId, arrival, departure);
            Assert.AreEqual(1, campSites.Count);
        }

        [TestMethod]
        public void SearchReservationRun_SameDates_ReturnsNoList()
        {
            var arrival = new DateTime(2019, 07, 16);
            var departure = new DateTime(2019, 07, 19);

            CampSiteSqlDAO dao = new CampSiteSqlDAO(ConnectionString);
            IList<CampSite> campSites = dao.SearchReservationRun(CampgroundId, arrival, departure);
            Assert.AreEqual(0, campSites.Count);
        }

        [TestMethod]
        public void SearchReservationRun_DatesThatFallOutside_ReturnsNoList()
        {
            var arrival = new DateTime(2019, 07, 19);
            var departure = new DateTime(2019, 07, 27);

            CampSiteSqlDAO dao = new CampSiteSqlDAO(ConnectionString);
            IList<CampSite> campSites = dao.SearchReservationRun(CampgroundId, arrival, departure);
            Assert.AreEqual(0, campSites.Count);
        }
    }
}
