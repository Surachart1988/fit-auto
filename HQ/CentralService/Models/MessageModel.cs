using CentralService.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models
{
    public class MessageModel
    {

        public int? Id { get; set; }

        public string Code { get; set; }

        [Required(ErrorMessage = "คุณต้องใส่ชื่อรายการ")]
        [Display(Name = "ชื่อรายการ")]
        [StringLength(255)]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "สถานะการใช้งาน")]
        public MessageStatus Status { get; set; }

        [Display(Name = "สถานะการใช้งาน")]
        public string StatusName { get; set; }

        [Required(ErrorMessage = "คุณต้องใส่ช่วงเวลาที่แสดง")]
        [Display(Name = "ช่วงเวลาที่แสดง")]
        public string DateRange { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Parse(DateTime.Now.ToString());

        public DateTime EndDate { get; set; } = DateTime.Parse(DateTime.Now.ToString());

        [Display(Name = "รายละเอียดคอนเทนต์")]
        public string Content { get; set; }

        [Display(Name = "แนบข้อมูล")]
        public string FileName { get; set; }

        public MessageDocType DocType { get; set; }

    }
}
