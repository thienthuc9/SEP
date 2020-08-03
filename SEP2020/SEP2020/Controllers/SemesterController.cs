using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP2020.Models;

namespace SEP2020.Areas.SEP.Controllers
{
    public class SemesterController : Controller
    {


        SEP2020Entities model = new SEP2020Entities();
        // GET: SEP/Semester
        public JsonResult IsUserExists(string namesemester)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!model.Semesters.Any(x => x.namesemester == namesemester), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Index()
        {

            var semester = model.Semesters.OrderByDescending(x => x.id_semester).ToList();
            return View(semester);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var semester = model.Semesters.FirstOrDefault(x => x.id_semester == id);
            return View(semester);
        }
        [HttpPost]
        public ActionResult Edit(int id, Semester s)
        {
            var semester = model.Semesters.FirstOrDefault(x => x.id_semester == id);
            if (ModelState.IsValid)
            {
                semester.start_date = s.start_date;
                semester.end_date = s.end_date;
                semester.namesemester = s.namesemester;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
           

        }
        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.Account = model.Accounts.OrderByDescending(x => x.id).ToList();
            ViewBag.isCreate = true;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_semester,namesemester,start_date,end_date,Account_id")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                model.Semesters.Add(semester);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.Account = model.Accounts.OrderByDescending(x => x.id).ToList();
            return View();
        }
        //public ActionResult Create()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.Semesters.Add(semester);
        //        model.SaveChanges();
        //        PopularMessage(true);
        //    }
        //    else
        //    {
        //        PopularMessage(false);
        //    }


        //    return View();
        //}

        //private void PopularMessage(bool success)
        //{
        //    if (success)
        //        Session["success"] = "Successfull!";
        //    else
        //        Session["success"] = "Fail!";
        //}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var semester = model.Semesters.FirstOrDefault(x => x.id_semester == id);
            return View(semester);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var semester = model.Semesters.FirstOrDefault(x => x.id_semester == id);
            var Re = model.Researches.Where(x => x.Semester_id == id);
            if(Re.Count() != 0)
            {
                TempData["msg"] = "<script>alert('HỌC KÌ ĐÃ TỒN TẠI TRONG NCKH, VUI LÒNG QUAY LẠI !!!');</script>";
              
            }
            else
            {
                model.Semesters.Remove(semester);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }


    }
}