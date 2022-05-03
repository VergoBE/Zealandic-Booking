using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zealandic_Booking.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Location name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }

        public Location(int locationId, string name, string address)
        {
            LocationID = locationId;
            Name = name;
            Address = address;
        }

        public Location()
        {
            
        }
    }
}
