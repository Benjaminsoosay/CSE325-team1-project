using CommunityLibrary.Data;
using CommunityLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityLibrary.Services;

public class CategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET ALL CATEGORIES
    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    // GET CATEGORY BY ID
    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // GET CATEGORY WITH ITS BOOKS
    public async Task<Category?> GetCategoryWithBooksAsync(int id)
    {
        return await _context.Categories
            .Include(c => c.Books)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // CREATE CATEGORY
    public async Task<Category> CreateCategoryAsync(Category category)
    {
        _context.Categories.Add(category);

        await _context.SaveChangesAsync();

        return category;
    }

    // UPDATE CATEGORY
    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        var existingCategory = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == category.Id);

        if (existingCategory == null)
        {
            return false;
        }

        existingCategory.Name = category.Name;
        existingCategory.Description = category.Description;

        await _context.SaveChangesAsync();

        return true;
    }

    // DELETE CATEGORY
    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return false;
        }

        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();

        return true;
    }

    // CHECK IF CATEGORY EXISTS
    public async Task<bool> CategoryExistsAsync(int id)
    {
        return await _context.Categories
            .AnyAsync(c => c.Id == id);
    }

    // CHECK IF CATEGORY NAME ALREADY EXISTS
    public async Task<bool> CategoryNameExistsAsync(
        string name,
        int? excludeId = null)
    {
        var query = _context.Categories
            .AsQueryable();

        if (excludeId.HasValue)
        {
            query = query.Where(c => c.Id != excludeId.Value);
        }

        return await query.AnyAsync(
            c => c.Name.ToLower() == name.ToLower());
    }
}