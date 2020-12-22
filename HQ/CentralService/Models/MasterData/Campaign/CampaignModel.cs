using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models.MasterData.Campaign
{
    public class CampaignModel
    {
        public CampaignModel()
        {
            Mode = "";
        }
        public string Mode { get; set; }
        [Display(Name = "รหัสแคมเปญ")]
        public string campaign_id { get; set; }
        [Display(Name = "ชื่อแคมเปญ")]
        public string campaign_name { get; set; }
        
        public string campaign_add_date { get; set; }
        public string campaign_edit_date { get; set; }
        public string campaign_add_time { get; set; }
        public string campaign_edit_time { get; set; }
        [Display(Name = "สถานะ")]
        public bool? deleted { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
        public int SendClient { get; set; }
    }
}
