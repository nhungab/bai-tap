using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web2.Models;

namespace web2.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        private eshop1Entities db = new eshop1Entities();
        public ActionResult Index()
        {
            var data = db.Tb_Category.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tb_Category obj)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    db.Tb_Category.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    // Xử lý ngoại lệ nếu cần
                    ModelState.AddModelError("", "Lỗi khi thêm sản phẩm. Vui lòng thử lại.");
                }
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Tb_Category obj = db.Tb_Category.Find(id);

            return View(obj);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Tb_Category obj = db.Tb_Category.Find(id);
                if (obj != null)
                {
                    db.Tb_Category.Remove(obj);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch {
                // Xử lý ngoại lệ nếu cần
                return View(id);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Tb_Category obj = db.Tb_Category.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(Tb_Category obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    // Cập nhật thông tin sản phẩm
                    var existingCategory = db.Tb_Category.Find(obj.id);
                    if (existingCategory != null)
                    {
                        existingCategory.Name = obj.Name;
                        existingCategory.NameVN = obj.NameVN;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu cần
                    Console.WriteLine(ex.ToString());
                }
            }
            return View(obj);
        }
    }
}