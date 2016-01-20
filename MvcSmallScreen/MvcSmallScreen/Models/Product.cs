using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSmallScreen.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Goods> Goods { get; set; }
    }
}