using Domain.Api.Pages.Admin.Shared;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.User
{
    public class UserListModel : ListPagerModel<Persistance.Entities.Entities.User>
    {
        public UserListModel(IUserService service) : base(service)
        {
            IncludedProperties = new List<string>
            {
                nameof(Persistance.Entities.Entities.User.Id),
                nameof(Persistance.Entities.Entities.User.Email),
                nameof(Persistance.Entities.Entities.User.Name),
                nameof(Persistance.Entities.Entities.User.Role)
            };
        }
    }
}
