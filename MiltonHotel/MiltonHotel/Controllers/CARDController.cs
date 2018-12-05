using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiltonHotel.Models;

namespace MiltonHotel.Controllers
{
    public class CARDController : Controller
    {
        // GET: CARD
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult cardDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cardDetails(CARD card)
        {
            if (ModelState.IsValid)
            {
                using (Model4 db = new Model4())
                {
                    card.CID = (long) Session["CID"];
                    db.CARDs.Add(card);
                    db.SaveChanges();

                }

                ModelState.Clear();
                Session["card_no"] = card.CREDIT_CARD_NO;
                return RedirectToAction("confimCard", "CARD");
            }
            return View();
        }

        public ActionResult confimCard()
        {
            List<CARD> card = new List<CARD>();
            using (Model4 db = new Model4())
            {
               card = db.CARDs.ToList();
                return View(card);
            }
        }
    }
}