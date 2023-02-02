using Microsoft.EntityFrameworkCore;

namespace Books.Models.Entities.TypeConfig
{
    public static class Extension
    {
        public static void ConfigurationAllTypeConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorTypeConfig());
            modelBuilder.ApplyConfiguration(new BookTypeConfig());
            modelBuilder.ApplyConfiguration(new PublishingHouseTypeConfig());
        }
    }
}
