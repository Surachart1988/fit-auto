using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace CentralService.Models
{
  public  class RegisterBlueCardModel
    {

        [Display(Name = "เลขบัตร ปชช.")]
        public string ThaiIDCard { get; set; }

        [Display(Name = "เบอร์โทรศัพท์")]
        public string MoblieNumber { get; set; }

        [Display(Name = "อีเมลล์")]
        public string Email { get; set; }

        [Display(Name = "หมายเลขบัตร BlueCard")]
        public string CardNumber { get; set; }
        public string MID { get; set; }
        public string TID { get; set; }
        public RegisterBlueCardModel()
        {

        }
    }
}
