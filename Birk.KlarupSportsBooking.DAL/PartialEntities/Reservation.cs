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

        /// <summary>
        /// A property that returns the day of the reservation in string
        /// </summary>
        public string WeekDay
        {
            get
            {
                return ReservationFrom.DayOfWeek.ToString();
            }
        }

        /// <summary>
        /// A property that retuns the name of the reservations activity
        /// </summary>
        public string ReservationActivityName
        {
            get
            {
                if (Activity == null)
                {
                    return "No activity";
                }
                else
                {
                    return Activity.ActivityName;
                }
                
            }
        }

        /// <summary>
        /// A property that return the date of the reservation in string
        /// </summary>
        public string DateOfReservation
        {
            get
            {
                return ReservationFrom.ToString("dd.MM.yyy");
            }
        }

        /// <summary>
        /// A property that gets the time the activity starts in hours
        /// </summary>
        public string HourFrom
        {
            get
            {
                return ReservationFrom.Hour.ToString();
            }
        }

        /// <summary>
        /// A property that gets the time the activity ends in hours
        /// </summary>
        public string HourTo
        {
            get
            {
                return ReservationTo.Hour.ToString();
            }
        }

    }
}
