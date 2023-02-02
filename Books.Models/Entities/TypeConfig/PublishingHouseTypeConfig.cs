using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Models.Entities.TypeConfig
{
    public class PublishingHouseTypeConfig : IEntityTypeConfiguration<PublishingHouse>
    {
        public void Configure(EntityTypeBuilder<PublishingHouse> builder)
        {
            builder.ToTable("PublishingHouse");
            builder.HasKey(ph => ph.PublishingHouseId);
            builder.Property(ph => ph.Name).IsRequired().HasColumnType("varchar(100)");
            builder.HasMany(ph => ph.Authors)
                .WithOne(a => a.PublishingHouse)
                .HasForeignKey(a => a.PublishingHouseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
