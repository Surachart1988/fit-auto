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
    
    public partial class SB_Question_Choice
    {
        public int question_choice_id { get; set; }
        public Nullable<int> question_detail_id { get; set; }
        public string question_choice { get; set; }
        public string question_choice_name { get; set; }
        public string question_choice_type { get; set; }
        public string question_choice_value { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
    }
}
