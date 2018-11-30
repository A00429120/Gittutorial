namespace MiltonHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOOKING")]
    public partial class BOOKING
    {
        [Key]
        public long BOOKING_NO { get; set; }

        public long CID { get; set; }

        public int ROOM_NO { get; set; }

        [Display(Name = "No. of Guests")]
        public int QUANTITY { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [todayVal]
        public DateTime FROM_DATE { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [dateval]
        public DateTime TO_DATE { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime BOOKED_DATE { get; set; }

        public virtual ROOM ROOMS { get; set; }
    }
}
