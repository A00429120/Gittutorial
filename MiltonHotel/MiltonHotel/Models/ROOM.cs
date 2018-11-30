namespace MiltonHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROOMS")]
    public partial class ROOM
    {
        [Key]
        [Display(Name = "Room Number")]
        public int ROOM_NO { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Room Type")]
        public string ROOM_TYPE { get; set; }

        [Display(Name = "Room Price")]
        public double PRICE { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Room Name")]
        public string ROOM_NAME { get; set; }

        //public virtual ROOM ROOMS1 { get; set; }

        //public virtual ROOM ROOM1 { get; set; }
    }
}
