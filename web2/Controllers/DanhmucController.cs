using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web2.Models;

namespace web2.Controllers
{
    public class DanhmucController : Controller
    {
        Models.eshop1Entities db = new Models.eshop1Entities();
        // GET: Danhmuc
        public ActionResult Index(string SearchString)
        {
            //lay danh sach cac san pham cua Hot

            //List<Models.Tb_Product> hotProduct = db.Tb_Product.Take(126).ToList();
            //ViewBag.hotProduct = hotProduct;
            //List<Models.Tb_Category> hotcategory = db.Tb_Category.Take(40).ToList();
            //ViewBag.hotcategory = hotcategory;
            //return View();
            IQueryable<Tb_Product> queryProduct = db.Tb_Product;
            IQueryable<Tb_Category> queryCategory = db.Tb_Category;

            if (!string.IsNullOrEmpty(SearchString))
            {
                // Lọc sản phẩm theo tên
                queryProduct = queryProduct.Where(p => p.Name.Contains(SearchString));

                // Lọc danh mục theo tên
                queryCategory = queryCategory.Where(c => c.Name.Contains(SearchString));
            }

            // Lấy danh sách các sản phẩm của Hot
            List<Tb_Product> hotProduct = queryProduct.Take(126).ToList();
            ViewBag.hotProduct = hotProduct;

            // Lấy danh sách các danh mục của Hot
            List<Tb_Category> hotCategory = queryCategory.Take(40).ToList();
            ViewBag.hotCategory = hotCategory;

            return View();
        }
        public ActionResult Category(int id)
        {
            List<Models.Tb_Category> hotcategory = db.Tb_Category.Take(40).ToList();
            ViewBag.hotcategory = hotcategory;
            var hotProduct = db.Tb_Product.Where(m => m.CategoryID == id).ToList();
            ViewBag.hotProduct = hotProduct;
            return View();
        }
    }
}