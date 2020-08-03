using SEP2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEP2020.Controllers
{
    public class TKController : Controller
    {
        SEP2020Entities model = new SEP2020Entities();
        // GET: TK
        public ActionResult Index()

        {

            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();

            var Research = model.Researches.OrderByDescending(x => x.id).ToList();
            return View(Research);
        }
        [HttpPost]
        public ActionResult Index(int Semester_id)
        {
            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();
            var Research = model.Researches.OrderByDescending(x => x.id).ToList().Where(a => a.Semester_id == Semester_id);
            return View(Research);
        }
    }
}