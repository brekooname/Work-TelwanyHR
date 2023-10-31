using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Static
{
    public class Root
    {
        public List<TimeZone> TimeZone { get; set; }
    }

    public class TimeZone
    {
        public int Id { get; set; }
        public string Continent { get; set; }
        public List<NewRow> NewRow { get; set; }
    }

    public class NewRow
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Tz { get; set; }
    }
}