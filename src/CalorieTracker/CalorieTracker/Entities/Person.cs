using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Entities
{
    [Table ("Person")]

    public class Person
    {

		// Tento řádek propojí uživatele s jeho jídly v C# kódu
		public List<Food> Foods { get; set; } = new List<Food>();

		public Person() { }

        public Person(int personId, string pname,int age, int height, int weight)
        {

            PersonID = personId;
            PName = pname;
            Age = age;
			Height = height;
            Weight = weight;
            

		}


		[Key]
        [Column("PersonID")]
        public int PersonID { get; set; }

        [Column("PName")]
        public string PName { get; set; }

        [Column("Age")]
        public int Age { get; set; }

		[Column("Height")]
        public int Height { get; set; }


        [Column("Weight")]
        public int Weight { get; set; }

        
    }
}
