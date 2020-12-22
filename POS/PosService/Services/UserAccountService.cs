
using PosData;
using PosData.Models;
using CentralService.Injection;
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PosService.Services
{
    public class UserAccountService : IUserAccountService
    {
        private Entities _db;

        public UserAccountService(Entities conn)
        {
            _db = conn;
        }

        public void CheckOpenDayEnd(out bool _Openbatch, out bool _endOldYet, out bool _endtodayYet)
        {
            _endOldYet = false; _endtodayYet = false;
            var tmp = _db.ST_DayStart.OrderByDescending(x => x.run_id).ToArray().Select(s => new
            {
                key = s,
                _sDate = s.day_start?.ToString("dd/MM/yyyy")
            });
            try
            {
                var data = _db.ST_DayStart.OrderByDescending(x => x.run_id).FirstOrDefault();
                var checkDate = data?.day_start != null ? (data.day_start ?? DateTime.Now).ToString("dd/MM/yyyy") : "";
                if (data != null && checkDate == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    _Openbatch = true;
                    _endOldYet = true;
                    var dd = _db.VSmart_BatchDetail.FirstOrDefault(x => x.BatchID == data.blue_card_batch_id);
                    if (dd != null)
                    {
                        _endtodayYet = dd.CloseDateTime != null;
                    }
                    else
                    {
                        _endtodayYet = false;
                    }
                }
                else
                {
                    var _yesterdays = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                    _Openbatch = false;


                    var ok = tmp.AsEnumerable().FirstOrDefault(w => w._sDate == _yesterdays);
                    if (ok != null)
                    {
                        var dd = _db.VSmart_BatchDetail.FirstOrDefault(x => x.BatchID == ok.key.blue_card_batch_id);
                        if (dd != null)
                        {
                            _endOldYet = dd.CloseDateTime != null;
                        }
                    }
                    else
                    {
                        _endOldYet = true;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateIPAddrs(string iisName, string ipV4)
        {
            var sbs = _db.SB_System.FirstOrDefault();
            //sbs.client_url = "http://" + ipV4 + "/" + iisName + "/WebService/webclient.asmx/";
            sbs.client_url = $"http://{ipV4}/{iisName}/WebService/webclient.asmx/";
            _db.Entry(sbs).State = EntityState.Modified;
            var de = sbs.dealercode;

            var dm = _db.SB_Dealercode_Master.FirstOrDefault(w => w.dealercode == de);
            //dm.http_path = "http://" + ipV4 + "/" + iisName + "/WebService/webclient.asmx/";
            dm.http_path = $"http://{ipV4}/{iisName}/WebService/webclient.asmx/";
            dm.ip_address = ipV4;
            dm.ip_address_pub = ipV4;
            _db.Entry(dm).State = EntityState.Modified;

            _db.SaveChanges();
            var result = await SendIPV4toHQ(ipV4, de);
            return result;
        }
        public async Task<string> SendIPV4toHQ(string request, string dealerCode)
        {
            var hqPath = _db.SB_System.First(s => s.dealercode == dealerCode).hq_url;//.ToUpper().Replace("PTT_HQ/WEBSERVICE/WEBHQ.ASMX/", "FIT_HQ")
            Uri hqUri = new Uri(hqPath);
            string hqurl = string.Format("{0}://{1}/{2}",hqUri.Scheme,hqUri.Authority, "FIT_HQ");

            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("AddsIP", request),
                    new KeyValuePair<string, string>("dealerCode", dealerCode)
                });
                var resp = await client.PostAsync($"{hqurl}/Home/UpdateIPV4Client", content);
                if (resp != null)
                {
                    if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    else
                    {
                        var result = await resp.Content.ReadAsStringAsync();
                        return result;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public UserSessionModel IsValid(UserAccountModel user, string password, string dealerCode)
        {
            try
            {


                var encodePassword = password;
                var model = _db.SBHRUsers.Where(u => u.susername == user.UserName
                && u.spassword == encodePassword
                && u.dealercode == dealerCode)
                    .Select(u => new UserSessionModel
                    {
                        gbusername = u.susername,
                        gbuser = u.stfname + " " + u.stlname,
                        gblevel = u.clevel,
                        gbuserId = u.user_id,
                        gbsempno = u.SEmpNo,
                        DealerCode = u.dealercode,

                        check_expire_user = u.check_expire_user,
                        user_expire_date = u.user_expire_date

                    }).FirstOrDefault();
                if (model == null) return null;

                var systemModel = _db.SB_System.FirstOrDefault(s => s.dealercode == model.DealerCode);

                if (systemModel == null) return null;
                model.ClientUrl = systemModel.client_url.Replace("/WebService/webclient.asmx/", "");
                var dealerCodeModel = _db.SB_Dealercode_Master.FirstOrDefault(d => d.dealercode == model.DealerCode);
                model.DealerName = dealerCodeModel.DealerName;
                var branchModel = _db.SB_Branch.First();
                model.BranchDocNoRun = branchModel.doc_no_run;
                model.BranchNo = branchModel.branch_no;
                if (systemModel == null)
                {
                    systemModel = _db.SB_System.FirstOrDefault();
                    model.HQUrl = systemModel + "/PTT_HQ";
                }
                else
                    model.HQUrl = systemModel.hq_url.Replace("/WebService/webhq.asmx/", "");

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
