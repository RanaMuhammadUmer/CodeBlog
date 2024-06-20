using CodeBlog.Models.Domain;
using CodeBlog.Models.DTO;
using CodeBlog.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestParams param)
        {
            var category = new Category
            {
                Name = param.Name,
                UrlHandle = param.UrlHandle
            };

            await _repository.CreateAsync(category);

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = param.UrlHandle
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _repository.GetCategoriesAsync();

            List<CategoryDto> categoryDtos = new List<CategoryDto>();

            foreach (var item in categories)
            {
                categoryDtos.Add(new CategoryDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    UrlHandle = item.UrlHandle
                });
            }

            return Ok(categoryDtos);
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var category = await _repository.GetCategoryByIdAsync(Id);

            if (category == null)
            {
                return BadRequest("Category not found");
            }

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(categoryDto);
        }

        [HttpPut]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid Id, UpdateCategoryRequestParams param)
        {
            var category = new Category
            {
                Id = Id,
                Name = param.Name,
                UrlHandle = param.UrlHandle
            };

            category = await _repository.UpdateCategory(category);

            if (category == null)
            {
                return NotFound();
            }

            var dto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(dto);
        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid Id)
        {
            await _repository.DeleteCategoryAsync(Id);

            return Ok();
        }
    }
}
