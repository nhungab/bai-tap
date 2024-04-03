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
    public class OrderController : Controller
    {
        private eshop1Entities db = new eshop1Entities();
        // GET: Admin/Order
        public ActionResult Index()
        {
            var data = db.Tb_Order.ToList();
            return View(data);
        }
        
        
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Tb_Order obj = db.Tb_Order.Find(id);
            var lst = db.Tb_User.ToList();
            ViewBag.UserID = new SelectList(lst, "id", "Username");
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(Tb_Order obj)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    // Cập nhật thông tin sản phẩm
                    var existingUser = db.Tb_Order.Find(obj.id);
                    if (existingUser != null)
                    {
                        existingUser.Name = obj.Name;
                        existingUser.UserID = obj.UserID;
                        existingUser.OderDate = obj.OderDate;
                        existingUser.Address = obj.Address;
                        existingUser.Phone = obj.Phone;
                        existingUser.Note = obj.Note;
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
            // Xử lý ngoại lệ nếu cần
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            // Xử lý lỗi, log, hoặc hiển thị thông báo cho người dùng
            // Nếu ModelState không hợp lệ hoặc có lỗi, bạn cần tạo SelectList cho CategoryID và trả về View với model obj
            var lst = db.Tb_User.ToList();
            ViewBag.UserID = new SelectList(lst, "id", "Username", obj.UserID);
            return View(obj);
        }
    }
}