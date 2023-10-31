using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HR.DAL.Smtp
{
    public class SmtpConfig
    {
        public static string GetConnectionString()
        {
            JObject json = JObject.Parse(File.ReadAllText(@"SmtpConfig.json"));
            string value = (string)json["ConnectionString"];
            return value;
        }

        public static string DynamicConnection()
        {
            JObject json = JObject.Parse(File.ReadAllText(@"SmtpConfig.json"));
            string value = (string)json["DynamicConnection"];
            return value;
        }

        public static JObject GetTimeZone()
        {
            JObject json = JObject.Parse(File.ReadAllText(@"TimeZone.json"));
            //string strJson = json.ToString();
            return json;
        }
    }
}
