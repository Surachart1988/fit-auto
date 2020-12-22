using PosData.Models;
using CentralService.Injection;
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosService.Services
{
    public class TransferService : ITransferService
    {
        private Entities _db;
        private IMovementProductService _movementProductService;

        public TransferService(Entities conn, IMovementProductService movementProductService)
        {
            _db = conn;
            _movementProductService = movementProductService;
        }

        public void DropNumberStoke(string docNo, string branchNo, string docCode)
        {
            var dbDetails = _db.ST_TRNDetail.Where(j => j.doc_no == docNo && j.branch_no == branchNo && j.doc_code == docCode).ToArray();

            //var productModel = dbDetails.Select(d => new ProductModel
            //{
            //    Code = d.pro_code,
            //    Name = d.pro_name,
            //    Unit = (int)d.sale_unit_code,
            //    Store = d.locat_code,
            //    Number = -d.store_qty,
            //    Reason = d.rec_memo
            //}).ToArray();

            //foreach (var product in productModel)
            //{
            //    _movementProductService.AddTodbDetailMovement(docNo, branchNo, docCode, product, product.Number);
            //    _movementProductService.UpdateProlocationData(docNo, product.Code, product.Store != null ? (int)product.Store : 0, product.Number);
            //    UpdateProductData(product.Code, (double)product.Number);
            //}
        }

        public void PushNumberStoke(string docNo, string branchNo, string docCode)
        {
            var dbDetails = _db.ST_TRNDetail.Where(j => j.doc_no == docNo && j.branch_no == branchNo && j.doc_code == docCode).ToArray();

            //var productModel = dbDetails.Select(d => new ProductModel
            //{
            //    Code = d.pro_code,
            //    Name = d.pro_name,
            //    Unit = (int)d.sale_unit_code,
            //    Store = d.locat_code,
            //    Number = d.store_qty,
            //    Reason = d.rec_memo
            //}).ToArray();

            //foreach (var product in productModel)
            //{
            //    _movementProductService.AddTodbDetailMovement(docNo, branchNo, docCode, product, product.Number);
            //    _movementProductService.UpdateProlocationData(docNo, product.Code, product.Store != null ? (int)product.Store : 0, product.Number);
            //    UpdateProductData(product.Code, (double)product.Number);
            //}
        }

        public void UpdateProductData(string productNo, double number)
        {
            var dbModel = _db.SB_Product.FirstOrDefault(p => p.pro_code == productNo);

            if (dbModel == null)
                return;

            dbModel.pro_accqty += number;
            dbModel.pro_ocqty += number;
            _db.Entry(dbModel).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
