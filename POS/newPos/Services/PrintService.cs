using CentralService.Models;
using CrystalDecisions.CrystalReports.Engine;
using newPos.Models;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newPos.Services
{
    public class PrintService
    {
        Entities _db = new Entities();
        public void PrintSlipAuto(ReportModels model)
        {
            var rpt = new ReportClass();

            try
            {
                var printer_slip_default = _db.SB_System.FirstOrDefault()?.printer_slip_default;
                model.ReportName = model?.ReportName;
                rpt.FileName = model.MapUrlPrint;
                rpt.Load();

                switch (model.ReportName)
                {
                    case "redeem.rpt":
                        rpt.SetParameterValue("doc_no", model?.ref_docno ?? "");
                        rpt.SetParameterValue("invoice_no", model?.doc_no ?? "");

                        break;
                    case "gen_wifi.rpt":
                        rpt.SetParameterValue("hash_wifi", model?.wifi_password ?? "");
                        rpt.SetParameterValue("datenow", model?.print_time ?? "");
                        break;
                    case "petty_cash.rpt":
                        var run_id = _db.ST_DayStart.OrderByDescending(p => p.run_id).FirstOrDefault()?.run_id;
                        rpt.SetParameterValue("run_id", run_id);

                        break;
                }

                rpt.PrintOptions.PrinterName = printer_slip_default;

                rpt.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw;
            }
            finally
            {
                rpt.Close();
                rpt.Dispose();
            }
        }


    }
}