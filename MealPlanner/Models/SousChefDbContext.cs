using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SousChef.Models
{
    public class SousChefDbContext : DbContext
    {
        public SousChefDbContext(DbContextOptions<SousChefDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        Name = "Charlie",
                        Email = "myemail@email.com",
                        Location = "SomewhereOverTheRainbow"
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Hayley",
                        Email = "otherEmail@email.com",
                        Location = "Somewhere else"
                    }
                );
        }
    }
}
