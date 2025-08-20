using Domain.Generics.Persistance;

namespace Domain.Persistance.Entities.Entities
{
    public class Product : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public decimal Price { get; set; }
        public int Position { get; set; }
        public bool IsNew { get; set; }
        public virtual ICollection<Color> Colors { get; set; } = new HashSet<Color>();

    }
}
