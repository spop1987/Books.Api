using System;

namespace Books.Models.Dtos
{
    public class AuthorDto
    {
        public string AuthorName { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
