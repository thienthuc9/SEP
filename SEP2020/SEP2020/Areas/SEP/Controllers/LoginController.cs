using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace SEP2020.Areas.SEP.Controllers
{
    public class LoginController : Controller
    {
        // GET: SEP/Login
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult LogOff()
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    return RedirectToAction("Login", "Account");
        //}
    }
}