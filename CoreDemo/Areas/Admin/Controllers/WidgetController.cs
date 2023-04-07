using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetController : Controller
    {
        public IActionResult Index()//İstatistik hesaplarının yapıldığı kısım.
        {
            return View();
        }
    }
}
