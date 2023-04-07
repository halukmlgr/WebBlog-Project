using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
    public class CommentsList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
           { new UserComment
                 {
                    ID=1,
                    username="haluk"
                 },
                 new UserComment
                 {
                     ID=2,
                     username="ayşe"
                 },
                 new UserComment
                 {
                     ID=3,
                     username="erdem"
                 }
           };
            return View(commentValues);
        }
    }
}
