using CentralService.Injection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class SearchModel : ISearchModel
    {
        public string PageType { get; set; }
        public string TitleName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ValueSearch { get; set; }
        public string KeywordsSearch { get; set; }
        public string Status { get; set; }
        public int KeySearch { get; set; }
        public bool DocClose { get; set; }
        public bool? DocCancel { get; set; }
    }
}
