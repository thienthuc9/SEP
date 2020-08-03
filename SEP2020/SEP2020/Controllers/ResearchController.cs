using SEP2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEP2020.Controllers
{
    public class ResearchController : Controller
    {
        SEP2020Entities model = new SEP2020Entities();
        //public JsonResult Cascading_Get_Categories()
        //{
        //    var northwind = new SEP2020Entities();

        //    return Json(northwind.ResearchCategories.Select(c => new { id = c.id, Name = c.Name }), JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult Cascading_Get_Products(int? categories)
        //{
        //    var northwind = new SEP2020Entities();
        //    var products = northwind.RearchItems.AsQueryable();

        //    if (categories != null)
        //    {
        //        products = products.Where(p => p.Category_id == categories);
        //    }

        //    return Json(products.Select(p => new { id = p.id, CT = p.CT }), JsonRequestBehavior.AllowGet);
        //}


        // GET: Research
        //[HttpGet]
        //public JsonResult GetDistrictByCityId(int id)
        //{
        //    // Disable proxy creation
        //    model.Configuration.ProxyCreationEnabled = false;
        //    var listDistrict = model.ResearchCategories.Where(x => x.id == id).ToList();
        //    return Json(listDistrict, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetList(int id)
        {
            model.Configuration.ProxyCreationEnabled = false;
            List<RearchItem> Item = model.RearchItems.Where(x => x.id == id).ToList();

            return Json(Item, JsonRequestBehavior.AllowGet);
        }

  
        public JsonResult GetListAC(int id)
        {
            model.Configuration.ProxyCreationEnabled = false;
            List<Account> Item = model.Accounts.Where(x => x.id == id).ToList();

            return Json(Item, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetCategory(int id)
        //{
        //    model.Configuration.ProxyCreationEnabled = false;
        //    List<ResearchCategory> List = model.ResearchCategories.ToList();

        //    return Json(List, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Index()

        {
            ViewBag.Account = model.Accounts.OrderByDescending(x => x.id).ToList();
            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();
            ViewBag.ResearchCategories = model.ResearchCategories.OrderByDescending(x => x.id).ToList();
            var Research = model.Researches.OrderByDescending(x => x.id).ToList();
            return View(Research);
        }
        [HttpPost]
        public ActionResult Index(int Semester_id)
        {
            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList(); 
            var Research = model.Researches.OrderByDescending(x => x.id).ToList().Where(a=>a.Semester_id == Semester_id);
            return View(Research);
        }
     
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ResearchCategories = model.ResearchCategories.OrderByDescending(x => x.id).ToList();
            ViewBag.ResearchItem = model.RearchItems.OrderByDescending(x => x.id).ToList();
            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();
            ViewBag.Research = model.Researches.OrderByDescending(x => x.id).ToList();
            ViewBag.Account = model.Accounts.OrderByDescending(x => x.id).ToList();
            ViewBag.Faculty = model.Faculties.OrderByDescending(x => x.id).ToList();
            ViewBag.isCreate = true;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Explain,Quantity,Note,Semester_id,Item_id,Account_id")] Research f)
        {
            if (ModelState.IsValid)
            {
                model.Researches.Add(f);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResearchItem = model.RearchItems.OrderByDescending(x => x.id).ToList();
            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();
            ViewBag.Research = model.Researches.OrderByDescending(x => x.id).ToList();
            ViewBag.Account = model.Accounts.OrderByDescending(x => x.id).ToList();
            ViewBag.Faculty = model.Faculties.OrderByDescending(x => x.id).ToList();
            ViewBag.isCreate = true;
            return View();


        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = model.Researches.FirstOrDefault(x => x.id == id);
            ViewBag.ResearchItem = model.RearchItems.OrderByDescending(x => x.id).ToList();
            ViewBag.Semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();
            ViewBag.Research = model.Researches.OrderByDescending(x => x.id).ToList();
            ViewBag.Account = model.Accounts.OrderByDescending(x => x.id).ToList();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(int id, Research r)
        {
            var research = model.Researches.FirstOrDefault(x => x.id == id);
            if (ModelState.IsValid)
            {
                
             
                research.Quantity = r.Quantity;
                research.Explain = r.Explain;
               
                research.Note = r.Note;
                research.Account_id = r.Account_id;
                research.Item_id = r.Item_id;
                research.Semester_id = r.Semester_id;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();


        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var research = model.Researches.FirstOrDefault(x => x.id == id);
            return View(research);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var research = model.Researches.FirstOrDefault(x => x.id == id);
            model.Researches.Remove(research);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}