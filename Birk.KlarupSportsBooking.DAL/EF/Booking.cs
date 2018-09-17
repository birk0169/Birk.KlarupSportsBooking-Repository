namespace Birk.KlarupSportsBooking.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public int Id { get; set; }

        public DateTime ActivityTimeFrom { get; set; }

        public DateTime ActivityTimeTo { get; set; }

        public int ActivityId { get; set; }

        public int AdminId { get; set; }

        public int ReservationId { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
