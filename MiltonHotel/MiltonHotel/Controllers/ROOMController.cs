using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiltonHotel.Controllers
{
    public class ROOMController : Controller
    {

        public ActionResult seeRecords(s)
        {
            List<Models.ROOM> room = (List<Models.ROOM>) TempData["room"];
            return View(room);
        }
    }
}