using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace web2.Models.MetaData
{
    public class Tb_UserMetaData
    {
        public int id { get; set; }
        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Tai khoan khong duoc de trong!")]
        [MinLength(2, ErrorMessage = "Tai khoan toi thieu 2 ky tu")]
        public string Username { get; set; }
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mat khau khong duoc de trong!")]
        [MinLength(2, ErrorMessage = "Mat khau toi thieu 2 ky tu")]
        public string Password { get; set; }
        [DisplayName("Họ tên")]
        public string Fullname { get; set; }
        [DisplayName("Quyền")]
        public Nullable<int> RoleID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}