using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Domain.Generics;

namespace Domain.Api.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly IUserService userService;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public LoginModel(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await userService.GetUserByEmail(Email);
                var hashedPassword = Password.HashStringSHA512();

                if (user?.PasswordHash == hashedPassword)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, user.Role == Generics.Enums.UserRole.Admin ? "GraceSAllowAdmin" : "User")
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(new ClaimsPrincipal(identity));

                    return Redirect("/Admin/Users/UsersList");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return Page();
        }
    }
}
