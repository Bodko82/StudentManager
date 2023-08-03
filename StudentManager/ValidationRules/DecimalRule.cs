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
    public class DecimalRule : ValidationRule
    {
        private static readonly Regex regex = new(@"^\d{1,6}(\.\d{1,2})?$", RegexOptions.Compiled);

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Value cannot be empty.");

            if (!regex.IsMatch(value.ToString()))
                return new ValidationResult(false, "Invalid format. Up to two decimal places allowed.");

            return ValidationResult.ValidResult;
        }
    }
}
