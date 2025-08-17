namespace Domain.Generics.Persistance
{
    public class Entity
    {
        public Guid? Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public bool IsEmpty()
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                var value = prop.GetValue(this);

                if (prop.PropertyType == typeof(string))
                    continue;

                if (value != null && !Equals(value, Activator.CreateInstance(prop.PropertyType)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
