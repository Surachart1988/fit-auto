using HQPosData.Models;
using CentralService.Injection;
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HQService.Services
{
    public class TransferDataService : ITransferDataService
    {
        private HQEntities _db;
        //static HttpClientHandler handler = new HttpClientHandler();
        static HttpClient client = new HttpClient();
        const string BaseApiUrl = "FIT_POS/api/Transfers";
        readonly string Conn = ConfigurationManager.ConnectionStrings["HQEntities"].ToString();

        public TransferDataService(HQEntities conn)
        {
            _db = conn;
        }

        public async Task<TransferDataModel> SendData(TransferDataModel Model)
        {
            foreach (var item in Model.DealerList)
            {
                if (!string.IsNullOrEmpty(item.id_send_client))
                {
                    //int[] intArray = Enumerable.Range(0, 600000).ToArray();
                    Uri _url = new Uri(item.http_path);
                    try
                    {
                        //var results = intArray
                        //    .Select(async t =>
                        //    {
                        //string requestUri = "";
                        //#if DEBUG
                        item.http_path = $"http://localhost:7777/api/Transfers";
                        //#else
                        //requestUri = $"{_url.Scheme}://{_url.Authority}/{BaseApiUrl}";
                        //#endif
                        //item.http_path = $"{_url.Scheme}://{_url.Authority}/{BaseApiUrl}";
                        using (HttpResponseMessage response = await client.PostAsync(item.http_path, BuildContent(item, Model.Type)))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var responseBody = response.Content.ReadAsStringAsync().Result;
                                item.SendStatus = response.IsSuccessStatusCode;
                            }
                            else
                            {
                                item.SendStatus = response.IsSuccessStatusCode;
                                item.error_massage = response.ReasonPhrase;
                            }
                        }
                    }
                    catch (TaskCanceledException e) //HttpClient throws this on timeout
                    {
                        item.error_massage = "Request timed out";
                    }
                    catch (Exception e)
                    {
                        item.error_massage = e.InnerException.Message ?? e.Message;
                    }
                    //Task.WaitAll(results.ToArray());
                }
                else
                {
                    item.error_massage = "ไม่พบข้อมูลที่ต้องการนำออกสาขา";
                }
            }
            return Model;
            #region .bak
            /*  Handle known exceptions, wait a little (say 1000 msec) 
             *  and try again (for say 3 times). Only if failed all times then you can quit/report an error to your users
                private const int NumberOfRetries = 3;
                private const int DelayOnRetry = 1000;

                public static async Task<HttpResponseMessage> GetFromUrlAsync(string url) {
                    using (var client = new HttpClient()) {
                        for (int i=1; i <= NumberOfRetries; ++i) {
                            try {
                                return await client.Async(url); 
                            }
                            catch (Exception e) when (i < NumberOfRetries) {
                                await Task.Delay(DelayOnRetry);
                            }
                        }
                    }
                }
             */
            #endregion
        }

        public void TransferLog(TransferDataModel model, int userid)
        {
            try
            {
                foreach (var row in model.DealerList)
                {
                    var _log = new ST_Transfer_Data_Log();
                    _log.url_send = row.http_path;
                    _log.dealer_code = row.dealercode;
                    _log.source_table = model.Type;
                    _log.action_type = row.SendStatus == true ? "send" : "error";
                    _log.send_status = row.SendStatus == true ? 1 : 0;
                    _log.send_datetime = DateTime.Now;
                    _log.user_id = userid;
                    _log.message = row.SendStatus == true ? "" : row.error_massage ?? "";
                    _log.id_send_client = row.id_send_client;
                    _db.ST_Transfer_Data_Log.Add(_log);
                    _db.SaveChanges();
                }
            }
            catch
            {
                //TO DO:
            }
        }

        public void SetSendClient(TransferDataModel model)
        {
            foreach (var items in model.DealerList.Where(w => w.SendStatus))
            {
                string _SqlCmd = "";
                try
                {
                    switch (model.Type.ToUpper().Replace("DETAIL", ""))
                    {
                        case "BRANCH": _SqlCmd = $"UPDATE SB_Branch SET SendClient = 0 where dealercode in ({items.id_send_client})"; break;
                        //case "PRODUCT": PRODUCT(); break;
                        //case "MAIN_NEXTSERVICE": MAIN_NEXTSERVICE(); break;
                        //case "NEXTSERVICE": NEXTSERVICE(); break;
                        //case "CUSTOMER": CUSTOMER(); break;
                        //case "HRUSER": HRUSER(); break;
                        //case "COMHRUSER": COMHRUSER(); break;
                        //case "PRODUCTSET": PRODUCTSET(); break;
                        //case "PROPRICE": PROPRICE(); break;
                        //case "GROOVE": GROOVE(); break;
                        //case "CHECKLIST": CHECKLIST(); break;
                        //case "SUPP": SUPP(); break;
                        case "PROMOTION": _SqlCmd = $"UPDATE SB_PromotionHeader SET SendClient = 0 where pro_id in ({items.id_send_client})"; break;
                        case "CAMPAIGN": _SqlCmd = $"UPDATE SB_Campaign SET SendClient = 0 where campaign_id in ({items.id_send_client})"; break;
                            //case "COUPON": COUPON(); break;
                            //case "COMPANY": COMPANY(); break;
                            //case "PROGROUP": PROGROUP(); break;
                            //case "PROTYPEUSED": PROTYPEUSED(); break;
                            //case "PROBRAND": PROBRAND(); break;
                            //case "PROMODEL": PROMODEL(); break;
                            //case "PROSIZE": PROSIZE(); break;
                            //case "UNITNAME": UNITNAME(); break;
                            //case "LOCATION": LOCATION(); break;
                            //case "LOCATIONDOT": LOCATIONDOT(); break;
                            //case "PRICEOWN": PRICEOWN(); break;
                            //case "CARTYPE": CARTYPE(); break;
                            //case "CARBRAND": CARBRAND(); break;
                            //case "CARMODEL": CARMODEL(); break;
                            //case "CARCOLOR": CARCOLOR(); break;
                            //case "AUTOCHECK": AUTOCHECK(); break;
                            //case "CARGEAR": CARGEAR(); break;
                            //case "CUSTYPE": CUSTYPE(); break;
                            //case "BUSSTYPE": BUSSTYPE(); break;
                            //case "CONTENTUP": CONTENTUP(); break;
                            //case "VOTE": VOTE(); break;
                            //case "DAY3": DAY3(); break;
                            //case "QUESTION": QUESTION(); break;
                            //case "JOBSTATUS": JOBSTATUS(); break;
                            //case "TEXTREPORT": TEXTREPORT(); break;
                            //case "BANK": BANK(); break;
                            //case "CARDTYPE": CARDTYPE(); break;
                            //case "PAYTYPE": PAYTYPE(); break;
                            //case "INSTALLMENT": INSTALLMENT(); break;
                            //case "BVAT": BVAT(); break;
                            //case "SVAT": SVAT(); break;
                            //case "TAXCON": TAXCON(); break;
                            //case "TAXTYPE": TAXTYPE(); break;
                            //case "TAXMONEY": TAXMONEY(); break;
                            //case "TAXINCOME": TAXINCOME(); break;
                            //case "TAXINCOMERATE": TAXINCOMERATE(); break;
                            //case "AUTHENGROUP": AUTHENGROUP(); break;
                            //case "CUSTCAR": CUSTCAR(); break;
                            //case "MEETING": MEETING(); break;
                            //case "RedeemSetting": RedeemSetting(); break;
                    }
                    _db.Database.ExecuteSqlCommand(_SqlCmd);
                }
                catch (Exception ex)
                {
                    //TO DO:
                }
            }
        }

        public TransferDataModel PrepareData(SendClientModel model)
        {
            TransferDataModel obj = new TransferDataModel
            {
                Type = model.act
            };

            foreach (var row in model.BranchList.Where(w => w.IsCheck))
            {
                DataSet ds = new DataSet();
                string id_sender = "";
                try
                {
                    switch (model.act.ToUpper().Replace("DETAIL", ""))
                    {
                        case "BRANCH":
                            var branch = _db.SB_Branch.Where(w => w.SendClient == 1 && w.dealercode == row.dealercode);
                            if (branch.Any(a => a.flag_hq == "True"))
                            {
                                id_sender = branch.FirstOrDefault().doc_no_run.ToString();
                                BuildDataContainer(ds, "SB_System", "", "", $"branch_id = '{id_sender}'");
                            }
                            else
                            {
                                id_sender = string.Join(",", branch.Select(s => "" + s.dealercode + ""));
                                if (!string.IsNullOrEmpty(id_sender))
                                {
                                    BuildDataContainer(ds, "SB_Branch", "", id_sender);
                                    BuildDataContainer(ds, "SB_System", "", id_sender);
                                    BuildDataContainer(ds, "SB_Dealercode_Master", "004");
                                }
                            }
                            break;
                        //case "PRODUCT": PRODUCT(); break;
                        //case "MAIN_NEXTSERVICE": MAIN_NEXTSERVICE(); break;
                        //case "NEXTSERVICE": NEXTSERVICE(); break;
                        //case "CUSTOMER": CUSTOMER(); break;
                        //case "HRUSER": HRUSER(); break;
                        //case "COMHRUSER": COMHRUSER(); break;
                        //case "PRODUCTSET": PRODUCTSET(); break;
                        //case "PROPRICE": PROPRICE(); break;
                        //case "GROOVE": GROOVE(); break;
                        //case "CHECKLIST": CHECKLIST(); break;
                        //case "SUPP": SUPP(); break;
                        case "PROMOTION":
                            var promotion = _db.SB_PromotionHeader.Where(w => w.SendClient == 1);
                            id_sender = string.Join(",", promotion.Select(s => "'" + s.pro_id + "'"));
                            if (!string.IsNullOrEmpty(id_sender))
                            {
                                BuildDataContainer(ds, "SB_Campaign", string.Join(",", promotion.Select(s => "'" + s.campaign_id + "'").Distinct()));
                                BuildDataContainer(ds, "SB_PromotionHeader", id_sender);
                                BuildDataContainer(ds, "SB_PromotionDetail", id_sender);
                                BuildDataContainer(ds, "SB_PromotionCouponDetailEmp", id_sender);
                                if (promotion.Any(a => a.coupon_id != ""))
                                    BuildDataContainer(ds, "SB_CouponDetail", string.Join(",", promotion.Select(s => "'" + s.coupon_id + "'").Distinct()));
                                BuildDataContainer(ds, "SB_PromotionType", "", "", "pro_type_id <> '' ");
                                BuildDataContainer(ds, "SB_PromotionGroupUsed", "", "", "pro_group_used_id <> '' ");
                                BuildDataContainer(ds, "SB_PromotionGiveType", "", "", "pro_give_type_id <> '' ");
                                BuildDataContainer(ds, "SB_PromotionConditionTime", "", "", "pro_condition_time_id <> '' ");
                                BuildDataContainer(ds, "SB_PromotionDiscount", "", "", "pro_discount_id <> '' ");
                                BuildDataContainer(ds, "SB_PromotionPrice", "", "", "pro_price_id <> '' ");
                            }
                            break;
                            case "CAMPAIGN":
                            var campaign = _db.SB_Campaign.Where(w => w.SendClient == 1);
                            id_sender = string.Join(",", campaign.Select(s => "'" + s.campaign_id + "'"));
                            if (!string.IsNullOrEmpty(id_sender))
                            {
                                BuildDataContainer(ds, "SB_Campaign", id_sender);
                            }
                            break;
                            //case "COUPON": COUPON(); break;
                            //case "COMPANY": COMPANY(); break;
                            //case "PROGROUP": PROGROUP(); break;
                            //case "PROTYPEUSED": PROTYPEUSED(); break;
                            //case "PROBRAND": PROBRAND(); break;
                            //case "PROMODEL": PROMODEL(); break;
                            //case "PROSIZE": PROSIZE(); break;
                            //case "UNITNAME": UNITNAME(); break;
                            //case "LOCATION": LOCATION(); break;
                            //case "LOCATIONDOT": LOCATIONDOT(); break;
                            //case "PRICEOWN": PRICEOWN(); break;
                            //case "CARTYPE": CARTYPE(); break;
                            //case "CARBRAND": CARBRAND(); break;
                            //case "CARMODEL": CARMODEL(); break;
                            //case "CARCOLOR": CARCOLOR(); break;
                            //case "AUTOCHECK": AUTOCHECK(); break;
                            //case "CARGEAR": CARGEAR(); break;
                            //case "CUSTYPE": CUSTYPE(); break;
                            //case "BUSSTYPE": BUSSTYPE(); break;
                            //case "CONTENTUP": CONTENTUP(); break;
                            //case "VOTE": VOTE(); break;
                            //case "DAY3": DAY3(); break;
                            //case "QUESTION": QUESTION(); break;
                            //case "JOBSTATUS": JOBSTATUS(); break;
                            //case "TEXTREPORT": TEXTREPORT(); break;
                            //case "BANK": BANK(); break;
                            //case "CARDTYPE": CARDTYPE(); break;
                            //case "PAYTYPE": PAYTYPE(); break;
                            //case "INSTALLMENT": INSTALLMENT(); break;
                            //case "BVAT": BVAT(); break;
                            //case "SVAT": SVAT(); break;
                            //case "TAXCON": TAXCON(); break;
                            //case "TAXTYPE": TAXTYPE(); break;
                            //case "TAXMONEY": TAXMONEY(); break;
                            //case "TAXINCOME": TAXINCOME(); break;
                            //case "TAXINCOMERATE": TAXINCOMERATE(); break;
                            //case "AUTHENGROUP": AUTHENGROUP(); break;
                            //case "CUSTCAR": CUSTCAR(); break;
                            //case "MEETING": MEETING(); break;
                            //case "RedeemSetting": RedeemSetting(); break;
                    }

                    obj.DealerList.Add(new TransferDetail
                    {
                        dealercode = row.dealercode,
                        plant_no = row.plant_no,
                        DealerName = row.DealerName,
                        http_path = row.http_path,
                        id_send_client = id_sender,
                        Soure = ds
                    });
                }
                catch (Exception ex)
                {
                    obj.DealerList.Add(new TransferDetail
                    {
                        dealercode = row.dealercode,
                        plant_no = row.plant_no,
                        DealerName = row.DealerName,
                        http_path = row.http_path,
                        id_send_client = id_sender,
                        error_massage = ex.Message
                    });
                }
            }

            return obj;
        }

        private void BuildDataContainer(DataSet ds, string table_name, string selfid, string dealercode = "", string selfcmd = "")
        {
            var _cmd = _db.Transfer_Data.Where(w => w.Source_Table == table_name).FirstOrDefault();
            string sql = $"SELECT {_cmd.Destination_Field} FROM {_cmd.Destination_Table} WHERE 1=1";
            if (!string.IsNullOrEmpty(selfcmd))
            {
                sql += $" AND {selfcmd} ";
            }
            else
            {
                foreach (var _key in _cmd.Source_Key.Split(','))
                {
                    if (_key.ToLower() == "dealercode")
                        sql += $" AND {_key} = '{dealercode}' ";
                    else
                        sql += $" AND {_key} in ({selfid}) ";
                }
            }

            using (var adapter = new SqlDataAdapter(sql, Conn))
            {
                adapter.Fill(ds, table_name);
            }
        }

        private static FormUrlEncodedContent BuildContent(TransferDetail item, string pagefrom)
        {
            //return new StringContent(json, Encoding.UTF8, "application/json");
            var json = JsonConvert.SerializeObject(item.Soure);
            return new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("DesSoure", json), new KeyValuePair<string, string>("Actfrom", pagefrom) });
        }
    }
}
