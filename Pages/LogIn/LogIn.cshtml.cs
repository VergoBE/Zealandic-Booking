using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zealandic_Booking.Models;
using Zealandic_Booking.Services;

namespace Zealandic_Booking.Pages.LogIn
{
    public class LogInModel : PageModel
    {
        private UserService _userService;

        public LogInModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string UserName { get; set; }

        public string Role { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            List<User> users = _userService.Users;
            foreach (User user in users)
            {
                if (UserName == user.Username)
                {
                    var passwordHasher = new PasswordHasher<string>();
                    if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)
                    {
                        //LoggedInUser = user;
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, UserName),
                            new Claim(ClaimTypes.Role, Role)
                        };

                        if (Role == "Teacher") claims.Add(new Claim(ClaimTypes.Role, "Teacher"));
                        if (UserName == "admin") claims.Add(new Claim(ClaimTypes.Role, "admin"));
                        if (Role == "Student")claims.Add( new Claim(ClaimTypes.Role, "Student"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Index");
                    }
                }
            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}
