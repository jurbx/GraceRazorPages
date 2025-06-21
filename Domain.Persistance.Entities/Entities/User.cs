using Domain.Generics.Persistance;

namespace Domain.Persistance.Entities
{
    public class User : Entity
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
    }
}
