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
    public class DeleteBookingModel : PageModel
    {
        private BookingService _bookingService;
        private List<Models.Booking> bookings;

        public DeleteBookingModel(BookingService bookingService)
        {
            this._bookingService = bookingService;
            bookings = bookingService.GetBookings().ToList();
        }
        [BindProperty] public Models.Booking Booking { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _bookingService.DeleteBooking(id);
            return RedirectToPage("GetBookings");
        }
    }
}

