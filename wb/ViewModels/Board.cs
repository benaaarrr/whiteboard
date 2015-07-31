using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wb.Models;

namespace wb.ViewModels
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Card> Cards { get; set; }
    }
}