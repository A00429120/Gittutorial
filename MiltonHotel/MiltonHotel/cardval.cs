using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MiltonHotel.Models;

namespace MiltonHotel
{
    public class cardval : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
                            ValidationContext validationContext)
        {
            CARD card = (CARD)validationContext.ObjectInstance;
            string str = value.ToString();

            string type = card.CARD_TYPE;

            if (!IsVisa(str) && type == "Visa")
            {
                return new ValidationResult("Invalid Visa Card No.");
            }
            else if (!IsAmex(str) && type == "American Express")
            {
                return new ValidationResult("Invalid American Express Card No.");
            }
            else if (!IsMaster(str) && type == "Master Card")
            {
                return new ValidationResult("Invalid Master Card No.");
            }
            return ValidationResult.Success;
        }

        private bool IsVisa(string cardno)
        {
            bool isVisa = false;
            string pattern = "^4\\d{15}$";
            Regex regex = new Regex(pattern);
            return isVisa = regex.IsMatch(cardno);
        }
        private bool IsAmex(string cardno)
        {
            bool isAmex = false;
            string pattern = "^3(4|7)\\\\d{13}$";
            Regex regex = new Regex(pattern);
            return isAmex = regex.IsMatch(cardno);
        }
        private bool IsMaster(string cardno)
        {
            bool isMaster = false;
            string pattern = "^5[1-5]\\d{14}$";
            Regex regex = new Regex(pattern);
            return isMaster = regex.IsMatch(cardno);
        }
    }
}