
using Books.DataBase.SqlServer.DataAccess;
using Books.Models.Dtos;
using Books.Models.Translators;

namespace BooksService
{
    public interface IServices
    {
        Task<PublishingHouseDto> GetPublishingById(int id);
    }
    public class Services : IServices
    {
        private readonly IToDtoTranslator _toDtoTranslator;
        private readonly IQueries _queries;

        public Services(IToDtoTranslator toDtoTranslator, IQueries queries)
        {
            _toDtoTranslator = toDtoTranslator;
            _queries = queries;
        }
        public async Task<PublishingHouseDto> GetPublishingById(int id)
        {
            var publishingHouse = await _queries.GetPublishingHouseById(id);
            var publishinHouseDto = await _toDtoTranslator.ToPublishingHouseDto(publishingHouse);
            return publishinHouseDto;
        }
    }
}
