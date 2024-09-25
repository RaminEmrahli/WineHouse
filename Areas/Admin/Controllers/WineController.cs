using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WineHouse.Entities;

namespace WineHouse.Areas.Admin.Controllers
{
	[Area("Admin"),Authorize]
	public class WineController : Controller
	{
		private readonly ApplicationContext _context;
		public WineController(ApplicationContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var data=_context.Wines.Include(x=>x.Category).ToList();
			return View(data);
		}
		[HttpGet]
		public IActionResult Create()
		{
			List<Category> categories= new List<Category>();
			categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
		}
		public IActionResult Create(Wine model)
		{
			Wine wine = new Wine()
			{
				Name = model.Name,
				CategoryId = model.CategoryId,
				Price =model.Price,
				ImageUrl=model.File.FileName,
				Specifications=model.Specifications,
			};
            _context.Wines.Add(wine);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
		}
		[AllowAnonymous]
		public IActionResult Details(int id)
		{
			var data = _context.Wines.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            if (data is null)
            {
				return NotFound();
            }
            return View(data);
		}
	}
}
