using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class RecipesController : Controller
    {
        // Временный список рецептов
        private static List<Recipe> recipes = new List<Recipe>
        {
            new Recipe
            {
                Id = 1,
                Title = "Паста",
                Ingredients = "Макароны, сыр, соус",
                Steps = "Сварить макароны и добавить соус"
            },

            new Recipe
            {
                Id = 2,
                Title = "Салат",
                Ingredients = "Помидоры, огурцы, масло",
                Steps = "Нарезать и перемешать"
            }
        };

        // Список рецептов
        public IActionResult Index()
        {
            return View(recipes);
        }

        // Просмотр рецепта
        [Route("Recipes/View/{id}")]
        public IActionResult ViewRecipe(int id)
        {
            var recipe = recipes.FirstOrDefault(r => r.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: форма добавления
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: добавление рецепта
        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            recipe.Id = recipes.Count + 1;

            recipes.Add(recipe);

            return RedirectToAction("Index");
        }
    }
}