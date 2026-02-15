using Microsoft.EntityFrameworkCore;
using CalorieTracker.Entities;
using Org.BouncyCastle.Asn1.Mozilla;

namespace CalorieTracker.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}


		public DbSet<Food> Foods { get; set; }

		public DbSet<User> Users { get; set; }
		   
		public DbSet<Person> Persons { get; set; }   

		
		/*
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4c1_kvechsimon_db2;user=kvechsimon;password=123456");
		}
		*/
	}
}
