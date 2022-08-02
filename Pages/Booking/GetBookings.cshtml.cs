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
    
    [Authorize(Roles = "admin,teacher,student")]
    public class GetBookingsModel : PageModel
    {
        private BookingService bookingService;
        //private UserService userService;
        //private RoomService roomService;
        private ObjectService<Models.Room> roomService;
        private ObjectService<User> userService;
        private IEnumerable<User> users;
        private IEnumerable<Models.Room> rooms;

        public GetBookingsModel(BookingService bookingService, ObjectService<User> userService, ObjectService<Models.Room> roomService)
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


            return Page();
        }
    }
}
