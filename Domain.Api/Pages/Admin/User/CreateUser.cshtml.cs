using Domain.Api.Pages.Admin.Shared;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.User
{
    public class CreateUserModel : CreatePageModel<Persistance.Entities.Entities.User>
    {
        private readonly IUserService userService;

        public CreateUserModel(IUserService service) : base(service)
        {
            this._Entity = new Persistance.Entities.Entities.User();
        }
    }
}
