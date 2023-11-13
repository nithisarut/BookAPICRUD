using Library.Models;
using Library.Service;
using LibraryAPI.Datas;
using LibraryAPI.DTOS.Category;

using LibraryAPI.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiCategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public readonly DataContext db;
        public ApiCategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryAll()
        {
            return Ok(await categoryService.GetAll());
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Category>> AddCategory([FromForm] CategoryRequest categoryRequest)
        {
            var category = categoryRequest.Adapt<Category>();
            await categoryService.Create(category);
            categoryService.Create(category);
            return CreatedAtAction(nameof(AddCategory), category);
        }

    

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(int id, [FromForm] CategoryRequest categoryRequest)
        {
            if (id != categoryRequest.CategoryId) return BadRequest();
            var result = await categoryService.GetById(id);


            if (result == null) return NotFound();

            var category = categoryRequest.Adapt(result);
            await categoryService.Update(category);
            return Ok(category);

        }
        [HttpDelete]
      
        public async Task<ActionResult<Category>> DeleteCategory([FromQuery] int id)
        {
            var result = await categoryService.GetById(id);
            if (result == null) return NotFound();
            await categoryService.Delete(result);
        
            return Ok(new { msg = "OK" });
        }
    }
}
