using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public class RoomService : IRoomService
    {
        private List<Room> rooms;
        public DBService<Room> DbService { get; set; }

        public RoomService(DBService<Room> dbService)
        {
            DbService = dbService;
            rooms = dbService.GetObjectsAsync().Result.ToList();
        }
        public async void AddRoom(Room room)
        {
            rooms.Add(room);
            await DbService.AddObjectAsync(room);
        }
        public IEnumerable<Room> GetRooms()
        {
            return rooms;
        }

        public IEnumerable<Room> GetRoomList(string id)
        {
            List<Room> roomSearch = new List<Room>();
            foreach (Room room in rooms)
            {
                if (room.Title.Contains(id))
                {
                    roomSearch.Add(room);
                }
                    
            }
            //return (from room in rooms where room.RoomID == id select room).FirstOrDefault();
            return roomSearch;
        }

        public Room GetRoom(int? id)
        {
            return (from room in rooms where room.RoomID == id select room).FirstOrDefault();
        }

        public async Task DeleteRoom(int roomId)
        {
            Room roomToBeDeleted = null;
            foreach (Room i in rooms)
            {
                if (i.RoomID == roomId)
                {
                    roomToBeDeleted = i;
                    break;
                }
            }
            //Room roomToBeDeleted = GetRoom(roomId);
            if (roomToBeDeleted != null)
            {
                rooms.Remove(roomToBeDeleted);
                _DeleteRoom(roomToBeDeleted);
            }
            
        }

        public async void _DeleteRoom(Room roomToBeDeleted)
        {
            await DbService.DeleteObjectAsync(roomToBeDeleted);
        }

        public async void UpdateRoom(Room room)
        {
            if (room != null)
            {
                await DbService.UpdateObjectAsync(room);
            }
        }
    }
}
