using SEP2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEP2020.Areas.SEP.Controllers
{
    public class KhoaController : Controller
    {
        SEP2020Entities model = new SEP2020Entities();
        public JsonResult KhoaEx(string Name)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!model.Faculties.Any(x => x.Name == Name), JsonRequestBehavior.AllowGet);
        }
        // GET: SEP/Khoa
        [Authorize]
        public ActionResult Index()
        {
            var khoa = model.Faculties.OrderByDescending(x => x.id).ToList();
            return View(khoa);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var khoa = model.Faculties.FirstOrDefault(x => x.id == id);
            return View(khoa);
        }
        [HttpPost]
        public ActionResult Edit(int id, Faculty f)
        {
            var khoa = model.Faculties.FirstOrDefault(x => x.id == id);
            if (ModelState.IsValid)
            {
                khoa.Name = f.Name;


                model.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();

        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.isCreate = true;
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include ="id,Name")]Faculty f)
        {
            if (ModelState.IsValid)
            {
                model.Faculties.Add(f);
                model.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
           
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var khoa = model.Faculties.FirstOrDefault(x => x.id == id);
            return View(khoa);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var khoa = model.Faculties.FirstOrDefault(x => x.id == id);
            var re = model.Accounts.Where(x => x.Falcuty_id == id);
            if (re.Count() != 0)
            {
                TempData["msg"] = "<script>alert('ĐÃ CÓ GV Ở TRONG KHOA NÀY, VUI LÒNG QUAY LẠI !!!');</script>";

            }
            else
            {
                model.Faculties.Remove(khoa);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
           
        }
    }
}