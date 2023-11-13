using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.DTOS.Book
{
    public class BookRequest
    {
        public int? BookId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
   
        public int CategoryId { get; set; }
        public IFormFileCollection? FormFiles { get; set; }



    }
}
