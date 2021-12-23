using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.Helper
{
   public static class _AppDate
    {
        public static int GetDateIndex()
        {
            
            int day = (int)DateTime.Now.AddHours(3).DayOfWeek+1;
            if (day == 7)
            {
                return 0;
            }
            else
            {
                return day;
            }
        }
    }
}
