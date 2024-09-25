using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WineHouse.Controllers
{
	public class WineController : Controller
	{
		private readonly ApplicationContext _context;
		public WineController(ApplicationContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var data = _context.Wines.Include(x => x.Category).ToList();
			return View(data);
		}
        public async Task<IActionResult> Details(int id)
        {
            var wineDetails = _context.Wines
                   .Include(c => c.Category)
                   .FirstOrDefault(n => n.Id == id);
            return View(wineDetails);
        }
    }
}
