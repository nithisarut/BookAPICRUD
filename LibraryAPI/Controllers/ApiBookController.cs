using Library.Models;
using LibraryAPI.Datas;
using LibraryAPI.DTOS.Book;
using LibraryAPI.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiBookController : ControllerBase
    {
        public readonly DataContext db;
        public readonly IBookService bs;
        public ApiBookController(DataContext dataContext, IBookService bookService)
        {
            db = dataContext;
            bs = bookService;
        }

   

        [HttpGet("[action]")]
   
        public async Task<IActionResult> GetBook()
        {
            return Ok((await bs.GetAll()).Select(BookResponse.FromBook));
        }


     
        [HttpGet("search")] 
        public async Task<IActionResult> GetBookByName([FromQuery] string name)
        {

            var result = await bs.Search(name);
            return Ok((result).Select(BookResponse.FromBook));
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook([FromForm] BookRequest bookRequest)
        {

            (string erorrMesage, string imageName) = await bs.UploadImage(bookRequest.FormFiles);
            if (!string.IsNullOrEmpty(erorrMesage)) return BadRequest(erorrMesage);
            
            var book = bookRequest.Adapt<Book>();
            book.Image = imageName;
            await bs.Create(book);
            return CreatedAtAction(nameof(AddBook), book);
        }

        [HttpPut]
        public async Task<ActionResult<Book>> UpdateBook([FromForm] BookRequest bookRequest)
        {

     
         
            var result = await bs.GetByID((int)bookRequest.BookId);
            
            if (result == null) return NotFound();

      

            #region จัดการรูปภาพ
            (string erorrMesage, string imageName) = await bs.UploadImage(bookRequest.FormFiles);
            if (!string.IsNullOrEmpty(erorrMesage)) return BadRequest(erorrMesage);
            if (!string.IsNullOrEmpty(imageName))
            {
                await bs.DeleteImage(result.Image);
                result.Image = imageName;
            }
            #endregion

          
            var product = bookRequest.Adapt(result);
            await bs.Update(product);
            return Ok(product);

        }

        [HttpDelete]
       
        public async Task<ActionResult<Book>> DeleteBook([FromQuery] int id)
        {
            var result = await bs.GetByID(id);
            if (result == null) return NotFound();
            await bs.Delete(result);
            await bs.DeleteImage(result.Image);

            return Ok(new { msg = "OK" });
        }
    }
}
