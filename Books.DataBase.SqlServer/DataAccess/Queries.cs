
using Books.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.DataBase.SqlServer.DataAccess
{
    public interface IQueries
    {
        Task<PublishingHouse> GetPublishingHouseById(int id);
    }

    public class Queries : IQueries
    {
        private readonly BookDbContext _bookDbContext;

        public Queries(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }
        public async Task<PublishingHouse> GetPublishingHouseById(int id)
        {
            return await PublishingHousesWithIncludes()
                .FirstOrDefaultAsync(ph => ph.PublishingHouseId == id);
        }

        private IQueryable<PublishingHouse> PublishingHousesWithIncludes()
        {
            return _bookDbContext.PublishingHouses
                .Include(ph => ph.Authors).ThenInclude(a => a.Books).AsQueryable();
        }
    }
}
