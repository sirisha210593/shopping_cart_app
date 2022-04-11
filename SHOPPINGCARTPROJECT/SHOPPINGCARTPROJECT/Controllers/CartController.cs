using SHOPPINGCARTPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOPPINGCARTPROJECT.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        private readonly ShoppingCartEntities obj;
        private List<Cart> shoppinglist;
        public CartController()
        {
            obj = new ShoppingCartEntities();
            shoppinglist = new List<Cart>();
        }
        //[Authorize]
        public ActionResult Add(string ProductId)
        {
            Cart cart = new Cart();
            Product pro = obj.Products.Single(x => x.ProductId.ToString() == ProductId);
            if (Session["count"] != null)
            {
                shoppinglist = (List<Cart>)Session["cart"];
            }
            if (shoppinglist.Any(model => model.ProductId == ProductId))
            {
                cart = shoppinglist.Single(model => model.ProductId == ProductId);
                cart.Quantity++;
                cart.Total = cart.UnitPrice * cart.Quantity;
            }
            else
            {
                cart.ProductId = ProductId;
                cart.Image = pro.Image;
                cart.ProductName = pro.ProductName;
                cart.Quantity = 1;
                cart.Total = pro.Price;
                cart.UnitPrice = pro.Price;
                shoppinglist.Add(cart);

            }
            Session["cart"] = shoppinglist;
            Session["count"] = shoppinglist.Count;
            return RedirectToAction("Index", "Home");
        }
       //  [Authorize]
        public ActionResult Myorder()
        {

            return View((List<Cart>)Session["cart"]);

        }

        public ActionResult Remove(Cart s)
        {
            shoppinglist = (List<Cart>)Session["cart"];
            shoppinglist.RemoveAll(x => x.ProductId == s.ProductId);
            Session["cart"] = shoppinglist;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "Cart");

        }
        [HttpPost]
        public ActionResult CreateOrder1()
        {

            shoppinglist = Session["cart"] as List<Cart>;


            foreach (var item in shoppinglist)
            {
                Order objOrder = new Order
                {
                    Total = item.Total,
                    Quantity = (int)item.Quantity,
                    ProductName=item.ProductName,
                    OrderDate = DateTime.Now
                };
                obj.Orders.Add(objOrder);
                obj.SaveChanges();
            }

            Session["cart"] = null;
            Session["count"] = null;
            return RedirectToAction("Myorder", "Cart");

        }
        
        public ActionResult CreateOrder()
        {

            IEnumerable<Order1> listOfShopping = (from objItem in obj.Orders
                                                    select new Order1()
                                                    {
                                                        OrderId = objItem.OrderId,
                                                        ProductName = objItem.ProductName,
                                                        Total= objItem.Total,
                                                        Quantity=objItem.Quantity,
                                                        OrderDate= objItem.OrderDate

                                                    }).ToList();
            return View(listOfShopping);
        }
    }
}
