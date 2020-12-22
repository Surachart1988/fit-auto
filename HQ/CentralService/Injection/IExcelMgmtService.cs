using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CentralService.Injection
{
    public interface IExcelMgmtService
    {
        void ImportPromotionDiscountPrice(DataTable failDt, ExtraPromotionModel model, Stream Request);
    }
}
