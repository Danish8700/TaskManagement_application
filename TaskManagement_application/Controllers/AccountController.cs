using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagement_application.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName)
        {
            SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["dbms"].ConnectionString);

            SqlCommand cmd = new SqlCommand("sp_LoginUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", UserName);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["UserId"] = dr["UserId"];
                Session["UserName"] = dr["UserName"];
                return RedirectToAction("Index", "Task");
            }

            ViewBag.Error = "Invalid User";
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}
