using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace web2.Models.MetaData
{
    public class Tb_Product
    {
        [DisplayName("Ma san pham")]
        public int id { get; set; }
        [DisplayName("Ten san pham")]
        [Required(ErrorMessage = "Ten khong duoc de trong!")]
        public string Name { get; set; }
        [DisplayName("Ten")]
        public string Slug { get; set; }
        [DisplayName("Don gia")]
        [Required(ErrorMessage = "Don gia khong duoc de trong!")]
        public Nullable<double> UnitPrice { get; set; }
        [DisplayName("Anh")]
        public string Image { get; set; }
        [DisplayName("Thoi gian")]
        public Nullable<System.DateTime> ProductDate { get; set; }
        [DisplayName("San co")]
        public Nullable<bool> Available { get; set; }
        [DisplayName("Danh muc")]
        public Nullable<int> CategoryID { get; set; }
        [DisplayName("Mo ta")]
        public string Description { get; set; }

    }
}