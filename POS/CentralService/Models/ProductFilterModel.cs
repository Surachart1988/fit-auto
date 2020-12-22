using CentralService.Injection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class ProductFilterModel
    {
        public ProductFilterModel()
        {
            ddlProdFirstGrpList = new List<ProdFirstGrpModel> {
                new ProdFirstGrpModel {
                    product_group_code = "",
                    product_group_name = "กลุ่มสินค้า"
                } };
            ddlProGrpList = new List<ProGrpListModel> {
                new ProGrpListModel {
                    progroup_code = "",
                    progroup_name = "ประเภทสินค้า"
                } };
            ddlProBrandList = new List<ProBrandListModel> {
                new ProBrandListModel {
                    pro_brand_code = "",
                    pro_brand = "ยี่ห้อ"
                } };
            ddlProModelList = new List<PromodelModel> {
                new PromodelModel {
                    pro_model_code = "",
                    pro_model = "รุ่น"
                } };
            ddlProSizeList = new List<ProSizeModel> {
                new ProSizeModel {
                    pro_size_code = "",
                    size_name = "ขนาดสินค้า"
                } };

        }
        public int product_group_code { get; set; }
        public string progroup_code { get; set; }
        public int pro_brand_code { get; set; }
        public int pro_model_code { get; set; }
        public int pro_size_code { get; set; }
        public IEnumerable<ProdFirstGrpModel> ddlProdFirstGrpList { get; set; }
        public IEnumerable<ProGrpListModel> ddlProGrpList { get; set; }
        public IEnumerable<ProBrandListModel> ddlProBrandList { get; set; }
        public IEnumerable<PromodelModel> ddlProModelList { get; set; }
        public IEnumerable<ProSizeModel> ddlProSizeList { get; set; }
    }
}
