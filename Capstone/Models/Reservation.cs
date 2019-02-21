using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Reservation
    {
        /// <summary>
        /// Gets the reservation ID (PK).
        /// </summary>
        public int ReservationId { get; set; }

        /// <summary>
        /// Gets the site ID (FK).
        /// </summary>
        public int SiteId { get; set; }
        
        /// <summary>
        /// Gets the name for the reservation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the start date of the reservation.
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Gets the end date of the reservation.
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Gets the date of the reservation.
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
