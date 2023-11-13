using Library.Models;

namespace LibraryAPI
{
    public class BookResponse
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime Created { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }



        static public BookResponse FromBook(Book book)
        {
            // return ตัวมันเอง
            return new BookResponse
            {
               BookId = (int)book.BookId,
                Name = book.Name, 
                Price = book.Price, 
                Created = book.Created, 
                Image = book.Image,
                CategoryId = book.CategoryId, 
                CategoryName = book.Category.CategoryName

            };
        }
    }
}
