using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiltonHotel.Controllers
{
    public class BOOKINGController : Controller
    {
        // GET: BOOKING
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult findRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult findRoom(Models.BOOKING book)
        {
            if(ModelState.IsValid)
            {
                using (Models.Model3 db = new Models.Model3())
                {
                    //var usr = db.BOOKINGs.F

                }
            }
            return View();
        }


        public ActionResult book(int id)
        {
            Session["ROOM_NO"] = id;
            if (Session["CID"] == null)
            {
                return RedirectToAction("login", "CUSTOMER");
            }

            //return View();
        }
    }
}