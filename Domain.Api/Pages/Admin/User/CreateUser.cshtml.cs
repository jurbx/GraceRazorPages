using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.User
{
    public class CreateUserModel : PageModel
    {
        private readonly IUserService userService;

        [BindProperty]
        public Persistance.Entities.Entities.User User { get; set; }

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

        public async Task<IActionResult> OnPostAsync(Persistance.Entities.Entities.User user)
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
