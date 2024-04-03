using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web2.Models;

namespace web2.Areas.Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        private eshop1Entities db = new eshop1Entities();
        // GET: Admin/Order
        public ActionResult Index()
        {
            var data = db.Tb_OderDetail.ToList();
            return View(data);
        }

        
    }
}