using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages.WorkInProgress
{
    public class SimpleBookingModel : PageModel
    {
        private BookingService bookingService;
        private RoomService roomService;
        private UserService userService;
        public int currentYear { get; set; }
        public int currentMonth { get; set; }
        public int currentDay { get; set; }
        public List<Models.Booking> Bookings { get; private set; }
        public List<Models.User> Users { get; private set; }
        public List<Models.Room> Rooms { get; private set; }
        public List<DateTime> allDateTimes { get; private set; }
        public SimpleBookingModel(BookingService bookingService, RoomService roomService, UserService userService)
        {
            this.bookingService = bookingService;
            this.roomService = roomService;
            this.userService = userService;
            DateTime currentDT = DateTime.Now;
            currentYear = currentDT.Year;
            currentMonth = currentDT.Month;
            currentDay = currentDT.Day;
        }

        public IActionResult OnGet()
        {
            DateTime currentDT = DateTime.Now;
            currentYear = currentDT.Year;
            currentMonth = currentDT.Month;
            currentDay = currentDT.Day;
            Bookings = bookingService.GetBookings().ToList();
            Users = userService.GetUsers().ToList();
            Rooms = roomService.GetRooms().ToList();
            foreach (var item in Bookings)
            {
                //allDateTimes.Add(item.Time);
            }
            return Page();
        }

        //public int year { get; set; }
        //public int month { get; set; }
        //public int day { get; set; }
        public Models.Room room { get; set; }
        public Models.User user { get; set; }
        public Models.Booking booking { get; set; }
        //public string time { get; set; }
        //public int postRoomID { get; set; }
        //public int postUserID { get; set; }
        private DateTime datetime;
        private string buffer;
        public string Message { get; set; }
        

        public async Task<IActionResult> OnPost(int year, int month, int day, int postRoomID, int postUserID, string time)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
                Bookings = bookingService.GetBookings().ToList();
                Users = userService.GetUsers().ToList();
                Rooms = roomService.GetRooms().ToList();
                room = roomService.GetRoom(postRoomID);
                user = userService.GetUser(postUserID);
            var id = Bookings.Select(b => b.UserID);
            foreach(int number in id)
                if (number != postUserID || time != datetime.ToString())
                {
                CultureInfo cultureInfoCreate = CultureInfo.CreateSpecificCulture("en-DK");
                buffer = year.ToString() + "/" + month.ToString() + "/" + day.ToString() + " " + time;
                datetime = DateTime.Parse(buffer,cultureInfoCreate);
                booking = new Models.Booking(null, datetime, postRoomID, postUserID);
                await bookingService.AddBooking(booking);
                }
                else if(postUserID == number || time == datetime.ToString() )
                {
                    Message = "Du har allerede booked!";
                }
            return RedirectToPage("/Index");
        }
    }
}
