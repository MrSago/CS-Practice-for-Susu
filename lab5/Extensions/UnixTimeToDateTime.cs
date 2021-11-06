
using System;

namespace lab5.Extensions
{
    public static class UnixTimeToDateTime
    {
        public static DateTime Convert(double unixTimeStamp)
        {
            DateTime result = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            result = result.AddSeconds(unixTimeStamp).ToLocalTime();
            return result;
        }

        public static DateTime Convert(string unixTimeStamp)
        {
            double value = unixTimeStamp != null ? double.Parse(unixTimeStamp) : 0.0;
            DateTime result = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            result = result.AddSeconds(value).ToLocalTime();
            return result;
        }
    }
}

