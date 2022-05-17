using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Zealandic_Booking.Models;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages.WorkInProgress
{
    public class BookingControllerModel : PageModel
    {
        private BookingService bookingService;
        public List<Models.Booking> Bookings { get; private set; }
        private string bufferSTR;

        public BookingControllerModel(BookingService bs)
        {
            bookingService = bs;
        }
        public JsonResult OnGet(int Year, int Month, int Day, int roomID)
        {
            //var userID = Int32.Parse(HttpContext.User.Identities.First().Claims.ElementAt(1).Value);
            Bookings = bookingService.GetBookings().ToList();
            foreach (Models.Booking item in Bookings)
            {
                if (item.Time.Day == Day && item.Time.Month == Month && item.Time.Year == Year && item.RoomID == roomID)
                {
                    bufferSTR = bufferSTR + "x" + item.Time.Hour.ToString()+ "x";
                }
            }
            return new JsonResult(bufferSTR);
        }
    }
}
