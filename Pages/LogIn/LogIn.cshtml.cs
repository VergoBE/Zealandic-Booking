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
        private ObjectService<User> _userService;

        public LogInModel(ObjectService<User> userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            IEnumerable<User> users = _userService.GetObjectlist();
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
                            new Claim(ClaimTypes.Role, user.Role),
                            new Claim(ClaimTypes.UserData, user.UserID.ToString()),
                            new Claim(ClaimTypes.Name, user.Name)
                        };

                        if (user.Role == "teacher") claims.Add(new Claim(ClaimTypes.Role, "teacher"));
                        if (user.Role == "admin") claims.Add(new Claim(ClaimTypes.Role, "admin"));
                        if (user.Role == "student")claims.Add( new Claim(ClaimTypes.Role, "student"));

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
