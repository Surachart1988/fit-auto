//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PosData.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VSmart_OrderDetailFront
    {
        public int POS_TransactionID { get; set; }
        public int POS_ComputerID { get; set; }
        public int POS_OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public string Product_Code { get; set; }
        public decimal Product_Price { get; set; }
        public decimal Product_Quan { get; set; }
        public Nullable<bool> Flag_Send { get; set; }
    }
}