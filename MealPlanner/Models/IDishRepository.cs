using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SousChef.Models
{
    public interface IDishRepository
    {
        public Dish GetDish(int id);

        public IEnumerable<Dish> GetAllDishes();

        public Dish Add(Dish dish);

        public Dish Delete(int id);

        public Dish Update(Dish dishChanges);
    }
}
