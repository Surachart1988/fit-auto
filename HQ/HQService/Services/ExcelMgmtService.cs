using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using HQPosData.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using static HQService.HQServiceUnityExtension;

namespace HQService.Services
{
    public class ExcelMgmtService : IExcelMgmtService
    {
        private HQEntities _db;
        private Mapper _mapper;
        private DocService _docService;

        public ExcelMgmtService(HQEntities conn, Mapper mapper, DocService docService)
        {
            _db = conn;
            _mapper = mapper;
            _docService = docService;
        }
        //PromotionDiscountPrice
        public void ImportPromotionDiscountPrice(DataTable failDt, ExtraPromotionModel model, Stream Request)
        {
            ExcelPackage package = new ExcelPackage(Request);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
            int rows = worksheet.Dimension.Rows;
            int columns = worksheet.Dimension.Columns;
            var tmp = new List<SbPromotionDetailDisc>();
            SbPromotionDetailDisc sbPromotionDetailDics = null;
            for (int row = 2; row <= rows; row++)
            {
                model.Excel_Mgmt.TotalRecords++;
                var procode = worksheet.Cells[row, 1].Value.ToString();
                var proname = worksheet.Cells[row, 2].Value.ToString();
                var skuproprice = worksheet.Cells[row, 3].Text == "" ? 0 : float.Parse(worksheet.Cells[row, 3].Text);
                var discount_rate = worksheet.Cells[row, 4].Text == "" ? 0 : float.Parse(worksheet.Cells[row, 4].Text);
                if (model.SBPromotionDisDetail.Any(a => a.pro_code == procode) || discount_rate >= skuproprice || discount_rate == 0)
                {
                    model.Excel_Mgmt.FailImport++;
                    failDt.Rows.Add(procode, proname, skuproprice, discount_rate);
                    // msg = procode + " " + worksheet.Cells[row, 2].Value.ToString();
                    //throw new Exception("ErrorPromotionPrice");
                }
                else
                {
                    sbPromotionDetailDics = new SbPromotionDetailDisc
                    {
                        pro_code = procode,
                        pro_name = proname,
                        pro_price_detail = skuproprice,
                        pro_discount_rate_special = discount_rate
                    };
                    model.SBPromotionDisDetail.Add(sbPromotionDetailDics);
                    model.Excel_Mgmt.SuccessImport++;
                }
            }
            model.Excel_Mgmt.failDTGlobal = failDt.Copy();
        }
    }
}
