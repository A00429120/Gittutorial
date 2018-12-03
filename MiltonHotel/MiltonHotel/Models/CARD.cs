﻿namespace MiltonHotel.Models

{

    using System;

    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    using System.Data.Entity.Spatial;



    [Table("CARD")]

    public partial class CARD

    {

        [Key]

        [StringLength(50)]

        [Required(ErrorMessage = "The card No. should be entered")]

        [Display(Name = "Card No.")]

        [cardval]

        public string CREDIT_CARD_NO { get; set; }



        [StringLength(50)]

        [Required(ErrorMessage = "The card type should be entered")]

        [Display(Name = "Card Type")]

        public string CARD_TYPE { get; set; }



        [Required(ErrorMessage = "The  name should be entered")]

        [Display(Name = "Name on the card")]

        public string NAME_ON_CARD { get; set; }



        //[Column(TypeName = "date")]

        //[DataType(DataType.Date)]

        [Required(ErrorMessage = "The Expiry date should be entered")]

        [Display(Name = "Expiry Date")]

        [RegularExpression("^(0[1-9]|1[0-2])/20(1[6-9]|2[0-9]|3[0-1])$")]

        public string EXP_DATE { get; set; }



        public long CID { get; set; }

    }

}