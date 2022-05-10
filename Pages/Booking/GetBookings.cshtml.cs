using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealandic_Booking.Models;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages.Booking
{
    [Authorize(Roles = "Teacher")]
    [Authorize(Roles = "Student")]
    [Authorize(Roles = "admin")]
    public class GetBookingsModel : PageModel
    {
        private BookingService bookingService;
        private UserService userService;
        private RoomService roomService;
        private IEnumerable<User> users;
        private IEnumerable<Models.Room> rooms;

        public GetBookingsModel(BookingService bookingService, UserService userService, RoomService roomService)
        {
            this.bookingService = bookingService;
            this.userService = userService;
            this.roomService = roomService;

        }

        public List<Models.Booking> Bookings { get; private set; }
        [BindProperty] public string SearchString { get; set; }

        public IActionResult OnGet()
        {
            Bookings = bookingService.GetBookings().ToList();
            Bookings = (from booking in Bookings orderby booking.Time.Date select booking).ToList();
            users = userService.GetUsers();
            rooms = roomService.GetRooms();
            foreach (var booking in Bookings)
            {
                foreach (var user in users)
                {
                    if (booking.UserID == user.UserID)
                    {
                        booking.User = user;
                    }
                }
                foreach (var room in rooms)
                {
                    if (booking.RoomID == room.RoomID)
                    {
                        booking.Room = room;
                    }
                }
            }

            return Page();
        }
    }
}
