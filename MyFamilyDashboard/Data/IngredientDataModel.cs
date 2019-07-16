using System.ComponentModel.DataAnnotations;
namespace MyFamilyDashboard.Data
{
    public class IngredientDataModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        public float Quantity { get; set; }
        public IngredientUnitDataModel Unit { get; set; }
        public string Note { get; set; }
        public RecipeDataModel Recipe { get; set; }
    }
}
