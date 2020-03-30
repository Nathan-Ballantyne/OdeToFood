using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IResturantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurent Add(Restaurent newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurent Delete(int id)
        {
            var restaurant = GetById(id);
            if(restaurant != null)
            {
                db.Restaurents.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurent GetById(int id)
        {
            return db.Restaurents.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurents.Count();
        }

        public IEnumerable<Restaurent> GetRestaruentsByName(string name)
        {
            var query = from r in db.Restaurents
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurent Update(Restaurent updatedRestaurant)
        {
            var entity = db.Restaurents.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
