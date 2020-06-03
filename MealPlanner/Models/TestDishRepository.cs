using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SousChef.Models
{
    public class TestDishRepository : IDishRepository
    {
        private List<Dish> _dishList;
        public TestDishRepository()
        {
            _dishList = new List<Dish>
            {
                new Dish() { DishId = 1, Name = "TestDish1" },
                new Dish() { DishId = 2, Name = "TestDish2" }
            };
        }

        public void Add(Dish dish)
        {
            _dishList.Add(dish);
        }

        public Dish Delete(int id)
        {
            Dish dish = _dishList.FirstOrDefault(e => e.DishId == id);
            if (dish != null)
            {
                _dishList.Remove(dish);
            }

            return dish;
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            return _dishList;
        }

        public Dish GetDish(int id)
        {
            return _dishList.FirstOrDefault(d => d.DishId == id);
        }

        public Dish Update(Dish dishChanges)
        {
            Dish dish = _dishList.FirstOrDefault(e => e.DishId == dishChanges.DishId);
            if (dish != null)
            {
                dish = dishChanges;
            }

            return dishChanges;
        }

        Dish IDishRepository.Add(Dish dish)
        {
            dish.DishId = _dishList.Max(e => e.DishId) + 1;
            _dishList.Add(dish);
            return dish;
        }
    }
}
