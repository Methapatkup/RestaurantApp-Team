
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp
{
    internal class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }

        public Restaurant(int id, string name, string type, double rating)
        {
            Id = id;
            Name = name;
            Type = type;
            Rating = rating;
        }
    }

    internal class Program
    {
        // List เก็บข้อมูลร้านอาหาร
        static List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant(1, "Quanjude Roast Duck", "Beijing Cuisine", 4.5),
            new Restaurant(2, "Donglaishun Hot Pot", "Hot Pot", 4.6),
            new Restaurant(3, "Din Tai Fung", "Taiwanese Cuisine", 4.7),
            new Restaurant(4, "Haidilao Hot Pot", "Hot Pot", 4.8),
            new Restaurant(5, "Yang's Dumplings", "Chinese Cuisine", 4.3)
        };

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n================================");
                Console.WriteLine("       RESTAURANT APP");
                Console.WriteLine("================================");
                Console.WriteLine("1. Add Restaurant");
                Console.WriteLine("2. Show All Restaurants");
                Console.WriteLine("0. Exit");
                Console.WriteLine("================================");
                Console.Write("Select menu: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1;
                }

                switch (choice)
                {
                    case 1:
                        AddRestaurant();
                        break;

                    case 2:
                        ShowRestaurants();
                        break;

                    case 0:
                        Console.WriteLine("Exit Program");
                        break;

                    default:
                        Console.WriteLine("Invalid menu!");
                        break;
                }

            } while (choice != 0);
        }

        // A: เพิ่มข้อมูลร้านอาหาร
        static void AddRestaurant()
        {
            Console.WriteLine("\n--- Add Restaurant ---");

            Console.Write("Enter restaurant name: ");
            string name = Console.ReadLine();

            Console.Write("Enter restaurant type: ");
            string type = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(type))
            {
                Console.WriteLine("Please enter all information.");
                return;
            }

            Console.Write("Enter restaurant rating (0-5): ");

            double rating;

            while (!double.TryParse(Console.ReadLine(), out rating)
                || rating < 0 || rating > 5)
            {
                Console.Write("Please enter rating between 0-5: ");
            }

            int newId = restaurants.Count == 0
                ? 1
                : restaurants.Max(r => r.Id) + 1;

            Restaurant newRestaurant =
                new Restaurant(newId, name, type, rating);

            restaurants.Add(newRestaurant);

            Console.WriteLine("\nRestaurant added successfully!");
            Console.WriteLine("Restaurant ID: " + newId);
        }

        // แสดงรายชื่อร้านอาหารทั้งหมด
        static void ShowRestaurants()
        {
            Console.WriteLine("\n=== Restaurant List ===");
            Console.WriteLine("ID | Name | Type | Rating");

            foreach (Restaurant restaurant in restaurants)
            {
                Console.WriteLine(
                    $"{restaurant.Id} | {restaurant.Name} | " +
                    $"{restaurant.Type} | {restaurant.Rating:F1}"
                );
            }

            int totalRestaurants = restaurants.Count;

            double averageRating = restaurants.Average(r => r.Rating);

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Total restaurants: {totalRestaurants}");
            Console.WriteLine($"Average rating: {averageRating:F2}");

            double maxRating = restaurants.Max(r => r.Rating);
            double minRating = restaurants.Min(r => r.Rating);

            var highestRated = restaurants.Where(r => r.Rating == maxRating).ToList();
            var lowestRated = restaurants.Where(r => r.Rating == minRating).ToList();

            Console.WriteLine("------------------------------");
            Console.WriteLine("=== Summary ===");

            Console.WriteLine($"Highest rating ({maxRating}):");
            foreach (Restaurant r in highestRated)
            {
                Console.WriteLine($"  - {r.Name} ({r.Type})");
            }

            Console.WriteLine($"Lowest rating ({minRating}):");
            foreach (Restaurant r in lowestRated)
            {
                Console.WriteLine($"  - {r.Name} ({r.Type})");
            }


        }
    }
}
