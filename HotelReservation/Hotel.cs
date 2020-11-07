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
        public int rating { get; set; }

        public Hotel()
        {
            hotelName = "";
            weekendRate = 0;
            weekdayRate = 0;
            rating = 0;
        }

        public Hotel(string name, int mfrate, int ssrate, int rating)
        {
            this.hotelName = name;
            this.weekendRate = ssrate;
            this.weekdayRate = mfrate;
            this.rating = rating;
        }
    }
}
