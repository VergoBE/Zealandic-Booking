using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages.Room
{
    public class GetRoomsModel : PageModel
    {
        private RoomService roomService;

        public GetRoomsModel(RoomService roomService)
        {
            this.roomService = roomService;
        }

        public List<Models.Room> Rooms { get;  private set; }
        
        public IActionResult OnGet()
        {
            Rooms = roomService.GetRooms().ToList();
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            Rooms = roomService.GetRoom(id).ToList();
            return Page();
        }
    }
}
