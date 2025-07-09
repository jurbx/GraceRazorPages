using Domain.Services.Contracts.Services;
using Domain.Persistance.Entities.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.Users
{
    public class UsersList : PageModel
    {
        private readonly IUserService userService;

        public IEnumerable<User> Users { get; private set; }

        public UsersList(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task OnGetAsync()
        {
            Users = await userService.GetAllAsync();
        }
    }
}
