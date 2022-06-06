using System.Collections.Generic;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public interface ILocationService
    {
        DBService<Location> DbService { get; set; }
        void AddLocation(Location location);
        IEnumerable<Location> GetLocations();
        Location GetLocation(int id);
        Location DeleteLocation(int locationId);
        void _DeleteLocation(Location locationToBeDeleted);
        void UpdateLocation(Location location);
    }
}