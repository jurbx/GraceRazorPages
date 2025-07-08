using Domain.Generics.Persistance;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistance.Repositories
{
    public class UserRepository : Repository<User, ProgramDbContext>, IUserRepository
    {
        public UserRepository(IDbContextFactory<ProgramDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
