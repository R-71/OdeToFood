using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Ray's Pizza", Location="LA", Cuisine=CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Mahid's coffe", Location="India", Cuisine=CuisineType.Indian},
                new Restaurant {Id = 3, Name = "Paulo's Burgers", Location="Mexico", Cuisine=CuisineType.Mexician},
            };
        }
        public Restaurant GetById(int Id)
        {
            return restaurants.SingleOrDefault(r => r.Id == Id);
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            Console.WriteLine(restaurants[0].Name);
            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            Console.WriteLine(restaurants[0].Name);
            return from restaurant in restaurants
                   where string.IsNullOrEmpty(name) || restaurant.Name.ToLower().StartsWith(name.ToLower())
                   orderby restaurant.Id
                   select restaurant;
        }
    }

}
