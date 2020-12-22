using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Injection
{
    public interface ISearchModel
    {
        string PageType { get; set; }
        string TitleName { get; set; }
        //[Display(Name = "ค้นหาจากวันที่")]
        //[DataType(DataType.Text), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        string StartDate { get; set; }

        //[Display(Name = "ถึงวันที่")]
        //[DataType(DataType.Text), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        string EndDate { get; set; }

        [Display(Name = "คำค้นหา")]
        string ValueSearch { get; set; }
        string KeywordsSearch { get; set; }
        string Status { get; set; }
        [Display(Name = "จาก")]
        int KeySearch { get; set; }

        bool DocClose { get; set; }

        bool? DocCancel { get; set; }
    }
}
