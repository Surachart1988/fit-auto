using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newPos.Models
{
    public class SystemDataBlueCardModel
    {
        public string MID { get; set; }
        public string TID { get; set; }
        public int BatchID { get; set; }
        public Nullable<System.DateTime> OpenDateTime { get; set; }
        public Nullable<System.DateTime> CloseDateTime { get; set; }
        public decimal TotalLoyaltyPrice { get; set; }
        public decimal TotalLoyaltyPoint { get; set; }
        public int OpenStaffID { get; set; }
        public int CloseStaffID { get; set; }
        public int ShopID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}