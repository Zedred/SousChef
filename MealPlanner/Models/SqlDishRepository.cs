using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SousChef.Models
{
    public class SqlDishRepository : IDishRepository
    {
        private readonly SousChefDbContext context;

        public SqlDishRepository(SousChefDbContext context)
        {
            this.context = context;
        }

        public Dish Add(Dish dish)
        {
            context.Dishes.Add(dish);
            context.SaveChanges();
            return dish;
        }

        public Dish Delete(int id)
        {
            Dish dish = context.Dishes.Find(id);
            if (dish != null)
            {
                context.Dishes.Remove(dish);
                context.SaveChanges();
            }
            return dish;
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            return context.Dishes;
        }

        public Dish GetDish(int id)
        {
            return context.Dishes.Find(id);
        }

        public Dish Update(Dish dishChanges)
        {
            var dish = context.Dishes.Attach(dishChanges);
            dish.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return dishChanges;
        }
    }
}
