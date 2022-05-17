using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zealandic_Booking.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MemberID { get; set; }
        [ForeignKey("Booking")]
        public int? BookingID { get; set; }
        [ForeignKey("User")]
        public int? UserID { get; set; }
        public User User { get; set; }
        public Booking Booking{ get; set; }

        public Member(int? memberId, int? bookingId, int? userId)
        {
            MemberID = memberId;
            BookingID = bookingId;
            UserID = userId;
        }

        public Member()
        {
            
        }
    }
}
