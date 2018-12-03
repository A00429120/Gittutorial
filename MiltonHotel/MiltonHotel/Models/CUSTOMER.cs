namespace MiltonHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMER")]
    public partial class CUSTOMER
    {
        [Key]
        public long CID { get; set; }

        [Required(ErrorMessage = "The First Name should be entered")]
        [RegularExpression("[^\\;\\:\\!\\@\\#\\$\\%\\^\\*\\+\\?\\<\\>\\d\\/]*", ErrorMessage = "The name should not contain any special charectes or digits")]
        [Display(Name = "First Name")]
        public string FNAME { get; set; }

        [Required(ErrorMessage = "The Last name should be entered")]
        [RegularExpression("[^\\;\\:\\!\\@\\#\\$\\%\\^\\*\\+\\?\\<\\>\\d\\/]*", ErrorMessage = "The name should not contain any special charectes or digits")]
        [Display(Name = "Last Name")]
        public string LNAME { get; set; }

        [Required(ErrorMessage = "The street name should be entered")]
        [Display(Name = "Street")]
        public string STREET { get; set; }

        [Required(ErrorMessage = "The city should be entered")]
        [RegularExpression("[^\\;\\:\\!\\@\\#\\$\\%\\^\\*\\+\\?\\<\\>\\d\\/]*", ErrorMessage = "The city should not contain any special charectes or digits")]
        [Display(Name = "City")]
        [StringLength(50)]
        public string CITY { get; set; }

        [Required(ErrorMessage = "The State should be entered")]
        [Display(Name = "State/Province")]
        [RegularExpression("[^\\;\\:\\!\\@\\#\\$\\%\\^\\*\\+\\?\\<\\>\\d]*", ErrorMessage = "The State should not contain any special charectes or digits")]
        [StringLength(50)]
        public string STATE { get; set; }

        [Required(ErrorMessage = "The country should be selected")]
        [Display(Name = "Country")]
        [StringLength(50)]
        public string COUNTRY { get; set; }

        [Required(ErrorMessage = "The postal code should be entered")]
        [Display(Name = "Postal Code")]
        [postalval]
        [StringLength(50)]
        public string POSTAL_CODE { get; set; }

        [Required(ErrorMessage = "The phone number should be entered")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public long PHONE { get; set; }

        [Required(ErrorMessage = "The email id should be entered")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [StringLength(50)]
        public string MAIL { get; set; }

        [Required(ErrorMessage = "The password should be entered")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string PASSWORD { get; set; }

        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "The password should be confirmed")]
        [Compare("PASSWORD", ErrorMessage = "The password must match with the confirm password")]
        [DataType(DataType.Password)]
        public string ConfPassword { get; set; }
    }
}
