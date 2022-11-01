using HR.Static;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Common
{
    public class AppConstant
    {
        public static readonly object[] EmptyValues = { Guid.Empty, string.Empty, null };

        public struct Cookies
        {
            public static string UserFullNameCookie { get; set; }
            public static string userId { get; set; } = "UserId";
        }

       
    }
    public struct AppDate
    {
        public static DateTime Now = DateTime.UtcNow.AddHours(HourServer.hours);
    }
}
