using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class CampGround
    {
        /// <summary>
        /// Gets the campground ID (PK).
        /// </summary>
        public int CampgroundId { get; set; }

        /// <summary>
        /// Gets the park ID (FK).
        /// </summary>
        public int ParkId { get; set; }

        /// <summary>
        /// Gets the campground name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the open from date.
        /// </summary>
        public int OpenFrom { get; set; }

        /// <summary>
        /// Gets the open to date.
        /// </summary>
        public int OpenTo { get; set; }

        /// <summary>
        /// Gets the daily fee.
        /// </summary>
        public decimal DailyFee { get; set; }
    }
}
