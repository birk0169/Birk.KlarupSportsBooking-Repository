using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birk.KlarupSportsBooking.DAL.EF;

namespace Birk.KlarupSportsBooking.BIZ
{
    class ReservationHandler : BaseHandler
    {
        //Get
        /// <summary>
        /// Returns all reservations from the database in a list
        /// </summary>
        /// <returns>All reservation from the database in a list</returns>
        public List<Reservation> GetAlllReservation()
        {
            return Model.Reservations.ToList();
        }

        //Add
        public void AddReservationToDB(Reservation reservation)
        {
            if (reservation == null)
            {

            }
            else
            {
                Model.Reservations.Add(reservation);
                Model.SaveChanges();
            }

        }
    }
}
