using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.ComponentModel.DataAnnotations;
using MiltonHotel.Models;

namespace MiltonHotel
{
    public class dateval : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
                            ValidationContext validationContext)
        {
            BOOKING book = (BOOKING)validationContext.ObjectInstance;

            DateTime toDate = (DateTime)value;
            DateTime fromDate = book.FROM_DATE;

            int result = DateTime.Compare(toDate, fromDate);

            if (result < 0)
            {
                return new ValidationResult("The to date cannot be earlier than from date");
            }

            return ValidationResult.Success;
        }
    }
}