using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        public int? BookId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime Created { get; set; }
        public string Image { get; set; }
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

    }
}
