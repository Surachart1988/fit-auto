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
        string StartDate { get; set; }
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
