using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Entities
{

    [Table("Food")]

    public class Food
    {
        [Key]
        [Column("FoodID")]
        public int FoodId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("IngredientsID")]
        public int IngredientsID { get; set; }

        [Column("TotalCal")]
        public int TotalCal {  get; set; }

    }
}
