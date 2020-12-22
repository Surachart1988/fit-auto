namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Transfer_Data_Log
    {
        [Key]
        public int id { get; set; }
        [StringLength(500)]
        public string url_send { get; set; }
        [StringLength(50)]
        public string dealer_code { get; set; }
        [StringLength(255)]
        public string source_table { get; set; }
        [StringLength(10)]
        public string action_type { get; set; }
        public int send_status { get; set; }
        public DateTime send_datetime { get; set; }
        public int user_id { get; set; }
        public string message { get; set; }
        public string id_send_client { get; set; }
    }
}
