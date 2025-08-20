using Domain.Generics.Persistance;

namespace Domain.Persistance.Entities.Entities
{
    public class Color : Entity
    {
        public string? RGBCode { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
