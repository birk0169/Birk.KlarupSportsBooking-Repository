using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birk.KlarupSportsBooking.DAL.EF
{
    public partial class Activity
    {
        /// <summary>
        /// A constructer for the activity class
        /// </summary>
        /// <param name="activityName">The name of the activity</param>
        /// <param name="hallSpace">The amount of hall space the activity takes up out of 6</param>
        public Activity(string activityName, int hallSpace)
        {
            ActivityName = activityName;
            HallSpace = hallSpace;
            Bookings = new HashSet<Booking>();
            Reservations = new HashSet<Reservation>();
        }
        
    }
}
