using Domain.Api.Pages.Admin.Shared.Model;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.User
{
    public class UserListModel : BaseListModel<Persistance.Entities.Entities.User>
    {
        public UserListModel(IUserService service) : base(service)
        {
            IncludedProperties = new List<string>
            {
                nameof(Persistance.Entities.Entities.User.Email),
                nameof(Persistance.Entities.Entities.User.Name),
                nameof(Persistance.Entities.Entities.User.Role)
            };
        }
    }
}
