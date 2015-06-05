using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wb.Models
{
    public class Card
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public int X_Position { get; set; }
        public int Y_Position { get; set; }
        
        public DateTime CreatedOn { get; set; }
    }
}