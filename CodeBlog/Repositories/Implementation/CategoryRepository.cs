using CodeBlog.Data;
using CodeBlog.Models.Domain;
using CodeBlog.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodeBlog.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CodeBlogDbContext _context;

        public CategoryRepository(CodeBlogDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid Id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Category?> UpdateCategory(Category category)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (existingCategory != null)
            {
                _context.Entry(existingCategory).CurrentValues.SetValues(category);
                await _context.SaveChangesAsync();

                return category;
            }
            return null;
        }

        public async Task DeleteCategoryAsync(Guid Id)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == Id);

            if (existingCategory != null)
            {
                _context.Categories.Remove(existingCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
