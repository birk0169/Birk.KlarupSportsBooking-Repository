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
            if (day == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                DateTime endDay = day.AddHours(24);
                return Model.Bookings.Where(x => x.ActivityTimeFrom >= day).Where(y => y.ActivityTimeFrom <= endDay).ToList();
            }
            
        }

        //Add
        /// <summary>
        /// Adds one or more booking if its fixed to the datebase
        /// </summary>
        /// <param name="reservation"></param>
        /// <param name="admin"></param>
        public void AddBookingsToDB(Reservation reservation, Admin admin)
        {
            //Ceck for nulls
            if (reservation == null || (reservation.Union == null && reservation.UnionId == 0))
            {
                throw new ArgumentNullException();
            }
            else if (reservation.Activity == null && reservation.ActivityId == 0)
            {
                throw new ArgumentNullException();
            }
            else if (admin == null)
            {
                throw new ArgumentNullException();
            }

            if (reservation.IsFixed)
            {
                Fixed fixedReservation = reservation.Fixeds.FirstOrDefault();
                DateTime startTime = reservation.ReservationFrom;
                DateTime endTime = reservation.ReservationTo;
                while (true)
                {
                    //Check time
                    if (endTime > fixedReservation.PeriodEnd)
                    {
                        break;
                    }

                    if (startTime > fixedReservation.PeriodStart)
                    {
                        Booking booking = new Booking(reservation, admin, startTime, endTime);
                        //Add to DB
                        Model.Bookings.Add(booking);
                        Model.SaveChanges();
                    }
                    
                    //Next week
                    startTime.AddDays(7);
                    endTime.AddDays(7);
                }
            }
            else
            {
                Booking booking = new Booking(reservation, admin);
                Model.Bookings.Add(booking);
                Model.SaveChanges();
            }
            
        }
        
    }
}
