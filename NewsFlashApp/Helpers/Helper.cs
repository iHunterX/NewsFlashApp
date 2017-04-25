using System;
using System.Globalization;
using System.Linq;
using UIKit;

namespace NewsFlashApp.Helpers
{
    static class Helper
    {
        /// <summary>
        /// Converts a date to a week number.
        /// ISO 8601 week 1 is the week that contains the first Thursday that year.
        /// </summary>
        public static int ToIso8601Weeknumber(this DateTime date)
        {
            var thursday = date.AddDays(3 - date.DayOfWeek.DayOffset());
            return (thursday.DayOfYear - 1) / 7 + 1;
        }

        /// <summary>
        /// Converts a week number to a date.
        /// Note: Week 1 of a year may start in the previous year.
        /// ISO 8601 week 1 is the week that contains the first Thursday that year, so
        /// if December 28 is a Monday, December 31 is a Thursday,
        /// and week 1 starts January 4.
        /// If December 28 is a later day in the week, week 1 starts earlier.
        /// If December 28 is a Sunday, it is in the same week as Thursday January 1.
        /// </summary>
        public static DateTime FromIso8601Weeknumber(int weekNumber, int? year = null, DayOfWeek day = DayOfWeek.Monday)
        {
            var dec28 = new DateTime((year ?? DateTime.Today.Year) - 1, 12, 28);
            var monday = dec28.AddDays(7 * weekNumber - dec28.DayOfWeek.DayOffset());
            return monday.AddDays(day.DayOffset());
        }

        /// <summary>
        /// Iso8601 weeks start on Monday. This returns 0 for Monday.
        /// </summary>
        private static int DayOffset(this DayOfWeek weekDay)
        {
            return ((int)weekDay + 6) % 7;
        }


        public static UIColor ToUiColor(this string hexString)
        {
            hexString = hexString.Replace("#", "");

            if (hexString.Length == 3)
                hexString = hexString + hexString;

            if (hexString.Length != 6)
                throw new Exception("Invalid hex string");

            int red = Int32.Parse(hexString.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            int green = Int32.Parse(hexString.Substring(2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            int blue = Int32.Parse(hexString.Substring(4, 2), System.Globalization.NumberStyles.AllowHexSpecifier);

            return UIColor.FromRGB(red, green, blue);
        }

        private static readonly Random Random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            lock (Random)
            {
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[Random.Next(s.Length)]).ToArray());
            }
        }


        private static readonly object SyncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (SyncLock)
            { // synchronize
                return Random.Next(min, max);
            }
        }

        public static T RandomEnum<T>()
        {
            Type type = typeof(T);
            Array values = Enum.GetValues(type);
            lock (Random)
            {
                object value = values.GetValue(Random.Next(values.Length));
                return (T)Convert.ChangeType(value, type);
            }
        }




        public static int GetWeeksInYear(int year)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            Calendar cal = dfi?.Calendar;
            return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);
        }
    }
}
