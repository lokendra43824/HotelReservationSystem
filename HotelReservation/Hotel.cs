using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public class Hotel
    {
        public string hotelName { get; set; }
        public int weekdayRate { get; set; }
        public int weekendRate { get; set; }

        public Hotel()
        {
            hotelName = "";
            weekendRate = 0;
            weekdayRate = 0;
        }

        public Hotel(string name, int mfrate, int ssrate)
        {
            this.hotelName = name;
            this.weekendRate = ssrate;
            this.weekdayRate = mfrate;
        }
    }
}
