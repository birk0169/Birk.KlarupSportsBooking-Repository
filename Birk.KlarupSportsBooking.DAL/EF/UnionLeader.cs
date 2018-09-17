namespace Birk.KlarupSportsBooking.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UnionLeader
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(8)]
        public string PhoneNumber { get; set; }

        public int AddressId { get; set; }

        public int UnionId { get; set; }

        public virtual Address Address { get; set; }

        public virtual Union Union { get; set; }
    }
}
