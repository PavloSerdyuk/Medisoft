using System.Collections.Generic;

namespace ADO_DAL.Interfaces
{
    public interface IDishRepository
    {
        IList<Dish> GetDishes();
        Dish GetDishById(int? id);
        Dish CreateDish(Dish dish);
        Dish UpdateDish(Dish dish);
        bool DeleteDishById(int? id);
    }
}
