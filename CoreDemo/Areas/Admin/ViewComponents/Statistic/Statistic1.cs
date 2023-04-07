using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Context = DataAccessLayer.Concrete.Context;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
         Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();//Toplam blog sayısını getirmek için yazıldı.
            ViewBag.v2=c.Contacts.Count();//Toplam iletişim sayısı
            ViewBag.v3=c.Comments.Count();//Toplam yorum sayısı
            //Alttaki 4 satır kod hava durumunu çekmek için yazıldı.
            string api = "9f4438b5d9505fd9877f40f3180e61f4";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document= XDocument.Load(connection);
            ViewBag.v4=document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
