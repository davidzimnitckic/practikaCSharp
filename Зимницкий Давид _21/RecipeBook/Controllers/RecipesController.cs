using Microsoft.AspNetCore.Mvc;
using RecipeBook.Data;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class RecipesController : Controller
    {
        private readonly AppDbContext _context;

        public RecipesController(AppDbContext context)
        {
            _context = context;
        }

        // Список
        public IActionResult Index()
        {
            var recipes = _context.Recipes.ToList();

            return View(recipes);
        }

        // CREATE GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return View(recipe);
            }

            _context.Recipes.Add(recipe);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // EDIT GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recipe = _context.Recipes.Find(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return View(recipe);
            }

            _context.Recipes.Update(recipe);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recipe = _context.Recipes.Find(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // DELETE POST
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var recipe = _context.Recipes.Find(id);

            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}