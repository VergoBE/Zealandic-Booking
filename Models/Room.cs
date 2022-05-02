using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zealandic_Booking.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public bool IT_Tools { get; set; }
        [ForeignKey("Building")]
        public int BuildingID { get; set; }
        [ForeignKey("Location")]
        public int LocationID { get; set; }

        public Room(int roomId, string roomName, string roomTitle, bool iTTools, int buildingId, int locationId)
        {
            RoomID = roomId;
            Name = roomName;
            Title = roomTitle;
            IT_Tools = iTTools;
            BuildingID = buildingId;
            LocationID = locationId;
        }

        public Room()
        {
            
        }
    }
}
