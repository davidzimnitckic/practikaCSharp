using System.ComponentModel.DataAnnotations;

namespace RecipeBook.ViewModels
{
    public class RecipeViewModel
    {
        [Required(ErrorMessage = "Введите название")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [StringLength(200, ErrorMessage = "Максимум 200 символов")]
        public string Description { get; set; } 

        [Required(ErrorMessage = "Введите ингредиенты")]
        public string Ingredients { get; set; }
    }
}