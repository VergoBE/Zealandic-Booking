﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public class RoomService
    {
        private List<Room> rooms;
        public DBService<Room> DbService { get; set; }

        public RoomService(DBService<Room> dbService)
        {
            DbService = dbService;
            rooms = dbService.GetObjectsAsync().Result.ToList();
        }
        public async void AddItem(Room room)
        {
            rooms.Add(room);
            await DbService.AddObjectAsync(room);
        }
        public IEnumerable<Room> GetRooms()
        {
            return rooms;
        }

        public IEnumerable<Room> GetRoom(int id)
        {
            List<Room> roomSearch = new List<Room>();
            foreach (Room room in rooms)
            {
                if (room.RoomID == id)
                {
                    roomSearch.Add(room);
                }
                    
            }
            //return (from room in rooms where room.RoomID == id select room).FirstOrDefault();
            return roomSearch;
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

        private async void _DeleteRoom(Room roomToBeDeleted)
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
