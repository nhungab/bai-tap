using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using web2.Models;

namespace web2.Controllers
{
    public class KhachHangController : Controller
    {
        private eshop1Entities db = new eshop1Entities();
        // GET: KhachHang
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(Models.Tb_User obj, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //kiem tra dang nhap cua nguoi dung
                var crrObj = db.Tb_User.FirstOrDefault(m => m.Username == obj.Username && m.Password == obj.Password && m.RoleID == 2);
                if (crrObj == null)
                {
                    ModelState.AddModelError("", "Dang nhap that bai, Tai khoan hoac mat khau khong dung");
                }
                else
                {
                    ModelState.AddModelError("", "Dang nhap thanh cong");
                    //Luu lai trang thai dang nhap cua nguoi dung va kiem soat dang nhap bang Session voi Cookie
                    Session["user"] = crrObj;
                    Session["id"] =crrObj.id ;
                    Session["address"] = crrObj.Address;
                    Session["phone"] = crrObj.Phone;
                    Session["quyen"] = crrObj.RoleID;

                    return RedirectToAction("Index","Home");
                }
            }

            return View(obj);
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(Tb_User obj)
        {
            //Kiem tra va luu database
            if(ModelState.IsValid)
            {
                var check = db.Tb_User.FirstOrDefault(m => m.Username == obj.Username);
                if(check == null)
                {
                    obj.RoleID = 2;
                    db.Tb_User.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.error = "Tài khoản đã tồn tại";
                    return View();
                }
            }
            return View(obj);
        }
        public ActionResult Dangxuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}