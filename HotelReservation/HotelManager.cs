using HotelReservation.HotelReservationSystem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HotelReservation
{
    public class HotelManager
    {
        /// <summary>
        /// List of Hotels of type Hotel
        /// </summary>
        public List<Hotel> hotelList = new List<Hotel>();

        string rewardCustomerRegex = "^([Rr][Ee][Ww][Aa][Rr][Dd])$";
        string regularCustomerRegex = "^([Rr][Ee][Gg][Uu][Ll][Aa][Rr])$";

        /// <summary>
        /// Manual adding of Hotels in the HotelList
        /// </summary>
        /// <param name="newHotel"></param>
        public void AddHotel(Hotel newHotel)
        {
            if (!hotelList.Contains(newHotel))
            {
                hotelList.Add(newHotel);
            }
            else { Console.WriteLine("Hole already exists"); }
        }

        /// <summary>
        /// Method to add Default Hotels to the List
        /// Specifically used in Testing
        /// </summary>
        public void CreateHotelList()
        {
            hotelList.Add(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelList.Add(new Hotel("Bridgewood", 160, 120, 100, 40, 4));
            hotelList.Add(new Hotel("Ridgewood", 220, 190, 110, 50, 5));
        }

        /// <summary>
        /// Method to details Rates of each Hotel
        /// </summary>
        public void DisplayHotels()
        {
            Console.WriteLine("Name\tRegualr Weekday Rate\tREgular Weekend Rate\tReward Weekday Rate\tReward Weekend Rate\tCustomer Rating");
            foreach (var hotel in hotelList)
            {
                Console.WriteLine(hotel.hotelName + "\t" + hotel.weekdayRate + "\t" + hotel.weekendRate + "\t" + hotel.weekdayLoyaltyRate
                    + "\t" + hotel.weekendLoyaltyRate + "\t" + hotel.rating);
            }
        }


        /// <summary>
        /// Method to find the cheapest hotels in the list as per the date range
        /// Does NOT considers ratings
        /// </summary>
        /// <param name="startDate">Start date of stay</param>
        /// <param name="endDate">end date of stay</param>
        /// <param name="type">customer type</param>
        /// <returns>Dictionary containing cheapest hotel along with its price</returns>
        public Dictionary<Hotel, int> FindCheapHotel(DateTime startDate, DateTime endDate, string type)
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
                    cost = Math.Min(cost, TotalCostCalculation(hotel, startDate, endDate, type));

                }
                foreach (var hotel in hotelList)
                {
                    if (TotalCostCalculation(hotel, startDate, endDate, type) == cost)
                        cheapestHotelList.Add(hotel, cost);
                }
            }
            return cheapestHotelList;
        }


        /// <summary>
        /// Method to find the cheapest hotels in the list as per the date range
        /// Does Considers RATING
        /// </summary>
        /// <param name="startDate">Start date of stay</param>
        /// <param name="endDate">end date of stay</param>
        /// <param name="type">customer type</param>
        /// <returns>Dictionary containing cheapest hotel along with its price</returns>
        public Dictionary<Hotel, int> FindCheapestBestRatedHotel(DateTime startDate, DateTime endDate, string type)
        {
            var cheapestHotelsDict = FindCheapHotel(startDate, endDate, type);
            var cheapestBestRatedHotels = new Dictionary<Hotel, int>();
            var maxRating = 0;
            foreach (var kvp in cheapestHotelsDict)
                maxRating = Math.Max(maxRating, kvp.Key.rating);
            foreach (var kvp in cheapestHotelsDict)
                if (kvp.Key.rating == maxRating)
                    cheapestBestRatedHotels.Add(kvp.Key, kvp.Value);
            return cheapestBestRatedHotels;
        }


        /// <summary>
        /// Method to calculate the total cost of stay
        /// </summary>
        /// <param name="hotel">Hotel Details</param>
        /// <param name="startDate">Start date of stay</param>
        /// <param name="endDate">end date of stay</param>
        /// <param name="type">Customer Type</param>
        /// <returns>Total Cost incurred</returns>
        public int TotalCostCalculation(Hotel hotel, DateTime startDate, DateTime endDate, string type)
        {
            var totalCost = 0;
            var weekdayRate = hotel.weekdayRate;
            var weekendRate = hotel.weekendRate;
            if (Regex.IsMatch(rewardCustomerRegex, type))
            {
                weekdayRate = hotel.weekdayLoyaltyRate;
                weekendRate = hotel.weekendLoyaltyRate;
            }
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    totalCost += weekendRate;
                else
                    totalCost += weekdayRate;
            }
            return totalCost;
        }


        /// <summary>
        /// Lists ratings of all the hotels
        /// </summary>
        /// <returns>Integer List of ratings</returns>
        public List<int> RetrieveHotelRatings()
        {
            List<int> ratingList = new List<int>();
            foreach (var hotel in hotelList)
            {
                ratingList.Add(hotel.rating);
            }
            return ratingList;
        }

        /// <summary>
        /// Validates the Customer Type for Regular or Reward
        /// </summary>
        /// <param name="customerType">Customer Type entered by user</param>
        /// <returns>True or False for Valid Customer Type</returns>
        public bool ValidateCustomerType(string customerType)
        {
            return (Regex.IsMatch(customerType, rewardCustomerRegex) || Regex.IsMatch(customerType, regularCustomerRegex));
        }


        //public bool ContentEquals<TKey, TValue>(Dictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> otherDictionary)
        //{
        //    return (otherDictionary ?? new Dictionary<TKey, TValue>())
        //        .OrderBy(kvp => kvp.Key)
        //        .SequenceEqual((dictionary ?? new Dictionary<TKey, TValue>())
        //                           .OrderBy(kvp => kvp.Key));
        //}
    }
}