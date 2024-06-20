using CodeBlog.Models.Domain;
using CodeBlog.Models.DTO;

namespace CodeBlog.Repositories.Interface
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateAsync(Category category);

        public Task<IEnumerable<Category>> GetCategoriesAsync();

        public Task<Category?> GetCategoryByIdAsync(Guid Id);

        public Task<Category?> UpdateCategory(Category category);

        public Task DeleteCategoryAsync(Guid Id);
    }
}
