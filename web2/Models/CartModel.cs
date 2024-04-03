using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web2.Models
{
    public class CartModel
    {
        public int ProductId { get; set; }
        public Tb_Product ProductDetail { get; set; }
        public int Quantity { get; set; } = 1;

        public double Account { get; set; }
        public string Note { get; set; }
    }
}