using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class PromotionList
    {
        public string pro_id { get; set; }

        public string pro_name { get; set; }

        public bool IsCheck { get; set; }
    }
    public class DealercodeModel
    {
        public string plant_no { get; set; }
        public string dealercode { get; set; }

        public string DealerName { get; set; }

        public bool IsCheck { get; set; }
    }
    public class ConditionMonth
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsSelected { get; set; }
    }
    public class ConditionWeek
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsSelected { get; set; }
    }
    public enum _days
    {
        อาทิตย์,
        จันทร์,
        อังคาร,
        พุธ,
        พฤหัสบดี,
        ศุกร์,
        เสาร์

    }
}
