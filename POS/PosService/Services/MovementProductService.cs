using PosData;
using PosData.Models;
using CentralService.Injection;
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosService.Services
{
    public class MovementProductService : IMovementProductService
    {
        private Entities _db;
        public MovementProductService(Entities conn)
        {
            _db = conn;
        }

        

        public void AddTodbDetailMovement(string docNo, string branchNo, string docCode, ProductModel product,double? diffrent)
        {
            //if (product.Store == null)
            //    return;
            //var dbModel = new ST_Movement
            //{
            //    branch_no = branchNo,
            //    doc_no = docNo,
            //    doc_code = docCode,
            //    pro_code = product.Code,
            //    doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
            //    doc_time = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture),
            //    cus_code = product.ProducerCode,
            //    locat_code = (int)product.Store,
            //    DATE_REPORT = double.Parse((DateTime.Now).ToString("yyyyMMdd", CultureInfo.InvariantCulture))
            //};

            //_db.ST_Movement.Add(dbModel);
        }

        public void UpdateProlocationData(string branchNo, string code, int storeId, double? stockDiffrent)
        {
            if (stockDiffrent == null || stockDiffrent == 0)
                return;

            var dbModel = _db.SB_Prolocation.FirstOrDefault(p => (p.pro_code == code && p.locat_code == storeId));

            if (dbModel == null)
            {
                dbModel = new SB_Prolocation
                {
                    branch_no = branchNo,
                    pro_code = code,
                    locat_code = storeId,
                    pro_qoh = stockDiffrent
                };
                _db.SB_Prolocation.Add(dbModel);
            }
            else
            {
                dbModel.pro_qoh += stockDiffrent;
                _db.Entry(dbModel).State = EntityState.Modified;
            }
            _db.SaveChanges();
        }
    }
}
