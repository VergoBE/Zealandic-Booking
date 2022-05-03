using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public class BuildingService
    {
        private List<Building> buildings;
        public DBService<Building> DbService { get; set; }

        public BuildingService(DBService<Building> dbService)
        {
            DbService = dbService;
            buildings = dbService.GetObjectsAsync().Result.ToList();
        }
        public async void AddItem(Building building)
        {
            buildings.Add(building);
            await DbService.AddObjectAsync(building);
        }
        public IEnumerable<Building> GetBuildings()
        {
            return buildings;
        }

        public Building GetBuilding(int id)
        {
            //foreach (Building building in buildings)
            //{
            //    if (building.BuildingID == id)
            //        return building;
            //}
            return (from building in buildings where building.BuildingID == id select building).FirstOrDefault();
            //return null;
        }

        public Building DeleteBuilding(int buildingId)
        {
            //Building buildingToBeDeleted = null;
            //foreach (Building i in buildings)
            //{
            //    if (i.BuildingID == buildingId)
            //    {
            //        buildingToBeDeleted = i;
            //        break;
            //    }
            //}
            Building buildingToBeDeleted = GetBuilding(buildingId);
            if (buildingToBeDeleted != null)
            {
                buildings.Remove(buildingToBeDeleted);
                _DeleteBuilding(buildingToBeDeleted);
            }
            return buildingToBeDeleted;
        }

        private async void _DeleteBuilding(Building buildingToBeDeleted)
        {
            await DbService.DeleteObjectAsync(buildingToBeDeleted);
        }

        public async void UpdateBuilding(Building building)
        {
            if (building != null)
            {
                await DbService.UpdateObjectAsync(building);
            }
        }
    }
}
