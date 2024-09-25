using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WineHouse.Areas.Admin.Controllers
{
	[Area("Admin"),Authorize]
	public class OrderController : Controller
	{
		private readonly ApplicationContext _context;
		public OrderController(ApplicationContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var data = _context.Orders.ToList();

			return View(data);
		}
	}
}
