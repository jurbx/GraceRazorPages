using Domain.Generics.Persistance;
using Domain.Persistance.Entities.Entities;

namespace Domain.Persistance.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
