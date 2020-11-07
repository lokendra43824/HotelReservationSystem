using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace HotelReservationSystem
    {
        public class Hotel
        {

            /// <summary>
            /// objects containing details of Hotel Class
            /// </summary>
            public string hotelName { get; set; }
            public int weekdayRate { get; set; }
            public int weekendRate { get; set; }
            public int weekendLoyaltyRate { get; set; }
            public int weekdayLoyaltyRate { get; set; }
            public int rating { get; set; }

            /// <summary>
            /// Default Ctor for Hotel Class
            /// </summary>
            public Hotel()
            {
                hotelName = "";
                weekendRate = 0;
                weekdayRate = 0;
                weekdayLoyaltyRate = 0;
                weekendLoyaltyRate = 0;
                rating = 0;
            }


            /// <summary>
            /// Parameterised Ctor for Hotel Class
            /// </summary>
            /// <param name="name">Name of the hotel</param>
            /// <param name="mfrate">Weekday Rates for Regular Customer</param>
            /// <param name="ssrate">Weekend Rates for Reward Customer</param>
            /// <param name="weekdayL">Weekday Rates for Regular Customer</param>
            /// <param name="weekendL">Weekend Rates for Reward Customer</param>
            /// <param name="rating">Rating of the hotel</param>
            public Hotel(string name, int mfrate, int ssrate, int weekdayL, int weekendL, int rating)
            {
                this.hotelName = name;
                this.weekendRate = ssrate;
                this.weekdayRate = mfrate;
                this.rating = rating;
                this.weekendLoyaltyRate = weekendL;
                this.weekdayLoyaltyRate = weekdayL;
            }
        }
    }
}
