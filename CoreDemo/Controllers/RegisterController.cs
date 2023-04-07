using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;


namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer P)
        {
            //doğrulama işlemlerinin yapıldığı yer. Kayıt işlemi yapılmadan
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(P);    
            if (results.IsValid)
            {
                P.WriterStatus = true;
                P.WriterAbout = "Deneme Test";
                wm.TAdd(P);
                return RedirectToAction("Index", "BlogControllers");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }
    }
}
