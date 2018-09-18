using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birk.KlarupSportsBooking.DAL.EF;

namespace Birk.KlarupSportsBooking.BIZ
{
    public class BookingHandler : BaseHandler
    {
        /// <summary>
        /// Returns all bookings from the database
        /// </summary>
        /// <returns>Bookings from the database in a list</returns>
        public List<Booking> GetAllBookings()
        {
            return Model.Bookings.ToList();
        }

        public List<Booking> GetAllBookingSpecificDate(DateTime day)
        {
            DateTime endDay = day.AddHours(24);
            return Model.Bookings.Where(x => x.ActivityTimeFrom >= day).Where(y => y.ActivityTimeFrom <= endDay).ToList();
        }
    }
}
