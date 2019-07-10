using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class DatetimeExtension
    {
        public const string TimeFormat = "HH:mm";
        public const string DateFormat = "dd-MMM-yyyy";
        public const string DateTimeFormat = "dd-MMM-yyyy HH:mm";

        public static string ToDateTimeString (this DateTime currentDateTime)
            => currentDateTime.ToString(DateTimeFormat);
    }
}
