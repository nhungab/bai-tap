using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web2.Models;

namespace web2.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        private eshop1Entities db = new eshop1Entities();
        public ActionResult Index()
        {
            var data = db.Tb_User.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tb_User obj)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    db.Tb_User.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    
                }
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Tb_User obj = db.Tb_User.Find(id);

            return View(obj);
        }
        public ActionResult Deletef(int id)
        {
            try
            {
                Tb_User obj = db.Tb_User.Find(id);
                if (obj != null)
                {
                    db.Tb_User.Remove(obj);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                // Xử lý ngoại lệ nếu cần
                return View(id);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Tb_User obj = db.Tb_User.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(Tb_User obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
             
                    // Cập nhật thông tin sản phẩm
                    var existingUser = db.Tb_User.Find(obj.id);
                    if (existingUser != null)
                    {
                        existingUser.Password = obj.Password;
                        existingUser.Fullname = obj.Fullname;
                        existingUser.RoleID = obj.RoleID;
                        existingUser.Address = obj.Address;
                        existingUser.Phone = obj.Phone;

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