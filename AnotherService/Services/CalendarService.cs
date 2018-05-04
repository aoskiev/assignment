using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherService.Services
{
    public class CalendarService
    {
        public int GetWeeksInYear(int year)
        {
            DateTimeFormatInfo format = DateTimeFormatInfo.CurrentInfo;
            DateTime endOfYear = new DateTime(year, 12, 31);
            Calendar cal = format.Calendar;
            return cal.GetWeekOfYear(endOfYear, format.CalendarWeekRule, format.FirstDayOfWeek);
        }
    }
}
