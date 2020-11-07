using System;
using System.Collections.Generic;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System\n");
            HotelManager manager = new HotelManager();
            bool val = true;
            while (val)
            {
                Console.WriteLine("Choose among the following option\n1.Add Hotel\n2.Display Hotel\n3.Exit\n4.Find Cheapest Hotel");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            manager.AddHotel(new Hotel("Bridgewood", 150, 50));
                            manager.AddHotel(new Hotel("Ridgewood", 220, 150));
                            manager.AddHotel(new Hotel("Lakewood", 110, 90));
                            break;
                        }

                    case 2:
                        {
                            manager.DisplayHotels();
                            break;
                        }

                    case 3:
                        {
                            val = false;
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Enter the startDate");
                            DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Enter the endDate");
                            DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                            Dictionary<Hotel, int> cheapHotelList = manager.FindCheapHotel(startDate, endDate);
                            foreach (var kvp in cheapHotelList)
                            {
                                Console.WriteLine("Cheapest Hotel will be: " + kvp.Key.hotelName + " with price $" + kvp.Value);
                            }
                            break;
                        }

                    default: break;
                }
            }
        }
    }
}
