using Library.Models;

namespace LibraryAPI
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        static public CategoryResponse FromCategory(Category category)
        {

            return new CategoryResponse
            { 
              CategoryId = category.CategoryId, 
              CategoryName = category.CategoryName 
            };

        }
    }
}
