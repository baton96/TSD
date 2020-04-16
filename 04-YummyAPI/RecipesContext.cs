using Microsoft.EntityFrameworkCore;

namespace RecipesAPI
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options){}

        public DbSet<Recipe> Recipes { get; set; }
    }
}