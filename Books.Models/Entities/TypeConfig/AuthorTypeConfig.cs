
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Models.Entities.TypeConfig
{
    public class AuthorTypeConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(a => a.AuthorId);
            builder.Property(a => a.AuthorName).IsRequired().HasColumnType("varchar(150)");
            builder.HasOne(a => a.PublishingHouse)
                .WithMany(p => p.Authors)
                .HasForeignKey(a => a.PublishingHouseId)
                .OnDelete(DeleteBehavior.Cascade);   
            builder.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
