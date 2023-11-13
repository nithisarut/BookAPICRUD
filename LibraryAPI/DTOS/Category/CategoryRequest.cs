using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOS.Category
{
    public class CategoryRequest
    {
        public int? CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
