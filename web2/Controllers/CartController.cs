using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web2.Models;

namespace web2.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private eshop1Entities db = new eshop1Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int id)
        {

            List<Models.CartModel> data;
            if (Session["Cart"] == null)
            {
                data = new List<Models.CartModel>();
            }
            else
            {
                data = (List<Models.CartModel>)Session["Cart"];
            }

            Models.CartModel check = data.FirstOrDefault(m => m.ProductId == id);

            if (check != null)
            {
                check.Quantity = check.Quantity + 1;
                check.Account = (double)check.ProductDetail.UnitPrice * check.Quantity;

            }
            else
            {
                Models.Tb_Product obj = db.Tb_Product.FirstOrDefault(m => m.id == id);
                Models.CartModel newCart = new Models.CartModel
                {
                    ProductId = id,
                    ProductDetail = obj,
                    Quantity = 1,
                    Account = (double)obj.UnitPrice,
                    Note = "",

                };

                data.Add(newCart);
            }


            Session["Cart"] = data;
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            List<web2.Models.CartModel> data = (List<web2.Models.CartModel>)Session["Cart"];
            var selectcart = data.FirstOrDefault(m => m.ProductId == id);
            if (selectcart != null)
            {
                data.Remove(selectcart);
            }
            Session["Cart"] = data;
            return RedirectToAction("Index");
        }
        
        public ActionResult ThanhToan()
        {
            //kiem tra dang nhap nguoi dung
            if (Session["user"] == null)
            {
                return RedirectToAction("Dangnhap","KhachHang");
            }
            return View();
        }
    }
}