using Microsoft.AspNetCore.Mvc;
using CalorieTracker.Data;
using CalorieTracker.Entities;

namespace CalorieTracker.Controllers
{
	public class FoodsController : Controller
	{
		public AppDbContext DbContext { get; set; }

		public List<Food> Foods { get; set; }

		public FoodsController()
		{
			DbContext = new AppDbContext();
			
			Foods = DbContext.Foods.ToList();
		}

		[HttpGet]
		public IActionResult List()
		{
			return View(Foods);
		}

		[HttpGet]
		public IActionResult Ingredients(int id) /*Dodělat  Ingredients*/
		{
			// najde Views/Foods/Food.cshtml automaticky
			Food  food = Foods.First(s => s.FoodId == id);
			return View(food);
		}
	}
}
