
using HQPosData;
using HQPosData.Models;
using CentralService.Injection;
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HQService.Services
{
    public class UserAccountService : IUserAccountService
    {
        private HQEntities _db;

        public UserAccountService(HQEntities conn)
        {
            _db = conn;
        }

        public UserSessionModel IsValid(UserAccountModel user, string password)
        {
            var encodePassword = password;
            var model = _db.SBHRUsers.Where(u => u.susername.ToLower() == user.UserName.ToLower().Trim()
                                                 && u.spassword == encodePassword)
                .Select(u => new UserSessionModel
                {
                    gbusername = u.susername,
                    gbuser = u.stfname + " " + u.stlname,
                    gblevel = u.clevel,
                    gbuserId = u.user_id,
                    gbsempno = u.SEmpNo,
                    DealerCode = u.dealercode
                }).FirstOrDefault();

            if (model == null) return model;

            var branchModel = _db.SB_Branch.First();
            model.BranchDocNoRun = branchModel.doc_no_run;
            model.BranchNo = branchModel.branch_no;

            var systemModel = _db.SB_System.FirstOrDefault(d => d.hq_url.Contains("WebService"));
            if (systemModel == null)
            {
                systemModel = _db.SB_System.FirstOrDefault();
                model.HQUrl = systemModel + "/PTT_HQ";
            }
            else
                model.HQUrl = systemModel.hq_url.Replace("/WebService/webhq.asmx/", "");
            return model;
        }
    }
}
