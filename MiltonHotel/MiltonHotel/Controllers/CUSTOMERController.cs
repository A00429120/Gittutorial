using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MiltonHotel.Controllers
{
    public class CUSTOMERController : Controller
    {
        // GET: CUSTOMER
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signup(Models.CUSTOMER acc)
        {
            if (ModelState.IsValid)
            {
                using (Models.Model1 db = new Models.Model1())
                {
                    db.CUSTOMERs.Add(acc);
                    db.SaveChanges();

                }
                ModelState.Clear();
                // ViewBag.Message = acc.Fname + " " + acc.lname + " is successfully registered";
                TempData["Success"] = acc.FNAME + " " + acc.LNAME + " is successfully registered";
                return RedirectToAction("Login");
            }
            return View();
        }

        //login page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string MAIL, string password)
        {
            using (Models.Model1 db = new Models.Model1())
            {
                var usr = db.CUSTOMERs.FirstOrDefault(u => u.MAIL == MAIL && u.PASSWORD == password);
                if (usr != null)
                {
                    Session["CID"] = usr.CID;
                    Session["MAIL"] = usr.MAIL.ToString();
                    Session["FNAME"] = usr.FNAME.ToString();
                    Session["LNAME"] = usr.LNAME.ToString();

                        return RedirectToAction("findRoom", "BOOKING");

                }
                else
                {
                    ModelState.AddModelError("", "Username or password is wrong please login");
                }
            }
            return View();
        }


        public ActionResult LoggedOn()
        {
            if (Session["CID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}