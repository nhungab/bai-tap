using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web2.Models;

namespace web2.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private eshop1Entities db = new eshop1Entities();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var data = db.Tb_Product.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var lst = db.Tb_Category.ToList();
            ViewBag.CategoryID = new SelectList(lst, "id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tb_Product obj, HttpPostedFileBase fImage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Lưu file ảnh
                    if (fImage != null && fImage.ContentLength > 0)
                    {
                        string fName = Path.GetFileName(fImage.FileName);
                        string folder = Server.MapPath("~/Assets/Uploads/" + fName);
                        fImage.SaveAs(folder);
                        obj.Image = "/Assets/Uploads/" + fName;
                    }

                    db.Tb_Product.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch {
                    // Xử lý ngoại lệ nếu cần
                    ModelState.AddModelError("", "Lỗi khi thêm sản phẩm. Vui lòng thử lại.");
                }
            }

            // Nếu ModelState không hợp lệ hoặc có lỗi, bạn cần tạo SelectList cho CategoryID và trả về View với model obj
            var lst = db.Tb_Category.ToList();
            ViewBag.CategoryID = new SelectList(lst, "id", "Name", obj.CategoryID);
            return View(obj);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Tb_Product obj = db.Tb_Product.Find(id);
            
            return View(obj);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Tb_Product obj = db.Tb_Product.Find(id);
                if (obj != null)
                {
                    db.Tb_Product.Remove(obj);
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
            Tb_Product obj = db.Tb_Product.Find(id);
            var lst = db.Tb_Category.ToList();
            ViewBag.CategoryID = new SelectList(lst, "id", "Name");
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(Tb_Product obj, HttpPostedFileBase fImage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Lưu file ảnh
                    if (fImage != null && fImage.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(fImage.FileName);
                        string folder = Server.MapPath("~/Assets/Uploads/");
                        string fullPath = Path.Combine(folder, fileName);
                        fImage.SaveAs(fullPath);

                        // Cập nhật đường dẫn ảnh trong đối tượng sản phẩm
                        obj.Image = "/Assets/Uploads/" + fileName;
                    }

                    // Cập nhật thông tin sản phẩm
                    var existingProduct = db.Tb_Product.Find(obj.id);
                    if (existingProduct != null)
                    {
                        existingProduct.Name = obj.Name;
                        existingProduct.UnitPrice = obj.UnitPrice;
                        existingProduct.ProductDate = obj.ProductDate;
                        existingProduct.Available = obj.Available;
                        existingProduct.CategoryID = obj.CategoryID;
                        existingProduct.Description = obj.Description;
                        existingProduct.Image = obj.Image; // Đặt lại đường dẫn ảnh
                        existingProduct.Slug = obj.Slug;

                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    
                }
            }
            // Xử lý ngoại lệ nếu cần
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            // Xử lý lỗi, log, hoặc hiển thị thông báo cho người dùng
            // Nếu ModelState không hợp lệ hoặc có lỗi, bạn cần tạo SelectList cho CategoryID và trả về View với model obj
            var categories = db.Tb_Category.ToList();
            ViewBag.CategoryID = new SelectList(categories, "id", "Name", obj.CategoryID);
            return View(obj);
        }

    }
}