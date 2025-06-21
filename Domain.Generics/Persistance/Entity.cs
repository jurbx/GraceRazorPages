namespace Domain.Generics.Persistance
{
    public class Entity
    {
        public Guid? Id { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
    }
}
