using CentralService.Models;
using CentralService.Models.MasterData.Campaign;
using System;
using System.Collections.Generic;
using System.Text;
using static CentralService.Models.MasterData.VendorModel;

namespace CentralService.Injection
{
    public interface IDropDownService
    {
        IEnumerable<IdNameModel> GetPaymentFormat();

        IEnumerable<CodeNameModel> GetBank();
        IEnumerable<ProdFirstGrpModel> GetProdFirstGrp();
        IEnumerable<ProGrpListModel> GetProGrp(string prodgrpCode);
        IEnumerable<ProBrandListModel> GetProBrand(string progroupCode);
        IEnumerable<PromodelModel> GetProModel(string probrandCode);
        IEnumerable<ProSizeModel> GetProSize(string promodelCode);
        IEnumerable<CodeNameModel> GetCardType();
        IEnumerable<CodeNameModel> GetProductGroup();
        IEnumerable<CodeNameModel> GetCustomerGroup();
        IEnumerable<CampaignModel> GetCampaign();
        IEnumerable<ProvinceModel> GetProvince();
        IEnumerable<PrinterComModel> GetPrinterCom();
        IEnumerable<UnitModel> GetddlSaleUnitCode();
        IEnumerable<AmphurModel> GetAmphur(int? prov_id);
        IEnumerable<TambolModel> GetTambol(int? amphur_id, int? prov_id);
        IEnumerable<ZipcodeModel> GetZipCode(int? amphur_id, int? prov_id);
        IEnumerable<locationModel> GetLocation();
        IEnumerable<VattypeModel> GetVattype();
        IEnumerable<BvatModel> GetBvat();
    }
}
