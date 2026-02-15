using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieTracker.Entities
{

    [Table ("User")]

    public class User
    {

        public User() //Pro vytváření 
        { }


        public User(int userId, string username, string password, string email,int personId)
        {
            UserID = userId;
            UserName = username;
            Password = password;
            Email = email;
            PersonID = personId;

		}


		[Key]
        [Column("UserID")]
        public int UserID { get; set; }
        [Column("Username")]
        public string UserName { get; set; }
        [Column("Password")]
        public string Password { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("PersonID")]
        public int PersonID { get; set; }


    }
}
