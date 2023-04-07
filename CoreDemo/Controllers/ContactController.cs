using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		ContactManager cm = new ContactManager(new EfContactRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact P)
		{
			P.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			P.ContactStatus = true;
			cm.ContactAdd(P);
			return RedirectToAction("Index","BlogControllers");
			//Neden "Index","Blog" yazıyoruz bunun sebebi mesaj gönderilten sonra gideceği sayfayı belirtmek için
		}
	}
}
