using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface ICampSiteDAO
    {
        /// <summary>
        /// List of sites.
        /// </summary>
        /// <returns></returns>
        IList<CampSite> SearchReservationRun(int campgroundId, DateTime arrivalDate, DateTime departureDate);
    }
}
