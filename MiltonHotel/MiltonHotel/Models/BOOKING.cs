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
        [Range(1,10,ErrorMessage ="the number of customers must be more than 0 and less than 10")]
        [Required(ErrorMessage = "The number of guests should be enterd")]
        public int QUANTITY { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "The checkin date must be entered")]
        [Display(Name = "Check-in Date")]
        [DataType(DataType.Date)]
        [todayVal]
        public DateTime FROM_DATE { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "The checkin date must be entered")]
        [Display(Name = "Check-out date")]
        [DataType(DataType.Date)]
        [dateval]
        public DateTime TO_DATE { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime BOOKED_DATE { get; set; } = DateTime.Now;

        public virtual ROOM ROOMS { get; set; }
    }
}
