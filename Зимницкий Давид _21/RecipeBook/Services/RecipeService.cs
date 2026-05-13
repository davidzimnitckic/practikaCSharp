using RecipeBook.Models;

namespace RecipeBook.Services
{
    public class RecipeService : IRecipeService
    {
        public List<Recipe> SearchByIngredient(List<Recipe> recipes, string ingredient)
        {
            return recipes
                .Where(r => r.Ingredients.Contains(ingredient,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}