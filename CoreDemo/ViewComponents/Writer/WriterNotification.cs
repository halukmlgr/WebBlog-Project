using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificaitonRepository());
        public IViewComponentResult Invoke()
        { 
            var values = nm.GetList();
            return View(values);
        }
    }
}
