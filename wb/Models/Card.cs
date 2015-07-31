using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wb.ViewModels;

namespace wb.Models
{
    public class Card
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public int X_Position { get; set; }
        public int Y_Position { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public virtual Board Board { get; set; }       
 
        public Card ToDto()
        {
            return new Card { Content = this.Content, Id = this.Id, X_Position = this.X_Position, Y_Position = this.Y_Position };
        }
    }
}