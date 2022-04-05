using System.Globalization;
using System.Text.RegularExpressions;

namespace CHC.DateTimeExtensions
{
    public static class DateTimeExtensions
    {
        private static string[]? WEEKS_ROC_NAME;
        private static readonly TaiwanCalendar TAIWAN_CALENDAR = new TaiwanCalendar();

        public static void Initialization(string[] weeks)
        {
            WEEKS_ROC_NAME = weeks;
        }

        public static string FormatROC(this DateTime target, string format, DateTimeKind kind = DateTimeKind.Local)
        {
            if (kind == DateTimeKind.Utc || target.Kind == DateTimeKind.Utc)
                target = target.ToLocalTime();

            var culture = CultureInfo.CreateSpecificCulture("zh-TW");
            culture.DateTimeFormat.Calendar = TAIWAN_CALENDAR;
            if (WEEKS_ROC_NAME is not null)
                culture.DateTimeFormat.AbbreviatedDayNames = WEEKS_ROC_NAME;

            return target.ToString(format, culture);
        }

        public static DateTime ConvertByROCDateToDateTime(this string target)
        {
            int publicHolidayYear = 1911;
            int year;
            int month;
            int day;
            int hour;
            int minute;
            int second;
            bool Is12HourClock = target.Contains("下午");

            var dateStringArray = Regex.Split(target, @"[:*./\s\-\u4E00-\u9FFF]").Where(x => !string.IsNullOrEmpty(x) && !string.IsNullOrWhiteSpace(x)).ToArray();

            var dateArray = dateStringArray.Select(x => Convert.ToInt32(x)).ToArray();
            year = dateArray[0] >= publicHolidayYear ? dateArray[0] : dateArray[0] + publicHolidayYear;
            month = dateArray[1];
            day = dateArray[2];
            hour = dateArray.Length > 3 ? Is12HourClock ? dateArray[3] + 12 : dateArray[3] : 0;
            minute = dateArray.Length > 4 ? dateArray[4] : 0;
            second = dateArray.Length > 5 ? dateArray[5] : 0;

            var result = new DateTime(year, month, day, hour, minute, second);

            return result;
        }
    }
}