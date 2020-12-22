namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_dsHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CS_dsHeader()
        {
            CS_dsDetail = new HashSet<CS_dsDetail>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string doc_code { get; set; }

        [StringLength(10)]
        public string doc_date { get; set; }

        [StringLength(8)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string ven_code { get; set; }

        [StringLength(255)]
        public string emp_code { get; set; }

        [StringLength(1)]
        public string doc_Close { get; set; }

        [StringLength(1)]
        public string doc_Cancle { get; set; }

        [StringLength(10)]
        public string doc_cancledate { get; set; }

        [StringLength(10)]
        public string date_report { get; set; }

        public int? detail_line { get; set; }

        [StringLength(255)]
        public string doc_no2 { get; set; }

        [StringLength(500)]
        public string sRemark { get; set; }

        [StringLength(500)]
        public string sCcRemark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CS_dsDetail> CS_dsDetail { get; set; }
    }
}
