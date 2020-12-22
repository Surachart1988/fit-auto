using CentralService.Models.MasterData.Campaign;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models
{
    public class ExtraPromotionModel
    {
        public ExtraPromotionModel()
        {
            SBCouponDetail = new List<SBCouponDetail>();
            SBPromotionDisDetail = new List<SbPromotionDetailDisc>();
            SBProCouponDetailEmp = new List<SB_ProCouponDetailEmp>();
            PromotionItems = new List<PromotionItem>();
            temp_prodgroupList = new List<ProdFirstGrpModel>();
            temp_progroupList = new List<ProGrpListModel>();
            temp_probrandList = new List<ProBrandListModel>();
            temp_PromodelList = new List<PromodelModel>();
            temp_ProSizeList = new List<ProSizeModel>();
            temp_ProductsList = new List<ProductsModel>();
        }

        #region Step1

        public string pro_id { get; set; }
        [Display(Name = "ชื่อโปรโมชั่น")]
        public string pro_name { get; set; }
        [Display(Name = "วันที่เริ่มใช้")]
        public string pro_start_date { get; set; }
        public string pro_start_time { get; set; }
        [Display(Name = "วันที่สิ้นสุด")]
        public string pro_end_date { get; set; }
        public string pro_end_time { get; set; }
        public DateTime pro_start { get; set; }
        [Display(Name = "ชื่อแคมเปญ")]
        public string campaign_id { get; set; }
        public IEnumerable<CampaignModel> CampaignList { get; set; }

        // เงื่อนไขรอบเวลา
        public int pro_condition_time_id { get; set; }
        public string pro_condition_time_detail { get; set; }
        public List<ConditionWeek> ConditionWeek { get; set; }
        public List<ConditionMonth> ConditionMonth { get; set; }
        public string pro_condition_time_start { get; set; }
        public string pro_condition_time_end { get; set; }
        //1 รอบสัปดาห์ ,//2 รอบเดือน
        public string ProConditionWeekStart { get; set; }

        public string ProConditionWeekTimeEnd { get; set; }

        public string ProConditionMonthStart { get; set; }

        public string ProConditionMonthEnd { get; set; }

        // สาขาที่ร่วมรายการ
        public List<DealercodeModel> Dealers { get; set; }
        public string branch_no_list { get; set; }

        // อนุญาตใช้ร่วมกับโปรโมชั่นอื่น
        public bool allow_muti_promotion { get; set; }
        //0 = ไม่ได้, 1 = ได้
        public string allow_muti_promotion_detail { get; set; }
        public List<PromotionList> PromotionList { get; set; }
        // อนุญาต
        public bool allow_promotion { get; set; }
        //0 = ไม่ได้, 1 = ได้

        public bool? allow_muti_voucher { get; set; }


        #endregion

        #region Step2

        //โปรโมชั่นจะใช้กับ :
        public int pro_group_used_id { get; set; }
        public List<PromotionGrpUsed> PromotionGrpUsed { get; set; }

        #endregion

        #region Step3

        //เลือกประเภทลูกค้า
        public string pro_group_used_detail { get; set; }
        public List<ProGrpUsedDetail> ProGrpUsedDetailsList { get; set; } //เลือกประเภทลูกค้า :

        public List<ProdFirstGrpModel> prodfirstgroupList { get; set; }//กลุ่มสินค้า :
        public List<ProdFirstGrpModel> temp_prodgroupList { get; set; }
        public List<ProGrpListModel> progroupList { get; set; } //ประเภทสินค้า :
        public List<ProGrpListModel> temp_progroupList { get; set; }
        public List<ProBrandListModel> probrandList { get; set; } //ยี่ห้อสินค้า :
        public List<ProBrandListModel> temp_probrandList { get; set; }
        public List<PromodelModel> PromodelList { get; set; } //รุ่นสินค้าสินค้า :
        public List<PromodelModel> temp_PromodelList { get; set; }
        public List<ProSizeModel> ProSizeList { get; set; } //ขนาดสินค้า :
        public List<ProSizeModel> temp_ProSizeList { get; set; }
        public List<ProductsModel> ProductsList { get; set; } //ค้นหาสินค้า :
        public List<ProductsModel> temp_ProductsList { get; set; }

        //เงื่อนไขจำนวนสินค้า
        public int pro_give_type_id { get; set; }
        //จำนวนสินค้าจากเงื่อนไข pro_give_type_id
        public int pro_give_type_detail { get; set; }
        public List<ProGiveTypeList> ProGiveTypeList { get; set; }

        //จำนวนที่ระบุข้างต้นใช้สำหรับสินค้านี้ :
        public bool pro_give_product_same { get; set; }

        //กำหนดเงื่อนไขราคา
        public int pro_price_id { get; set; }
        public double PerUnitCost { get; set; }
        public double pro_price_total { get; set; }
        public List<ProPriceModel> ProPriceModelList { get; set; }

        // โปรโมชั่นส่วนลดราคา,โปรโมชั่นส่วนลดบัตรกำนัน,โปรโมชั่นส่วนลดพนักงาน
        //รูปแบบส่วนลด
        public int pro_type_id { get; set; }
        public double pro_type_detail { get; set; }
        public List<ProTypeList> ProTypeList { get; set; }

        // โปรโมชั่นของแถม
        // รูปแบบของรางวัล
        public bool pro_give_same_buy { get; set; }
        public List<ProductsModel> ProdGiveList { get; set; }
        public int pro_discount_id { get; set; }
        public double pro_discount_num { get; set; }
        public double pro_discount_rate { get; set; }
        public int pro_give_free_amount { get; set; }

        public int pro_discount_unit_id { get; set; }
        public string pro_discount_unit { get; set; }
        //public double pro_discount_num2 { get; set; }
        //public double pro_discount_rate2 { get; set; }
        //public string pro_discount_unit2 { get; set; }
        public string rate_price_cal { get; set; }

        // โปรโมชั่นส่วนลดคูปอง
        // รูปแบบคูปอง
        public string coupon_id { get; set; }//รหัสคูปองกรณีที่เลือกประเภทโปรโมชั่นเป็น คูปอง
        public int group_coupon_id { get; set; }
        public string coupon_group_id { get; set; }
        public string coupon_code { get; set; }
        public string coupon_code2 { get; set; }
        public string coupon_name { get; set; }
        public decimal? coupon_value_amount { get; set; }
        public decimal? coupon_value_percent { get; set; }
        #endregion

        public string pro_add_date { get; set; }
        public string pro_add_time { get; set; }
        public string pro_edit_date { get; set; }
        public string pro_edit_time { get; set; }
        public bool? deleted { get; set; } //สถานะโปรโมชั่น 0 = เปิดการใช้งาน , 1 = ปิดการใช้งาน
        public int? SendClient { get; set; } // สถานะส่งไปสาขา 0 = ส่งแล้ว , 1 = ยังไม่ส่ง

        public int count_give_product { get; set; } // pagelist
        public string used_promotion { get; set; } // pagelist
        public string check_expired { get; set; } // pagelist
        [Display(Name = "สถานะ")]
        public string Status { get; set; } // pagelist

        public string Mode { get; set; } // pagelist

        public string title_price_view { get; set; }

        public SbPromotionConditionTime ProConditionTime { get; set; }
        public SbPromotionDiscount ProDiscount { get; set; }
        public SbPromotionGiveType ProGiveType { get; set; }
        public SbPromotionGroupUsed ProGroupUsed { get; set; }
        public SbPromotionType ProType { get; set; }
        public List<SbPromotionDetail> SbPromotionDetail { get; set; }
        public List<SBCouponDetail> SBCouponDetail { get; set; }
        public List<SB_ProCouponDetailEmp> SBProCouponDetailEmp { get; set; }
        public List<SbPromotionDetailDisc> SBPromotionDisDetail { get; set; }
        public List<PromotionItem> PromotionItems { get; set; }
        //public string progroupcode { get; set; }//progrpuseddetail
    }
    public class PromotionItem
    {
        public int pro_brand_code { get; set; }
        public string pro_brand { get; set; }
        public int pro_model_code { get; set; }
        public string pro_model { get; set; }
        public string pro_code { get; set; }
        public string pro_tname { get; set; }
        public int pro_size_code { get; set; }
        public string size_name { get; set; }
        public string pro_discount { get; set; }
    }
    public class ProPriceModel
    {
        public int pro_price_id { get; set; }
        public string pro_price_name { get; set; }
    }
    public class PromotionGrpUsed
    {
        public int pro_group_used_id { get; set; }
        public string pro_group_used_name { get; set; }
    }
    public class ProGiveTypeList
    {
        public int pro_give_type_id { get; set; }
        public string pro_give_type_name { get; set; }
        public string pro_give_type_unit { get; set; }
    }
    public class ProGrpUsedDetail
    {
        public string custype_code { get; set; }
        public string custype_name { get; set; }

        public bool IsCheck { get; set; }

    }
    public class ProTypeList
    {
        public int pro_type_id { get; set; }
        public string pro_type_name { get; set; }
    }
}

