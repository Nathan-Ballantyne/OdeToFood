using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IResturantData
    {
        IEnumerable<Restaurent> GetAll();
    }

    public class InMemoryResturantData : IResturantData
    {
        readonly List<Restaurent> restaurents;
        public InMemoryResturantData()
        {
            restaurents = new List<Restaurent>()
            {
                new Restaurent{Id=1, Location="Whakatane", Cuisine=CuisineType.Italian, Name="Nathans Pizza"},
                new Restaurent{Id=2, Location="Auckland", Cuisine=CuisineType.Mexican, Name="Carlos Spicy Mexican"},
                new Restaurent{Id=3, Location="Tauranga", Cuisine=CuisineType.Indian, Name="Gados Indian Restuarent"}
            };
        }
        public IEnumerable<Restaurent> GetAll()
        {
            return from r in restaurents
                   orderby r.Name
                   select r;
        }
    }
}
