using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

public class PhoneNumberValidationRule : ValidationRule
{
    private static readonly Regex _regex = new Regex(@"\+38\(0\d{2}\)\d{3}-\d{2}-\d{2}");

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value == null || !_regex.IsMatch((string)value))
        {
            return new ValidationResult(false, "Невірний формат телефонного номера");
        }

        return ValidationResult.ValidResult;
    }
}

