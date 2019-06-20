using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFamilyDashboard.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public IngredientUnit Unit { get; set; }
    }
}
