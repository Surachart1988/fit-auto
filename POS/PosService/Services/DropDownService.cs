using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.MasterData.Campaign;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static CentralService.Models.MasterData.VendorModel;

namespace PosService.Services
{
    public class DropDownService : IDropDownService
    {
        private Entities _db;

        public DropDownService(Entities conn)
        {
            _db = conn;
        }

        public IEnumerable<CodeNameModel> GetBank()
        {
            var list = new List<CodeNameModel> {
                new CodeNameModel {
                    Code = "-",
                    Name = "เลือกธนาคาร"
                } };

            list.AddRange(_db.SB_Bank.Select(p => new CodeNameModel
            {
                Code = p.bank_code,
                Name = p.bank_name
            }));

            return list;
        }

        public IEnumerable<CodeNameModel> GetCardType()
        {
            var list = new List<CodeNameModel> {
                new CodeNameModel {
                    Code = "",
                    Name = "เลือกชนิดบัตร",
                     dfField1 = ""
                } };

            list.AddRange(_db.SB_CardType.Select(p => new CodeNameModel
            {
                Code = p.card_code,
                Name = p.card_name,
                dfField1 = p.bank_code
            }));

            return list;
        }

        public IEnumerable<CodeNameModel> GetCustomerGroup()
        {
            var list = new List<CodeNameModel> {
                new CodeNameModel {
                    Code = "",
                    Name = "เลือกกลุ่มลูกค้า"
                } };

            list.AddRange(_db.SB_Custype.Select(p => new CodeNameModel
            {
                Code = p.custype_code,
                Name = p.custype_name
            }));

            return list;
        }

        public IEnumerable<IdNameModel> GetPaymentFormat()
        {
            var list = new List<IdNameModel> {
                new IdNameModel {
                    Id = 0,
                    Name = "เลือกรูปแบบการชำระ"
                } };

            list.AddRange(_db.SB_Installment_Type.Select(p => new IdNameModel
            {
                Id = p.installment_id,
                Name = p.installment_name
            }));

            return list;
        }

