using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerCounselling.Models;

namespace InterViewPreparation.Controllers
{
    public class RegisterController : Controller
    {
        MyCounsellingDatabaseEntities db = new MyCounsellingDatabaseEntities();

        public ActionResult Register()
        {
            return View();
        }

        public JsonResult SaveData(User model)
        {
            var dataUserName = db.Users.Where(x => x.Username == model.Username).SingleOrDefault();
            if (dataUserName == null)
            {
                db.Users.Add(model);
                db.SaveChanges();
                return Json("Registration Successful", JsonRequestBehavior.AllowGet);
            }
            else
            {
                model.Username = "";
                return Json("Failed", JsonRequestBehavior.AllowGet);
            }
           
        }

        public JsonResult CheckVaildUser(User model)
        {
            string result = "Fail";
           // var DataItem = db.Users.Where(x => x.Username == model.Username && x.Password == model.Password).SingleOrDefault();
            if (model.Username =="sujeet" && model.Password=="12345")
            {
               // Session["UserID"] = DataItem.UserID.ToString();
              //  Session["UserName"] = DataItem.Username.ToString();
                result = "Success";
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AfterLogin()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }

    }
}
