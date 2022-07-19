using BlogSiteAPI.Interfaces;
using BlogSiteAPI.Models;
using BlogSiteAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<Category>> GetCategories() =>
            await categoryService.GetCategories();

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(string id)
        {
            var category = await categoryService.GetCategory(id);

            if(category == null) return NotFound();
            else return category;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category NewCategory)
        {
            await categoryService.CreateCategory(NewCategory);
            return CreatedAtAction(nameof(GetCategories), new { id = NewCategory.Id }, NewCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id,Category UpdateCategory)
        {
            var category = await categoryService.GetCategory(id);

            if(category is null)return NotFound();
            else
            {
                UpdateCategory.Id = category.Id;
                await categoryService.UpdateCategory(id, UpdateCategory);
                return NoContent(); ;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await categoryService.GetCategory(id);

            if (category is null) return NotFound();
            else
            {
                await categoryService.DeleteCategory(id);
                return NoContent() ;
            }
        }
    }
}
