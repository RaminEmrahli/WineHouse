using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WineHouse.Entities;

namespace WineHouse.Areas.Admin.Controllers
{
	[Area("Admin"),Authorize]
	public class CategoryController : Controller
	{
		private readonly ApplicationContext _context;
		public CategoryController(ApplicationContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var data = _context.Categories.ToList();
			return View(data);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		public IActionResult Create(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
        public IActionResult Delete(int id)
        {
            var cinemaDetails = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (cinemaDetails == null) return View("NotFound");
            _context.Categories.Remove(cinemaDetails);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
