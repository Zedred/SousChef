using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SousChef.Models
{
    public class TestUserRepository : IUserRepository
    {
        private List<User> _userList;

        public TestUserRepository()
        {
            _userList = new List<User>()
            {
                new User() { Id = 1, Name = "Charlie", Email = "MyEmail@whatever.com", Location = "BumFuckNowhere, AL"},
                new User() { Id = 2, Name = "Hayley", Email = "HockeyGirl@something.com", Location = "BumFuckNowhere, NZ"}
            };
        }

        public User Add(User user)
        {
            user.Id = _userList.Max(e => e.Id) + 1;
            _userList.Add(user);
            return user;
        }

        public User Delete(int id)
        {
            User user = _userList.FirstOrDefault(e => e.Id == id);
            if (user != null)
            {
                _userList.Remove(user);
            }

            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userList;
        }

        public User GetUser(int inId)
        {
            return _userList.FirstOrDefault(e => e.Id == inId);
        }

        public User Update(User userChanges)
        {
            User user = _userList.FirstOrDefault(e => e.Id == userChanges.Id);
            if (user != null)
            {
                user = userChanges;
            }

            return userChanges;
        }
    }
}
