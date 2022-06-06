using System.Collections.Generic;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public interface IBuildingService
    {
        DBService<Building> DbService { get; set; }
        void AddBuilding(Building building);
        IEnumerable<Building> GetBuildings();
        Building GetBuilding(int id);
        Building DeleteBuilding(int buildingId);
        void _DeleteBuilding(Building buildingToBeDeleted);
        void UpdateBuilding(Building building);
    }
}