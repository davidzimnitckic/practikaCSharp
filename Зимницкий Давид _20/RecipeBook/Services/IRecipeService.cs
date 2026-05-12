using RecipeBook.Models;

namespace RecipeBook.Services
{
    public interface IRecipeService
    {
        List<Recipe> SearchByIngredient(List<Recipe> recipes, string ingredient);
    }
}