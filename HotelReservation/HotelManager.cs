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
            if (!hotelList.Contains(newHotel))
            {
                hotelList.Add(newHotel);
            }
            else { Console.WriteLine("Hotel already exists"); }
        }

        public void CreateHotelList()
        {
            hotelList.Add(new Hotel("Lakewood", 110, 90));
            hotelList.Add(new Hotel("Bridgewood", 150, 50));
            hotelList.Add(new Hotel("Ridgewood", 220, 190));
        }

        public void DisplayHotels()
        {
            Console.WriteLine("Name\tWeekday Rate\tWeekend Rate");
            foreach (var hotel in hotelList)
            {
                Console.WriteLine(hotel.hotelName + "\t" + hotel.weekdayRate + "\t" + hotel.weekendRate);
            }
        }

        public Dictionary<Hotel, int> FindCheapHotel(DateTime startDate, DateTime endDate)
        {
            var cheapestHotelList = new Dictionary<Hotel, int>();
            if (startDate > endDate)
            {
                throw new HotelException(HotelException.ExceptionType.INVALID_DATE, "Invalid Dates");
            }

            else
            {
                var cost = Int32.MaxValue;
                foreach (var hotel in hotelList)
                {
                    var temp = cost;
                    cost = Math.Min(cost, TotalCostCalculation(hotel, startDate, endDate));

                }
                foreach (var hotel in hotelList)
                {
                    if (TotalCostCalculation(hotel, startDate, endDate) == cost)
                        cheapestHotelList.Add(hotel, cost);
                }
            }
            return cheapestHotelList;
        }

        public int TotalCostCalculation(Hotel hotel, DateTime startDate, DateTime endDate)
        {
            var totalCost = 0;
            var weekdayRate = hotel.weekdayRate;
            var weekendRate = hotel.weekendRate;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    totalCost += weekendRate;
                else
                    totalCost += weekdayRate;
            }
            return totalCost;
        }
    }
}
