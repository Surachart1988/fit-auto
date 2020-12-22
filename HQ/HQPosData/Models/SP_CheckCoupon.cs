using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HQPosData.Models
{
    class SP_CheckCoupon
    {
        public string coupon_id { get; set; }
        public string coupon_end_date { get; set; }
        public Nullable<bool> UseCoupon { get; set; }
    }
}
