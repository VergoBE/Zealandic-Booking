using System.Collections.Generic;
using System.Threading.Tasks;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public interface IRoomService
    {
        DBService<Room> DbService { get; set; }
        void AddRoom(Room room);
        IEnumerable<Room> GetRooms();
        IEnumerable<Room> GetRoomList(string id);
        Room GetRoom(int? id);
        Task DeleteRoom(int roomId);
        void _DeleteRoom(Room roomToBeDeleted);
        void UpdateRoom(Room room);
    }
}