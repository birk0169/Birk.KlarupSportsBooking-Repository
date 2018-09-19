using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birk.KlarupSportsBooking.DAL.EF
{
    public partial class Booking
    {
        public Booking()
        {
            
        }

        //Constructor
        /// <summary>
        /// A constructor for the booking class
        /// </summary>
        /// <param name="reservation"></param>
        /// <param name="admin"></param>
        public Booking(Reservation reservation, Admin admin)
        {
            ReservationId = reservation.Id;
            ActivityTimeFrom = reservation.ReservationFrom;
            ActivityTimeTo = reservation.ReservationTo;
            ActivityId = reservation.Activity.Id;
            AdminId = admin.Id;
        }

        /// <summary>
        /// Another constructor for the booking class but with datetime inputs
        /// </summary>
        /// <param name="reservation"></param>
        /// <param name="admin"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public Booking(Reservation reservation, Admin admin, DateTime from, DateTime to)
        {
            ReservationId = reservation.Id;
            ActivityTimeFrom = from;
            ActivityTimeTo = to;
            ActivityId = reservation.Activity.Id;
            AdminId = admin.Id;
        }

        /// <summary>
        /// Returns to week day of the booking
        /// </summary>
        public String WeekDay
        {
            get
            {
                return ActivityTimeFrom.DayOfWeek.ToString();
            }
        }

        /// <summary>
        /// Returns the date of booking
        /// </summary>
        public string DateOfBooking
        {
            get
            {
                return ActivityTimeFrom.ToString();
            }
        }

        /// <summary>
        /// Returns the time from in hours
        /// </summary>
        public string TimeFrom
        {
            get
            {
                return ActivityTimeFrom.Hour.ToString();
            }
        }

        /// <summary>
        /// Returns the time to in hours
        /// </summary>
        public string TimeTo
        {
            get
            {
                return ActivityTimeTo.Hour.ToString();
            }
        }

        public string ActivityName
        {
            get
            {
                return Activity.ActivityName;
            }
        }

        public int HallSpaceUsed
        {
            get
            {
                return Activity.HallSpace;
            }
        }

    }
}
