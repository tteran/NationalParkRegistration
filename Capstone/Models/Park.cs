using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Park
    {
        /// <summary>
        /// Gets the park ID (PK).
        /// </summary>
        public int ParkId { get; set; }

        /// <summary>
        /// Gets the park name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the location of the park.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets the established date of the park.
        /// </summary>
        public DateTime EstablishDate { get; set; }

        /// <summary>
        /// Gets the area of the park.
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// Gets the annual number of visitors to the park.
        /// </summary>
        public int Visitors { get; set; }

        /// <summary>
        /// Gets a short description of the park.
        /// </summary>
        public string Description { get; set; }
    }
}
