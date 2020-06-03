using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SousChef.Models
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly SousChefDbContext context;
        public SqlUserRepository(SousChefDbContext context)
        {
            this.context = context;
        }
        public User Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            User user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users;
        }

        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public User Update(User userChanges)
        {
            var user = context.Users.Attach(userChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return userChanges;
        }
    }
}
