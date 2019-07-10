using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty (this string value)
            => string.IsNullOrEmpty(value);

        public static int ToInt (this string value)
            => int.Parse(value);

        public static bool ContainsIgnoreCase (this string value,string search)
            => value?.ToLower().Contains(search.ToLower()) ?? false;

        public static bool EqualsIgnoreCase (this string a,string b)
            => a.Equals(b,StringComparison.OrdinalIgnoreCase);

        public static string FirstLetterToUpperCase (this string value)
        {
            if(value.IsNullOrEmpty()) return null;

            var expectedFirstLetter = char.ToUpper(value[0]);
            if(value[0] == expectedFirstLetter) return value;

            if(value.Length == 1) return expectedFirstLetter.ToString();

            return expectedFirstLetter + value.Substring(1);
        }
    }
}
