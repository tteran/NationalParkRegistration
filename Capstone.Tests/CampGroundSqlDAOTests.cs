using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class CampGroundSqlDAOTests : CapstoneDAOTests
    {
        [TestMethod]
        public void ViewCampgrounds_ShouldReturnAllCampgrounds()
        {
            CampGroundSqlDAO dao = new CampGroundSqlDAO(ConnectionString);
            IList<CampGround> campGrounds = dao.ViewCampgrounds(ParkId);
            Assert.AreEqual(1, campGrounds.Count);
        }

        [TestMethod]
        public void ViewCampground_ShouldReturn1Campground()
        {
            CampGroundSqlDAO dao = new CampGroundSqlDAO(ConnectionString);
            CampGround camp = dao.ViewCampground(CampgroundId);
            Assert.AreEqual(1, camp);
        }
    }
}
