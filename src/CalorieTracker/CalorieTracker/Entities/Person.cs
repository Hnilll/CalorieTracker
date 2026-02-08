using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Entities
{
    [Table ("Person")]

    public class Person
    {
        [Key]
        [Column("PersonID")]
        public int PersonID { get; set; }

        [Column("Name")]
        public string PName { get; set; }

        [Column("Height")]
        public int Height { get; set; }


        [Column("Weight")]
        public int Weight { get; set; }

        [Column("FoodID")]
        public int FoodID { get; set; }
    }
}
