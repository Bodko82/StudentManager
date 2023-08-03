using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentManager.ValidationRules
{
    public class OnlyDigitsRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Value cannot be empty.");

            if (!int.TryParse(value.ToString(), out int result))
                return new ValidationResult(false, "Only integer values allowed.");

            return ValidationResult.ValidResult;
        }
    }

}
