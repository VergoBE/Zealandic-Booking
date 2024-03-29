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
    [Authorize(Roles = "teacher,admin,student")]
    public class DeleteBookingModel : PageModel
    {
        private BookingService _bookingService;
        private List<Models.Booking> bookings;

        [BindProperty]public string Message {get; set;}


        public DeleteBookingModel(BookingService bookingService)
        {
            this._bookingService = bookingService;
            bookings = bookingService.GetBookings().ToList();
        }
        [BindProperty] public Models.Booking SingleBooking { get; set; }
        public IActionResult OnGet(int id)
        {
            try
            {
                SingleBooking = _bookingService.GetBooking(id);
                Message = "Du sletter bookingen i " + SingleBooking.Room.Title +" ved " + SingleBooking.Time +" af "+ SingleBooking.User.Name;
                return Page();

            }
            catch
            {
                Message = "Vi l�b ind i en fejl, s� du blev sendt til forsiden";

                //return Redirect("/Index");
                return RedirectToPage("/Index",Message);
                
            }
            

        }
        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Models.Booking singleBooking = _bookingService.GetBooking(id);
            if (singleBooking.User.Role == "student" || singleBooking.User.Role == "teacher" || singleBooking.User.Role == "admin")
            {
                _bookingService.DeleteBooking(id);
                return RedirectToPage("../index");

            }
            else if(singleBooking.User.Role != "student" || singleBooking.User.Role != "teacher" || singleBooking.User.Role != "admin")
            {
                return RedirectToPage("../Admin/AccessDenied");
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


