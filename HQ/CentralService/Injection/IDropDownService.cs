using CentralService.Models;
using CentralService.Models.MasterData.Campaign;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
    public interface IDropDownService
    {
        IEnumerable<IdNameModel> GetPaymentFormat();

        IEnumerable<CodeNameModel> GetBank();

        IEnumerable<CodeNameModel> GetCardType();
        IEnumerable<CodeNameModel> GetProductGroup();
        IEnumerable<CodeNameModel> GetCustomerGroup();
        IEnumerable<CampaignModel> GetCampaign();
        IEnumerable<ProdFirstGrpModel> GetProdFirstGrp();
        IEnumerable<ProGrpListModel> GetProGrp(string prodgrpCode);
        IEnumerable<ProBrandListModel> GetProBrand(string progroupCode);
        IEnumerable<PromodelModel> GetProModel(string probrandCode);
        IEnumerable<ProSizeModel> GetProSize(string promodelCode);
        IEnumerable<ProvinceModel> GetProvince();
        IEnumerable<PrinterComModel> GetPrinterCom();
        IEnumerable<AmphurModel> GetAmphur(int? prov_id);
        IEnumerable<TambolModel> GetTambol(int? amphur_id, int? prov_id);
        IEnumerable<ZipcodeModel> GetZipCode(int? amphur_id, int? prov_id);
    }
}
