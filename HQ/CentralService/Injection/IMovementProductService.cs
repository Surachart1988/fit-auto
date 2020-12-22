using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Injection
{
    public interface IMovementProductService
    {
        //3 save ST_Movement  (See classic/stk_checkstock_save.asp line  277-291)
        void AddTodbDetailMovement(string docNo, string branchNo, string docCode, ProductModel product,double? stockDiffrent);

        //4 ****global function**** Run fcommon.asp >   Recal_ST_Movement(Rs("pro_code"),Rs("locat_code"),date_to_number(doc_date))  

        //5 Update prolocation by pro_code and locat_code  (See classic/stk_checkstock_save.asp line  303-312)               
        void UpdateProlocationData(string branchNo, string code, int storeId, double? stockDiffrent);
    }
}
