using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MiltonHotel.Models;

namespace MiltonHotel
{
    public class postalval : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
                            ValidationContext validationContext)
        {
            CUSTOMER cust = (CUSTOMER)validationContext.ObjectInstance;
            string str = value.ToString();

            string country = cust.COUNTRY;

            if (!IsCanadianZipCode(str) && country == "Canada")
            {
                return new ValidationResult("Invalid Canadian postal code");
            }
            else if (!IsUSZipCode(str) && country == "USA")
            {
                return new ValidationResult("Invalid USA postal code");
            }
            return ValidationResult.Success;
        }

        private bool IsUSZipCode(string zipCode)
        {
            bool isValidUsOrCanadianZip = false;
            string pattern = @"^\d{5}-\d{4}|\d{5}$";
            Regex regex = new Regex(pattern);
            return isValidUsOrCanadianZip = regex.IsMatch(zipCode);
        }
        private bool IsCanadianZipCode(string zipCode)
        {
            bool isValidUsOrCanadianZip = false;
            string pattern = @"^[A-Z]\d[A-Z] \d[A-Z]\d$";
            Regex regex = new Regex(pattern);
            return isValidUsOrCanadianZip = regex.IsMatch(zipCode);
        }
    }
}