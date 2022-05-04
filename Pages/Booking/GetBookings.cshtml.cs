using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages.Booking
{
    [Authorize(Roles = "Teacher")]
    [Authorize(Roles = "Student")]
    [Authorize(Roles = "admin")]
    public class GetBookingsModel : PageModel
    {
        private BookingService bookingService;

        public GetBookingsModel(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        public List<Models.Booking> Bookings { get; private set; }
        [BindProperty] public string SearchString { get; set; }

        public IActionResult OnGet()
        {
            Bookings = bookingService.GetBookings().ToList();
            return Page();
        }
    }
}
