using Microsoft.AspNetCore.Mvc;
using CalorieTracker.Data;
using CalorieTracker.Entities;

namespace CalorieTracker.Controllers
{
	public class FoodController : Controller
	{
		//public AppDbContext DbContext { get; set; }

		private readonly AppDbContext _context;

		public List<Food> Foods { get; set; }

		public FoodController(AppDbContext context)
		{
			//DbContext = new AppDbContext();

			_context = context;

			Foods = _context.Foods.ToList();
		}

		[HttpGet]
		public IActionResult Food() 
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

		
		[HttpGet]
		public IActionResult Create() //Pro vytváření nového jídla.
        {
			return View();
		}
    }
}
