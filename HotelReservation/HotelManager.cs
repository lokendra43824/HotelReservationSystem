using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public class HotelManager
    {
        public List<Hotel> hotelList = new List<Hotel>();

        public void AddHotel(Hotel newHotel)
        {
            hotelList.Add(newHotel);
        }

        public void DisplayHotels()
        {
            foreach (var hotel in hotelList)
            {
                Console.WriteLine(hotel.hotelName + "\t" + hotel.rateOfRegularCustomer);
            }
        }
    }
}
