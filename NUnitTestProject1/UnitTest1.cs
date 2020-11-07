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
            manager.AddHotel(new Hotel("Lakewood", 110, 80, 80, 80, 3));
            manager.AddHotel(new Hotel("Bridgewood", 160, 120, 100, 40, 4));
            manager.AddHotel(new Hotel("Ridgewood", 220, 180, 110, 50, 5));

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
            actualCheapHotelList = manager.FindCheapHotel(startDate, endDate, 0);

            Dictionary<Hotel, int> expectedCheapHotelList = new Dictionary<Hotel, int>();
            expectedCheapHotelList.Add(new Hotel("Lakewood", 110, 90, 80, 80, 3), 220);

            CollectionAssert.AreEqual(expectedCheapHotelList, actualCheapHotelList);
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
            actualCheapHotelList = manager.FindCheapHotel(startDate, endDate, 0);

            Dictionary<Hotel, int> expectedCheapHotelList = new Dictionary<Hotel, int>();
            expectedCheapHotelList.Add(new Hotel("Lakewood", 110, 90, 80, 80, 3), 200);
            expectedCheapHotelList.Add(new Hotel("Bridgewood", 160, 120, 100, 40, 4), 200);

            CollectionAssert.AreEquivalent(expectedCheapHotelList, actualCheapHotelList);
        }

        [Test]
        public void GiventheListofHotels_ShouldReturn_TheirRatings()
        {
            HotelManager manager = new HotelManager();
            manager.CreateHotelList();

            List<int> ratingList = new List<int>();
            ratingList = manager.RetrieveHotelRatings();

            List<int> expectedRatingList = new List<int>() { 3, 4, 5 };

            CollectionAssert.AreEqual(ratingList, expectedRatingList);

        }

        /// <summary>
        /// Test case to check for correct output list of cheap hotels for weekdays & weekends
        /// date range includes both weekdays and weekends
        /// should return results considering ratings as well
        /// </summary>
        [Test]
        public void GivenStartandEndDates_ShouldReturn_CheapestHotelForWeekendandWeekdaysRATINGS()
        {
            HotelManager manager = new HotelManager();
            manager.CreateHotelList();

            DateTime startDate = Convert.ToDateTime("11Sep2020");
            DateTime endDate = Convert.ToDateTime("12Sep2020");

            Dictionary<Hotel, int> actualCheapHotelList = new Dictionary<Hotel, int>();
            actualCheapHotelList = manager.FindCheapestBestRatedHotel(startDate, endDate, 0);

            Dictionary<Hotel, int> expectedCheapHotelList = new Dictionary<Hotel, int>();
            expectedCheapHotelList.Add(new Hotel("Lakewood", 110, 90, 80, 80, 3), 200);
            expectedCheapHotelList.Add(new Hotel("Bridgewood", 160, 120, 100, 40, 4), 200);

            CollectionAssert.AreEquivalent(expectedCheapHotelList, actualCheapHotelList);
        }


        /// <summary>
        /// Test case to check for correct output list of cheap hotels for weekdays & weekends
        /// date range includes both weekdays and weekends 
        /// should return results considering ratings as well FOR A REWARD CUSTOMER
        /// </summary>
        [Test]
        public void GivenStart_EndDates_Type_ShouldReturn_CheapestHotelForWeekendandWeekdaysREWARD()
        {
            HotelManager manager = new HotelManager();
            manager.CreateHotelList();

            DateTime startDate = Convert.ToDateTime("11Sep2020");
            DateTime endDate = Convert.ToDateTime("12Sep2020");

            Dictionary<Hotel, int> actualCheapHotelList = new Dictionary<Hotel, int>();
            actualCheapHotelList = manager.FindCheapestBestRatedHotel(startDate, endDate, 1);

            Dictionary<Hotel, int> expectedCheapHotelList = new Dictionary<Hotel, int>();
            expectedCheapHotelList.Add(new Hotel("Ridgewood", 220, 190, 110, 50, 3), 140);

            CollectionAssert.AreEquivalent(expectedCheapHotelList, actualCheapHotelList);
        }





    }
}

