using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFDemos.Common.ValidationRules
{
    public class RequiredRule :ValidationRule
    {
        public override ValidationResult Validate (object value,CultureInfo cultureInfo)
        {
            if(value == null)
            {
                return new ValidationResult(false,"required");
            }

            if(string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false,"required");
            }

            return new ValidationResult(true,null);
        }
    }
}
