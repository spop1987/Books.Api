
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models.Entities
{
    public class Book
    {
        //[Key]
        public int BookId { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string Title { get; set; }

        //[ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
