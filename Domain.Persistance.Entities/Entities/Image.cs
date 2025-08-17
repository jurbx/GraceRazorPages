using Domain.Generics.Persistance;

namespace Domain.Persistance.Entities.Entities
{
    public class Image : Entity
    {
        public Guid? EntityId { get; set; }
        public required string ImagePath { get; set; }
    }
}
