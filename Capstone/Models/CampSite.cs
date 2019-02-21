using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class CampSite
    {
        /// <summary>
        /// Gets the site ID (PK).
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Gets the campground ID (FK).
        /// </summary>
        public int CampgroundId { get; set; }

        /// <summary>
        /// Gets the site number.
        /// </summary>
        public int SiteNumber { get; set; }

        /// <summary>
        /// Gets the max occupancy.
        /// </summary>
        public int MaxOccupancy { get; set; }

        /// <summary>
        /// Gets if the park is accessible for handicap.
        /// </summary>
        public bool IsAccessible { get; set; }

        /// <summary>
        /// Gets the max rv length.
        /// </summary>
        public int MaxRvLength { get; set; }

        /// <summary>
        /// Gets if the site has utilities.
        /// </summary>
        public bool HasUtilties { get; set; }  
    }
}
