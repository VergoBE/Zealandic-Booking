using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public class LocationService
    {
        private List<Location> locations;
        public DBService<Location> DbService { get; set; }

        public LocationService(DBService<Location> dbService)
        {
            DbService = dbService;
            locations = dbService.GetObjectsAsync().Result.ToList();
        }
        public async void AddItem(Location location)
        {
            locations.Add(location);
            await DbService.AddObjectAsync(location);
        }
        public IEnumerable<Location> GetLocations()
        {
            return locations;
        }

        public Location GetLocation(int id)
        {
            foreach (Location location in locations)
            {
                if (location.LocationID == id)
                    return location;
            }

            return null;
        }

        public Location DeleteLocation(int locationId)
        {
            Location locationToBeDeleted = null;
            foreach (Location i in locations)
            {
                if (i.LocationID == locationId)
                {
                    locationToBeDeleted = i;
                    break;
                }
            }
            if (locationToBeDeleted != null)
            {
                locations.Remove(locationToBeDeleted);
                _DeleteLocation(locationToBeDeleted);
            }
            return locationToBeDeleted;
        }

        private async void _DeleteLocation(Location locationToBeDeleted)
        {
            await DbService.DeleteObjectAsync(locationToBeDeleted);
        }

        public async void UpdateLocation(Location location)
        {
            if (location != null)
            {
                await DbService.UpdateObjectAsync(location);
            }
        }
    }
}
