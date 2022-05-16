using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? BookingID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }
        [ForeignKey("Room")] 
        public int? RoomID { get; set; }
        [ForeignKey("User")] 
        public int? UserID { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
        private UserService UserService { get; set; }
        

        public Booking(int? bookingId, DateTime bookingTime, int roomId, int userId)
        {
            BookingID = bookingId;
            Time = bookingTime;
            RoomID = roomId;
            UserID = userId;
        }
        public Booking()
        {
            
        }
    }
}
