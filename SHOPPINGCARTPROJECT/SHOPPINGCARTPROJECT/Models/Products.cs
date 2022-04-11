using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOPPINGCARTPROJECT.Models
{
    public class Products
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PropertyId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public HttpPostedFileBase Image { get; set; }

        public IEnumerable<SelectListItem> SelectProducts { get; set; }
    }
}