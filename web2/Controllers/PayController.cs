using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web2.Models;

namespace web2.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        private eshop1Entities db = new eshop1Entities();
        public ActionResult Index()
        {
            if (Session["id"]==null)
            {
                return RedirectToAction("Dangnhap", "KhachHang");
            }
            else
            {
                //lay thong tin tu sesion gio hang
                var lstCart = (List<CartModel>)Session["Cart"];
                // gan gia tri cho bang oder
                Tb_Order obj = new Tb_Order();
                obj.Name = "Don hang- "+ DateTime.Now.ToString("ddMMyyyyHHmmss");
                obj.UserID = int.Parse(Session["id"].ToString());
                obj.OderDate = DateTime.Now;
                obj.Address = Session["address"].ToString();
                obj.Phone = int.Parse(Session["phone"].ToString());
                obj.Note = "Khong";
                //luu thong tin
                db.Tb_Order.Add(obj);
                db.SaveChanges();

                //lay Oderid vua moi toa de luu vao bang oderDetail
                int intOderid = obj.id;
                List<Tb_OderDetail> lstOrderDetail = new List<Tb_OderDetail>();
                foreach (var item in lstCart)
                {
                    Tb_OderDetail objorder = new Tb_OderDetail();
                    objorder.OderID = intOderid;
                    objorder.Quantity = item.Quantity;
                    objorder.UnitPrice = item.Account ;
                    objorder.ProductID = item.ProductDetail.id;
                    lstOrderDetail.Add(objorder);
                }
                db.Tb_OderDetail.AddRange(lstOrderDetail);
                db.SaveChanges();
            }
            return View();
        }
    }
}