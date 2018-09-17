namespace Birk.KlarupSportsBooking.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservation()
        {
            Bookings = new HashSet<Booking>();
            Fixeds = new HashSet<Fixed>();
        }

        public int Id { get; set; }

        public DateTime ReservationFrom { get; set; }

        public DateTime ReservationTo { get; set; }

        public bool IsFixed { get; set; }

        public int UnionId { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fixed> Fixeds { get; set; }

        public virtual Union Union { get; set; }
    }
}
