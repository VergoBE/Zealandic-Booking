using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zealandic_Booking.Models;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Interfaces
{
    public interface IBookingService
    {
        DBService<Booking> DbService { get; set; }
        Task AddBooking(Booking booking);
        IEnumerable<Booking> GetBookings();
        Booking GetBooking(int? id);
        Booking DeleteBooking(int? bookingId);
        void _DeleteBooking(Booking bookingToBeDeleted);
        void UpdateBooking(Booking booking);
    }
}
