using System;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryResturantData : IResturantData
    {
        readonly List<Restaurent> restaurents;
        public InMemoryResturantData()
        {
            restaurents = new List<Restaurent>()
            {
                new Restaurent{Id=1, Location="Whakatane", Cuisine=CuisineType.Italian, Name="Nathans Pizza"},
                new Restaurent{Id=2, Location="Auckland", Cuisine=CuisineType.Mexican, Name="Mexico"},
                new Restaurent{Id=3, Location="Tauranga", Cuisine=CuisineType.Indian, Name="Spice Junction"}
            };
        }

        public Restaurent GetById(int id)
        {
            return restaurents.SingleOrDefault(r => r.Id == id);
        }


        public Restaurent Update(Restaurent updatedRestaurant)
        {
            var restaurent = restaurents.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurent != null)
            {
                restaurent.Name = updatedRestaurant.Name;
                restaurent.Location = updatedRestaurant.Location;
                restaurent.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurent;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurent> GetRestaruentsByName(string name = null)
        {
            return from r in restaurents
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurent Add(Restaurent newRestaurant)
        {

            restaurents.Add(newRestaurant);
            newRestaurant.Id = restaurents.Max(r => r.Id) + 1;
            return newRestaurant;

        }

        public Restaurent Delete(int id)
        {
            var restaurant = restaurents.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurents.Remove(restaurant);
            }
            return restaurant;
        }
    }
}
