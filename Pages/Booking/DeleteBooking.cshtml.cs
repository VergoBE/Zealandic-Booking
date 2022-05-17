using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealandic_Booking.Models;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages.Booking
{
    [Authorize(Roles = "Teacher,admin")]
    public class DeleteBookingModel : PageModel
    {
        private BookingService _bookingService;
        private List<Models.Booking> bookings;
        private UserService userService;
        private IEnumerable<User> users;

        [BindProperty] public string Message {get; set;}


        public DeleteBookingModel(BookingService bookingService, UserService userService)
        {
            this._bookingService = bookingService;
            this.userService = userService;
            bookings = bookingService.GetBookings().ToList();
            users = userService.GetUsers();
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

            Models.Booking singleBooking = _bookingService.GetBooking(id);
            if (singleBooking.User.Role == "student")
            {
                _bookingService.DeleteBooking(id);
                Message = "the booking at " + singleBooking.Time + " is deleted";
            }
            else
            {
                
            }
           
                    //MailMessage eMailMessage = new MailMessage();
                    //eMailMessage.From = new MailAddress("email@edu.zealand.dk",User.Identity.ToString());
                    //eMailMessage.To.Add(new MailAddress(booking.User.Username+"@edu.zealand.dk",booking.User.Name));
                    //eMailMessage.Subject = "Your Booking was removed";
                    //eMailMessage.Body = "Your booking was removed by"+User.Identity+"\n Consider making a new booking";
                    //eMailMessage.Priority = MailPriority.Normal;
                    //using (SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587))
                    //{
                    //    MailClient.EnableSsl = true;
                    //    MailClient.Credentials = new System.Net.NetworkCredential("account2@gmail.com", "password");
                    //    MailClient.Send(eMailMessage);
                    //}
            return Page();
        }

            

            //return RedirectToPage("GetBookings");
    }
}


