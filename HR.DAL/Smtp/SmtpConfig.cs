using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HR.DAL.Smtp
{
    public class SmtpConfig
    {
        public static string GrtConnectionString()
        {
            string connectionString = "";
            string[] file = File.ReadAllLines("SmtpConfig.txt");
            for (int i = 0; i < file.Length; i++)
                connectionString += file[i];
            return connectionString;
        }
    }
}
