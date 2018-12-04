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
                Session["FROM_DATE"] = book.FROM_DATE;
                Session["TO_DATE"] = book.TO_DATE;
                Session["QUANTITY"] = book.QUANTITY;
                Models.Model2 rm = new Models.Model2();
                List<Models.ROOM> rooms = rm.ROOMS.ToList();
                List<Models.ROOM> rmz = rooms;
                using (Models.Model3 db = new Models.Model3())
                {
                    List<Models.BOOKING> bookings = db.BOOKINGs.Where(u => (u.FROM_DATE <= book.TO_DATE && u.TO_DATE >= book.FROM_DATE) ).ToList();
                    foreach(Models.BOOKING bk in bookings)
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
            if(Session["CID"] == null)
            {
                return RedirectToAction("login", "CUSTOMER");
            }
            else
            {
                return RedirectToAction("confimCard", "CARD");
            }
            //return View();
        }

        public ActionResult confirmBooking(string cardNo)
        {
            Models.BOOKING book = new Models.BOOKING();
                using (Models.Model3 db = new Models.Model3())
                {
                book.ROOM_NO = (int)Session["ROOM_NO"];
                book.TO_DATE = (DateTime)Session["TO_DATE"];
                book.FROM_DATE = (DateTime)Session["FROM_DATE"];
                book.QUANTITY = (int)Session["QUANTITY"];
                book.CID = (long)Session["CID"];
                    db.BOOKINGs.Add(book);
                    db.SaveChanges();

                }

                ModelState.Clear();
            //API CALL TO TRANSACTION
            Models.ROOM room = new Models.ROOM();
            Models.CARD card = new Models.CARD();
            using (Models.Model2 db = new Models.Model2())
            {
                room = db.ROOMS.FirstOrDefault(m => m.ROOM_NO == book.ROOM_NO);
                card = db.CARDs.FirstOrDefault(m => m.CREDIT_CARD_NO == cardNo.ToString());
                book = db.BOOKINGs.FirstOrDefault(m => m.ROOM_NO == book.ROOM_NO && m.QUANTITY == book.QUANTITY
                && m.FROM_DATE == book.FROM_DATE && m.TO_DATE == book.TO_DATE);
            }
                ServiceReference1.Assignment3Client test = new ServiceReference1.Assignment3Client();
            //TODO
            string responce = test.create(book.BOOKING_NO.ToString(), cardNo.ToString(),card.EXP_DATE,Session["FNAME"]+ " "+ Session["LNAME"],
                room.PRICE.ToString(),((book.TO_DATE-book.FROM_DATE).TotalDays+1).ToString());

            TempData["room_details"] = "Room No : "+ book.ROOM_NO +"\nCheck-in Date : "+book.FROM_DATE+"\nCheck-out Date: "
                +book.TO_DATE+"\nTotal Price : "+ ((book.TO_DATE - book.FROM_DATE).TotalDays + 1) * room.PRICE;

            Session["ROOM_NO"] = null;
            Session["FROM_DATE"] = null;
            Session["TO_DATE"] = null;
            Session["QUANTITY"] = null;
            TempData["booking_success"] = "Payment responce: "+responce+" The room No.:"+ book.ROOM_NO+" has been booked";
                return RedirectToAction("findRoom");

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
                Models.BOOKING obj = db.BOOKINGs.Where(m => m.BOOKING_NO == id).FirstOrDefault();
                if(obj != null && obj.FROM_DATE > DateTime.Now)
                {
                    db.BOOKINGs.Remove(obj);
                    db.SaveChanges();

                    ServiceReference1.Assignment3Client test = new ServiceReference1.Assignment3Client();

                    string responce = test.remove(id.ToString());

                    TempData["deleted"] = "Payment responce: " + responce + " Booking deleted successfuly";
                }
                else
                {
                    TempData["deleted"] = "It is not possible to delete bookings older than Today";
                }
                return RedirectToAction("showBookings");
            }
        }

    }
}
