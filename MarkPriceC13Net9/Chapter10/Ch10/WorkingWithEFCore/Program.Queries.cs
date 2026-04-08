using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();

        SectionTitle("Categories and how many products they have");

        IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products);
        
        if (categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }

        foreach (Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products");
        }
    }
}