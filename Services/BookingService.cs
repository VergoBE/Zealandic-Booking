using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zealandic_Booking.Interfaces;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public class BookingService : IBookingService
    {
        private List<Booking> bookings;
        public DBService<Booking> DbService { get; set; }

        public BookingService(DBService<Booking> dbService)
        {
            DbService = dbService;
            bookings = dbService.GetObjectsAsync().Result.ToList();
        }
        public async Task AddBooking(Booking booking)
        {
            bookings.Add(booking);
            await DbService.AddObjectAsync(booking);
        }
        public IEnumerable<Booking> GetBookings()
        {
            return bookings;
        }

        public Booking GetBooking(int id)
        {

            //foreach (Booking booking in bookings)
            //{
            //    if (booking.BookingID == id) 
            //        return booking;
            //}
            return (from booking in bookings where booking.BookingID == id select booking).FirstOrDefault();
            //return null;
        }
        
        public Booking DeleteBooking(int bookingId)
        {
            //Booking bookingToBeDeleted = null;
            Booking bookingToBeDeleted = GetBooking(bookingId);
            //foreach (Booking i in bookings)
            //{
            //    if (i.BookingID == bookingId)
            //    {
            //        bookingToBeDeleted = i;
            //        break;
            //    }
            //}
            
            if (bookingToBeDeleted != null)
            {
              bookings.Remove(bookingToBeDeleted);
              _DeleteBooking(bookingToBeDeleted);
            }
            return bookingToBeDeleted;
        }

        private async void _DeleteBooking(Booking bookingToBeDeleted)
        {
            await DbService.DeleteObjectAsync(bookingToBeDeleted);
        }

        public async void UpdateBooking(Booking booking)
        {
            if (booking != null)
            {
                await DbService.UpdateObjectAsync(booking);
            }
        }
    }
}
