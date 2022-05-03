using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zealandic_Booking.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }


        public User(int userId, string name, string role, string username, string password)
        {
            UserID = userId;
            Name = name;
            Role = role;
            Username = username;
            Password = password;
        }

        public User()
        {
            
        }
    }
}
