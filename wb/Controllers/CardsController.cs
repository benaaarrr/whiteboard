using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wb.Models;

namespace wb.Controllers
{
    public class CardsController : Controller
    {
        private CardContext db = new CardContext();

        // GET: Cards
        
        public JsonResult Load()
        {            
            var card = db.Cards.Take(1).OrderByDescending(c => c.CreatedOn).Single();
            return Json(card, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Save(string cardHtml)
        {
            var success = false;
            try
            {
                if (cardHtml.Length > 0)
                {
                    db.Cards.Add(new Card() { CreatedOn = DateTime.Now, Html = cardHtml });
                    db.SaveChanges();
                }
                success = true;
            }
            catch(Exception ex)
            {
                success = false;
            }
            
            return Json(new {result = success});
        }
    }
}
