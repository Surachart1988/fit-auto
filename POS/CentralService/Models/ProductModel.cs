using CentralService.Enums;
using CentralService.Injection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Models
{
    public class ProductModel
    {
        public string branch_no { get; set; }
        public string pro_code { get; set; }
        public string pro_ven_code { get; set; }
        public string alternate_code { get; set; }
        public string subgroup_code { get; set; }
        public string ven_code { get; set; }
        public string pro_recordtype { get; set; }
        public string pro_tname { get; set; }
        public string pro_ename { get; set; }
        public string pro_type { get; set; }
        public string progroup_code { get; set; }
        public int? pro_brand_code { get; set; }
        public string pro_brand { get; set; }
        public int? pro_model_code { get; set; }
        public string pro_model { get; set; }
        public int? pro_size_code { get; set; }
        public string pro_size { get; set; }
        public string pro_stock { get; set; }
        public int? store_unit_code { get; set; }
        public string store_unit { get; set; }
        public int? buy_unit_code { get; set; }
        public string buy_unit { get; set; }
        public int? sale_unit_code { get; set; }
        public string sale_unit { get; set; }
        public double? max_qty { get; set; }
        public double? ord_qty { get; set; }
        public double? min_qty { get; set; }
        public double? lasted_cost { get; set; }
        public double? average_cost { get; set; }
        public int? locat_code { get; set; }
        public string store_location { get; set; }
        public double? pro_ohqty { get; set; }
        public double? pro_accqty { get; set; }
        public double? pro_poqty { get; set; }
        public double? pro_ocqty { get; set; }
        public double? pro_otqty { get; set; }
        public double? pro_bqty { get; set; }
        public double? pro_amtavg { get; set; }
        public double? pro_amtfifo { get; set; }
        public double? pro_amtlasted { get; set; }
        public double? pro_disc { get; set; }
        public double? pro_price_retail { get; set; }
        public double? pro_price_ws { get; set; }
        public double? pro_price_buy { get; set; }
        public double? pro_invat { get; set; }
        public string cancel_date { get; set; }
        public string pro_cantype { get; set; }
        public string stock_status { get; set; }
        public string rec_date { get; set; }
        public string rec_memo { get; set; }
        public string tpe_package { get; set; }
        public int Pro_Code_Run { get; set; }
        public string AF_Status { get; set; }
        public double? SCARD_TYPE { get; set; }
        public string SUB_NEXTSERV_CODE { get; set; }
        public double? KM { get; set; }
        public double? SER_DAY { get; set; }
        public double? DATE_REPORT { get; set; }
        public double? Average_Cost_VAT { get; set; }
        public double? Average_Cost_NOVAT { get; set; }
        public double? LASTED_COST_VAT { get; set; }
        public string TB_Status { get; set; }
        public string EU_Status { get; set; }
        public double? EU_Point { get; set; }
        public string TOP_Status { get; set; }
        public double? TOP_Point { get; set; }
        public string lasted_cost_date { get; set; }
        public double? pro_ohqty_cs { get; set; }
        public double? pro_qoh_cs { get; set; }
        public double? pro_accqty_export { get; set; }
        public double? pro_otqty_export { get; set; }
        public double? pro_ohqty_export { get; set; }
        public double? average_cost_export { get; set; }
        public double? lasted_cost_export { get; set; }
        public string dash_board_progroup { get; set; }
        public string dash_board_progroup_2 { get; set; }
        public int? package_day { get; set; }
        public int? package_free { get; set; }
        public string package_pro_code { get; set; }
        public string product_type_service { get; set; }
        public double? recal_vat_movement { get; set; }
        public double? recal_vat_avgcost { get; set; }
        public double? recal_novat_movement { get; set; }
        public double? recal_total_movement { get; set; }
        public string flag_promotion { get; set; }
        public int? type_used_id { get; set; }
        public string dealercode { get; set; }
        public string flag_fast_product { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
        public string out_of_stock { get; set; }
        public string Part_No { get; set; }
        public string type_of_product { get; set; }
        public string pro_code_SAP { get; set; }

        public int product_group_code { get; set; }
        public string progroup_name { get; set; }
        public string probrand_name { get; set; }
        public string promodel_name { get; set; }
        public string prosize_name { get; set; }
        public double pro_price { get; set; }

        public bool is_proset { get; set; }
        public int? ps_gen_id { get; set; }
        public string ps_code { get; set; }
        public string ps_name { get; set; }
    }

    public class ProductIsValid
    {
        public string StoreIsValid { get; set; }

        public string NumberIsValid { get; set; }
    }
}
