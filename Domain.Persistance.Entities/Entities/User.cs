using Domain.Generics.Enums;
using Domain.Generics.Persistance;

namespace Domain.Persistance.Entities.Entities
{
    public class User : Entity
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public UserRole? Role { get; set; }

    }
}
