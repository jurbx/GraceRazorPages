using Domain.Generics.Persistance;

namespace Domain.Persistance.Entities.Entities
{
    public class Category : ImgEntity
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

    }
}
