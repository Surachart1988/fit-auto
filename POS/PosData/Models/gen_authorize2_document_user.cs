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
    
    public partial class gen_authorize2_document_user
    {
        public int user_id { get; set; }
        public int doc_id { get; set; }
        public string create_per { get; set; }
        public string edit_per { get; set; }
        public string view_per { get; set; }
        public string delete_per { get; set; }
        public string approve_per { get; set; }
        public string print_per { get; set; }
        public string export_per { get; set; }
    }
}