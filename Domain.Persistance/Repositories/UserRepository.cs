using Domain.Generics.Enums;
using Domain.Generics.Persistance;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistance.Repositories
{
    public class UserRepository : Repository<User, ProgramDbContext>, IUserRepository
    {
        public UserRepository(IDbContextFactory<ProgramDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await dbSet.Where(model => model.Email == email).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync(UserRole userRole) 
        {
            return await dbSet.Where(user => user.Role == userRole).CountAsync();
        }
    }
}
