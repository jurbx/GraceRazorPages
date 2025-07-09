using Domain.Generics.Services;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Services.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public override Task CreateAsync(User user)
        {
            if (user.PasswordHash != null)
            {
                using (HashAlgorithm algorithm = SHA512.Create())
                {
                    var passwordByte = algorithm.ComputeHash(Encoding.UTF8.GetBytes(user.PasswordHash));
                    user.PasswordHash = Encoding.UTF8.GetString(passwordByte);
                }
            }
            

            return base.CreateAsync(user);
        }

        public async override Task UpdateAsync(User user)
        {
            var dbUser = await repository.GetByIdAsync(user.Id);
            if (user.PasswordHash != null)
                user.PasswordHash = dbUser.PasswordHash;

            await repository.UpdateAsync(user);
        }
    }
}
