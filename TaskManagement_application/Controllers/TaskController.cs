using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement_application.DAL;
using TaskManagement_application.Models;

namespace TaskManagement_application.Controllers
{
    public class TaskController : Controller
    {
        TaskDAL dal = new TaskDAL();

        public ActionResult Index(string search)
        {

            if (!string.IsNullOrEmpty(search))
            {
                return View(dal.SearchTasks(search));
            }
            else
            {
                return View(dal.GetAllTasks());
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskModel model)
        {
            model.CreatedBy = Convert.ToInt32(Session["UserId"]);
            model.LastUpdatedBy = model.CreatedBy;

            TaskDAL dal = new TaskDAL();
            dal.InsertTask(model);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            dal.DeleteTask(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(dal.GetTaskById(id));
        }

        [HttpPost]
        public ActionResult Edit(TaskModel model)
        {
            model.LastUpdatedBy = Convert.ToInt32(Session["UserId"]);

            TaskDAL dal = new TaskDAL();
            dal.UpdateTask(model);

            return RedirectToAction("Index");
        }
    }
}