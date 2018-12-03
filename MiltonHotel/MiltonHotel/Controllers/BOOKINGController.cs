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
            if (ModelState.IsValid)
            {
                Session["FROM_DATE"] = book.FROM_DATE;
                Session["TO_DATE"] = book.TO_DATE;
                Session["QUANTITY"] = book.QUANTITY;
                Models.Model2 rm = new Models.Model2();
                List<Models.ROOM> rooms = rm.ROOMS.ToList();
                List<Models.ROOM> rmz = rooms;
                using (Models.Model3 db = new Models.Model3())
                {
                    List<Models.BOOKING> bookings = db.BOOKINGs.Where(u => (u.FROM_DATE <= book.TO_DATE || u.TO_DATE >= book.FROM_DATE)).ToList();
                    foreach (Models.BOOKING bk in bookings)
                    {
                        foreach (Models.ROOM rz in rmz.ToList())
                        {
                            if (rz.ROOM_NO == bk.ROOM_NO && rooms.Contains(rz))
                            {
                                rooms.Remove(rz);
                            }
                        }
                    }
                    TempData["room"] = rooms;
                    return RedirectToAction("seeRecords", "ROOM");
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

        public ActionResult showBookings()
        {
            List<Models.BOOKING> bookings = new List<Models.BOOKING>();
            long cid = (long)Session["CID"];
            using (Models.Model2 db = new Models.Model2())
            {
                bookings = db.BOOKINGs.Where(m => m.CID == cid).ToList();
                return View(bookings);
            }
        }

        public ActionResult deleteBooking(int id)
        {
            using (Models.Model2 db = new Models.Model2())
            {
                Models.BOOKING obj = db.BOOKINGs.Where(m => m.BOOKING_NO == id && m.FROM_DATE > DateTime.Now).FirstOrDefault();
                if (obj != null)
                {
                    db.BOOKINGs.Remove(obj);
                    db.SaveChanges();
                    TempData["deleted"] = "Booking deleted successfuly";

                }
                return RedirectToAction("showBookings");
            }
        }


    }
}