using HotelReservation;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddingListofHotels_ShouldReturn_()
        {
            HotelManager manager = new HotelManager();
            manager.AddHotel(new Hotel("Lakewood", 110));
            manager.AddHotel(new Hotel("Bridgewood", 160));
            manager.AddHotel(new Hotel("Ridgewood", 220));

            int actual = manager.hotelList.Count;
            Assert.AreEqual(3, actual);

        }
    }
}