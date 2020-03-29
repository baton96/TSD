using Microsoft.EntityFrameworkCore;
using MVCRecipes.Models;

namespace MVCRecipes.Data
{
    public class MVCRecipeContext : DbContext
    {
        public MVCRecipeContext(
            DbContextOptions<MVCRecipeContext> options
            ) : base(options)
        {
        }

        public DbSet<Recipe> Movie { get; set; }
    }
}