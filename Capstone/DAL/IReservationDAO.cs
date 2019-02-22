using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IReservationDAO
    {
        int CreateReservation(Reservation reservation, DateTime arrivalDate, DateTime departureDate);
    }
}
