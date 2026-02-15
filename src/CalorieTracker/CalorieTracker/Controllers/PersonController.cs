using CalorieTracker.Data;
using Microsoft.AspNetCore.Mvc;
using CalorieTracker.Entities;
using Microsoft.EntityFrameworkCore;


namespace CalorieTracker.Controllers
{
	public class PersonController : Controller
	{
		private readonly AppDbContext _context;

		

		public PersonController(AppDbContext context)
		{
			_context = context;
		}

		// 1. Stránka pro čisté zobrazení (Read-only)
		public async Task<IActionResult> Person()
		{

			var person = await _context.Persons
				.Include(p => p.Foods) // Klíčový příkaz pro načtení 1:N vztahu
				.FirstOrDefaultAsync();

			if (person == null) return NotFound();
			return View(person);
		

			/*
			var person = await _context.Persons.FirstOrDefaultAsync();
			if (person == null) return NotFound("Uživatel nenalezen");
			return View(person); // Vrátí soubor Details.cshtml
			*/
		}

		// 2. Stránka s formulářem (Edit)
		public async Task<IActionResult> Edit()
		{
			var person = await _context.Persons.FirstOrDefaultAsync();
			if (person == null) return NotFound();
			return View(person); // Vrátí soubor Edit.cshtml
		}

		// 3. Akce pro uložení (POST) - tu už máš v podstatě hotovou
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(Person person)
		{
			if (ModelState.IsValid)
			{
				_context.Update(person);
				await _context.SaveChangesAsync();
				TempData["Success"] = "Údaje byly úspěšně aktualizovány.";
				// PO ULOŽENÍ přesměrujeme zpět na Details (zobrazení)
				return RedirectToAction(nameof(Person));
			}
			return View("Edit", person);
		}

	}
}
