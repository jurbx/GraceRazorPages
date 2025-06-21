using Domain.Generics.Services;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities;
using Domain.Services.Contracts.Services;

namespace Domain.Services.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }
    }
}
