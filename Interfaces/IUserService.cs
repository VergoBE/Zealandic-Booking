using System.Collections.Generic;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public interface IUserService
    {
        DBService<User> DbService { get; set; }
        void AddUser(User user);
        IEnumerable<User> GetUsers();
        User GetUser(int? id);
        User DeleteUser(int userId);
        void _DeleteUser(User userToBeDeleted);
        void UpdateUser(User user);
    }
}