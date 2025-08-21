using Domain.Persistance.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Persistance.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Colors)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();

            builder.Property(x => x.RGBCode).HasDefaultValue("#FFFFFF");
        }
    }
}
