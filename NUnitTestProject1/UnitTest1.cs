using HotelReservation;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddingListofHotels_ShouldReturn_CountofHotelsinList()
        {
            HotelManager manager = new HotelManager();
            manager.AddHotel(new Hotel("Lakewood", 110, 80));
            manager.AddHotel(new Hotel("Bridgewood", 160, 120));
            manager.AddHotel(new Hotel("Ridgewood", 220, 180));

            int actual = manager.hotelList.Count;
            Assert.AreEqual(3, actual);

        }

        /// <summary>
        /// Test case to check for correct output list of cheap hotels for weekdays
        /// date range includes only weekdays
        /// </summary>
        [Test]
        public void GivenStartandEndDates_ShouldReturn_CheapestHotelForWeekdays()
        {
            HotelManager manager = new HotelManager();
            manager.CreateHotelList();

            DateTime startDate = Convert.ToDateTime("10Sep2020");
            DateTime endDate = Convert.ToDateTime("11Sep2020");

            Dictionary<Hotel, int> actualCheapHotelList = new Dictionary<Hotel, int>();
            actualCheapHotelList = manager.FindCheapHotel(startDate, endDate);
           
            Dictionary<Hotel, int> expectedCheapHotelList = new Dictionary<Hotel, int>();
            expectedCheapHotelList.Add(new Hotel("Lakewood", 110, 90), 220);
          
            Assert.AreEqual(expectedCheapHotelList, actualCheapHotelList);
        }

        /// <summary>
        /// Test case to check for correct output list of cheap hotels for weekdays & weekends
        /// date range includes both weekdays and weekends
        /// </summary>
        [Test]
        public void GivenStartandEndDates_ShouldReturn_CheapestHotelForWeekendandWeekdays()
        {
            HotelManager manager = new HotelManager();
            manager.CreateHotelList();

            DateTime startDate = Convert.ToDateTime("11Sep2020");
            DateTime endDate = Convert.ToDateTime("12Sep2020");

            Dictionary<Hotel, int> actualCheapHotelList = new Dictionary<Hotel, int>();
            actualCheapHotelList = manager.FindCheapHotel(startDate, endDate);

            Dictionary<Hotel, int> expectedCheapHotelList = new Dictionary<Hotel, int>();
            expectedCheapHotelList.Add(new Hotel("Lakewood", 110, 90), 200);
            expectedCheapHotelList.Add(new Hotel("Bridgewood", 220, 150), 200);

            Assert.AreEqual(expectedCheapHotelList, actualCheapHotelList);
        }





    }
}