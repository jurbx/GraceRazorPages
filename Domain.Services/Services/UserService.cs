using Domain.Generics;
using Domain.Generics.Services;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;

namespace Domain.Services.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        public override Task CreateAsync(User user)
        {
            if (user.PasswordHash != null)
            {
                user.PasswordHash = user.PasswordHash.HashStringSHA512();
            }
            

            return base.CreateAsync(user);
        }

        public async override Task UpdateAsync(User user)
        {
            var dbUser = await repository.GetByIdAsync(user.Id);
            if (dbUser == null) 
            {
                return;
            }

            user.CreatedOn = dbUser.CreatedOn;
            user.UpdatedOn = DateTimeOffset.Now;

            if (user.PasswordHash != null)
                user.PasswordHash = dbUser.PasswordHash;

            await repository.UpdateAsync(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await userRepository.GetUserByEmail(email);
        }
    }
}
