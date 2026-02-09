using CalorieTracker.Data;
using CalorieTracker.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CalorieTracker.Models.Auth;
using Microsoft.AspNetCore.Authentication;

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
			LoginViewModel model = new LoginViewModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			User? user = DbContext.Users
				.FirstOrDefault(u => u.UserName == model.Username && u.Password == model.Password);
			if (user == null)
			{
				return View(model);
			}


			List<Claim> claims = new List<Claim>();

			Claim claim = new Claim ("id", user.UserID.ToString());
			Claim idClaim = new Claim("username", user.UserName);
			ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			ClaimsPrincipal principal = new ClaimsPrincipal(identity);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
			return RedirectToAction("Index", "MyPlace");
		}
	}
}
