using Domain.Services.Contracts.Services;
using Domain.Services.Services;
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

        public IActionResult OnGet(Guid? id)
        {
            var user = userService.GetByIdAsync(id);

            if (user != null)
            {
                userService.DeleteAsync(id);
            }

            return Redirect("/Admin/Users/UsersList");
        }
    }
}
