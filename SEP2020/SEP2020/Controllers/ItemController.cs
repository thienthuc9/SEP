using SEP2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEP2020.Controllers
{
    public class ItemController : Controller
    {
        SEP2020Entities model = new SEP2020Entities();
        // GET: Item
        public ActionResult Index()
        {
            var item = model.RearchItems.OrderByDescending(x => x.id).ToList();
            return View(item);
        }
        public JsonResult CTEx(string CT)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!model.RearchItems.Any(x => x.CT == CT), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetList(int id)
        {
            model.Configuration.ProxyCreationEnabled = false;
            List<ResearchCategory> Item = model.ResearchCategories.Where(x => x.id == id).ToList();
            return Json(Item, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MaCT(string MaNCKH)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!model.RearchItems.Any(x => x.MaNCKH == MaNCKH), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            ViewBag.ResearchCategories = model.ResearchCategories.OrderByDescending(x => x.id).ToList();
            ViewBag.ResearchItem = model.RearchItems.OrderByDescending(x => x.id).ToList();
            ViewBag.isCreate = true;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MaNCKH,CT,unit,exchange,about,Category_id")] RearchItem f)
        {
            if (ModelState.IsValid)
            {
                model.RearchItems.Add(f);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResearchCategories = model.ResearchCategories.OrderByDescending(x => x.id).ToList();
            ViewBag.ResearchItem = model.RearchItems.OrderByDescending(x => x.id).ToList();
            ViewBag.isCreate = true;
            return View();

          
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = model.RearchItems.FirstOrDefault(x => x.id == id);
            ViewBag.ResearchCategories = model.ResearchCategories.OrderByDescending(x => x.id).ToList();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(int id, RearchItem f)
        {

            var item = model.RearchItems.FirstOrDefault(x => x.id == id);
            if (ModelState.IsValid)
            {
                item.CT = f.CT;
                item.exchange = f.exchange;
                item.unit = f.unit;
                item.about = f.about;
                item.Category_id = f.Category_id;
                item.MaNCKH = f.MaNCKH;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = model.RearchItems.FirstOrDefault(x => x.id == id);
            return View(item);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var re = model.Researches.Where(x => x.Item_id == id);

            var item = model.RearchItems.FirstOrDefault(x => x.id == id);
            if (re.Count() != 0)
            {
                TempData["msg"] = "<script>alert('MỤC NCKH NÀY  ĐÃ TỒN TẠI TRONG GIỜ NCKH , VUI LÒNG QUAY LẠI !!!');</script>";
            }
            else
            {
                model.RearchItems.Remove(item);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
          
        }
    }
}