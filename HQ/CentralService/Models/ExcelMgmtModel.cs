using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;

namespace CentralService.Models
{
    public class ExcelMgmtModel
    {
        public ExcelMgmtModel()
        {
            //TotalRecords = new int();
            //SuccessUpdate = new int();
            //FailImport = new int();
            //NotUpdate = new int();
            //NotExist = new int();
            //filePathGlobal = "";
            //failDTGlobal = new DataTable();
        }
        public int TotalRecords { get; set; }
        public int SuccessImport { get; set; }
        public int FailImport { get; set; }
        public int NotUpdate { get; set; }
        public int NotExist { get; set; }
        public string filePathGlobal { get; set; }

        public DataTable failDTGlobal;
    }
}