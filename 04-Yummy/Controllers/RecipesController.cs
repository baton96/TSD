using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCRecipes.Data;
using MVCRecipes.Models;

namespace MVCRecipes.Controllers
{
    public class RecipesController : Controller
    {
        private readonly MVCRecipeContext _context;

        public RecipesController(MVCRecipeContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Recipes/Search/5
        public async Task<IActionResult> Search()
        {
            var allMovies = await _context.Movie.ToListAsync();
            var filteredMovies = allMovies.AsEnumerable();
            var query = Request.Query;
            if (query["name"].Count == 1) filteredMovies = allMovies.Where(x => x.Name.ToLower().Contains(query["name"].ToString().ToLower()));
            if (query["time"].Count == 1) filteredMovies = allMovies.Where(x => x.Time == int.Parse(query["time"]));
            if (query["difficulty"].Count == 1) filteredMovies = allMovies.Where(x => x.Difficulty == int.Parse(query["difficulty"]));
            if (query["likes"].Count == 1) filteredMovies = allMovies.Where(x => x.Likes == int.Parse(query["likes"]));
            if (query["ingredients"].Count == 1)
                filteredMovies = allMovies.Where(x =>
                    x.Ingredients.ToLower().Contains(query["ingredients"].ToString().ToLower())
                );

            return View(filteredMovies);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Movie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Time,Difficulty,Likes,Ingredients,Process,TipsNTricks")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Movie.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Time,Difficulty,Likes,Ingredients,Process,TipsNTricks")] Recipe recipe)
        {
            if (id != recipe.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Movie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
