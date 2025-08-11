using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.User
{
    public class DeleteUser : PageModel
    {
        private readonly IUserService userService;

        public DeleteUser(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var user = await userService.GetByIdAsync(id);

            if (user != null)
            {
                if (!(user.Role == Generics.Enums.UserRole.Admin && await userService.GetCountAsync(user.Role) <= 1))
                {
                    await userService.DeleteAsync(id);
                }
            }

            return Redirect("/Admin/User/UserList");
        }
    }
}