        public IEnumerable<CodeNameModel> GetProductGroup()
        {
            var list = new List<CodeNameModel> {
                new CodeNameModel {
                    Code = "",
                    Name = "เลือกกลุ่มสินค้า"
                } };

            list.AddRange(_db.SB_Progroup.Select(p => new CodeNameModel
            {
                Code = p.progroup_code,
                Name = p.progroup_name
            }));

            return list;
        }
        public IEnumerable<CampaignModel> GetCampaign()
        {
            var list = new List<CampaignModel> {
                new CampaignModel {
                    campaign_id = "",
                    campaign_name = "เลือกข้อมูล"
                } };

            list.AddRange(_db.SB_Campaign.Select(p => new CampaignModel
            {
                campaign_id = p.campaign_id,
                campaign_name = p.campaign_name
            }));

            return list;
        }
        public IEnumerable<ProdFirstGrpModel> GetProdFirstGrp()
        {
            var list = new List<ProdFirstGrpModel> {
                new ProdFirstGrpModel {
                    product_group_code = "",
                    product_group_name = "กลุ่มสินค้า"
                } };

            list.AddRange(_db.SB_Product_FirstGroup.OrderBy(o => o.product_group_id).Select(s => new ProdFirstGrpModel
            {
                product_group_code = s.product_group_code.ToString(),
                product_group_name = s.product_group_name
            }));

            return list;
        }
        public IEnumerable<ProGrpListModel> GetProGrp(string prodgrpCode)
        {
            var list = new List<ProGrpListModel> {
                new ProGrpListModel {
                    progroup_code = "",
                    progroup_name = "ประเภทสินค้า"
                } };
            string swjere = "";
            if (!string.IsNullOrEmpty(prodgrpCode))
            {
                swjere = "and product_group_code = " + prodgrpCode;

                string sql = @"
                           SELECT * FROM SB_progroup 
  where 1=1 " + swjere + " order by progroup_name";
                list.AddRange(_db.Database.SqlQuery<ProGrpListModel>(
                    sql
                        ).Select(s => new ProGrpListModel
                        {
                            progroup_code = s.progroup_code,
                            progroup_name = s.progroup_name
                        }));
            }
            return list;
        }
        public IEnumerable<ProBrandListModel> GetProBrand(string progroupCode)
        {
            var list = new List<ProBrandListModel> {
                new ProBrandListModel {
                    pro_brand_code = "",
                    pro_brand = "ยี่ห้อ"
                } };
            string swjere = "";
            if (!string.IsNullOrEmpty(progroupCode))
            {
                swjere = "and progroup_code = " + progroupCode;
                string sql = @"SELECT CONVERT(nvarchar,a.pro_brand_code) as pro_brand_code, a.pro_brand FROM SB_probrand as a where 1=1 " + swjere + " Order by pro_brand asc";
                list.AddRange(_db.Database.SqlQuery<ProBrandListModel>(
                    sql
                ).Select(s => new ProBrandListModel
                {
                    pro_brand_code = s.pro_brand_code,
                    pro_brand = s.pro_brand
                }));
            }
            return list;
        }
        public IEnumerable<PromodelModel> GetProModel(string probrandCode)
        {
            var list = new List<PromodelModel> {
                new PromodelModel {
                    pro_model_code = "",
                    pro_model = "รุ่น"
                } };
            string swjere = "";
            if (!string.IsNullOrEmpty(probrandCode))
            {
                swjere = " and a.pro_brand_code  = " + probrandCode;
                list.AddRange(_db.Database.SqlQuery<PromodelModel>(@"
                            SELECT CONVERT(nvarchar,a.pro_model_code) as pro_model_code , a.pro_model
                            FROM SB_Promodel AS a	
                                LEFT JOIN SB_Probrand AS b ON a.pro_brand_code = b.pro_brand_code
where 1=1 " + swjere + " ORDER BY a.pro_model").Select(s => new PromodelModel
                {
                    pro_model_code = s.pro_model_code,
                    pro_model = s.pro_model
                }));
            }


            return list;
        }
        public IEnumerable<ProSizeModel> GetProSize(string promodelCode)
        {
            var list = new List<ProSizeModel> {
                new ProSizeModel {
                    pro_size_code = "",
                    size_name = "ขนาดสินค้า"
                } };
            string where = "";
            if (!string.IsNullOrEmpty(promodelCode))
            {
                where += " AND a.pro_model_code in ( " + promodelCode + " )";
                string sql = @"SELECT DISTINCT CONVERT(nvarchar,b.pro_size_code) as pro_size_code , b.size_name FROM SB_Product AS a LEFT JOIN SB_ProSize AS b ON a.pro_size_code = b.pro_size_code
								WHERE a.pro_size_code IS NOT NULL AND b.pro_size_code IS NOT NULL
								{0}
								ORDER BY b.size_name";
                list.AddRange(_db.Database.SqlQuery<ProSizeModel>(string.Format(sql, where)).Select(s => new ProSizeModel
                {
                    pro_size_code = s.pro_size_code,
                    size_name = s.size_name
                }));
            }

            return list;
        }
        public IEnumerable<ProvinceModel> GetProvince()
        {
            var list = new List<ProvinceModel>(){
                new ProvinceModel {
                    prov_id = 0,
                    prov_name = "เลือกจังหวัด"
                }};
            list.AddRange(_db.SB_province.Select(s => new ProvinceModel
            {
                prov_id = s.add_provid,
                prov_name = s.add_province
            }));

            return list;
        }
        public IEnumerable<AmphurModel> GetAmphur(int? prov_id = 0)
        {
            var list = new List<AmphurModel>(){
                new AmphurModel {
                    amphur_id = 0,
                    amphur_name = "เลือกอำเภอ"
                }};
            list.AddRange(_db.SB_Prov_Amphur.Where(w => w.prov_id == prov_id).Select(s => new AmphurModel
            {
                amphur_id = s.amphur_id ?? 0,
                amphur_name = s.amphur_name
            }));

            return list;
        }
        public IEnumerable<TambolModel> GetTambol(int? amphur_id = 0, int? prov_id = 0)
        {
            var list = new List<TambolModel>(){
                new TambolModel {
                    tambol_id = 0,
                    tambol_name = "เลือกตำบล"
                }};
            list.AddRange(_db.SB_Prov_Tambol.Where(w => w.amphur_id == amphur_id && w.prov_id == prov_id).Select(s => new TambolModel
            {
                tambol_id = s.tambol_id ?? 0,
                tambol_name = s.tambol_name
            }));

            return list;
        }
        public IEnumerable<ZipcodeModel> GetZipCode(int? amphur_id = 0, int? prov_id = 0)
        {
            var list = new List<ZipcodeModel>(){
                new ZipcodeModel {
                    zip_id = "0",
                    zip_code = "เลือกรหัสไปรษณีย์"
                }};
            list.AddRange(_db.SB_Prov_Tambol.Where(w => w.amphur_id == amphur_id && w.prov_id == prov_id)
                .GroupBy(
                    r => new { r.zipcode }
                    )
                    .Select(s => new ZipcodeModel
                    {
                        zip_id = s.Key.zipcode,
                        zip_code = s.Key.zipcode
                    }));

            return list;
        }
        public IEnumerable<UnitModel> GetddlSaleUnitCode()
        {
            var list = new List<UnitModel>(){
                new UnitModel {
                    unit_code = 0,
                    unit_name = "หน่วยสินค้า"
                }};
            list.AddRange(_db.SB_UnitName.OrderBy(o => o.unit_name).Select(s => new UnitModel
            {
                unit_code = s.unit_code,
                unit_name = s.unit_name
            }));

            return list;
        }
        public IEnumerable<PrinterComModel> GetPrinterCom()
        {
            var list = new List<PrinterComModel>(){
                new PrinterComModel {
                    print_id = "noprinter",
                    print_name = "No Printer"
                }};
            using (ManagementObjectSearcher printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer Where Default = True"))
            using (ManagementObjectCollection result = printerQuery.Get())
            {
                try
                {
                    foreach (ManagementObject printer in result)
                    {
                        if (Convert.ToBoolean(printer["Default"]))
                        {
                            list.Add(new PrinterComModel()
                            {
                                print_id = printer["Name"].ToString(),
                                print_name = printer["Name"].ToString(),
                            });
                        }
                        //if (Convert.ToBoolean(printer["Local"]))       // LOCAL PRINTERS.
                        //{
                        //    list.Add(new PrinterComModel()
                        //    {
                        //        print_id = printer["Name"].ToString(),
                        //        print_name = printer["Name"].ToString(),
                        //    });
                        //}
                        //foreach (PropertyData property in printer.Properties)
                        //{
                        //    list.Add(new PrinterComModel()
                        //    {
                        //        print_id = property.Name,
                        //        print_name = property.Name
                        //    });
                        //}
                    }
                }
                catch (ManagementException ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }
            return list;
        }

        public IEnumerable<locationModel> GetLocation()
        {
            var list = new List<locationModel>(){
                new locationModel {
                    locat_code = 0,
                    locat_name = "เลือกที่เก็บ"
                }};
            list.AddRange(_db.SB_location.OrderBy(o => o.locat_name).Select(s => new locationModel
            {
                locat_code = s.locat_code,
                locat_name = s.locat_name
            }));

            return list;
        }
        public IEnumerable<VattypeModel> GetVattype()
        {
            var list = new List<VattypeModel> {
                new VattypeModel {
                    vat_type = "",
                    vat_type_name = "เลือกข้อมูล"
                } };

            list.AddRange(_db.SB_vattype.Where(w => w.vat_type != "").Select(p => new VattypeModel
            {
                vat_type = p.vat_type,
                vat_type_name = p.vat_type_name
            }));

            return list;
        }

        public IEnumerable<BvatModel> GetBvat()
        {
            var list = new List<BvatModel> {
                new BvatModel {
                    vat_code = "",
                    vat_desc = "เลือกข้อมูล"
                } };

            list.AddRange(_db.SB_BVat.Where(w => w.vat_code != 0).Select(p => new BvatModel
            {
                vat_code = p.vat_code.ToString(),
                vat_desc = p.vat_desc
            }));

            return list;
        }
    }
}
