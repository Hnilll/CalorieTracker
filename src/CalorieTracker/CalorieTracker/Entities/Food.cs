using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Entities
{

    [Table("Food")]

    public class Food
    {

	    private Food() { }

		public Food(int Id, string name, int totalCal, int personId)
		{
            FoodId = Id;
            Name = name;
            TotalCal = totalCal;
            PersonID = personId;
		}

		[Key]
        [Column("FoodID")]
        public int FoodId { get; set; }
        [Column("FName")]
        public string Name { get; set; }
        [Column("TotalCal")]
        public int TotalCal { get; set; }

        [Column("PersonID")]
        public int PersonID {  get; set; }

    }
}
