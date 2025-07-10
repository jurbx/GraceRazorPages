using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService userService;

        [BindProperty]
        public User InputUser { get; set; }

        public RegisterModel(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await userService.CreateAsync(InputUser);

            return Redirect("/Admin/Users/UsersList");
        }
    }
}
