using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Common
{
    public static class DateTimeCommon
    {
        #region Extension
        /// <summary>
        /// Lay ngay dau tien trong tuan cua mot ngay bat ky
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime FirstDateOfWeek(this DateTime date)
        {
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            DayOfWeek dOfWeek = info.Calendar.GetDayOfWeek(date);
            var h = new Hashtable();
            h["Sunday"] = 6;
            h["Monday"] = 0;
            h["Tuesday"] = 1;
            h["Wednesday"] = 2;
            h["Thursday"] = 3;
            h["Friday"] = 4;
            h["Saturday"] = 5;
            double indexOfday = double.Parse(h[dOfWeek.ToString()].ToString());
            var tmpDate = date.AddDays(-indexOfday);
            return new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day);
        }

        /// <summary>
        /// Lay ngay cuoi cung trong tuan cua mot ngay bat ky
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime LastDateOfWeek(this DateTime date)
        {
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            DayOfWeek dOfWeek = info.Calendar.GetDayOfWeek(date);
            var h = new Hashtable();
            h["Sunday"] = 6;
            h["Monday"] = 0;
            h["Tuesday"] = 1;
            h["Wednesday"] = 2;
            h["Thursday"] = 3;
            h["Friday"] = 4;
            h["Saturday"] = 5;
            double indexOfday = double.Parse(h[dOfWeek.ToString()].ToString());
            var tmpDate = date.AddDays(6 - indexOfday);
            return new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, 23, 59, 59);
        }

        /// <summary>
        /// Ngay dau thang cua mot ngay bat ky
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return DateTime.Parse(date.Year + "-" + date.Month + "-01");
        }

        /// <summary>
        /// Ngay cuoi thang cua mot ngay bat ky
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return DateTime.Parse(date.Year + "-" + date.Month + "-" + DateTime.DaysInMonth(date.Year, date.Month));
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime StartOfDate(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day);
        }

        public static DateTime EndOfDate(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }

        #endregion

        #region Convert
        /// <summary>
        /// Convert từ chuỗi sang ngày tháng theo định dạng
        /// </summary>
        /// <param name="format">Chuỗi định dạng ngày tháng</param>
        /// <param name="value">Chuỗi giá trị</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static DateTime FromString(string value, string format, CultureInfo culture)
        {
            return DateTime.ParseExact(value, format, culture, DateTimeStyles.None);
        }

        /// <summary>
        /// Convert từ chuỗi sang ngày tháng theo định dạng, với kiểu ngày tháng của Việt Nam. 
        /// Có thể nhập định dạng dd-MM-yyyy hoặc dd/MM/yyyy
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime FromStringVn(string value)
        {
            return FromString(value.Replace(@"-", @"/"), "dd/MM/yyyy", new CultureInfo("vi-VN"));
        }
        #endregion

        #region Convert sang kiểu long và ngược lại

        /// <summary>
        /// Chuyển thời gian thành số long
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static Int64 GetTime(DateTime dt)
        {
            var st = new DateTime(1970, 1, 1);
            TimeSpan t = (dt.ToUniversalTime() - st);
            long retval = (Int64)(t.TotalMilliseconds + 0.5);
            return retval;
        }

        /// <summary>
        /// Chuyển từ long thành ngày tháng
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetTime(Int64 time)
        {
            if (time == 0)
            {
                return DateTime.Now;
            }

            var st = new DateTime(1970, 1, 1);
            DateTime dt = st.AddMilliseconds(time);
            return dt.ToLocalTime();
        }

        /// <summary>
        /// Chuyển từ long thành ngày tháng
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetTime(Int32 time)
        {
            return GetTime((long)time);
        }
        #endregion

        #region Start and End

        /// <summary>
        /// Lấy ngày bắt đầu là ngày truyền vào với thời gian là 00:00:00. 
        /// Nếu ngày bắt đầu là rỗng, hoặc không truyền vào thì lấy 
        /// ngày hiện tại trừ đi 7 ngày
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetAutoStartDate(DateTime? date = null)
        {
            var now = DateTime.Now;
            return date.HasValue
                       ? new DateTime(date.Value.Year, date.Value.Month, date.Value.Day)
                       : new DateTime(now.Year, now.Month, now.Day).AddDays(-7);

        }

        /// <summary>
        /// Lấy ngày bắt đầu là ngày truyền vào với thời gian là 00:00:00. 
        /// Nếu ngày bắt đầu là rỗng, hoặc không truyền vào thì lấy 
        /// ngày hiện tại trừ đi 7 ngày
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetAutoStartDate(long? date)
        {
            DateTime? dt = null;
            return date.HasValue
                       ? GetAutoStartDate(GetTime(date.Value))
                       : GetAutoStartDate(dt);
        }

        /// <summary>
        /// Lấy ngày kết thúc là ngày truyền vào với thời gian là 23:59:59
        /// Nếu ngày kết thúc là rỗng, hoặc không truyền vào thì lấy ngày hiện tại
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetAutoEndDate(DateTime? date = null)
        {
            var now = DateTime.Now;
            return date.HasValue
                       ? new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, 23, 59, 59)
                       : new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
        }

        /// <summary>
        /// Lấy ngày kết thúc là ngày truyền vào với thời gian là 23:59:59
        /// Nếu ngày kết thúc là rỗng, hoặc không truyền vào thì lấy ngày hiện tại
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetAutoEndDate(long? date)
        {
            DateTime? dt = null;
            return date.HasValue
                       ? GetAutoEndDate(GetTime(date.Value))
                       : GetAutoEndDate(dt);
        }

        /// <summary>
        /// Lấy ngày bắt đầu là ngày truyền vào với thời gian là 00:00:00. 
        /// Nếu ngày bắt đầu là rỗng, hoặc không truyền vào thì trả về null
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime? GetStartDate(DateTime? date = null)
        {
            if (date.HasValue)
            {
                return new DateTime(date.Value.Year, date.Value.Month, date.Value.Day);
            }
            return null;
        }

        /// <summary>
        /// Lấy ngày kết thúc là ngày truyền vào với thời gian là 23:59:59
        /// Nếu ngày kết thúc là rỗng, hoặc không truyền vào thì trả về null
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime? GetEndDate(DateTime? date = null)
        {
            if (date.HasValue)
            {
                return new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, 23, 59, 59);
            }
            return null;
        }

        #endregion
    }
}
