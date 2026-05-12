using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;
using RecipeBook.Services;
using RecipeBook.ViewModels;

namespace RecipeBook.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        private static List<Recipe> recipes = new List<Recipe>
        {
            new Recipe
            {
                Id = 1,
                Title = "Паста",
                Description = "Итальянская паста",
                Ingredients = "Макароны, сыр",
                Steps = "Сварить макароны"
            },

            new Recipe
            {
                Id = 2,
                Title = "Салат",
                Description = "Овощной салат",
                Ingredients = "Помидоры, огурцы",
                Steps = "Нарезать овощи"
            }
        };

        public IActionResult Index(string ingredient)
        {
            var result = recipes;

            if (!string.IsNullOrEmpty(ingredient))
            {
                result = _recipeService
                    .SearchByIngredient(recipes, ingredient);
            }

            ViewBag.SearchText = ingredient;

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RecipeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var recipe = new Recipe
            {
                Id = recipes.Count + 1,
                Title = model.Title,
                Description = model.Description,
                Ingredients = model.Ingredients,
                Steps = "Не указано"
            };

            recipes.Add(recipe);

            TempData["Message"] = "Рецепт успешно добавлен";

            return RedirectToAction("Index");
        }
    }
}