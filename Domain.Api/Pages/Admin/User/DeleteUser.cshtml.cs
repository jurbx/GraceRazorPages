using Domain.Api.Pages.Admin.Shared.Model;
using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.User
{
    public class DeleteUser : BaseDeleteModel<Persistance.Entities.Entities.User>
    {
        private readonly IUserService userService;

        public DeleteUser(IUserService userService) : base(userService)
        {
            this.userService = userService;
        }

        public override async Task<IActionResult> OnGetAsync(Guid? id)
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
