using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models.Entities
{
    public class Author
    {
        //[Key]
        public int AuthorId { get; set; }

        //[Required]
        //[MaxLength(100)]
        public string AuthorName { get; set; }

        public virtual List<Book> Books { get; set; } = new List<Book>();

        //[ForeignKey("PublishingHouseId")]
        public int PublishingHouseId { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
    }
}
