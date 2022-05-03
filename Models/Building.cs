using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zealandic_Booking.Models
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildingID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Building name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [ForeignKey("Location")]
        public int? LocationID { get; set; }
        public Location Location { get; set; }

        public Building(int buildingId, string buildingName, int locationId)
        {
            BuildingID = buildingId;
            Name = buildingName;
            LocationID = locationId;
        }

        public Building()
        {
            
        }
    }
}
