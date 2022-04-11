using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOPPINGCARTPROJECT.Models
{
    public class Cart
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public string Image { get; set; }
      
    }
}