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
        public ActionResult Index()
        {
            var boards = db.Boards.ToList();
            return View(boards);
        }

        public JsonResult NewCard(int id)
        {
            var board = db.Boards.Single(b => b.Id == id);
            var newCard = db.Cards.Add(new Card() { CreatedOn = DateTime.Now, Board = board });
            db.SaveChanges();

            return Json(newCard.ToDto(), JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Load(int id)
        {
            var cards = db.Boards.Single(x=>x.Id == id).Cards.ToList();
            
            var c = cards.Select(x=> x.ToDto());
            
            return Json(c, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Save(List<Card> cards)
        {
            foreach(var card in cards)
            {
                var c = db.Cards.Find(card.Id);
                c.Content = card.Content;
                c.X_Position = card.X_Position;
                c.Y_Position = card.Y_Position;
            }

            db.SaveChanges();
            
            return Json(new {result = true});
        }
    }
}
