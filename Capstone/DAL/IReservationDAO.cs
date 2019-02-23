using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IReservationDAO
    {
        /// <summary>
        /// Creates a reservation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        int CreateReservation(Reservation reservation);
    }
}
