using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyFamilyDashboard.Data
{
    public class RecipeDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IngredientDataModel> Ingredients { get; set; }
        public int ImageId { get; set; }

    }
}
