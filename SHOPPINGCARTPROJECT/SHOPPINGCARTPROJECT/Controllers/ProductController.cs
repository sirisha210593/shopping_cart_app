using SHOPPINGCARTPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOPPINGCARTPROJECT.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private readonly ShoppingCartEntities obj;

        public ProductController()
        {
            obj = new ShoppingCartEntities();
        }
        public ActionResult Index()
        {
            Products product = new Products
            {
                SelectProducts = from p in obj.Categories
                                 select new SelectListItem()
                                 {
                                     Text = p.CategoryName,
                                     Value = p.CategoryId.ToString(),
                                     Selected = true

                                 }
            };
            return View(product);
        }
        [HttpPost]
        public  JsonResult Index(Products productmodel)
        {
            string Newimg = Guid.NewGuid() + Path.GetExtension(productmodel.Image.FileName);
            productmodel.Image.SaveAs(Server.MapPath("~/Images/" + Newimg));
            Product ob = new Product
            {
                Image = "~/Images/" + Newimg,
                CategoryId = productmodel.CategoryId,
                ProductName = productmodel.ProductName,
                Price = productmodel.Price,
                Description = productmodel.Description,
                ProductId = Guid.NewGuid()
            };
            obj.Products.Add(ob);
            obj.SaveChanges();
            return Json("true",JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(string id)
        {
            try
            {

                var pro = obj.Products.SingleOrDefault(x => x.ProductId.ToString().ToLower() == id);
                //Product pro = obj.Products.Find(id);
                obj.Products.Remove(pro);
                obj.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Index", "Home", new { id, saveChangesError = true });
            }
            return RedirectToAction("Index", "Home");
        }
    }
}