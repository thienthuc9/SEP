using SEP2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEP2020.Controllers
{
    public class TKCategoryController : Controller
    {

        SEP2020Entities model = new SEP2020Entities();
        // GET: TK
        public ActionResult Index()

        {
            ViewBag.ResearchCategories = model.ResearchCategories.OrderByDescending(x => x.id).ToList();

            ViewBag.ResearchItem = model.RearchItems.OrderByDescending(x => x.id).ToList();
            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();

            var Research = model.Researches.OrderByDescending(x => x.id).ToList();
            return View(Research);
        }
        [HttpPost]
        public ActionResult Index(int Item_id, int Semester_id)
        {
            ViewBag.ResearchCategories = model.ResearchCategories.OrderByDescending(x => x.id).ToList();
            ViewBag.ResearchItem = model.RearchItems.OrderByDescending(x => x.id).ToList();
            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();

            var Research = model.Researches.OrderByDescending(x => x.id).ToList().Where(a => a.Item_id == Item_id).Where(b => b.Semester_id == Semester_id); ;
            return View(Research);
        }
    }
    
}