using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Enums
{
    public enum ClaimStatus
    {
        กำลังรับเคลม,
        รับเคลมแล้ว,
        กำลังส่งเคลม,
        ส่งเคลมแล้ว,
        เคลมเรียบร้อยแล้ว,
        ส่งคืนให้ลูกค้าแล้ว,
    }
}
