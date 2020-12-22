using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;

namespace CentralService.Models
{

    public class UserAccountModel
    {

        [Required]
        [Display(Name = "ชื่อเข้าใช้ระบบ")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "รหัสผ่าน")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string IpAddress { get; set; }
    }
}