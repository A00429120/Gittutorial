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
                    try {
                        card.CID = (long)Session["CID"];
                        db.CARDs.Add(card);
                        db.SaveChanges();
                    }
                    catch
                    {
                        TempData["err"] = "Card number already exists please enter a new one";
                        return RedirectToAction("cardDetails", "CARD");
                    }
                    

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
            long cust = (long)Session["CID"];
            using (Model4 db = new Model4())
            {
               card = db.CARDs.Where(m => m.CID == cust).ToList();
                return View(card);
            }
        }

        public ActionResult deleteCard(string cardNo)
        {
            using (Models.Model2 db = new Models.Model2())
            {
                Models.CARD obj = db.CARDs.Where(m => m.CREDIT_CARD_NO == cardNo).FirstOrDefault();
                if (obj != null)
                {
                    db.CARDs.Remove(obj);
                    db.SaveChanges();

                    TempData["deleted_card"] = "Card deleted successfuly";
                }

                return RedirectToAction("confimCard","CARD");
            }
        }
    }
}