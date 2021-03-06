//
// Copyright (c) 2009 Ivan Zlatev <ivan@ivanz.com>
//
// Authors:
//	Ivan Zlatev <ivan@ivanz.com>
//
// License: MIT/X11 - See LICENSE.txt
//

using System;

namespace PicasaUploader
{
    // Convert from/to time_t and DateTime
    //
    // time_t is an int representing the number of seconds since
    // Midnight UTC 1 Jan 1970 on the Gregorian Calendar.
    //
    public static class UnixTime
    {
        private readonly static DateTime _origin = new DateTime(1970, 1, 1, 0, 0, 0);

        public static DateTime ToDateTime(long time_t)
        {
            return _origin + new TimeSpan((time_t / 1000) * TimeSpan.TicksPerSecond);
        }

        public static long ToUnixDateTime(this DateTime time)
        {
            long difference = time.Ticks - _origin.Ticks;
            return ((difference / TimeSpan.TicksPerSecond) * 1000);
        }
    }
}
