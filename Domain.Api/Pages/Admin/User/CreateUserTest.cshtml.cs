using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.User
{
    public class CreateUserTestModel : PageModel
    {
        private readonly IUserService userService;

        public object User { get; set; } = new Persistance.Entities.Entities.User();
        public IEnumerable<string> ExcludedProperties { get; set; } = new List<string>
        {
            nameof(Domain.Persistance.Entities.Entities.User.Id),
            nameof(Domain.Persistance.Entities.Entities.User.CreatedOn),
            nameof(Domain.Persistance.Entities.Entities.User.UpdatedOn),
            nameof(Domain.Persistance.Entities.Entities.User.DeletedOn)
        };

        public CreateUserTestModel(IUserService userService) 
        {
            this.userService = userService;
        }

        public async Task OnPostAsync(Persistance.Entities.Entities.User user)
        {
            await userService.CreateAsync(user);
        }
    }
}
