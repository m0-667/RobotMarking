using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMarking.Utils
{
    internal class DateUtils
    {
        /// <summary>
        /// 获取某天的日期
        /// </summary>
        /// <param name="day"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static string GetDate(int day = 0, string flag = "MM/dd/yyyy")
        {
            DateTime dt = DateTime.Now;
            return dt.AddDays(day).ToString(flag);
        }
        public static string GetMonth(int day = 0)
        {
            DateTime dt = DateTime.Now;
            return dt.AddDays(day).ToString("MM");
        }

        public static string GetTime()
        {
            DateTime dt = DateTime.Now;
            return dt.ToLongTimeString();
        }

        public static int DateDiff(string dateStart, string dateEnd)
        {
            DateTime start = Convert.ToDateTime(dateStart);
            DateTime end = Convert.ToDateTime(dateEnd);
            TimeSpan sp = end.Subtract(start);
            return sp.Days;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="isHour"></param>
        /// <returns></returns>
        public static DateTime GetDate(int hour, int isHour)
        {
            DateTime dt = DateTime.Now;
            return dt.AddHours(hour);
        }

        public static DateTime CurrenDateTime()
        {
            return DateTime.Now;
        }

        public static int CurrenWeek()
        {
            return Convert.ToInt32(DateTime.Now.DayOfWeek);
        }
    }
}
