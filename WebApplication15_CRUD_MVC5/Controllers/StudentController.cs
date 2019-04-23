using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15_CRUD_MVC5.Models; 

namespace WebApplication15_CRUD_MVC5.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentDBHandle dbhandle = new StudentDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetStudent());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateNew()
        {         
          return View();
        }


        // GET: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentDBHandle sdb = new StudentDBHandle();
                    if (sdb.AddStudent(smodel))
                    {
                        ViewBag.Message = "Student Details Added Succesfully";
                        ModelState.Clear();
                    }
                }
                return new ViewResult { ViewName = "CreateNew" };
                // ActionLink("Create", "CreateNew");
                //return View();
            }
            catch 
            {
                return new ViewResult { ViewName = "CreateNew" };
                //return View();
            }          
        }

        //// POST: Student/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
