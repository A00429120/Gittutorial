using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MiltonHotel.Models;

namespace MiltonHotel
{
    public class todayVal : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
                           ValidationContext validationContext)
        {
            BOOKING book = (BOOKING)validationContext.ObjectInstance;

            DateTime fromDate = (DateTime)value;
            DateTime today = DateTime.Now;

            int result = DateTime.Compare(fromDate, today);

            if (result < 0)
            {
                return new ValidationResult("The to date cannot be earlier than today");
            }

            return  ValidationResult.Success;
        }
    }
}