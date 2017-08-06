using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DonorRegister
{
    public class RequiredFiedValidationRule : ValidationRule
    {
        public RequiredFiedValidationRule()
        {

        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == string.Empty)
                return new ValidationResult(false, "Required");
            return ValidationResult.ValidResult;
        }
    }
}
