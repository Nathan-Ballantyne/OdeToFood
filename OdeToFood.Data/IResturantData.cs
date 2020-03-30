using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IResturantData
    {
        IEnumerable<Restaurent> GetRestaruentsByName(string name);
        Restaurent GetById(int id);
        Restaurent Update(Restaurent updatedRestaurant);
        Restaurent Add(Restaurent newRestaurant);
        Restaurent Delete(int id);
        int Commit();
        int GetCountOfRestaurants();
    }
}
