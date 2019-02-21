using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IParkDAO
    {
        /// <summary>
        /// Returns a list of parks in the registry.
        /// </summary>
        /// <returns>A list of all the parks.</returns>
        IList<Park> ListAvailableParks();
    }
}
