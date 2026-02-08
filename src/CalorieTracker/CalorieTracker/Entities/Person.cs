using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Entities
{
    [Table ("Person")]

    public class Person
    {


        public Person(int personId, string pname, int height, int weight,int foodId)
        {

            PersonID = personId;
            PName = pname;
            Height = height;
            Weight = weight;
            FoodID = foodId;

		}


		[Key]
        [Column("PersonID")]
        public int PersonID { get; set; }

        [Column("PName")]
        public string PName { get; set; }

        [Column("Height")]
        public int Height { get; set; }


        [Column("Weight")]
        public int Weight { get; set; }

        [Column("FoodID")]
        public int FoodID { get; set; }
    }
}
