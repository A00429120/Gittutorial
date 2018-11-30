using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiltonHotel.Controllers
{
    public class ROOMController : Controller
    {
        private Models.Model2 db = new Models.Model2();
        // GET: ROOM
        public ActionResult seeRecords()
        {
            return View(db.ROOMS.ToList());
        }

        [HttpPost]
        public ActionResult seeRecords(Models.ROOM room)
        {
            
            return View(db.ROOMS.ToList());
        }
    }
}