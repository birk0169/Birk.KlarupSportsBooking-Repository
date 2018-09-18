using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birk.KlarupSportsBooking.DAL.EF
{
    public partial class Reservation
    {
        public Reservation(DateTime reservationFrom, DateTime reservationTo, bool isFixed, Union union, Activity activity)
        {
            ReservationFrom = reservationFrom;
            ReservationTo = reservationTo;
            IsFixed = isFixed;
            UnionId = union.Id;
            ActivityId = activity.Id;
            Bookings = new HashSet<Booking>();
            Fixeds = new HashSet<Fixed>();
        }
    }
}
