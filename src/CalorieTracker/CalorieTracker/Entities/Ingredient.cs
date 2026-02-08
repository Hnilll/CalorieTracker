using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Entities
{


    [Table ("Igredients")]
    public class Ingredient
    {

        public Ingredient(int InId,string Iname, int CPG, int weight, int foodID)
        {
            IngredientId = InId;
            IName = Iname;
            CaloriesPerGram = CPG;
            Weight = weight;
            FoodId = foodID;
		}



		[Key]
        [Column("IngredientID")]
        public int IngredientId { get; set; }
        [Column("IName")]
        public string IName { get; set; }
        [Column("Calories (per g)")]
        public int CaloriesPerGram { get; set; }
        [Column("Weight (g)")]
        public int Weight { get; set; }
		[Column("FoodID")]
        public int FoodId { get; set; }

	}
}
