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
        IList<CampSite> ListOfSites(int campgroundId);
    }
}
