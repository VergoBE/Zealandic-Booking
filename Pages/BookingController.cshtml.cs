using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var userID = 0;
            try
            {
                userID = Int32.Parse(HttpContext.User.Identities.First().Claims.ElementAt(1).Value);

            }
            catch (Exception e)
            {
                return new JsonResult("");
            }
            Bookings = bookingService.GetBookings().ToList();
            foreach (Models.Booking item in Bookings)
            {
                if (item.Time.Day == Day && item.Time.Month == Month && item.Time.Year == Year && item.RoomID == roomID)
                {
                    bufferSTR = bufferSTR + "x" + item.Time.Hour.ToString()+ "x";
                }
                if (item.Time.Day == Day && item.Time.Month == Month && item.Time.Year == Year && item.UserID == userID)
                {
                    bufferSTR = bufferSTR + "x" + item.Time.Hour.ToString() + "x";
                }
                //DateTime currentDT = DateTime.Now;
                //CultureInfo cultureInfoCreate = CultureInfo.CreateSpecificCulture("en-DK");
                //string buffer = Year.ToString() + "/" + Month.ToString() + "/" + Day.ToString() + " 00.00.00";
                //DateTime itemDatetime = DateTime.Parse(buffer);
                //if (currentDT.Date <= itemDatetime.Date)
                //{
                //    bufferSTR = bufferSTR + "y" + item.Time.Hour.ToString() + "y";
                //}
            }
            return new JsonResult(bufferSTR);
        }
    }
}
