using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSheduler1
{
    internal class Containerr
    {
        public static List<Task> alltask = new List<Task>();
        public static string total_date_view { get; set; } //02.05.2022
        public static string active_id = "";
        public static int last_id = 0;

        public static bool update = false;
        public static bool edit = false;
        public static DateTime convert(string dt)
        {
            string[] spl = dt.Split('.');
            return new DateTime(Convert.ToInt32(spl[2]), Convert.ToInt32(spl[1]), Convert.ToInt32(spl[0]));
        }
        public static string getdate(DateTime dt)
        {
            string day = dt.Day.ToString();
            string mount = dt.Month.ToString();
            if (day.Length==1)
            {
                day = "0" + day;
            }
            if (mount.Length == 1)
            {
                mount = "0" + mount;
            }
            return String.Format($"{day}.{mount}.{dt.Year}");
        }
    }
}
