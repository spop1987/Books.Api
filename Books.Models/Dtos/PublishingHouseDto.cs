using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models.Dtos
{
    public class PublishingHouseDto
    {
        public int PublishingId { get; set; }
        public string Name { get; set; }
        public List<AuthorDto> Authors { get; set; }
    }
}
