using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages.WorkInProgress
{
    public class SimpleBookingModel : PageModel
    {
        private BookingService bookingService;
        private RoomService roomService;
        private UserService userService;
        public List<Models.Booking> Bookings { get; private set; }
        public List<Models.User> Users { get; private set; }
        public List<Models.Room> Rooms { get; private set; }
        public SimpleBookingModel(BookingService bookingService, RoomService roomService, UserService userService)
        {
            this.bookingService = bookingService;
            this.roomService = roomService;
            this.userService = userService;
        }

        public IActionResult OnGet()
        {
            Bookings = bookingService.GetBookings().ToList();
            Users = userService.GetUsers().ToList();
            Rooms = roomService.GetRooms().ToList();
            return Page();
        }
    }
}
