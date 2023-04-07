﻿using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            return View();

        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }






        //public async Task<IActionResult> Index(Writer P)
        //{
        //	Context c=new Context();
        //          var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == P.WriterMail && x.WriterPassword == P.WriterPassword);
        //	if (datavalue!=null)
        //	{
        //		var claims = new List<Claim>
        //		{
        //			new Claim(ClaimTypes.Name,P.WriterMail)
        //		};
        //		var useridentity=new ClaimsIdentity(claims,"a");
        //		ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
        //		await HttpContext.SignInAsync(principal);
        //		return RedirectToAction("Index","Dashboard");
        //	}
        //	else { return View(); }

        //      }

    }
}
//Context C = new Context();
//var datavalue = C.Writers.FirstOrDefault(x => x.WriterMail == P.WriterMail && x.WriterPassword == P.WriterPassword);
//if (datavalue != null)
//{
//    HttpContext.Session.SetString("username", P.WriterMail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();
//}
