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
    
    public partial class ST_ChkPicture
    {
        public int doc_no_run { get; set; }
        public string doc_no { get; set; }
        public string pic_comment { get; set; }
        public string pic_name { get; set; }
        public string pic_path { get; set; }
        public byte[] pic_binary { get; set; }
        public Nullable<int> gen_id { get; set; }
        public Nullable<int> pic_number { get; set; }
        public string pic_comment_detail { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
    }
}