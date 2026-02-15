using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Entities
{

    [Table("Food")]

    public class Food
    {

	    public Food() { }

		public Food(int Id, string name, int totalCal, int weight, int personId)
		{
            FoodId = Id;
            Name = name;
            TotalCal = totalCal;
            Weight = weight;
			PersonID = personId;
		}

		[Key]
        [Column("FoodID")]
        public int FoodId { get; set; }
        [Column("FName")]
        public string Name { get; set; }
        [Column("TotalCal")]
        public int TotalCal { get; set; }

        [Column("Weight")]
        public int Weight { get; set; }

        [Column("PersonID")]    
        public int PersonID { get; set; }

		[ForeignKey("PersonID")]
        public Person Person {  get; set; }

    }
}
