using Domain.Generics.Enums;
using Domain.Generics.Services;
using Domain.Persistance.Entities.Entities;

namespace Domain.Services.Contracts.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<int> GetCountAsync(UserRole userRole);
    }
}
