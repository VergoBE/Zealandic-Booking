using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealandic_Booking.Models;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages.Admin
{
    //[Authorize(Roles = "admin")]
    public class CreateUserModel : PageModel
    {
        
        private UserService _userService;
        private PasswordHasher<string> passwordHasher;
        public List<User> Users { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The user's UserName cannot be longer than 100 characters.")]
        [BindProperty]
        public string UserName { get; set; }
        public int UserID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The user's name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The user's role cannot be longer than 50 characters.")]
        public string Role { get; set; }

        public CreateUserModel(UserService userService)
        {
            _userService = userService;
            passwordHasher = new PasswordHasher<string>();
        }
        public IActionResult OnGet()
        {
            Users = _userService.GetUsers().ToList();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(String gName, String gRole, String gUserName, String gPassword)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userService.AddUser(new User(null, gName, gRole, gUserName, passwordHasher.HashPassword(null, gPassword)));
            return RedirectToPage("/Index");
        }
    }
}
