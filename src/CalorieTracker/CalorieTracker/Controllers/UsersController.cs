using CalorieTracker.Data;
using CalorieTracker.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CalorieTracker.Controllers
{
	public class UsersController : Controller
	{

		public AppDbContext DbContext { get; set; }
		public List<User> Users { get; set; }

		public UsersController()
		{
			DbContext = new AppDbContext();
			Users = DbContext.Users.ToList();

		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			LoginVewModel model = new LoginVewModel();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVewModel model)
		{
			ApplicationUser? user = DbContext.Users
				.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
			if (user == null)
			{
				return View(model);
			}


			List<Claim> claims = new List<Claim>();

			Claim = new claims("id", user.Id.ToString());
			Claim idClaim = new Claim("username", user.Username);
			ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			ClaimsPrincipal principal = new ClaimsPrincipal(identity);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
			return RedirectToAction("Index", "MyPlace");
		}
	}
}
