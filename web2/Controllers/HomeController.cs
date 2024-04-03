using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web2.Models;

namespace web2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private eshop1Entities db = new eshop1Entities();
        public ActionResult Index()
        {
            //lay danh sach cac san pham cua Hot
            List<Models.Tb_Product> hotProduct = db.Tb_Product.Take(8).ToList();
            ViewBag.hotProduct = hotProduct;
            return View();
        }
        public ActionResult Detail(int id)
        {
            var obj = db.Tb_Product.Where(m=>m.id==id).FirstOrDefault();
            return View(obj);
        }


    }
}