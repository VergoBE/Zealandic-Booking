using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Zealandic_Booking.Models;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private BookingService bookingService;
        //private RoomService roomService;
        //private UserService userService;
        private ObjectService<User> userService;
        private ObjectService<Models.Room> roomService;
        //private ObjectService<User> userService;
        public int currentYear { get; set; }
        public int currentMonth { get; set; }
        public int currentDay { get; set; }
        public List<Models.Booking> Bookings { get; private set; }
        public List<Models.Booking> MyBookings { get; private set; }
        public List<User> Users { get; private set; }
        public List<Models.Room> Rooms { get; private set; }
        public bool LoginCheck { get; set; }
        public IndexModel(ILogger<IndexModel> logger, BookingService bookingService, ObjectService<Models.Room> roomService,ObjectService<User> userService)
        {
            _logger = logger;
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
            LoginCheck = true;
            try
            {
                string currentUserID = HttpContext.User.Identities.First().Claims.ElementAt(1).Value;
                DateTime currentDT = DateTime.Now;
                currentYear = currentDT.Year;
                currentMonth = currentDT.Month;
                currentDay = currentDT.Day;
                Bookings = bookingService.GetBookings().ToList();
                MyBookings = Bookings.Where(a => a.UserID == Int32.Parse(currentUserID)).ToList();
                Users = userService.GetObjectlistAsync();
                Rooms = roomService.GetObjectlistAsync();
                foreach (var item in Bookings)
                {
                    if (item.Time < currentDT)
                    {
                        bookingService.DeleteBooking(item.BookingID);
                    }   
                }
            }
            catch (Exception e)
            {
                LoginCheck = false;
                return RedirectToPage("/LogIn/LogIn");
            }
            
            
            return Page();
        }
        public Models.Room room { get; set; }
        public Models.User user { get; set; }
        public Models.Booking booking { get; set; }
        private DateTime datetime;
        private string buffer;


        public async Task<IActionResult> OnPost(int year, int month, int day, int postRoomID, int postUserID, string time)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string currentUserID = HttpContext.User.Identities.First().Claims.ElementAt(1).Value;

            Bookings = bookingService.GetBookings().ToList();
            Users = userService.GetObjectlistAsync();
            Rooms = roomService.GetObjectlistAsync();
            room = roomService.GetObjectByID(postRoomID);
            user = userService.GetObjectByID(postUserID);

            CultureInfo cultureInfoCreate = CultureInfo.CreateSpecificCulture("en-DK");
            buffer = year.ToString() + "/" + month.ToString() + "/" + day.ToString() + " " + time;
            datetime = DateTime.Parse(buffer,cultureInfoCreate);
            booking = new Models.Booking(null, datetime, postRoomID, Int32.Parse(currentUserID));
            var id = Bookings.Select(b => b.UserID);
            foreach (Models.Booking item in Bookings)
            {
                if (item.RoomID == booking.RoomID && item.Time == booking.Time)
                {
                    return RedirectToPage("/Index");
                }
            }
            await bookingService.AddBooking(booking);
            return RedirectToPage("/Index");
        }
    }
}
