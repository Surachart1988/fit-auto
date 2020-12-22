namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MessageData")]
    public partial class MessageData
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Status { get; set; }

        public string Content { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public bool SendClient { get; set; }

        public int DocType { get; set; }
    }
}
