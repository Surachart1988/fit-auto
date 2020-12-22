namespace HQPosData.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HQEntities : DbContext
    {
        public HQEntities()
            : base("name=HQEntities")
        {
        }

        public virtual DbSet<Authorize_Approve> Authorize_Approve { get; set; }
        public virtual DbSet<Authorize_Approve_User> Authorize_Approve_User { get; set; }
        public virtual DbSet<Authorize_Document> Authorize_Document { get; set; }
        public virtual DbSet<Authorize_Document_User> Authorize_Document_User { get; set; }
        public virtual DbSet<Authorize_Group> Authorize_Group { get; set; }
        public virtual DbSet<Authorize_Group_Approve> Authorize_Group_Approve { get; set; }
        public virtual DbSet<Authorize_Group_Document> Authorize_Group_Document { get; set; }
        public virtual DbSet<Authorize_Group_Menu> Authorize_Group_Menu { get; set; }
        public virtual DbSet<Authorize_Menu> Authorize_Menu { get; set; }
        public virtual DbSet<Authorize_Menu_Document> Authorize_Menu_Document { get; set; }
        public virtual DbSet<Authorize_Menu_Tree> Authorize_Menu_Tree { get; set; }
        public virtual DbSet<Authorize_Menu_User> Authorize_Menu_User { get; set; }
        public virtual DbSet<Authorize_User_Level> Authorize_User_Level { get; set; }
        public virtual DbSet<CAR_MASTER> CAR_MASTER { get; set; }
        public virtual DbSet<CS_cdHeader> CS_cdHeader { get; set; }
        public virtual DbSet<CS_dcDetail> CS_dcDetail { get; set; }
        public virtual DbSet<CS_dcHeader> CS_dcHeader { get; set; }
        public virtual DbSet<CS_dsDetail> CS_dsDetail { get; set; }
        public virtual DbSet<CS_dsHeader> CS_dsHeader { get; set; }
        public virtual DbSet<CS_ProCodeNew> CS_ProCodeNew { get; set; }
        public virtual DbSet<CS_proserial> CS_proserial { get; set; }
        public virtual DbSet<CS_sdDetail> CS_sdDetail { get; set; }
        public virtual DbSet<CS_sdHeader> CS_sdHeader { get; set; }
        public virtual DbSet<dtproperty> dtproperties { get; set; }
        public virtual DbSet<logupdate_data> logupdate_data { get; set; }
        public virtual DbSet<MessageData> MessageData { get; set; }
        public virtual DbSet<RP_Barcode> RP_Barcode { get; set; }
        public virtual DbSet<RP_Financial_Detail> RP_Financial_Detail { get; set; }
        public virtual DbSet<RP_Financial_Detail_Day_End> RP_Financial_Detail_Day_End { get; set; }
        public virtual DbSet<RP_Financial_Header> RP_Financial_Header { get; set; }
        public virtual DbSet<RP_Financial_Header_Day_End> RP_Financial_Header_Day_End { get; set; }
        public virtual DbSet<RP_SaleAndReceive> RP_SaleAndReceive { get; set; }
        public virtual DbSet<RP_TAXSUMGROUP> RP_TAXSUMGROUP { get; set; }
        public virtual DbSet<RP_VB_Adjust_stock> RP_VB_Adjust_stock { get; set; }
        public virtual DbSet<RP_VB_income> RP_VB_income { get; set; }
        public virtual DbSet<RP_VB_sale> RP_VB_sale { get; set; }
        public virtual DbSet<SB_3Day_List> SB_3Day_List { get; set; }
        public virtual DbSet<SB_Approve_Status> SB_Approve_Status { get; set; }
        public virtual DbSet<SB_AutoCheck> SB_AutoCheck { get; set; }
        public virtual DbSet<SB_AutoCheck_Set_Detail> SB_AutoCheck_Set_Detail { get; set; }
        public virtual DbSet<SB_AutoCheck_Set_Head> SB_AutoCheck_Set_Head { get; set; }
        public virtual DbSet<SB_AutoCheck_Set_Temp> SB_AutoCheck_Set_Temp { get; set; }
        public virtual DbSet<SB_Bank> SB_Bank { get; set; }
        public virtual DbSet<SB_bankaccount> SB_bankaccount { get; set; }
        public virtual DbSet<SB_Billing_Document> SB_Billing_Document { get; set; }
        public virtual DbSet<SB_Billing_Log> SB_Billing_Log { get; set; }
        public virtual DbSet<SB_Branch> SB_Branch { get; set; }
        public virtual DbSet<SB_busstype> SB_busstype { get; set; }
        public virtual DbSet<SB_BVat> SB_BVat { get; set; }
        public virtual DbSet<SB_Callpoint> SB_Callpoint { get; set; }
        public virtual DbSet<SB_Callstatus> SB_Callstatus { get; set; }
        public virtual DbSet<SB_Campaign> SB_Campaign { get; set; }
        public virtual DbSet<SB_Cancel_icard> SB_Cancel_icard { get; set; }
        public virtual DbSet<SB_Carbrand> SB_Carbrand { get; set; }
        public virtual DbSet<SB_CarColor> SB_CarColor { get; set; }
        public virtual DbSet<SB_CardType> SB_CardType { get; set; }
        public virtual DbSet<SB_CarGear> SB_CarGear { get; set; }
        public virtual DbSet<SB_CarModel> SB_CarModel { get; set; }
        public virtual DbSet<SB_Cartype> SB_Cartype { get; set; }
        public virtual DbSet<SB_Chq_Status> SB_Chq_Status { get; set; }
        public virtual DbSet<SB_CLUB_TYPE> SB_CLUB_TYPE { get; set; }
        public virtual DbSet<SB_Coupon> SB_Coupon { get; set; }
        public virtual DbSet<SB_CouponDetail> SB_CouponDetail { get; set; }
        public virtual DbSet<SB_PromotionCouponDetailEmp> SB_PromotionCouponDetailEmp { get; set; }
        public virtual DbSet<SB_Credit_card> SB_Credit_card { get; set; }
        public virtual DbSet<SB_CusCar> SB_CusCar { get; set; }
        public virtual DbSet<SB_Cuscar_Mileage_Job_Log> SB_Cuscar_Mileage_Job_Log { get; set; }
        public virtual DbSet<SB_Cuscar_Mileage_Log> SB_Cuscar_Mileage_Log { get; set; }
        public virtual DbSet<SB_Customer> SB_Customer { get; set; }
        public virtual DbSet<SB_Customer_Contact> SB_Customer_Contact { get; set; }
        public virtual DbSet<SB_Customer_Proprice> SB_Customer_Proprice { get; set; }
        public virtual DbSet<SB_Custype> SB_Custype { get; set; }
        public virtual DbSet<SB_Custype_pay> SB_Custype_pay { get; set; }
        public virtual DbSet<SB_Dealercode_Master> SB_Dealercode_Master { get; set; }
        public virtual DbSet<SB_decpay> SB_decpay { get; set; }
        public virtual DbSet<SB_Docno_Ref_Log> SB_Docno_Ref_Log { get; set; }
        public virtual DbSet<SB_document> SB_document { get; set; }
        public virtual DbSet<SB_ExtraDiscount> SB_ExtraDiscount { get; set; }
        public virtual DbSet<SB_FilmCar_Detail> SB_FilmCar_Detail { get; set; }
        public virtual DbSet<SB_FilmCar_Detail_Temp> SB_FilmCar_Detail_Temp { get; set; }
        public virtual DbSet<SB_FilmCar_Header> SB_FilmCar_Header { get; set; }
        public virtual DbSet<SB_FilmCar_Model> SB_FilmCar_Model { get; set; }
        public virtual DbSet<SB_FilmCar_Model_Temp> SB_FilmCar_Model_Temp { get; set; }
        public virtual DbSet<SB_FilmCar_Size> SB_FilmCar_Size { get; set; }
        public virtual DbSet<SB_Grooveprice> SB_Grooveprice { get; set; }
        public virtual DbSet<SB_incpay> SB_incpay { get; set; }
        public virtual DbSet<SB_Installment_Type> SB_Installment_Type { get; set; }
        public virtual DbSet<SB_location> SB_location { get; set; }
        public virtual DbSet<SB_Location_DOT> SB_Location_DOT { get; set; }
        public virtual DbSet<SB_log> SB_log { get; set; }
        public virtual DbSet<SB_meeting> SB_meeting { get; set; }
        public virtual DbSet<SB_paytype> SB_paytype { get; set; }
        public virtual DbSet<SB_priceown> SB_priceown { get; set; }
        public virtual DbSet<SB_Print_Log> SB_Print_Log { get; set; }
        public virtual DbSet<SB_Probrand> SB_Probrand { get; set; }
        public virtual DbSet<SB_Product> SB_Product { get; set; }
        public virtual DbSet<SB_Product_Barcode> SB_Product_Barcode { get; set; }
        public virtual DbSet<SB_Product_FirstGroup> SB_Product_FirstGroup { get; set; }
        public virtual DbSet<SB_Product_Child> SB_Product_Child { get; set; }
        public virtual DbSet<SB_Product_Child_Log> SB_Product_Child_Log { get; set; }
        public virtual DbSet<SB_product_group> SB_product_group { get; set; }
        public virtual DbSet<SB_product_group_detail> SB_product_group_detail { get; set; }
        public virtual DbSet<SB_Product_Picture> SB_Product_Picture { get; set; }
        public virtual DbSet<SB_Product_Qty> SB_Product_Qty { get; set; }
        public virtual DbSet<SB_Product_Replace> SB_Product_Replace { get; set; }
        public virtual DbSet<SB_Product_Replace_Code> SB_Product_Replace_Code { get; set; }
        public virtual DbSet<SB_Product_Set_Detail> SB_Product_Set_Detail { get; set; }
        public virtual DbSet<SB_Product_Set_Head> SB_Product_Set_Head { get; set; }
        public virtual DbSet<SB_Product_Set_Temp> SB_Product_Set_Temp { get; set; }
        public virtual DbSet<SB_Product_Sub> SB_Product_Sub { get; set; }
        public virtual DbSet<SB_Product_Temp_Delete> SB_Product_Temp_Delete { get; set; }
        public virtual DbSet<SB_Product_Type_Used> SB_Product_Type_Used { get; set; }
        public virtual DbSet<SB_Progroup> SB_Progroup { get; set; }
        public virtual DbSet<SB_Prolocation> SB_Prolocation { get; set; }
        public virtual DbSet<SB_promo> SB_promo { get; set; }
        public virtual DbSet<SB_Promodel> SB_Promodel { get; set; }
        public virtual DbSet<SB_promotion> SB_promotion { get; set; }
        public virtual DbSet<SB_PromotionConditionTime> SB_PromotionConditionTime { get; set; }
        public virtual DbSet<SB_PromotionDetail> SB_PromotionDetail { get; set; }
        public virtual DbSet<SB_PromotionDiscount> SB_PromotionDiscount { get; set; }
        public virtual DbSet<SB_PromotionGiveType> SB_PromotionGiveType { get; set; }
        public virtual DbSet<SB_PromotionGroupUsed> SB_PromotionGroupUsed { get; set; }
        public virtual DbSet<SB_PromotionHeader> SB_PromotionHeader { get; set; }
        public virtual DbSet<SB_PromotionPrice> SB_PromotionPrice { get; set; }
        public virtual DbSet<SB_PromotionType> SB_PromotionType { get; set; }
        public virtual DbSet<SB_proprice> SB_proprice { get; set; }
        public virtual DbSet<SB_Proprice_Log> SB_Proprice_Log { get; set; }
        public virtual DbSet<SB_ProSize> SB_ProSize { get; set; }
        public virtual DbSet<SB_PROSUB_NEXTSERV> SB_PROSUB_NEXTSERV { get; set; }
        public virtual DbSet<SB_PROSUB_NEXTSERV_CAR> SB_PROSUB_NEXTSERV_CAR { get; set; }
        public virtual DbSet<SB_prounit> SB_prounit { get; set; }
        public virtual DbSet<SB_province> SB_province { get; set; }
        public virtual DbSet<SB_Prov_Amphur> SB_Prov_Amphur { get; set; }
        public virtual DbSet<SB_Prov_Tambol> SB_Prov_Tambol { get; set; }
        public virtual DbSet<SB_Question_Choice> SB_Question_Choice { get; set; }
        public virtual DbSet<SB_Question_Detail> SB_Question_Detail { get; set; }
        public virtual DbSet<SB_Question_Head> SB_Question_Head { get; set; }
        public virtual DbSet<SB_sex> SB_sex { get; set; }
        public virtual DbSet<SB_statuscar> SB_statuscar { get; set; }
        public virtual DbSet<SB_Stock_Status> SB_Stock_Status { get; set; }
        public virtual DbSet<SB_svat> SB_svat { get; set; }
        public virtual DbSet<SB_Tax_Condition> SB_Tax_Condition { get; set; }
        public virtual DbSet<SB_Tax_Income> SB_Tax_Income { get; set; }
        public virtual DbSet<SB_Tax_Income_Rate> SB_Tax_Income_Rate { get; set; }
        public virtual DbSet<SB_Tax_Money> SB_Tax_Money { get; set; }
        public virtual DbSet<SB_Tax_Type> SB_Tax_Type { get; set; }
        public virtual DbSet<SB_TBPoint> SB_TBPoint { get; set; }
        public virtual DbSet<SB_TextReport> SB_TextReport { get; set; }
        public virtual DbSet<SB_TypeReceiveCheque> SB_TypeReceiveCheque { get; set; }
        public virtual DbSet<SB_TYRE_POSITION> SB_TYRE_POSITION { get; set; }
        public virtual DbSet<SB_UnitName> SB_UnitName { get; set; }
        public virtual DbSet<SB_vattype> SB_vattype { get; set; }
        public virtual DbSet<SB_Vendor> SB_Vendor { get; set; }
        public virtual DbSet<SB_Vendor_Replace> SB_Vendor_Replace { get; set; }
        public virtual DbSet<SB_Vote> SB_Vote { get; set; }
        public virtual DbSet<SB_Vote_Detail> SB_Vote_Detail { get; set; }
        public virtual DbSet<SB_WARRANTY_TYPE> SB_WARRANTY_TYPE { get; set; }
        public virtual DbSet<SBHRUser> SBHRUsers { get; set; }
        public virtual DbSet<ST_AbbDetail> ST_AbbDetail { get; set; }
        public virtual DbSet<ST_AbbHeader> ST_AbbHeader { get; set; }
        public virtual DbSet<ST_AbbTemp> ST_AbbTemp { get; set; }
        public virtual DbSet<ST_ACADetail> ST_ACADetail { get; set; }
        public virtual DbSet<ST_ACAHeader> ST_ACAHeader { get; set; }
        public virtual DbSet<ST_ACATemp> ST_ACATemp { get; set; }
        public virtual DbSet<ST_Addrbill> ST_Addrbill { get; set; }
        public virtual DbSet<ST_Ap_Log> ST_Ap_Log { get; set; }
        public virtual DbSet<ST_Apdetail> ST_Apdetail { get; set; }
        public virtual DbSet<ST_Apdocno> ST_Apdocno { get; set; }
        public virtual DbSet<ST_Apheader> ST_Apheader { get; set; }
        public virtual DbSet<ST_Aptemp> ST_Aptemp { get; set; }
        public virtual DbSet<ST_Ar_Addr> ST_Ar_Addr { get; set; }
        public virtual DbSet<ST_Ar_DocNo2_LOG> ST_Ar_DocNo2_LOG { get; set; }
        public virtual DbSet<ST_Ar_Log> ST_Ar_Log { get; set; }
        public virtual DbSet<ST_Ar_Payment_Temp> ST_Ar_Payment_Temp { get; set; }
        public virtual DbSet<ST_Ardetail> ST_Ardetail { get; set; }
        public virtual DbSet<ST_Ardocno> ST_Ardocno { get; set; }
        public virtual DbSet<ST_Arheader> ST_Arheader { get; set; }
        public virtual DbSet<ST_ArPayCancel_Log> ST_ArPayCancel_Log { get; set; }
        public virtual DbSet<ST_Artemp> ST_Artemp { get; set; }
        public virtual DbSet<ST_avg> ST_avg { get; set; }
        public virtual DbSet<ST_avg_cal> ST_avg_cal { get; set; }
        public virtual DbSet<ST_Banktrans> ST_Banktrans { get; set; }
        public virtual DbSet<ST_BAP_Log> ST_BAP_Log { get; set; }
        public virtual DbSet<ST_Barcode_Print> ST_Barcode_Print { get; set; }
        public virtual DbSet<ST_BIL_Log> ST_BIL_Log { get; set; }
        public virtual DbSet<ST_BILDetail> ST_BILDetail { get; set; }
        public virtual DbSet<ST_BILHeader> ST_BILHeader { get; set; }
        public virtual DbSet<ST_BILTemp> ST_BILTemp { get; set; }
        public virtual DbSet<ST_Cancel_icard> ST_Cancel_icard { get; set; }
        public virtual DbSet<ST_Car_reg> ST_Car_reg { get; set; }
        public virtual DbSet<ST_Car_Transfer> ST_Car_Transfer { get; set; }
        public virtual DbSet<ST_Chk_Log> ST_Chk_Log { get; set; }
        public virtual DbSet<ST_ChkDetail> ST_ChkDetail { get; set; }
        public virtual DbSet<ST_ChkHeader> ST_ChkHeader { get; set; }
        public virtual DbSet<ST_ChkPicture> ST_ChkPicture { get; set; }
        public virtual DbSet<ST_ChkTemp> ST_ChkTemp { get; set; }
        public virtual DbSet<ST_Ck_Log> ST_Ck_Log { get; set; }
        public virtual DbSet<ST_CkDetail> ST_CkDetail { get; set; }
        public virtual DbSet<ST_CkHeader> ST_CkHeader { get; set; }
        public virtual DbSet<ST_CkTemp> ST_CkTemp { get; set; }
        public virtual DbSet<ST_Claim_Online> ST_Claim_Online { get; set; }
        public virtual DbSet<ST_Claim_Online_Serial> ST_Claim_Online_Serial { get; set; }
        public virtual DbSet<ST_Coupon_Create_Log> ST_Coupon_Create_Log { get; set; }
        public virtual DbSet<ST_CST_Log> ST_CST_Log { get; set; }
        public virtual DbSet<ST_CSTApprove_Log> ST_CSTApprove_Log { get; set; }
        public virtual DbSet<ST_CSTDetail> ST_CSTDetail { get; set; }
        public virtual DbSet<ST_CSTDetail_Approve> ST_CSTDetail_Approve { get; set; }
        public virtual DbSet<ST_CSTHeader> ST_CSTHeader { get; set; }
        public virtual DbSet<ST_CSTHeader_Approve> ST_CSTHeader_Approve { get; set; }
        public virtual DbSet<ST_CSTTemp> ST_CSTTemp { get; set; }
        public virtual DbSet<ST_DayEnd_Docno> ST_DayEnd_Docno { get; set; }
        public virtual DbSet<ST_Docno> ST_Docno { get; set; }
        public virtual DbSet<ST_Document_Log> ST_Document_Log { get; set; }
        public virtual DbSet<ST_DST_Log> ST_DST_Log { get; set; }
        public virtual DbSet<ST_ICA_Log> ST_ICA_Log { get; set; }
        public virtual DbSet<ST_ICAApprove_Log> ST_ICAApprove_Log { get; set; }
        public virtual DbSet<ST_ICADetail> ST_ICADetail { get; set; }
        public virtual DbSet<ST_ICADetail_Approve> ST_ICADetail_Approve { get; set; }
        public virtual DbSet<ST_ICAHeader> ST_ICAHeader { get; set; }
        public virtual DbSet<ST_ICAHeader_Approve> ST_ICAHeader_Approve { get; set; }
        public virtual DbSet<ST_ICARD_EXPIRE> ST_ICARD_EXPIRE { get; set; }
        public virtual DbSet<ST_icard_id> ST_icard_id { get; set; }
        public virtual DbSet<ST_ICATemp> ST_ICATemp { get; set; }
        public virtual DbSet<ST_ICT_Log> ST_ICT_Log { get; set; }
        public virtual DbSet<ST_ICTDetail> ST_ICTDetail { get; set; }
        public virtual DbSet<ST_ICTHeader> ST_ICTHeader { get; set; }
        public virtual DbSet<ST_ICTTemp> ST_ICTTemp { get; set; }
        public virtual DbSet<ST_Job_Docno_Ref_Log> ST_Job_Docno_Ref_Log { get; set; }
        public virtual DbSet<ST_Job_Log> ST_Job_Log { get; set; }
        public virtual DbSet<ST_Job3Day_LOG> ST_Job3Day_LOG { get; set; }
        public virtual DbSet<ST_Job3Day_Question> ST_Job3Day_Question { get; set; }
        public virtual DbSet<ST_JobApprove_Log> ST_JobApprove_Log { get; set; }
        public virtual DbSet<ST_Jobdetail> ST_Jobdetail { get; set; }
        public virtual DbSet<ST_Jobdetail_Approve> ST_Jobdetail_Approve { get; set; }
        public virtual DbSet<ST_Jobdocno> ST_Jobdocno { get; set; }
        public virtual DbSet<ST_Jobheader> ST_Jobheader { get; set; }
        public virtual DbSet<ST_Jobheader_Approve> ST_Jobheader_Approve { get; set; }
        public virtual DbSet<ST_JobPicture> ST_JobPicture { get; set; }
        public virtual DbSet<ST_Jobtemp> ST_Jobtemp { get; set; }
        public virtual DbSet<ST_Jobtemp_Approve> ST_Jobtemp_Approve { get; set; }
        public virtual DbSet<ST_Logupdate_Data> ST_Logupdate_Data { get; set; }
        public virtual DbSet<ST_Movement> ST_Movement { get; set; }
        public virtual DbSet<ST_Movement_Cal> ST_Movement_Cal { get; set; }
        public virtual DbSet<ST_Movement_Report> ST_Movement_Report { get; set; }
        public virtual DbSet<ST_Movement_Sum> ST_Movement_Sum { get; set; }
        public virtual DbSet<ST_Movement_Sum_Log> ST_Movement_Sum_Log { get; set; }
        public virtual DbSet<ST_Movement_Vat> ST_Movement_Vat { get; set; }
        public virtual DbSet<ST_Movement_Vat_All> ST_Movement_Vat_All { get; set; }
        public virtual DbSet<ST_Movement_Vat_All_Cal> ST_Movement_Vat_All_Cal { get; set; }
        public virtual DbSet<ST_Movement_Vat_All_Log> ST_Movement_Vat_All_Log { get; set; }
        public virtual DbSet<ST_Movement_Vat_Cal> ST_Movement_Vat_Cal { get; set; }
        public virtual DbSet<ST_Movement_Vat_Day> ST_Movement_Vat_Day { get; set; }
        public virtual DbSet<ST_Movement_Vat_Day_All> ST_Movement_Vat_Day_All { get; set; }
        public virtual DbSet<ST_Movement_Vat_Day_All_Cal> ST_Movement_Vat_Day_All_Cal { get; set; }
        public virtual DbSet<ST_Movement_Vat_Day_All_Log> ST_Movement_Vat_Day_All_Log { get; set; }
        public virtual DbSet<ST_Movement_Vat_Day_Cal> ST_Movement_Vat_Day_Cal { get; set; }
        public virtual DbSet<ST_Movement_Vat_Ex> ST_Movement_Vat_Ex { get; set; }
        public virtual DbSet<ST_Movement_Vat_Ex_All> ST_Movement_Vat_Ex_All { get; set; }
        public virtual DbSet<ST_Movement_Vat_Ex_All_Cal> ST_Movement_Vat_Ex_All_Cal { get; set; }
        public virtual DbSet<ST_Movement_Vat_Ex_All_Log> ST_Movement_Vat_Ex_All_Log { get; set; }
        public virtual DbSet<ST_Movement_Vat_Ex_Cal> ST_Movement_Vat_Ex_Cal { get; set; }
        public virtual DbSet<ST_Movement_View> ST_Movement_View { get; set; }
        public virtual DbSet<ST_Payadj> ST_Payadj { get; set; }
        public virtual DbSet<ST_PayCancel_Log> ST_PayCancel_Log { get; set; }
        public virtual DbSet<ST_PayCard> ST_PayCard { get; set; }
        public virtual DbSet<ST_PayCard_Log> ST_PayCard_Log { get; set; }
        public virtual DbSet<ST_PayCash> ST_PayCash { get; set; }
        public virtual DbSet<ST_PayCashCard> ST_PayCashCard { get; set; }
        public virtual DbSet<ST_PayChq> ST_PayChq { get; set; }
        public virtual DbSet<ST_PayDep> ST_PayDep { get; set; }
        public virtual DbSet<ST_Paydoc> ST_Paydoc { get; set; }
        public virtual DbSet<ST_PayOnAcc> ST_PayOnAcc { get; set; }
        public virtual DbSet<ST_PayOther> ST_PayOther { get; set; }
        public virtual DbSet<ST_PayOwn> ST_PayOwn { get; set; }
        public virtual DbSet<ST_PCC_Log> ST_PCC_Log { get; set; }
        public virtual DbSet<ST_PCCDetail> ST_PCCDetail { get; set; }
        public virtual DbSet<ST_PCCHeader> ST_PCCHeader { get; set; }
        public virtual DbSet<ST_PCCTemp> ST_PCCTemp { get; set; }
        public virtual DbSet<ST_Pcn_Log> ST_Pcn_Log { get; set; }
        public virtual DbSet<ST_PCNApprove_Log> ST_PCNApprove_Log { get; set; }
        public virtual DbSet<ST_PCNDetail> ST_PCNDetail { get; set; }
        public virtual DbSet<ST_PCNDetail_Approve> ST_PCNDetail_Approve { get; set; }
        public virtual DbSet<ST_PCNHeader> ST_PCNHeader { get; set; }
        public virtual DbSet<ST_PCNHeader_Approve> ST_PCNHeader_Approve { get; set; }
        public virtual DbSet<ST_PCNTemp> ST_PCNTemp { get; set; }
        public virtual DbSet<ST_PCP_Log> ST_PCP_Log { get; set; }
        public virtual DbSet<ST_PCPDetail> ST_PCPDetail { get; set; }
        public virtual DbSet<ST_PCPHeader> ST_PCPHeader { get; set; }
        public virtual DbSet<ST_PCPTemp> ST_PCPTemp { get; set; }
        public virtual DbSet<ST_PDC_Log> ST_PDC_Log { get; set; }
        public virtual DbSet<ST_PDCDetail> ST_PDCDetail { get; set; }
        public virtual DbSet<ST_PDCHeader> ST_PDCHeader { get; set; }
        public virtual DbSet<ST_PDCTemp> ST_PDCTemp { get; set; }
        public virtual DbSet<ST_PDP_Log> ST_PDP_Log { get; set; }
        public virtual DbSet<ST_PDPDetail> ST_PDPDetail { get; set; }
        public virtual DbSet<ST_PDPHeader> ST_PDPHeader { get; set; }
        public virtual DbSet<ST_PDPTemp> ST_PDPTemp { get; set; }
        public virtual DbSet<ST_Po_Log> ST_Po_Log { get; set; }
        public virtual DbSet<ST_Podetail> ST_Podetail { get; set; }
        public virtual DbSet<ST_Poheader> ST_Poheader { get; set; }
        public virtual DbSet<ST_Potemp> ST_Potemp { get; set; }
        public virtual DbSet<ST_PPA_Log> ST_PPA_Log { get; set; }
        public virtual DbSet<ST_PPADetail> ST_PPADetail { get; set; }
        public virtual DbSet<ST_PPAHeader> ST_PPAHeader { get; set; }
        public virtual DbSet<ST_PPATemp> ST_PPATemp { get; set; }
        public virtual DbSet<ST_Pr_Log> ST_Pr_Log { get; set; }
        public virtual DbSet<ST_PrApprove_Log> ST_PrApprove_Log { get; set; }
        public virtual DbSet<ST_PrDetail> ST_PrDetail { get; set; }
        public virtual DbSet<ST_PrDetail_Approve> ST_PrDetail_Approve { get; set; }
        public virtual DbSet<ST_Prheader> ST_Prheader { get; set; }
        public virtual DbSet<ST_Prheader_Approve> ST_Prheader_Approve { get; set; }
        public virtual DbSet<ST_ProDot> ST_ProDot { get; set; }
        public virtual DbSet<ST_PromotionUsedDetail> ST_PromotionUsedDetail { get; set; }
        public virtual DbSet<ST_PromotionUsedHeader> ST_PromotionUsedHeader { get; set; }
        public virtual DbSet<ST_proserial> ST_proserial { get; set; }
        public virtual DbSet<ST_Proserial_Edit> ST_Proserial_Edit { get; set; }
        public virtual DbSet<ST_Proserial_TB> ST_Proserial_TB { get; set; }
        public virtual DbSet<ST_PrTemp> ST_PrTemp { get; set; }
        public virtual DbSet<ST_PTA_Log> ST_PTA_Log { get; set; }
        public virtual DbSet<ST_PTADetail> ST_PTADetail { get; set; }
        public virtual DbSet<ST_PTAHeader> ST_PTAHeader { get; set; }
        public virtual DbSet<ST_PTATemp> ST_PTATemp { get; set; }
        public virtual DbSet<ST_qr_05_ini_product> ST_qr_05_ini_product { get; set; }
        public virtual DbSet<ST_qr_05_sale_product> ST_qr_05_sale_product { get; set; }
        public virtual DbSet<ST_RCC_Log> ST_RCC_Log { get; set; }
        public virtual DbSet<ST_RCCDetail> ST_RCCDetail { get; set; }
        public virtual DbSet<ST_RCCHeader> ST_RCCHeader { get; set; }
        public virtual DbSet<ST_RCCTemp> ST_RCCTemp { get; set; }
        public virtual DbSet<ST_RCP_Log> ST_RCP_Log { get; set; }
        public virtual DbSet<ST_RCPDetail> ST_RCPDetail { get; set; }
        public virtual DbSet<ST_RCPHeader> ST_RCPHeader { get; set; }
        public virtual DbSet<ST_RCPTemp> ST_RCPTemp { get; set; }
        public virtual DbSet<ST_Rda_Log> ST_Rda_Log { get; set; }
        public virtual DbSet<ST_RDADetail> ST_RDADetail { get; set; }
        public virtual DbSet<ST_RDAHeader> ST_RDAHeader { get; set; }
        public virtual DbSet<ST_RDATemp> ST_RDATemp { get; set; }
        public virtual DbSet<ST_RDC_Log> ST_RDC_Log { get; set; }
        public virtual DbSet<ST_RDCDetail> ST_RDCDetail { get; set; }
        public virtual DbSet<ST_RDCHeader> ST_RDCHeader { get; set; }
        public virtual DbSet<ST_RDCTemp> ST_RDCTemp { get; set; }
        public virtual DbSet<ST_Rdisc_Detail> ST_Rdisc_Detail { get; set; }
        public virtual DbSet<ST_Rdisc_Head> ST_Rdisc_Head { get; set; }
        public virtual DbSet<ST_Rdisc_Log> ST_Rdisc_Log { get; set; }
        public virtual DbSet<ST_Rdisc_Temp> ST_Rdisc_Temp { get; set; }
        public virtual DbSet<ST_RDP_Log> ST_RDP_Log { get; set; }
        public virtual DbSet<ST_RDPDetail> ST_RDPDetail { get; set; }
        public virtual DbSet<ST_RDPHeader> ST_RDPHeader { get; set; }
        public virtual DbSet<ST_RDPTemp> ST_RDPTemp { get; set; }
        public virtual DbSet<ST_Records> ST_Records { get; set; }
        public virtual DbSet<ST_Return_Log> ST_Return_Log { get; set; }
        public virtual DbSet<ST_RETURNDETAIL> ST_RETURNDETAIL { get; set; }
        public virtual DbSet<ST_RETURNHEADER> ST_RETURNHEADER { get; set; }
        public virtual DbSet<ST_RETURNTEMP> ST_RETURNTEMP { get; set; }
        public virtual DbSet<ST_RPA_Log> ST_RPA_Log { get; set; }
        public virtual DbSet<ST_RPAdetail> ST_RPAdetail { get; set; }
        public virtual DbSet<ST_RPAdocno> ST_RPAdocno { get; set; }
        public virtual DbSet<ST_RPAheader> ST_RPAheader { get; set; }
        public virtual DbSet<ST_RPATemp> ST_RPATemp { get; set; }
        public virtual DbSet<ST_RTA_Log> ST_RTA_Log { get; set; }
        public virtual DbSet<ST_RTADetail> ST_RTADetail { get; set; }
        public virtual DbSet<ST_RTAHeader> ST_RTAHeader { get; set; }
        public virtual DbSet<ST_RTATemp> ST_RTATemp { get; set; }
        public virtual DbSet<ST_SCARD_DETAIL> ST_SCARD_DETAIL { get; set; }
        public virtual DbSet<ST_SCARD_DETAIL_TB> ST_SCARD_DETAIL_TB { get; set; }
        public virtual DbSet<ST_SCARD_HEAD> ST_SCARD_HEAD { get; set; }
        public virtual DbSet<ST_SCARD_HEAD_TB> ST_SCARD_HEAD_TB { get; set; }
        public virtual DbSet<ST_Services> ST_Services { get; set; }
        public virtual DbSet<ST_ShipPicture> ST_ShipPicture { get; set; }
        public virtual DbSet<ST_SST_Log> ST_SST_Log { get; set; }
        public virtual DbSet<ST_Trclaim> ST_Trclaim { get; set; }
        public virtual DbSet<ST_TRN_Log> ST_TRN_Log { get; set; }
        public virtual DbSet<ST_TRNDetail> ST_TRNDetail { get; set; }
        public virtual DbSet<ST_TRNHeader> ST_TRNHeader { get; set; }
        public virtual DbSet<ST_TRNTemp> ST_TRNTemp { get; set; }
        public virtual DbSet<ST_UpdateDetail> ST_UpdateDetail { get; set; }
        public virtual DbSet<ST_UpdateHeader> ST_UpdateHeader { get; set; }
        public virtual DbSet<ST_UpdateTemp> ST_UpdateTemp { get; set; }
        public virtual DbSet<ST_Voidno_Create_Log> ST_Voidno_Create_Log { get; set; }
        public virtual DbSet<ST_Voidno_Del_Log> ST_Voidno_Del_Log { get; set; }
        public virtual DbSet<ST_Vote_Log> ST_Vote_Log { get; set; }
        public virtual DbSet<ST_WTH_Log> ST_WTH_Log { get; set; }
        public virtual DbSet<ST_WTHDetail> ST_WTHDetail { get; set; }
        public virtual DbSet<ST_WTHHeader> ST_WTHHeader { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TClam_case> TClam_case { get; set; }
        public virtual DbSet<Transfer_Data> Transfer_Data { get; set; }
        public virtual DbSet<TRepair_case> TRepair_case { get; set; }
        public virtual DbSet<Authorize2_Approve_User> Authorize2_Approve_User { get; set; }
        public virtual DbSet<Authorize2_Approve_User_Web_Log> Authorize2_Approve_User_Web_Log { get; set; }
        public virtual DbSet<Authorize2_Document> Authorize2_Document { get; set; }
        public virtual DbSet<Authorize2_Document_User> Authorize2_Document_User { get; set; }
        public virtual DbSet<Authorize2_Document_User_Web_Log> Authorize2_Document_User_Web_Log { get; set; }
        public virtual DbSet<Authorize2_Group> Authorize2_Group { get; set; }
        public virtual DbSet<Authorize2_Group_Web_Log> Authorize2_Group_Web_Log { get; set; }
        public virtual DbSet<Authorize2_Menu> Authorize2_Menu { get; set; }
        public virtual DbSet<Authorize2_Menu_User> Authorize2_Menu_User { get; set; }
        public virtual DbSet<Authorize2_Menu_User_Web_Log> Authorize2_Menu_User_Web_Log { get; set; }
        public virtual DbSet<CS_cdDetail> CS_cdDetail { get; set; }
        public virtual DbSet<CS_DocNo> CS_DocNo { get; set; }
        public virtual DbSet<CS_ProLocation> CS_ProLocation { get; set; }
        public virtual DbSet<CS_SN> CS_SN { get; set; }
        public virtual DbSet<CS_tmpcdDetail> CS_tmpcdDetail { get; set; }
        public virtual DbSet<CS_tmpcdHeader> CS_tmpcdHeader { get; set; }
        public virtual DbSet<CS_tmpITEM> CS_tmpITEM { get; set; }
        public virtual DbSet<IP_Address> IP_Address { get; set; }
        public virtual DbSet<ISB_Transfer_Data> ISB_Transfer_Data { get; set; }
        public virtual DbSet<RP_AgeAp> RP_AgeAp { get; set; }
        public virtual DbSet<RP_AgeAr> RP_AgeAr { get; set; }
        public virtual DbSet<RP_ApkeepHeader> RP_ApkeepHeader { get; set; }
        public virtual DbSet<RP_ArkeepHeader> RP_ArkeepHeader { get; set; }
        public virtual DbSet<RP_TaxSaleHeader> RP_TaxSaleHeader { get; set; }
        public virtual DbSet<SB_3Day_List_Web_Log> SB_3Day_List_Web_Log { get; set; }
        public virtual DbSet<SB_Alltable> SB_Alltable { get; set; }
        public virtual DbSet<SB_AutoCheck_Web_Log> SB_AutoCheck_Web_Log { get; set; }
        public virtual DbSet<SB_Bank_Web_Log> SB_Bank_Web_Log { get; set; }
        public virtual DbSet<SB_BlueCard> SB_BlueCard { get; set; }
        public virtual DbSet<SB_BlueCardRedeemSetting> SB_BlueCardRedeemSetting { get; set; }
        public virtual DbSet<SB_Branch_Web_Log> SB_Branch_Web_Log { get; set; }
        public virtual DbSet<SB_busstype_Web_Log> SB_busstype_Web_Log { get; set; }
        public virtual DbSet<SB_BVat_Web_log> SB_BVat_Web_log { get; set; }
        public virtual DbSet<SB_Carbrand_Web_Log> SB_Carbrand_Web_Log { get; set; }
        public virtual DbSet<SB_CarColor_Web_Log> SB_CarColor_Web_Log { get; set; }
        public virtual DbSet<SB_CardType_Web_Log> SB_CardType_Web_Log { get; set; }
        public virtual DbSet<SB_CarGear_Web_Log> SB_CarGear_Web_Log { get; set; }
        public virtual DbSet<SB_CarModel_Web_Log> SB_CarModel_Web_Log { get; set; }
        public virtual DbSet<SB_Cartype_Web_log> SB_Cartype_Web_log { get; set; }
        public virtual DbSet<SB_Chq_Status_Sub> SB_Chq_Status_Sub { get; set; }
        public virtual DbSet<SB_CusCar_Web_Log> SB_CusCar_Web_Log { get; set; }
        public virtual DbSet<SB_Customer_Mobile_Log> SB_Customer_Mobile_Log { get; set; }
        public virtual DbSet<SB_Customer_Proprice_Web_Log> SB_Customer_Proprice_Web_Log { get; set; }
        public virtual DbSet<SB_Customer_Web_Log> SB_Customer_Web_Log { get; set; }
        public virtual DbSet<SB_Custype_Web_log> SB_Custype_Web_log { get; set; }
        public virtual DbSet<SB_Dealercode_Master_Web_Log> SB_Dealercode_Master_Web_Log { get; set; }
        public virtual DbSet<SB_FilmCarModel> SB_FilmCarModel { get; set; }
        public virtual DbSet<SB_FilmPosition> SB_FilmPosition { get; set; }
        public virtual DbSet<SB_Installment_Type_Web_Log> SB_Installment_Type_Web_Log { get; set; }
        public virtual DbSet<SB_Letter> SB_Letter { get; set; }
        public virtual DbSet<SB_Location_DOT_Web_Log> SB_Location_DOT_Web_Log { get; set; }
        public virtual DbSet<SB_location_Web_log> SB_location_Web_log { get; set; }
        public virtual DbSet<SB_Paytype_Web_Log> SB_Paytype_Web_Log { get; set; }
        public virtual DbSet<SB_Priceown_Web_Log> SB_Priceown_Web_Log { get; set; }
        public virtual DbSet<SB_Probrand_Web_Log> SB_Probrand_Web_Log { get; set; }
        public virtual DbSet<SB_Product_Barcode_Web_Log> SB_Product_Barcode_Web_Log { get; set; }
        public virtual DbSet<SB_Product_Replace_Code_Web_Log> SB_Product_Replace_Code_Web_Log { get; set; }
        public virtual DbSet<SB_Product_Type_Used_Web_Log> SB_Product_Type_Used_Web_Log { get; set; }
        public virtual DbSet<SB_Product_Web_Log> SB_Product_Web_Log { get; set; }
        public virtual DbSet<SB_Progroup_Web_Log> SB_Progroup_Web_Log { get; set; }
        public virtual DbSet<SB_Promodel_Web_Log> SB_Promodel_Web_Log { get; set; }
        public virtual DbSet<SB_Proprice_Log_Web_Log> SB_Proprice_Log_Web_Log { get; set; }
        public virtual DbSet<SB_proprice_Web_Log> SB_proprice_Web_Log { get; set; }
        public virtual DbSet<SB_ProSize_Web_Log> SB_ProSize_Web_Log { get; set; }
        public virtual DbSet<SB_Prov_Bak> SB_Prov_Bak { get; set; }
        public virtual DbSet<SB_Prov_Bak_Amphur> SB_Prov_Bak_Amphur { get; set; }
        public virtual DbSet<SB_Prov_Bak_Tambol> SB_Prov_Bak_Tambol { get; set; }
        public virtual DbSet<SB_Prov_Zone> SB_Prov_Zone { get; set; }
        public virtual DbSet<SB_Question_Choice_Web_Log> SB_Question_Choice_Web_Log { get; set; }
        public virtual DbSet<SB_Question_Detail_Web_Log> SB_Question_Detail_Web_Log { get; set; }
        public virtual DbSet<SB_Question_Head_Web_Log> SB_Question_Head_Web_Log { get; set; }
        public virtual DbSet<SB_SeeCar> SB_SeeCar { get; set; }
        public virtual DbSet<SB_statuscar_Web_Log> SB_statuscar_Web_Log { get; set; }
        public virtual DbSet<SB_Svat_Web_Log> SB_Svat_Web_Log { get; set; }
        public virtual DbSet<SB_System> SB_System { get; set; }
        public virtual DbSet<SB_System_Web_Log> SB_System_Web_Log { get; set; }
        public virtual DbSet<SB_Tax_Condition_Web_Log> SB_Tax_Condition_Web_Log { get; set; }
        public virtual DbSet<SB_Tax_Income_Rate_Web_Log> SB_Tax_Income_Rate_Web_Log { get; set; }
        public virtual DbSet<SB_Tax_Income_Web_Log> SB_Tax_Income_Web_Log { get; set; }
        public virtual DbSet<SB_Tax_Money_Web_Log> SB_Tax_Money_Web_Log { get; set; }
        public virtual DbSet<SB_Tax_Type_Web_Log> SB_Tax_Type_Web_Log { get; set; }
        public virtual DbSet<SB_TextReport_Web_Log> SB_TextReport_Web_Log { get; set; }
        public virtual DbSet<SB_UnitName_Web_Log> SB_UnitName_Web_Log { get; set; }
        public virtual DbSet<SB_Vendor_Temp_Delete> SB_Vendor_Temp_Delete { get; set; }
        public virtual DbSet<SB_Vendor_Web_Log> SB_Vendor_Web_Log { get; set; }
        public virtual DbSet<SB_Vote_Detail_Web_Log> SB_Vote_Detail_Web_Log { get; set; }
        public virtual DbSet<SB_Vote_Web_Log> SB_Vote_Web_Log { get; set; }
        public virtual DbSet<SBHRUser_Web_Log> SBHRUser_Web_Log { get; set; }
        public virtual DbSet<SBQty> SBQties { get; set; }
        public virtual DbSet<sbqty_change> sbqty_change { get; set; }
        public virtual DbSet<SBQty0000> SBQty0000 { get; set; }
        public virtual DbSet<SBQtyInv> SBQtyInvs { get; set; }
        public virtual DbSet<SBSale_Head> SBSale_Head { get; set; }
        public virtual DbSet<SBSale_Head_Prn> SBSale_Head_Prn { get; set; }
        public virtual DbSet<SBSale_Temp> SBSale_Temp { get; set; }
        public virtual DbSet<SBWorkf> SBWorkfs { get; set; }
        public virtual DbSet<SBWorkf_Detail> SBWorkf_Detail { get; set; }
        public virtual DbSet<ST_AVG_PRO_STOCK> ST_AVG_PRO_STOCK { get; set; }
        public virtual DbSet<ST_AVG_PRO_STOCK_CAL> ST_AVG_PRO_STOCK_CAL { get; set; }
        public virtual DbSet<ST_BAPDetail> ST_BAPDetail { get; set; }
        public virtual DbSet<ST_BAPHeader> ST_BAPHeader { get; set; }
        public virtual DbSet<ST_BAPTemp> ST_BAPTemp { get; set; }
        public virtual DbSet<ST_CarClean> ST_CarClean { get; set; }
        public virtual DbSet<ST_CarClean_Startup> ST_CarClean_Startup { get; set; }
        public virtual DbSet<ST_CarClean_Temp> ST_CarClean_Temp { get; set; }
        public virtual DbSet<ST_CarGlass> ST_CarGlass { get; set; }
        public virtual DbSet<ST_CarGlass_Startup> ST_CarGlass_Startup { get; set; }
        public virtual DbSet<ST_CarGlass_Temp> ST_CarGlass_Temp { get; set; }
        public virtual DbSet<ST_CommDetail> ST_CommDetail { get; set; }
        public virtual DbSet<ST_CommDetail_Master> ST_CommDetail_Master { get; set; }
        public virtual DbSet<ST_CommDetail_Temp> ST_CommDetail_Temp { get; set; }
        public virtual DbSet<ST_CommHeader> ST_CommHeader { get; set; }
        public virtual DbSet<ST_CommHeader_Temp> ST_CommHeader_Temp { get; set; }
        public virtual DbSet<ST_CommVariable_EmpRate> ST_CommVariable_EmpRate { get; set; }
        public virtual DbSet<ST_CommVariable_EmpRate_Master> ST_CommVariable_EmpRate_Master { get; set; }
        public virtual DbSet<ST_CommVariable_EmpRate_Temp> ST_CommVariable_EmpRate_Temp { get; set; }
        public virtual DbSet<ST_CommVariable_Fixed> ST_CommVariable_Fixed { get; set; }
        public virtual DbSet<ST_CommVariable_Fixed_JobDetail> ST_CommVariable_Fixed_JobDetail { get; set; }
        public virtual DbSet<ST_CommVariable_Fixed_JobDetail_Temp> ST_CommVariable_Fixed_JobDetail_Temp { get; set; }
        public virtual DbSet<ST_CommVariable_Fixed_Master> ST_CommVariable_Fixed_Master { get; set; }
        public virtual DbSet<ST_CommVariable_Fixed_Temp> ST_CommVariable_Fixed_Temp { get; set; }
        public virtual DbSet<ST_CommVariable_NoComm> ST_CommVariable_NoComm { get; set; }
        public virtual DbSet<ST_CommVariable_NoComm_JobDetail> ST_CommVariable_NoComm_JobDetail { get; set; }
        public virtual DbSet<ST_CommVariable_NoComm_JobDetail_Temp> ST_CommVariable_NoComm_JobDetail_Temp { get; set; }
        public virtual DbSet<ST_CommVariable_NoComm_Master> ST_CommVariable_NoComm_Master { get; set; }
        public virtual DbSet<ST_CommVariable_NoComm_Temp> ST_CommVariable_NoComm_Temp { get; set; }
        public virtual DbSet<ST_CommVariable_OnProfit> ST_CommVariable_OnProfit { get; set; }
        public virtual DbSet<ST_CommVariable_OnProfit_JobDetail> ST_CommVariable_OnProfit_JobDetail { get; set; }
        public virtual DbSet<ST_CommVariable_OnProfit_JobDetail_Temp> ST_CommVariable_OnProfit_JobDetail_Temp { get; set; }
        public virtual DbSet<ST_CommVariable_OnProfit_Master> ST_CommVariable_OnProfit_Master { get; set; }
        public virtual DbSet<ST_CommVariable_OnProfit_Temp> ST_CommVariable_OnProfit_Temp { get; set; }
        public virtual DbSet<ST_CommVariable_SaleAmt> ST_CommVariable_SaleAmt { get; set; }
        public virtual DbSet<ST_CommVariable_SaleAmt_JobDetail> ST_CommVariable_SaleAmt_JobDetail { get; set; }
        public virtual DbSet<ST_CommVariable_SaleAmt_JobDetail_Temp> ST_CommVariable_SaleAmt_JobDetail_Temp { get; set; }
        public virtual DbSet<ST_CommVariable_SaleAmt_Master> ST_CommVariable_SaleAmt_Master { get; set; }
        public virtual DbSet<ST_CommVariable_SaleAmt_Temp> ST_CommVariable_SaleAmt_Temp { get; set; }
        public virtual DbSet<ST_CST_Create> ST_CST_Create { get; set; }
        public virtual DbSet<ST_CST_Create_Cancel> ST_CST_Create_Cancel { get; set; }
        public virtual DbSet<ST_DayEnd_LOG> ST_DayEnd_LOG { get; set; }
        public virtual DbSet<ST_DSTDetail> ST_DSTDetail { get; set; }
        public virtual DbSet<ST_DSTHeader> ST_DSTHeader { get; set; }
        public virtual DbSet<ST_DSTTEMP> ST_DSTTEMP { get; set; }
        public virtual DbSet<ST_Header_Update> ST_Header_Update { get; set; }
        public virtual DbSet<ST_Lineno_Update> ST_Lineno_Update { get; set; }
        public virtual DbSet<ST_Movement_Export> ST_Movement_Export { get; set; }
        public virtual DbSet<ST_Movement_NO_ICT> ST_Movement_NO_ICT { get; set; }
        public virtual DbSet<ST_Po_Log_Web_Log> ST_Po_Log_Web_Log { get; set; }
        public virtual DbSet<ST_Podetail_Web_Log> ST_Podetail_Web_Log { get; set; }
        public virtual DbSet<ST_Poheader_Web_Log> ST_Poheader_Web_Log { get; set; }
        public virtual DbSet<ST_Proprice_Update> ST_Proprice_Update { get; set; }
        public virtual DbSet<ST_Rdisc_Head_Web_Log> ST_Rdisc_Head_Web_Log { get; set; }
        public virtual DbSet<ST_SERVICES_CHECK> ST_SERVICES_CHECK { get; set; }
        public virtual DbSet<ST_SSTDetail> ST_SSTDetail { get; set; }
        public virtual DbSet<ST_SSTHeader> ST_SSTHeader { get; set; }
        public virtual DbSet<ST_SSTTemp> ST_SSTTemp { get; set; }
        public virtual DbSet<ST_TRN_Log_Web_Log> ST_TRN_Log_Web_Log { get; set; }
        public virtual DbSet<ST_TRNDetail_Web_Log> ST_TRNDetail_Web_Log { get; set; }
        public virtual DbSet<ST_TRNHeader_Web_Log> ST_TRNHeader_Web_Log { get; set; }
        public virtual DbSet<TCS_ITEM> TCS_ITEM { get; set; }
        public virtual DbSet<TCS_location> TCS_location { get; set; }
        public virtual DbSet<vote_link_customer> vote_link_customer { get; set; }
        public virtual DbSet<ST_Transfer_Data_Log> ST_Transfer_Data_Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CS_cdHeader>()
                .Property(e => e.vate_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_cdHeader>()
                .Property(e => e.cd_payment)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_cdHeader>()
                .Property(e => e.doc_Close)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_cdHeader>()
                .Property(e => e.doc_Cancle)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_dcHeader>()
                .Property(e => e.cus_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_dcHeader>()
                .Property(e => e.doc_Close)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_dcHeader>()
                .Property(e => e.vate_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_dcHeader>()
                .Property(e => e.doc_Cancle)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_dcHeader>()
                .Property(e => e.NO_VAT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_dsHeader>()
                .Property(e => e.doc_Close)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_dsHeader>()
                .Property(e => e.doc_Cancle)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_dsHeader>()
                .HasMany(e => e.CS_dsDetail)
                .WithRequired(e => e.CS_dsHeader)
                .HasForeignKey(e => new { e.branch_no, e.doc_no })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CS_ProCodeNew>()
                .Property(e => e.pro_code)
                .IsUnicode(false);

            modelBuilder.Entity<CS_ProCodeNew>()
                .Property(e => e.pro_ven_code)
                .IsUnicode(false);

            modelBuilder.Entity<CS_ProCodeNew>()
                .Property(e => e.cStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_sdDetail>()
                .Property(e => e.line_No)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CS_sdDetail>()
                .Property(e => e.sn_ID_close)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_sdDetail>()
                .Property(e => e.sn_ID_cancle)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_sdDetail>()
                .Property(e => e.doc_no_run)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CS_sdHeader>()
                .Property(e => e.vate_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_sdHeader>()
                .Property(e => e.sd_payment)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_sdHeader>()
                .Property(e => e.doc_Close)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_sdHeader>()
                .Property(e => e.doc_Cancle)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.property)
                .IsUnicode(false);

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<MessageData>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MessageData>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<SB_ExtraDiscount>()
                .Property(e => e.ProgroupCode)
                .IsFixedLength();

            modelBuilder.Entity<SB_ExtraDiscount>()
                .Property(e => e.CustypeCode)
                .IsFixedLength();

            modelBuilder.Entity<SB_Product>()
                .Property(e => e.pro_ven_code)
                .IsUnicode(false);

            modelBuilder.Entity<SB_Product_Temp_Delete>()
                .Property(e => e.pro_ven_code)
                .IsUnicode(false);

            modelBuilder.Entity<SB_Progroup>()
                .Property(e => e.Default_CS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SB_Vendor>()
                .Property(e => e.sap_no)
                .IsUnicode(false);

            modelBuilder.Entity<ST_PayCard>()
                .Property(e => e.connect_type)
                .IsUnicode(false);

            modelBuilder.Entity<ST_PayCard>()
                .Property(e => e.credit_type)
                .IsUnicode(false);

            modelBuilder.Entity<CS_DocNo>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CS_DocNo>()
                .Property(e => e.cflag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_SN>()
                .Property(e => e.cflag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_tmpcdHeader>()
                .Property(e => e.vate_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_tmpcdHeader>()
                .Property(e => e.cd_payment)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_tmpcdHeader>()
                .Property(e => e.doc_Close)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_tmpcdHeader>()
                .Property(e => e.doc_Cancle)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS_tmpITEM>()
                .Property(e => e.doc_no_run)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.IDNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.MobileNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.MID)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.TID)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.ReponseCode)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.ReponseMSG)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.PointsAvailable)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.PointAccureToday)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.BirthDate)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.CardStatus)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.IntegrationKey)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.MemberStatus)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.PaymentType)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.Redeemedpoints)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.TotalAmount)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.Qantity)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.Discount)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.CouponCode)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.PINCode)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.TransectionID)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.PointsEarnedinTranction)
                .IsUnicode(false);

            modelBuilder.Entity<SB_BlueCard>()
                .Property(e => e.PointsEarnedToday)
                .IsUnicode(false);

            modelBuilder.Entity<SB_Product_Web_Log>()
                .Property(e => e.pro_ven_code)
                .IsUnicode(false);

            modelBuilder.Entity<SB_Progroup_Web_Log>()
                .Property(e => e.Default_CS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SBQty>()
                .Property(e => e.Discount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SBQty0000>()
                .Property(e => e.Funitprice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SBQty0000>()
                .Property(e => e.discount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SBQtyInv>()
                .Property(e => e.Funitprice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SBQtyInv>()
                .Property(e => e.discount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SBSale_Head_Prn>()
                .Property(e => e.Change_money)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ST_CommHeader>()
                .Property(e => e.approve_status)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_Export>()
                .Property(e => e.branch_no)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_Export>()
                .Property(e => e.doc_date)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_Export>()
                .Property(e => e.doc_no)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_Export>()
                .Property(e => e.doc_time)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_Export>()
                .Property(e => e.doc_code)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_Export>()
                .Property(e => e.cus_code)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_NO_ICT>()
                .Property(e => e.branch_no)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_NO_ICT>()
                .Property(e => e.doc_date)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_NO_ICT>()
                .Property(e => e.doc_no)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_NO_ICT>()
                .Property(e => e.doc_time)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_NO_ICT>()
                .Property(e => e.doc_code)
                .IsUnicode(false);

            modelBuilder.Entity<ST_Movement_NO_ICT>()
                .Property(e => e.cus_code)
                .IsUnicode(false);

            modelBuilder.Entity<TCS_ITEM>()
                .Property(e => e.pro_code)
                .IsUnicode(false);


        }
    }
}
