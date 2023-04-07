using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager cm=new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartilAddComment()//Partial eklemek için yazılıyor.
		{ 
		return PartialView();
		}
        [HttpPost]
        public PartialViewResult PartilAddComment(Comment P)//Partial eklemek için yazılıyor.
        {
			P.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			P.CommentStatus = true;
			P.BlogID = 15;
			cm.CommentAdd(P);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id) 
		{
			var values=cm.GetList(id);
			return PartialView(values);
		}
	}
}
