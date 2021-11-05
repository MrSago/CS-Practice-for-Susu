﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Extensions
{
    public static class UnixTimeToDateTime
    {
        public static DateTime Convert(double unixTimeStamp)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            result = result.AddSeconds(unixTimeStamp).ToLocalTime();
            return result;
        }

        public static DateTime Convert(string unixTimeStamp)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            result = result.AddSeconds(double.Parse(unixTimeStamp)).ToLocalTime();
            return result;
        }
    }
}
