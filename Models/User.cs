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
        public int? UserID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The user's name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Role cannot be longer than 50 characters.")]
        public string Role { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Username cannot be longer than 100 characters.")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }


        public User(int? userId, string name, string role, string username, string password)
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
