using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOPPINGCARTPROJECT.Models
{
    public class Order1
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}