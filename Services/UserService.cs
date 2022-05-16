using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public class UserService
    {
        private List<User> users;
        public DBService<User> DbService { get; set; }

        public UserService(DBService<User> dbService)
        {
            DbService = dbService;
            users = dbService.GetObjectsAsync().Result.ToList();
        }
        public async void AddUser(User user)
        {
            users.Add(user);
            await DbService.AddObjectAsync(user);
        }
        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUser(int? id)
        {
            //foreach (User user in users)
            //{
            //    if (user.UserID == id)
            //        return user;
            //}
            return (from user in users where user.UserID == id select user).FirstOrDefault();
        }

        public User DeleteUser(int userId)
        {
            //User userToBeDeleted = null;
            User userToBeDeleted = GetUser(userId); 
            //foreach (User i in users)
            //{
            //    if (i.UserID == userId)
            //    {
            //        userToBeDeleted = i;
            //        break;
            //    }
            //}
            if (userToBeDeleted != null)
            {
                users.Remove(userToBeDeleted);
                _DeleteUser(userToBeDeleted);
            }
            return userToBeDeleted;
        }

        private async void _DeleteUser(User userToBeDeleted)
        {
            await DbService.DeleteObjectAsync(userToBeDeleted);
        }

        public async void UpdateUser(User user)
        {
            if (user != null)
            {
                await DbService.UpdateObjectAsync(user);
            }
        }
    }
}
