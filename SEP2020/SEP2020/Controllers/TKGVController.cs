using SEP2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEP2020.Controllers
{
    public class TKGVController : Controller
    {
        SEP2020Entities model = new SEP2020Entities();
        // GET: TK
        public ActionResult Index()

        {

            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();

            ViewBag.Account = model.Accounts.OrderByDescending(x => x.id).ToList();

            var Research = model.Researches.OrderByDescending(x => x.id).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(int Account_id, int Semester_id)
        {

            ViewBag.Account = model.Accounts.OrderByDescending(x => x.id).ToList();
            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();
            var Research = model.Researches.OrderByDescending(x => x.id).ToList().Where(a => a.Account_id == Account_id).Where(b => b.Semester_id == Semester_id);
            return View(Research);
        }
    }
}