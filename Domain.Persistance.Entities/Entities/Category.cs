using Domain.Generics.Persistance;

namespace Domain.Persistance.Entities.Entities
{
    public class Category : Entity
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? HtmlIcon { get; set; }
        public int? Position { get; set; }

        public override string ToString()
        {
            return this.CategoryName ?? string.Empty;
        }
    }
}
