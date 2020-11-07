using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public class Hotel
    {
        internal string rateOfRegularCustomer;
        private string v1;
        private int v2;

        public string hotelName { get; set; }
        public int weekdayRate { get; set; }
        public int weekendRate { get; set; }
        public int weekendLoyaltyRate { get; set; }
        public int weekdayLoyaltyRate { get; set; }
        public int rating { get; set; }
       public Hotel()
        {
            hotelName = "";
            weekendRate = 0;
            weekdayRate = 0;
            weekdayLoyaltyRate = 0;
            weekendLoyaltyRate = 0;
            rating = 0;
        }
        public Hotel(string name, int mfrate, int ssrate, int weekdayL, int weekendL, int rating)
        {
            this.hotelName = name;
            this.weekendRate = ssrate;
            this.weekdayRate = mfrate;
            this.rating = rating;
            this.weekendLoyaltyRate = weekendL;
            this.weekdayLoyaltyRate = weekdayL;
        }

        public Hotel(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
