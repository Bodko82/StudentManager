using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentManager.ValidationRules
{
    public class EmailValidationRule : ValidationRule
    {
        public static readonly Regex EmailRegex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || !EmailRegex.IsMatch(value.ToString()))
            {
                return new ValidationResult(false, "Некоректний Email.");
            }

            return ValidationResult.ValidResult;
        }
    }


}
