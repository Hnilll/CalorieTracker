using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Entities
{


    [Table ("Igredients")]
    public class Ingredient
    {
        [Key]
        [Column ("Name")]
        public string Name { get; set; }
        [Column ("Calories (per g)")]
        public int CaloriesG {  get; set; }

        [Column ("Weight (g)")]
        public int WeightG { get; set; }


    }
}
