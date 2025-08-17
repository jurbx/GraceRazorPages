using Domain.Generics.Persistance;

namespace Domain.Persistance.Entities.Entities
{
    public class HomeSlide : Entity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
