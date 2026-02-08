using CalorieTracker.Data;
using CalorieTracker.Entities;
using CalorieTracker.Models;
using CalorieTracker.Models.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Diagnostics;

namespace CalorieTracker.Controllers
{
	public class AuthController : Controller
	{

		private readonly AppDbContext _dbContext;

		public  AuthController()
					{
			_dbContext = new AppDbContext();
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
			//1. Zkontrolovat zdali uživatel vůbec existuje
			User? user = _dbContext.Users
				.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
			if (user == null)
			{
				return View(model);
			}

			//2. Sestavit "identitu/totožnost" uživatele pomocí Claims
			List<Claim> claims = new List<Claim>();

			Claim idClaim = new Claim("id", user.Id.ToString());
			Claim usernameClaim = new Claim("username", user.Username);

			claims.Add(idClaim);
			claims.Add(usernameClaim);

			ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			ClaimsPrincipal principal = new ClaimsPrincipal(identity);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

			return RedirectToAction("Index", "Dashboard");
		}

	}
}

