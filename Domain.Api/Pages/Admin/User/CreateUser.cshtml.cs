using Domain.Api.Pages.Admin.Shared.Model;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.User
{
    public class CreateUserModel : BaseCreateModel<Persistance.Entities.Entities.User>
    {
        public CreateUserModel(IUserService service) : base(service)
        { }
    }
}
