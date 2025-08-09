using Domain.Generics.Persistance;
using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.User
{
    public class UserListModel : PageModel
    {
        private readonly IUserService userService;
        public IEnumerable<object> Users { get; set; }
        public IEnumerable<string> IncludedProperties { get; set; } = new List<string>()
        {
            nameof(Persistance.Entities.Entities.User.Id),
            nameof(Persistance.Entities.Entities.User.Name),
            nameof(Persistance.Entities.Entities.User.Email),
            nameof(Persistance.Entities.Entities.User.Role),
        };

        public UserListModel(IUserService userService) 
        {
            this.userService = userService;
        }

        public async Task OnGetAsync()
        {
            Users = await userService.GetAllAsync();
        }
    }
}
