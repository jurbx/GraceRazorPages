using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Api.Pages.Admin.Users
{
    public class CreateUserModel : PageModel
    {
        private readonly IUserService userService;

        [BindProperty]
        public User User { get; set; }

        public CreateUserModel(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task OnGetAsync(Guid? id)
        {
            var user = await userService.GetByIdAsync(id);

            if (user != null)
            {
                User = user;
            }
        }

        public async Task<IActionResult> OnPostAsync(User user)
        {
            if (User?.Id != null)
            {
                await userService.UpdateAsync(user);
            }
            else
            {
                await userService.CreateAsync(user);
            }

            return Redirect("/Admin/Users/UsersList");
        }
    }
}
