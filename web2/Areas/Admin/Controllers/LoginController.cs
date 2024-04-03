using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace web2.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        Models.eshop1Entities db = new Models.eshop1Entities();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // ReturnUrl để bắt đăng nhập vào trang người dùng cần

        [HttpPost]
        public ActionResult Index(Models.Tb_User obj, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //kiem tra dang nhap cua nguoi dung
                var crrObj = db.Tb_User.FirstOrDefault(m => m.Username == obj.Username && m.Password == obj.Password && m.RoleID==1);
                if (crrObj == null)
                {
                    ModelState.AddModelError("", "Dang nhap that bai, Tai khoan hoac mat khau khong dung, Ban khong phai admin");
                }
                else
                {
                    ModelState.AddModelError("", "Dang nhap thanh cong");
                    //Luu lai trang thai dang nhap cua nguoi dung va kiem soat dang nhap bang Session voi Cookie
                    //c1:
                    //Session["User"] = crrObj;

                    //c2:

                    FormsAuthentication.SetAuthCookie(crrObj.Username, false);
                    //false không ghi nhớ đăng nhập
                    if (ReturnUrl == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }
                    //hết phiên làm việc Logout ra thì ngay lập tức đăng nhập lại vào lại ngay trang đang làm việc
                }
            }

            return View(obj);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            //hủy phiên cokkie
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}