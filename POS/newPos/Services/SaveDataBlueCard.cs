using CentralService.Models;
using newPos.BlueCardService;
using newPos.Models;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace newPos.Services
{
    public class SaveDataBlueCard
    {
        private Entities _db;

        public SaveDataBlueCard(Entities conn)
        {
            _db = conn;
        }

        public void SaveVSmart_BatchDetail(VSmart_BatchDetail Model, bool FlagInsert)
        {
            try
            {
                var data = _db.VSmart_BatchDetail.FirstOrDefault(x => x.MID == Model.MID && x.TID == Model.TID && x.BatchID == Model.BatchID);
                if (FlagInsert && data == null)
                {
                    _db.VSmart_BatchDetail.Add(Model);
                }
                else
                {
                    // var data = _db.VSmart_BatchDetail.Find(Model);
                    if (data != null)
                    {
                        data.TotalLoyaltyPrice = Model.TotalLoyaltyPrice;
                        data.TotalLoyaltyPoint = Model.TotalLoyaltyPoint;
                        data.CloseStaffID = Model.CloseStaffID;
                        data.CloseDateTime = Model.CloseDateTime;
                        _db.Entry(data).State = EntityState.Modified;
                    }
                }

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }

        public void SaveVSmart_MaxStandID(VSmart_MaxStandID Model, bool FlagInsert)
        {
            try
            {
                var data = _db.VSmart_MaxStandID.OrderByDescending(o => o.MaxStandID).FirstOrDefault(x => x.MID == Model.MID && x.TID == Model.TID && x.BatchID == Model.BatchID);
                if (FlagInsert && Model != null)
                {
                    var incStand = new VSmart_MaxStandID
                    {
                        MID = data.MID,
                        TID = data.TID,
                        BatchID = data.BatchID,
                        MaxStandID = data.MaxStandID + 1
                    };
                    _db.VSmart_MaxStandID.Add(incStand);
                }
                else
                {
                    var inistand = new VSmart_MaxStandID
                    {
                        MID = Model.MID,
                        TID = Model.TID,
                        BatchID = Model.BatchID,
                        MaxStandID = 1
                    };
                    _db.VSmart_MaxStandID.Add(inistand);
                }

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }

        #region  RedeemPoints Set
        public void SaveVSmart_RedeemMaster(POSUI SendPosUI, POSUI ResponsePOSUI, int PosTransID)
        {
            try
            {
                var pos = _db.SB_Branch.FirstOrDefault();
                var RedeemMaster = new VSmart_RedeemMasterFront()
                {
                    POS_TransactionID = PosTransID,
                    POS_ComputerID = pos?.POS_ComputerID ?? 1,
                    POS_SessionID = SendPosUI.SystemData.Batch_ID,
                    POS_SessionComputerID = pos?.POS_ComputerID ?? 1,
                    MID = SendPosUI.SystemData.MID,
                    TID = SendPosUI.SystemData.TID,
                    Batch_ID = SendPosUI.SystemData.Batch_ID,
                    Stand_ID = SendPosUI.SystemData.Stand_ID,
                    //TRN_Point = Convert.ToDecimal(ResponsePOSUI.OrderData.PaymentData.PaymentItem[0].Qty),
                    TRN_Point = Convert.ToDecimal(ResponsePOSUI.OrderData.PaymentData.PaymentItem[0].ItemReturn.Qty_Used),
                    Card_No = ResponsePOSUI.CustomData.Card_No,
                    Phone_No = ResponsePOSUI.CustomData.Phone_No,
                    Trans_ID = Convert.ToInt64(ResponsePOSUI.OrderData.Tran_ID ?? "0"),
                    //POS_PaymentAmount = Convert.ToDecimal(SendPosUI.OrderData.PaymentData.PaymentItem[0].Price),
                    POS_PaymentAmount = Convert.ToDecimal(SendPosUI.OrderData.PaymentData.PaymentItem[0].ItemReturn.Price_Used),
                    InsertDateTime = DateTime.Now,
                    TransactionStatusID = Constants.TransactionStatusTypeID.Commit,
                    BlueCode = SendPosUI.CustomData.BlueCode,
                    Point_Balance = ResponsePOSUI.CustomData.Point_Balance ?? 0,
                    Redemption_ID = ResponsePOSUI.OrderData.Redemption_ID,
                    EarnPointByType = SendPosUI.OrderData.Earn_By_BIZ,
                    RedeemStatus = Constants.TransactionStatusTypeID.Commit,
                    RedeemID = 1,
                };
                _db.VSmart_RedeemMasterFront.Add(RedeemMaster);
                foreach (var item in SendPosUI.OrderData.OrderDetail.ToList())
                {

                    // -- Save RedeemDetailFront
                    InsertVSmart_RedeemDetailFront(RedeemMaster, item);


                }
                InsertVSmart_RedeemInfoFront(RedeemMaster, ResponsePOSUI.OrderData.PaymentData);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }

        }

        public void InsertVSmart_RedeemDetailFront(VSmart_RedeemMasterFront OrderMaster, OrderDetail item)
        {
            try
            {
                if (item.ProductData != null)
                {
                    foreach (var t in item.ProductData.ProductItem)
                    {
                        var redeemDetail = new VSmart_RedeemDetailFront()
                        {
                            POS_TransactionID = OrderMaster.POS_TransactionID,
                            POS_ComputerID = OrderMaster.POS_ComputerID,
                            Product_Code = t.Code,
                            Product_Point = Convert.ToDecimal(t.Price ?? 0),
                            Product_Quan = Convert.ToDecimal(t.Qty ?? 1)
                        };
                        _db.VSmart_RedeemDetailFront.Add(redeemDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }

        public void InsertVSmart_RedeemInfoFront(VSmart_RedeemMasterFront OrderMaster, PaymentData item)
        {
            try
            {
                var MasterData = _db.VSmart_RedeemPointPaymentSetting.FirstOrDefault();
                if (item.PaymentItem != null)
                {
                    for (int i = 0; i < item.PaymentItem.Length; i++)
                    {
                        var RedeemDetail = new VSmart_RedeemInfo()
                        {
                            TransactionID = OrderMaster.POS_TransactionID,
                            ComputerID = OrderMaster.POS_ComputerID,
                            TotalRedeemPoint = Convert.ToDecimal(item.PaymentItem[i].ItemReturn.Qty_Used),
                            PaymentAmount = Convert.ToDecimal(item.PaymentItem[i].ItemReturn.Price_Used),
                            VSmartProductCode = item.PaymentItem[i].Code,
                            RedeemPoint = MasterData?.RedeemPoint ?? 0,
                            PerPaymentAmount = MasterData?.PerPaymentAmount ?? 0,
                            RedeemNote = "",
                            RedeemID = MasterData?.RedeemID ?? 0,
                            RedeemStatus = Constants.TransactionStatusTypeID.Commit,
                        };
                        _db.VSmart_RedeemInfo.Add(RedeemDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }
        #endregion

        #region AccumulatePoints Set
        public void SaveVSmart_Order(POSUI SendPosUI, POSUI ResponsePOSUI, int PosTransID, string RefDocNo, bool FlagSend)
        {
            try
            {
                _db = new Entities();
                var Redeem = new VSmart_RedeemMasterFront();
                //if (ResponsePOSUI.OrderData != null) {
                //    Redeem = _db.VSmart_RedeemMasterFront.FirstOrDefault(x => x.Redemption_ID == ResponsePOSUI.OrderData.Redemption_ID);
                //}
                Redeem = _db.VSmart_RedeemMasterFront.FirstOrDefault(x => x.POS_TransactionID == PosTransID);

                var pos = _db.SB_Branch.FirstOrDefault();

                if (FlagSend == true)
                {
                    var OrderMaster = _db.VSmart_OrderMasterFront.FirstOrDefault(x => x.POS_TransactionID == PosTransID);
                    if (OrderMaster != null)
                    {
                        OrderMaster.Flag_Send = true;
                        OrderMaster.Net_Price = ResponsePOSUI.OrderData.NetGrandTotalPrice ?? 0;
                        OrderMaster.Trans_ID = Convert.ToInt64(ResponsePOSUI?.OrderData?.Tran_ID ?? "0");
                        OrderMaster.Point_Earn_Today = ResponsePOSUI.CustomData.Point_Earned_Today ?? 0;
                        OrderMaster.Return_Point = ResponsePOSUI.CustomData.Return_Point ?? 0;
                        OrderMaster.Customer_Name = ResponsePOSUI.CustomData.Name;
                        OrderMaster.Point_Balance = ResponsePOSUI.CustomData.Point_Balance ?? 0;
                        OrderMaster.PR_Message = ResponsePOSUI.SystemData.Description;
                        OrderMaster.TransactionStatusID = Constants.TransactionStatusTypeID.Commit;
                        OrderMaster.Day_Trn_Limit = ResponsePOSUI.CustomData.Day_TRN_Limit;
                        OrderMaster.Month_Trn_Limit = ResponsePOSUI.CustomData.Month_TRN_Limit;
                        OrderMaster.Year_Trn_Limit = ResponsePOSUI.CustomData.Year_TRN_Limit;
                        OrderMaster.U_Limit = ResponsePOSUI.CustomData.U_Limit;

                    }
                    var VSmart_OrderDetailFront = _db.VSmart_OrderDetailFront.Where(x => x.POS_TransactionID == PosTransID).ToList();
                    VSmart_OrderDetailFront.ForEach(x => x.Flag_Send = true);
                    var VSmart_OrderPaymentDataFront = _db.VSmart_OrderPaymentDataFront.Where(x => x.POS_TransactionID == PosTransID).ToList();
                    VSmart_OrderPaymentDataFront.ForEach(x => x.Flag_Send = true);
                    var VSmart_OrderDiscountDataFront = _db.VSmart_OrderDiscountDataFront.Where(x => x.POS_TransactionID == PosTransID).ToList();
                    VSmart_OrderDiscountDataFront.ForEach(x => x.Flag_Send = true);

                    _db.SaveChanges();
                }
                else
                {
                    // Order Master
                    var OrderMaster = new VSmart_OrderMasterFront()
                    {
                        Flag_Send = false,
                        POS_TransactionID = PosTransID, //
                        POS_ComputerID = pos?.POS_ComputerID ?? 1, // สอบถาม ComputerID
                        POS_SessionID = SendPosUI.SystemData.Batch_ID, // ใช่ batch id แทน เบื่องต้น
                        POS_SessionComputerID = pos?.POS_ComputerID ?? 1,
                        MID = SendPosUI.SystemData.MID,
                        TID = SendPosUI.SystemData.TID,
                        Batch_ID = SendPosUI.SystemData.Batch_ID,
                        Stand_ID = SendPosUI.SystemData.Stand_ID,
                        TRN_Price = SendPosUI.OrderData.GrandTotalPrice ?? 0,
                        TRN_Point = Redeem?.TRN_Point ?? 0,
                        Redeem_Trans_ID = 0,
                        Redeem_Price = Redeem?.POS_PaymentAmount ?? 0,
                        Payment_Type = "",// --- สอบถามเพิ่ม กรณีมีการชำระเป็น Partial -- Trander Code
                        Card_No = SendPosUI.CustomData.Card_No,
                        Phone_No = SendPosUI.CustomData.Phone_No,
                        InsertDateTime = DateTime.Now,
                        TransactionStatusID = Constants.TransactionStatusTypeID.Reversal,
                        Company_Type = "",
                        Business_Type = "",
                        Slip_Message_1 = "",
                        Slip_Message_2 = "",
                        Slip_Message_3 = "",
                        IsPTTCoBrand = 0,
                        BlueCode = SendPosUI.CustomData.BlueCode,
                        Net_PriceBeforeDiscount = SendPosUI.OrderData.GrandTotalPrice ?? 0,
                        Invoice_ID = SendPosUI.OrderData.Invoice_ID,
                        SaleModeName = "",
                        Redemption_ID = Redeem?.Redemption_ID,
                        EarnPointByType = SendPosUI.OrderData.Earn_By_BIZ,
                        Ref_DocNo = RefDocNo
                    };
                    _db.VSmart_OrderMasterFront.Add(OrderMaster);


                    foreach (var item in SendPosUI.OrderData.OrderDetail.ToList())
                    {

                        // -- Save Order Detail
                        InsertVSmart_OrderDetailFront(OrderMaster, item);
                        // -- Save Discount
                        InsertVSmart_OrderDiscountDataFront(OrderMaster, item);

                    }
                    // ----------- Save Payment 
                    InsertVSmart_OrderPaymentDataFront(OrderMaster, SendPosUI.OrderData.PaymentData);
                    _db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }

        public void InsertVSmart_OrderDetailFront(VSmart_OrderMasterFront OrderMaster, OrderDetail item)
        {
            try
            {
                if (item.ProductData != null)
                {
                    for (int i = 0; i < item.ProductData.ProductItem.Length; i++)
                    {
                        var OrderDetail = new VSmart_OrderDetailFront()
                        {
                            Flag_Send = false,
                            POS_TransactionID = OrderMaster.POS_TransactionID,
                            POS_ComputerID = OrderMaster.POS_ComputerID,
                            POS_OrderDetailID = item.ProductData.ProductItem[i].Seq ?? 1,
                            ProductID = Convert.ToInt32(item.ProductData.ProductItem[i].ID ?? "0"),
                            Product_Code = item.ProductData.ProductItem[i].Code,
                            Product_Price = Convert.ToDecimal(item.ProductData.ProductItem[i].Price ?? 0),
                            Product_Quan = Convert.ToDecimal(item.ProductData.ProductItem[i].Qty ?? 1)
                        };
                        _db.VSmart_OrderDetailFront.Add(OrderDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }

        public void InsertVSmart_OrderDiscountDataFront(VSmart_OrderMasterFront OrderMaster, OrderDetail item)
        {
            try
            {
                if (item.DiscountData != null)
                {
                    for (int i = 0; i < item.DiscountData.DiscountItem.Length; i++)
                    {
                        var Discount = new VSmart_OrderDiscountDataFront()
                        {
                            Flag_Send = false,
                            POS_TransactionID = OrderMaster.POS_TransactionID,
                            POS_ComputerID = OrderMaster.POS_ComputerID,
                            DiscountID = item.DiscountData.DiscountItem[i].Seq ?? 1,
                            Code = item.DiscountData.DiscountItem[i].Code,
                            Qty = Convert.ToDecimal(item.DiscountData.DiscountItem[i].Qty ?? 1),
                            Price = item.DiscountData.DiscountItem[i].Price ?? 0,
                            TenderTypeID = Constants.TenderTypeID.OtherDiscount,
                            Qty_Used = 0,
                            Qty_Return = 0,
                            Price_Used = 0,
                            Price_Balance = 0,
                            Price_Return = 0,
                            Other = "",
                        };

                        _db.VSmart_OrderDiscountDataFront.Add(Discount);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }

        public void InsertVSmart_OrderPaymentDataFront(VSmart_OrderMasterFront OrderMaster, PaymentData item)
        {
            try
            {
                if (item.PaymentItem != null)
                {
                    for (int i = 0; i < item.PaymentItem.Length; i++)
                    {
                        var OrderDetail = new VSmart_OrderPaymentDataFront()
                        {
                            Flag_Send = false,
                            POS_TransactionID = OrderMaster.POS_TransactionID,
                            POS_ComputerID = OrderMaster.POS_ComputerID,
                            PaymentID = i + 1,
                            Code = item.PaymentItem[i].Code,
                            Qty = Convert.ToDecimal(item.PaymentItem[i].Qty ?? 1),
                            Price = Convert.ToDecimal(item.PaymentItem[i].Price ?? 0),
                            TenderTypeID = Convert.ToByte(item.PaymentItem[i].TenderType),
                            Qty_Used = 0,
                            Qty_Balance = 0,
                            Qty_Return = 0,
                            Price_Used = 0,
                            Price_Balance = 0,
                            Price_Return = 0,
                            Other = "",
                        };
                        _db.VSmart_OrderPaymentDataFront.Add(OrderDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }
        #endregion

        public void InsertLogVSmart(string text, string _CallType, int? _TransationTid = null, string ref_docno = "")
        {
            var vsLog = new VSmart_DBLog
            {
                LogMessage = text,
                LogTime = DateTime.Now,
                CallType = _CallType,
                POS_TransactionID = _TransationTid,
                Doc_No = ref_docno
            };

            if (ref_docno != "") vsLog.Doc_No = ref_docno;

            _db.VSmart_DBLog.Add(vsLog);

            _db.SaveChanges();
        }
    }
}