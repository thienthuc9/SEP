using SEP2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEP2020.Controllers
{
    public class CategoryController : Controller
    {
        SEP2020Entities model = new SEP2020Entities();
        // GET: Category
        public ActionResult Index()
        {
            var danhmuc = model.ResearchCategories.OrderByDescending(x => x.id).ToList();
            return View(danhmuc);
            
        }
        public JsonResult NameExists(string Name)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!model.ResearchCategories.Any(x => x.Name == Name), JsonRequestBehavior.AllowGet);
        }
        public JsonResult MaC(int Ma)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!model.ResearchCategories.Any(x => x.Ma == Ma), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.isCreate = true;
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,Ma,Name")] ResearchCategory f)
        {
            if (ModelState.IsValid)
            {
                model.ResearchCategories.Add(f);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
           
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = model.ResearchCategories.FirstOrDefault(x => x.id == id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(int id, ResearchCategory f)
        {

            var item = model.ResearchCategories.FirstOrDefault(x => x.id == id);
            if (ModelState.IsValid)
            {
                item.Name = f.Name;
                item.Ma = f.Ma;


                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = model.ResearchCategories.FirstOrDefault(x => x.id == id);
            return View(item);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var re = model.RearchItems.Where(x => x.Category_id == id);
            var acc = model.ResearchCategories.FirstOrDefault(x => x.id == id);
            if(re.Count() != 0)
            {
                TempData["msg"] = "<script>alert('DANH MỤC NCKH NÀY  ĐÃ TỒN TẠI TRONG MỤC NCKH , VUI LÒNG QUAY LẠI !!!');</script>";
            }
            else
            {
                model.ResearchCategories.Remove(acc);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
           
        }

    }
}