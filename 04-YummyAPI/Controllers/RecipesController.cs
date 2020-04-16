﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RecipesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesContext _context;

        public RecipesController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var allRecipes = await _context.Recipes.ToListAsync();
            var filteredRecipes = allRecipes.AsEnumerable();
            var query = Request.Query;
            if (query["name"].Count == 1) filteredRecipes = allRecipes.Where(x => x.Name.ToLower().Contains(query["name"].ToString().ToLower()));
            if (query["time"].Count == 1) filteredRecipes = allRecipes.Where(x => x.Time == int.Parse(query["time"]));
            if (query["difficulty"].Count == 1) filteredRecipes = allRecipes.Where(x => x.Difficulty == int.Parse(query["difficulty"]));
            if (query["likes"].Count == 1) filteredRecipes = allRecipes.Where(x => x.Likes == int.Parse(query["likes"]));
            if (query["ingredients"].Count == 1)
                filteredRecipes = allRecipes.Where(x =>
                    x.Ingredients.ToLower().Contains(query["ingredients"].ToString().ToLower())
                );
            return filteredRecipes.ToList();
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.ID)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid) return null;
            if (await TryUpdateModelAsync<Recipe>(recipe))
            {
                _context.Recipes.Add(recipe);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetRecipe), new { id = recipe.ID }, recipe);
            }
            return null;
        }

        public async Task<ActionResult<Recipe>> PostRecipe2(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.ID }, recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return recipe;
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.ID == id);
        }
    }
}
