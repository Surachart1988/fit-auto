using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models.SystemData
{
    public class BranchModel
    {
        public BranchModel()
        {
            Mode = "";
            AddressModel = new AddressModel();
            DealerMasterModel = new DealerMasterModel();
        }
        public string Mode { get; set; }
        [Display(Name = "รหัสสาขา")]
        public string dealercode { get; set; }
        [Display(Name = "PLANT No.")]
        public string plant_no { get; set; }
        [Display(Name = "ชื่อสาขา")]
        public string branch_name { get; set; }
        [Display(Name = "จังหวัด")]
        public string add_province { get; set; }
        [Display(Name = "โทรศัพท์")]
        public string add_tel { get; set; }
        [Display(Name = "SOLD_TO")]
        public string sold_to { get; set; }
        [Display(Name = "SHIP_TO")]
        public string ship_to { get; set; }

        public string com_name { get; set; }

        public int doc_no_run { get; set; }

        public string branch_no { get; set; } = "004";

        public string zone_code { get; set; }

        public string add_name { get; set; }

        public string add_no { get; set; }

        public string add_moo { get; set; }

        public string add_trog { get; set; }

        public string add_soi { get; set; }

        public string add_road { get; set; }

        public string add_tumbol { get; set; }

        public string add_amphur { get; set; }

        public string add_fax { get; set; }

        public string tax_number { get; set; }

        public string manager_code { get; set; }

        public string branch_manager { get; set; }

        public string create_product { get; set; }

        public string rec_date { get; set; }

        public string com_engname { get; set; }

        public string add_engname { get; set; }

        public string add_engno { get; set; }

        public string add_engmoo { get; set; }

        public string add_engtrog { get; set; }

        public string add_engsoi { get; set; }

        public string add_engroad { get; set; }

        public string add_engtumbol { get; set; }

        public string add_engamphur { get; set; }

        public string add_engprovince { get; set; }

        public string dealer_type { get; set; }

        public string vat_default { get; set; }

        public string authorise_password { get; set; }

        public string e_mail { get; set; }

        public string web_site { get; set; }

        public int? client_limit { get; set; }

        public string tax_branch_id { get; set; }

        public string tax_branch { get; set; }

        public string license_key { get; set; }

        public string Vat_DB { get; set; }

        public string add_date { get; set; }

        public string add_time { get; set; }

        public string edit_date { get; set; }

        public string edit_time { get; set; }

        public string branch_used { get; set; }

        public int? salezone_id { get; set; }

        public int? salegroup_id { get; set; }

        public string flag_hq { get; set; }

        public int? SendClient { get; set; }

        public int? POS_ComputerID { get; set; }

        public string pos_id_1 { get; set; }

        public string pos_id_2 { get; set; }

        public string pos_id_3 { get; set; }

        public string mid { get; set; }

        public string tid { get; set; }

        public string ip_address { get; set; }

        public string ip_address_pub { get; set; }

        public string http_path { get; set; } = "http://localhost/PTT_Client_1/WebService/webclient.asmx/";

        public int? add_provid { get; set; }
        public int? add_tumbol_id { get; set; }
        public int? add_amphur_id { get; set; }
        public string add_zip { get; set; }
        public AddressModel AddressModel { get; set; }
        public DealerMasterModel DealerMasterModel { get; set; }
    }
}
