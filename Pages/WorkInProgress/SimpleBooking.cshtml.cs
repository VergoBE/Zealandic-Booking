using System;
using System.Collections.Generic;
using System.Linq;
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
            return Page();
        }

        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public Models.Room room { get; set; }
        public Models.User user { get; set; }
        public int time { get; set; }
        public int postRoomID { get; set; }
        public int postUserID { get; set; }

        public void OnPost(int year, int month, int day, int postRoomID, int postUserID, int time)
        {
            room = roomService.GetRoom(postRoomID);
            user = userService.GetUser(postUserID);
        }
    }
}
