using Books.Models.Dtos;
using Books.Models.Entities;


namespace Books.Models.Translators
{
    public interface IToDtoTranslator
    {
        Task<PublishingHouseDto> ToPublishingHouseDto(PublishingHouse publishingHouse);
    }
    public class ToDtoTranslator : IToDtoTranslator
    {
        public async Task<PublishingHouseDto> ToPublishingHouseDto(PublishingHouse publishingHouse)
        {
            if (publishingHouse == null)
                return null;

            return await Task.FromResult(new PublishingHouseDto
            {
                PublishingId = publishingHouse.PublishingHouseId,
                Name = publishingHouse.Name,
                Authors = ToListOFAuthorsDto(publishingHouse.Authors)
            });
        }

        private List<AuthorDto> ToListOFAuthorsDto(List<Author> authors)
        {
            var listOfAuthors = new List<AuthorDto>();

            authors.ForEach(a =>
            {
                var listOfBooks = ToListOfBooksDto(a.Books);
                var authorDto = new AuthorDto
                {
                    AuthorName = a.AuthorName,
                    Books = listOfBooks
                };
                listOfAuthors.Add(authorDto);
            });
            return listOfAuthors;
        }

        private List<BookDto> ToListOfBooksDto(List<Book> books)
        {
            var listOfBooks = new List<BookDto>();
            books.ForEach(b =>
            {
                var bookDto = new BookDto
                {
                    Title = b.Title
                };
                listOfBooks.Add(bookDto);
            });
            return listOfBooks;
        }
    }
}
