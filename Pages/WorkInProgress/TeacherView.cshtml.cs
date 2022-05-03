using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages.WorkInProgress
{
    public class TeacherViewModel : PageModel
    {
        #region Properties
        private UserService UserService { get; set; }
        private BookingService BookingService { get; set; }

        public List<Models.Booking> Bookings { get; set; }


        #endregion

        #region Constructor

        public TeacherViewModel(BookingService bookingService, UserService userService)
        {
            UserService = userService;
            BookingService = bookingService;
            Bookings = bookingService.GetBookings().ToList();
        }

        #endregion
        public void OnGet()
        {
        }
    }
}
