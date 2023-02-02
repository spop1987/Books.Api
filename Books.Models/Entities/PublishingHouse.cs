using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models.Entities
{
    public class PublishingHouse
    {
        //[Key]
        public int PublishingHouseId { get; set; }
        //[MaxLength(20)]
        public string Name { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
