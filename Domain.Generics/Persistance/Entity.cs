namespace Domain.Generics.Persistance
{
    public class Entity
    {
        public Guid? Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
