using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birk.KlarupSportsBooking.DAL.EF;

namespace Birk.KlarupSportsBooking.BIZ
{
    public class ReservationHandler : BaseHandler
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
        /// <summary>
        /// Adds a reservation to the DB
        /// </summary>
        /// <param name="reservation"></param>
        public void AddReservationToDB(Reservation reservation)
        {
            if (reservation == null || (reservation.Union == null && reservation.UnionId == 0))
            {
                throw new ArgumentNullException();
            }
            else if (reservation.Activity == null && reservation.ActivityId == 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                Model.Reservations.Add(reservation);
                Model.SaveChanges();
            }

        }
    }
}
