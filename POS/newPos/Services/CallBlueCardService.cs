using CentralService.Models;
using newPos.BlueCardService;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using newPos.Models;
using Unity.Policy.Mapping;


namespace newPos.Services
{
    public class CallBlueCardService
    {
        private Entities _db;
        // private string _MID = "055003003987302";
        //   private string _Card_No = "5555000085117181";
        private SaveDataBlueCard _blueCardService;
        public CallBlueCardService(Entities conn, SaveDataBlueCard blueCardService)
        {
            _db = conn;
            _blueCardService = blueCardService;
        }

        private POSUI CallBlueCardGetApi(POSUI posModel, int? TransPosID = null, string ref_docno = "")
        {
            try
            {

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(POSUI));
                MemoryStream mem = new MemoryStream();
                serializer.WriteObject(mem, posModel);
                string jsonString = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                _blueCardService.InsertLogVSmart(jsonString, Constants.CallTypeBlueCard.Send, TransPosID, ref_docno);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;

                int round = 1;
                // Endpoint   +"/execute/" + round;
                String url = _db.SB_System.FirstOrDefault()?.bluecard_url;
                if (string.IsNullOrEmpty(url))
                {
                    throw new ArgumentException("กรุณาตรวจสอบ URL BlueCard Server", url);
                }

                url += "/execute/" + round;
                #region Backup
                //String url = "http://ptt-lybpgw-t01.ptt.corp/BluePointGateway/Service/BlueServiceRestFulApp.svc/execute/" + round;
                #endregion

                // Call BluePointGateway Service (RestFul)
                var retJsonString = webClient.UploadString(url, "POST", jsonString);

                // Deserialize to POSUI
                MemoryStream memoryStream = new
                     MemoryStream(Encoding.UTF8.GetBytes(retJsonString ?? ""));
                POSUI retPOS = (POSUI)serializer.ReadObject(memoryStream);


                _blueCardService.InsertLogVSmart(retJsonString, Constants.CallTypeBlueCard.Response, TransPosID, ref_docno);


                return retPOS;
            }
            catch (Exception ex)
            {
                try
                {
                    _blueCardService.InsertLogVSmart(ex.ToString(), Constants.CallTypeBlueCard.Response, TransPosID, ref_docno);
                }
                catch
                {
                    LogManager.WriteLog(ex.ToString());
                }

                throw ex;
            }
        }

        #region BlueCard Function
        internal SB_BlueCardRedeemSetting GetRedeemSetting()
        {
            return _db.SB_BlueCardRedeemSetting.FirstOrDefault();
        }
        public string GetCardNo(string phoneNumber)
        {
            POSUI posModel = new POSUI
            {
                AddressData = new AddressData()
            };
            posModel.AddressData.Method = "GetCardNoByPhone";
            posModel.CustomData = new CustomerData() { Phone_No = phoneNumber };

            var retPOS = CallBlueCardGetApi(posModel);

            return retPOS.CustomData.Card_No;
        }
        public string GetCountTransationNotSuccess(int UserId)
        {
            // var sysData = GetDataSystemBlueCard(UserId);

            var CountTrans = _db.VSmart_OrderMasterFront.Where(x => x.Flag_Send != true).Count();
            return CountTrans.ToString();
        }
        public string TestSendData()
        {
            var branchModel = _db.SB_Branch.First();
            if (branchModel.connect_vpn == "true")
            {
                var retPOS = new POSUI();
                retPOS = GetLastBatchIDPOS(branchModel.MID, branchModel.TID);
                return retPOS.SystemData.Description;
            }
            else
            {
                return "";
            }
        }
        private POSUI GetTestData()
        {
            return new POSUI
            {
                AddressData = new AddressData { Method = "InsertTransPOS", MethodParam = MethodParam.IsOrder },
                CustomData = new CustomerData { Card_No = "5555880024335963" },
                SystemData = new SystemData
                {
                    MID = "055003003987302",
                    TID = "00000001",
                    Batch_ID = 30,
                    Stand_ID = 4,
                    Order_DateTime = DateTime.Now,
                    Employee_ID = "1"
                },
                OrderData = new OrderData
                {
                    GrandTotalPrice = 260,
                    //  Invoice_ID =  "AEW0000404",
                    SaleMode = SaleMode.TakeAway,
                    PaymentData = new PaymentData
                    {
                        PaymentItem = new List<PaymentItem>()
                        {
                            new PaymentItem { TenderCode = "302020",TenderType = TenderType.Cash , Price = 40 } // Cash
			// ** ถ้ามี Payment ด้วยชนิดอื่น ก็ เพิ่ม PaymentItem แล้วระบุ TenderCode นั้นๆ มา
                        }.ToArray()
                    },
                    OrderDetail = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            TotalPrice = 40,
                            ProductData = new ProductData
                            {
                             ProductItem = new List<ProductItem>()
                                {
                                    new ProductItem { Seq = 1, ID= "8510955", Code="0202005", Price = 40, ItemType = ProductItemType.Sale, Qty = 1 },

                                }.ToArray()
                            }
                        }
                    }.ToArray()
                }
            };
        }
        private POSUI GetTestData2()
        {
            return new POSUI
            {
                AddressData = new AddressData
                {
                    Method = "InsertTransPOS",
                    MethodParam = MethodParam.IsRedemption
                },
                CustomData = new CustomerData
                {
                    BlueCode = "1234"
                },
                SystemData = new SystemData { MID = "055000000069501", TID = "32134455", Batch_ID = 123, Stand_ID = 1234, Order_DateTime = DateTime.Now, Employee_ID = "1" },
                OrderData = new OrderData
                {
                    GrandTotalPrice = 260,
                    SaleMode = SaleMode.TakeAway,
                    PaymentData = new PaymentData
                    {
                        PaymentItem = new List<PaymentItem>()
                        {
                            new PaymentItem { TenderCode = "302090", Code = "5555880000000837", Qty = 500, Price = 100 } //BlueCard			                        
			  }.ToArray()
                    },
                    OrderDetail = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            TotalPrice = 260,
                            ProductData = new ProductData
                            {
                                ProductItem = new List<ProductItem>()
                                {
                                    new ProductItem { Seq = 1, ID= "8510955", Code="0202005", Price = 40, ItemType = ProductItemType.Sale, Qty = 1 },
                                    new ProductItem { Seq = 2, ID= "8510783", Code="0302001", Price = 50, ItemType = ProductItemType.Sale, Qty = 1 },
                                    new ProductItem { Seq = 3, ID= "8510784", Code="0402001", Price = 45, ItemType = ProductItemType.Sale, Qty = 1 },
                                    new ProductItem { Seq = 4, ID= "8510184", Code="402717", Price = 75, ItemType = ProductItemType.Sale, Qty = 1 },
                                    new ProductItem { Seq = 5, ID= "8510099", Code="TC-970101", Price = 15, ItemType = ProductItemType.Sale, Qty = 1 },
                                    new ProductItem { Seq = 5, ID= "8510109", Code="qpojsjfs", Price = 35, ItemType = ProductItemType.Sale, Qty = 1 }
                                }.ToArray()
                            }
                        }
                    }.ToArray()
                }
            };
        }

        public POSUI GetPointBalance(string phoneNumber, string cardNo)
        {

            var posModel = GetCardPoints(phoneNumber, cardNo);
            var cardPoint = CallBlueCardGetApi(posModel);

            return cardPoint;
        }
        private POSUI GetCardPoints(string phoneNumber, string cardNo)
        {
            var branchModel = _db.SB_Branch.First();

            return new POSUI
            {
                AddressData = new AddressData
                {
                    Method = "GetCardPoint"
                },
                CustomData = new CustomerData
                {
                    Card_No = cardNo,
                    Phone_No = phoneNumber
                },
                SystemData = new SystemData { MID = branchModel.MID },
            };
        }
        public POSUI CheckDupCitizenID(string _Citizen_ID)
        {
            POSUI posModel = new POSUI();
            posModel.AddressData = new AddressData
            {
                Method = "CheckDupCitizenID"
            };
            posModel.CustomData = new CustomerData
            {
                Citizen_ID = _Citizen_ID
            };
            var retPOS = CallBlueCardGetApi(posModel);
            return retPOS;
        }
        public POSUI CheckDupPhoneNo(string _PhoneNo, string _Citizen_ID)
        {
            var branchModel = _db.SB_Branch.First();
            var cardNo = GetCardNo(_PhoneNo);
            POSUI posModel = new POSUI
            {
                AddressData = new AddressData(),
                CustomData = new CustomerData
                {
                    Phone_No = _PhoneNo,
                    Citizen_ID = _Citizen_ID,
                },
            };
            posModel.AddressData.Method = "CheckDupPhoneNo";
            posModel.SystemData = new SystemData
            {
                MID = branchModel.MID
            };

            var retPOS = CallBlueCardGetApi(posModel);
            return retPOS;
        }
        public POSUI CheckDupCardNo(string _CardNo)
        {
            var branchModel = _db.SB_Branch.First();
            POSUI posModel = new POSUI
            {
                AddressData = new AddressData(),
                CustomData = new CustomerData
                {
                    Card_No = _CardNo,
                },
            };
            posModel.AddressData.Method = "GetCardPoint";
            posModel.SystemData = new SystemData
            {
                MID = branchModel.MID,
                TID = branchModel.TID
            };

            var retPOS = CallBlueCardGetApi(posModel);
            return retPOS;
        }
        public string CheckCardIsActivated(string cardnumber)
        {
            POSUI posModel = new POSUI
            {
                AddressData = new AddressData()
            };
            posModel.AddressData.Method = "CardIsActivated";
            posModel.CustomData = new CustomerData() { Card_No = cardnumber };

            var retPOS = CallBlueCardGetApi(posModel);

            return retPOS.SystemData.Description;
        }

        // เรียกข้อมูล Bathch ล่าสุด
        public POSUI GetLastBatchIDPOS(string _MID, string _TID)
        {


            POSUI posModel = new POSUI
            {
                AddressData = new AddressData()
            };
            posModel.AddressData.Method = "GetLastBatchIDPOS";
            posModel.SystemData = new SystemData
            {
                MID = _MID,
                TID = _TID
            };

            var retPOS = CallBlueCardGetApi(posModel);

            return retPOS;
        }
        private TenderType GetTenderType(string TenderCode)
        {
            var result = new TenderType();
            switch (TenderCode)
            {
                case Constants.PaymentType.Cash:
                    result = TenderType.Cash;
                    break;
                case Constants.PaymentType.BlueCard:
                    result = TenderType.Blue_Card;
                    break;
                case Constants.PaymentType.Creditcard:
                    result = TenderType.Credit_Card;
                    break;
                case Constants.PaymentType.OtherDiscount:
                    result = TenderType.OtherDiscount;
                    break;
                case Constants.PaymentType.Coupon:
                    result = TenderType.Coupon;
                    break;
                case Constants.PaymentType.OtherPayment:
                    result = TenderType.OtherDiscount;
                    break;
            }

            return result;
        }
        private string GetTenderCode(string PaymentType)
        {
            var result = "";
            switch (PaymentType)
            {
                case Constants.PaymentType.Cash:
                    result = Constants.TenderCode.Cash;
                    break;
                case Constants.PaymentType.BlueCard:
                    result = Constants.TenderCode.BlueCard;
                    break;
                case Constants.PaymentType.Creditcard:
                    result = Constants.TenderCode.Creditcard;
                    break;
                case Constants.PaymentType.OtherDiscount:
                    result = Constants.TenderCode.OtherDiscount;
                    break;
                case Constants.PaymentType.Coupon:
                    result = Constants.TenderCode.Coupon;
                    break;
                case Constants.PaymentType.OtherPayment:
                    result = Constants.TenderCode.OtherDiscount;
                    break;
            }

            return result;
        }
        public string ReSendOrderBlueCard()
        {
            try
            {
                string Result = "";
                var BatchId = _db.VSmart_BatchDetail.OrderByDescending(x => x.BatchID).FirstOrDefault()?.BatchID ?? 1;
                _db.VSmart_OrderMasterFront.Where(x => x.Flag_Send != true).ToList().ForEach(x =>
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(POSUI));
                    var SendJsonString = _db.VSmart_DBLog.FirstOrDefault(m => m.POS_TransactionID == x.POS_TransactionID && m.CallType == Constants.CallTypeBlueCard.Send)?.LogMessage;
                    if (SendJsonString != null)
                    {

                        MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(SendJsonString ?? ""));
                        POSUI SendPOS = (POSUI)serializer.ReadObject(memoryStream);
                        SendPOS.SystemData.Batch_ID = BatchId;
                        POSUI retPOS = CallBlueCardGetApi(SendPOS, x.POS_TransactionID);

                        if (retPOS != null && retPOS?.SystemData?.ReturnCode == "00")
                        {
                            _blueCardService.SaveVSmart_Order(SendPOS, retPOS, x.POS_TransactionID, x.Ref_DocNo, true);
                            var dbBlueCardModel = new SB_BlueCard
                            {
                                CardNumber = retPOS.OrderData.PaymentData.PaymentItem[0].Code,
                                PINCode = retPOS.CustomData.BlueCode,
                                TID = retPOS.SystemData.TID,
                                MID = retPOS.SystemData.MID,
                                PointsAvailable = retPOS.CustomData.Point_Balance, //Qty_Balance = 5000,  // Point Balance
                                PointsEarnedToday = retPOS.CustomData.Point_Earned_Today.ToString(),
                                Redeemedpoints = retPOS.OrderData.PaymentData.PaymentItem[0].Qty.ToString(), //Qty_Used = 500, 	    // TRN Point
                                Discount = retPOS.OrderData.PaymentData.PaymentItem[0].Price.ToString(), //Price_Used = 100,
                                DocNo = x.Ref_DocNo,
                                MemberName = retPOS.CustomData.Name,
                                Redemption_ID = retPOS.OrderData.Redemption_ID, //Redemption_ID = "123xfxjyefjcy11234"
                                ReponseCode = retPOS.SystemData.ReturnCode,
                                ReponseMSG = retPOS.SlipAdData.SlipAdInfo.Any() ? retPOS.SlipAdData.SlipAdInfo[0].SlipAd[0].Text : ""
                            };

                            _db.SB_BlueCard.Add(dbBlueCardModel);
                            _db.SaveChanges();
                        }
                    }

                });


                return Result;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                return "ไม่สามารถเชื่อมต่อ BlueCard ได้";
            }
        }
        public string GetDocNo_By_Refdocno(string refDocno)
        {
            return _db.ST_Arheader.FirstOrDefault(x => x.ref_docno == refDocno)?.doc_no;
        }
        #endregion

        public POSUI PostRegisterBlueCard(RegisterBlueCardModel model)
        {
            POSUI posModel = new POSUI
            {
                AddressData = new AddressData()
            };
            posModel.AddressData.Method = "CardActivate";

            posModel.CustomData = new CustomerData
            {
                Citizen_ID = model.ThaiIDCard,
                Phone_No = model.MoblieNumber,
                Card_No = model.CardNumber
            };
            posModel.SystemData = new SystemData
            {
                MID = model.MID,
                TID = model.TID,
            };

            var retPOS = CallBlueCardGetApi(posModel);

            return retPOS;
        }
        public string OpenBatchBlueCard(int userId, decimal MoneyDefault)
        {
            int iniBatch = 0;
            try
            {
                var resultMessage = ""; string _mID = "", _tID = "";
                var branchModel = _db.SB_Branch.First();
                var _olddayStart = _db.ST_DayStart.OrderByDescending(x => x.run_id).FirstOrDefault();

                try
                {
                    if (branchModel.connect_vpn == "true")
                    {
                        var retPOS = new POSUI();
                        retPOS = GetLastBatchIDPOS(branchModel.MID, branchModel.TID);
                        if (_olddayStart != null)
                        {
                            if (retPOS.SystemData.Batch_ID <= _olddayStart.blue_card_batch_id)
                                iniBatch = ((_olddayStart.blue_card_batch_id ?? 0) + 1);
                        }
                        else
                        {
                            iniBatch = (retPOS.SystemData.Batch_ID + 1);
                        }
                        //var iniBatch = (retPOS.SystemData.Batch_ID + 1);
                        _mID = retPOS.SystemData.MID;
                        _tID = retPOS.SystemData.TID;
                    }
                    else
                    {
                        _mID = branchModel.MID ?? "";
                        _tID = branchModel.TID ?? "";
                        if (_olddayStart != null)
                        {
                            iniBatch = ((_olddayStart.blue_card_batch_id ?? 0) + 1);
                        }
                        else
                        {
                            iniBatch = 1;
                        }
                    }
                    _blueCardService.SaveVSmart_BatchDetail(new VSmart_BatchDetail()
                    {
                        MID = _mID,
                        TID = _tID,
                        BatchID = iniBatch,
                        ShopID = branchModel.doc_no_run,
                        OpenDateTime = DateTime.Now,
                        OpenStaffID = userId,
                        UpdateDate = DateTime.UtcNow
                    }, true);
                    // Save data in ST_DayStart
                    var DayStart = new ST_DayStart()
                    {
                        computer_id = branchModel.POS_ComputerID,
                        day_start = DateTime.Now,
                        money_default = MoneyDefault,
                        staff_id = userId,
                        blue_card_batch_id = iniBatch


                    };
                    _db.ST_DayStart.Add(DayStart);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    resultMessage = "ไม่สามารถเชื่อมต่อ VPN BlueCard ได้";
                }


                return resultMessage;

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }
        public string VerifyDayEndPOS(int userId)
        {
            string desc = "";
            try
            {
                var branchModel = _db.SB_Branch.First();
                var sysData = GetDataSystemBlueCard(userId, "");
                var VsmartData = _db.VSmart_OrderMasterFront.Where(x => x.MID == sysData.MID && x.TID == sysData.TID && x.Batch_ID == sysData.BatchID).ToList();
                var VsmartRedeem = _db.VSmart_RedeemMasterFront.Where(x => x.MID == sysData.MID && x.TID == sysData.TID && x.Batch_ID == sysData.BatchID).ToList();
                POSUI posModel = new POSUI
                {
                    AddressData = new AddressData()
                };
                posModel.AddressData.Method = "VerifyDayEndPOS";
                posModel.SystemData = new SystemData
                {
                    MID = sysData.MID,
                    TID = sysData.TID,
                    Batch_ID = sysData.BatchID
                };
                posModel.Datas = new Datas
                {
                    Data01 = (VsmartData.Sum(x => x.Net_PriceBeforeDiscount)).ToString(),//ผลรวมของยอดขาย
                    Data02 = (VsmartRedeem.Sum(x => x.TRN_Point)).ToString()//ผลรวมของแต้มที่ใช้ไป

                };
                if (branchModel.connect_vpn == "true")
                {
                    var retPOS = CallBlueCardGetApi(posModel);

                    if (retPOS.SystemData.ReturnCode == "00")
                    {

                        _blueCardService.SaveVSmart_BatchDetail(new VSmart_BatchDetail()
                        {
                            MID = sysData.MID,
                            TID = sysData.TID,
                            BatchID = sysData.BatchID,
                            ShopID = sysData.ShopID,
                            CloseDateTime = DateTime.Now,
                            CloseStaffID = userId,
                            UpdateDate = DateTime.UtcNow,
                            TotalLoyaltyPrice = Convert.ToDecimal(posModel?.Datas.Data01 ?? "0"),
                            TotalLoyaltyPoint = Convert.ToDecimal(posModel?.Datas.Data02 ?? "0")
                        }, false);

                        var UpdateVSmartDB = _db.Database.SqlQuery<object>("SP_UpdateVSmartCloseBatchDayEnd").ToList();
                        desc = retPOS.SystemData.Description;
                    }
                }
                else
                {
                    _blueCardService.SaveVSmart_BatchDetail(new VSmart_BatchDetail()
                    {
                        MID = sysData.MID,
                        TID = sysData.TID,
                        BatchID = sysData.BatchID,
                        ShopID = sysData.ShopID,
                        CloseDateTime = DateTime.Now,
                        CloseStaffID = userId,
                        UpdateDate = DateTime.UtcNow,
                        TotalLoyaltyPrice = Convert.ToDecimal(posModel?.Datas.Data01 ?? "0"),
                        TotalLoyaltyPoint = Convert.ToDecimal(posModel?.Datas.Data02 ?? "0")
                    }, false);
                }

                return desc;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }
        public string TrytoOpenNewBatch(int userId)
        {
            int iniBatch = 0;
            try
            {
                var resultMessage = ""; string _mID = "", _tID = "";
                var branchModel = _db.SB_Branch.First();
                var data = _db.ST_DayStart.OrderByDescending(x => x.run_id).FirstOrDefault();

                try
                {
                    if (branchModel.connect_vpn == "true")
                    {
                        var retPOS = new POSUI();
                        retPOS = GetLastBatchIDPOS(branchModel.MID, branchModel.TID);
                        var checkDate = data?.day_start != null ? (data.day_start ?? DateTime.Now).ToString("dd/MM/yyyy") : "";
                        if (data != null && checkDate == DateTime.Now.ToString("dd/MM/yyyy"))
                        {
                            if (data != null)
                            {
                                if (retPOS.SystemData.Batch_ID <= data.blue_card_batch_id)
                                    iniBatch = ((data.blue_card_batch_id ?? 0) + 1);
                            }
                            else
                            {
                                iniBatch = (retPOS.SystemData.Batch_ID + 1);
                            }


                        }
                    }
                    else
                    {
                        _mID = branchModel.MID ?? "";
                        _tID = branchModel.TID ?? "";
                        iniBatch = ((data.blue_card_batch_id ?? 0) + 1);
                    }
                    _blueCardService.SaveVSmart_BatchDetail(new VSmart_BatchDetail()
                    {
                        MID = _mID,
                        TID = _tID,
                        BatchID = iniBatch,
                        ShopID = branchModel.doc_no_run,
                        OpenDateTime = DateTime.Now,
                        OpenStaffID = userId,
                        UpdateDate = DateTime.UtcNow
                    }, true);
                    // Save data in ST_DayStart
                    var DayStart = new ST_DayStart()
                    {
                        computer_id = branchModel.POS_ComputerID,
                        day_start = DateTime.Now,
                        money_default = data.money_default ?? 0,
                        staff_id = userId,
                        blue_card_batch_id = iniBatch
                    };
                    _db.ST_DayStart.Add(DayStart);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    resultMessage = "ไม่สามารถเชื่อมต่อ VPN BlueCard ได้";
                }


                return resultMessage;

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }
        }

        // CommitTransPOS ยืนยันการทำรายการ
        public POSUI CommitTransPOS(string _Trans_ID, string _Invoice_ID, int userId)
        {
            POSUI posModel = new POSUI();
            posModel.AddressData = new AddressData
            {
                Method = "CommitTransPOS"
            };
            posModel.OrderData = new OrderData
            {
                Tran_ID = _Trans_ID,
                Invoice_ID = _Invoice_ID
            };
            var retPOS = CallBlueCardGetApi(posModel, null, _Invoice_ID);

            return retPOS;
        }

        #region // แลกคะแนน เปิดบิล
        public POSUI RedeemPoints(PaymentModel model, int userId)
        {

            int PosTransID = 1;
            if (_db.ST_Arheader.Count() > 0)
            {
                PosTransID = (_db.ST_Arheader.OrderByDescending(x => x.doc_no_run).FirstOrDefault()?.doc_no_run ?? 1) + 1;
            }

            var posModel = GetRedeemPoints(model, userId);
            var retPOS = CallBlueCardGetApi(posModel, PosTransID, model.RefDocNo);
            if (retPOS.SystemData.ReturnCode == "94")
            {
                GetlastStand(new VSmart_MaxStandID
                {
                    BatchID = posModel.SystemData.Batch_ID,
                    MID = posModel.SystemData.MID,
                    TID = posModel.SystemData.TID
                }, out var newStand);
                posModel.SystemData.Stand_ID = newStand;
                retPOS = CallBlueCardGetApi(posModel, PosTransID, model.RefDocNo);
            }
            if (retPOS.SystemData.ReturnCode == "00")
            {
                if (!string.IsNullOrWhiteSpace(retPOS.OrderData.Redemption_ID))
                {
                    _blueCardService.SaveVSmart_RedeemMaster(posModel, retPOS, PosTransID);

                    var dbBlueCardModel = new SB_BlueCard
                    {
                        CardNumber = retPOS.OrderData.PaymentData.PaymentItem[0].Code,
                        PINCode = model.BlueCardCode,
                        TID = retPOS.SystemData.TID,
                        MID = retPOS.SystemData.MID,
                        PointsAvailable = retPOS.CustomData.Point_Balance, //Qty_Balance = 5000,  // Point Balance
                        PointsEarnedToday = retPOS.CustomData.Point_Earned_Today.ToString(),
                        //Redeemedpoints = retPOS.OrderData.PaymentData.PaymentItem[0].Qty.ToString(), //Qty_Used = 500, 	    // TRN Point
                        Redeemedpoints = retPOS.OrderData.PaymentData.PaymentItem[0].ItemReturn.Qty_Used.ToString(),
                        //Discount = retPOS.OrderData.PaymentData.PaymentItem[0].Price.ToString(), //Price_Used = 100,
                        Discount = retPOS.OrderData.PaymentData.PaymentItem[0].ItemReturn.Price_Used.ToString(), //Price_Used = 100,
                        DocNo = model.RefDocNo,
                        MemberName = retPOS.CustomData.Name,
                        Redemption_ID = retPOS.OrderData.Redemption_ID, //Redemption_ID = "123xfxjyefjcy11234"
                        ReponseCode = retPOS.SystemData.ReturnCode,
                        ReponseMSG = retPOS.SlipAdData.SlipAdInfo.Any() ? retPOS.SlipAdData.SlipAdInfo[0].SlipAd[0].Text : ""
                    };

                    _db.SB_BlueCard.Add(dbBlueCardModel);
                    _db.SaveChanges();
                }
            }
            return retPOS;

        }
        private POSUI GetRedeemPoints(PaymentModel model, int userId)
        {
            SetDataOrderDetail(model, userId, out var systemData, out int countDoc, out SB_Branch branchModel, out ProductItem[] productItems, out decimal totalPrice, out DiscountItem[] DiscountItems);

            var totalPaymentItem = new PaymentItem[1];
            totalPaymentItem[0] = new PaymentItem { TenderCode = Constants.TenderCode.BlueCard, Code = model.BlueCardNo, Qty = model.BlueCardUsePoint, Price = model.BlueCardMoney }; // Bluecard

            var posModel = new POSUI
            {
                AddressData = new AddressData
                {
                    Method = "InsertTransPOS",
                    MethodParam = MethodParam.IsRedemption
                },
                CustomData = new CustomerData
                {
                    Card_No = model.BlueCardNo,
                    BlueCode = model.BlueCardCode
                },
                SystemData = new SystemData
                {
                    MID = branchModel.MID,
                    TID = branchModel.TID,
                    Batch_ID = (int)systemData.BatchID,
                    Stand_ID = countDoc,
                    Order_DateTime = DateTime.Now,
                    Employee_ID = userId.ToString()
                },
                OrderData = new OrderData
                {
                    GrandTotalPrice = totalPrice,
                    SaleMode = SaleMode.TakeAway,
                    Earn_By_BIZ = model.BlueCardType ?? "1",
                    PaymentData = new PaymentData
                    {
                        PaymentItem = totalPaymentItem
                    },
                    OrderDetail = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            TotalPrice = totalPrice,
                            ProductData = new ProductData
                            {
                                ProductItem = productItems
                            }
                        }
                    }.ToArray()
                }
            };
            return posModel;
        }
        #endregion

        #region  // สะสมคะแนน เปิดบิล
        public string AccumulatePoints(PaymentModel model, int userId)
        {
            try
            {
                int PosTransID = 1;
                if (_db.ST_Arheader.Count() > 0)
                {
                    PosTransID = (_db.ST_Arheader.OrderByDescending(x => x.doc_no_run).FirstOrDefault()?.doc_no_run ?? 1) + 1;
                }

                // Get data for send to api ptt
                var posModel = GetAccumulatePoints(model, userId, out int Shop_ID);
                POSUI retPOS = new POSUI();
                try
                {
                    // Save Data in VSmart Order

                    retPOS = CallBlueCardGetApi(posModel, PosTransID, model.RefDocNo);
                    _blueCardService.SaveVSmart_Order(posModel, retPOS, PosTransID, model.RefDocNo, false);

                }
                catch
                {
                    // Save Data in VSmart Order
                    _blueCardService.SaveVSmart_Order(posModel, retPOS, PosTransID, model.RefDocNo, false);
                }

                if (retPOS.SystemData.ReturnCode == "94")
                {
                    GetlastStand(new VSmart_MaxStandID
                    {
                        BatchID = posModel.SystemData.Batch_ID,
                        MID = posModel.SystemData.MID,
                        TID = posModel.SystemData.TID
                    }, out var newStand);
                    posModel.SystemData.Stand_ID = newStand;
                    retPOS = CallBlueCardGetApi(posModel, PosTransID, model.RefDocNo);
                }

                if (retPOS != null && retPOS.SystemData.ReturnCode == "00")
                {
                    if (retPOS.SystemData.ReturnCode == "00")
                    {

                        _blueCardService.SaveVSmart_Order(posModel, retPOS, PosTransID, model.RefDocNo, true);

                        var data = _db.SB_BlueCard.FirstOrDefault(x => x.DocNo == model.RefDocNo);
                        if (data != null)
                        {
                            data.TID = retPOS.SystemData.TID;
                            data.MID = retPOS.SystemData.MID;
                            data.CardNumber = retPOS.CustomData.Card_No;
                            data.MobileNumber = model.BlueCardSaveMobile;
                            data.PointAccureToday = retPOS.CustomData.Point_Earned_Today;
                            data.PointsAvailable = retPOS.CustomData.Point_Balance;
                            data.PointsEarnedToday = retPOS.CustomData.Point_Earned_Today.ToString();
                            data.PointsEarnedinTranction = retPOS.CustomData.Return_Point.ToString();
                            data.DocNo = model.RefDocNo;
                            data.TransectionID = retPOS.OrderData.Tran_ID;
                            data.MemberName = retPOS.CustomData.Name;
                            data.ReponseCode = retPOS.SystemData.ReturnCode;
                            data.ReponseMSG = retPOS.SlipAdData.SlipAdInfo.Any()
                                ? retPOS.SlipAdData.SlipAdInfo[0].SlipAd[0].Text
                                : "";
                            _db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            // Save data in SB_BlueCard
                            var dbModel = new SB_BlueCard
                            {
                                TID = retPOS.SystemData.TID,
                                MID = retPOS.SystemData.MID,
                                CardNumber = retPOS.CustomData.Card_No,
                                MobileNumber = model.BlueCardSaveMobile,
                                PointAccureToday = retPOS.CustomData.Point_Earned_Today,
                                PointsAvailable = retPOS.CustomData.Point_Balance,
                                PointsEarnedToday = retPOS.CustomData.Point_Earned_Today.ToString(),
                                PointsEarnedinTranction = retPOS.CustomData.Return_Point.ToString(),
                                DocNo = model.RefDocNo,
                                TransectionID = retPOS.OrderData.Tran_ID,
                                MemberName = retPOS.CustomData.Name,
                                ReponseCode = retPOS.SystemData.ReturnCode,
                                ReponseMSG = retPOS.SlipAdData.SlipAdInfo.Any() ? retPOS.SlipAdData.SlipAdInfo[0].SlipAd[0].Text : ""
                            };

                            _db.SB_BlueCard.Add(dbModel);
                        }
                        //  if (retPOS.SlipAdData.SlipAdInfo.Any())
                        //  return retPOS.SlipAdData.SlipAdInfo[0].SlipAd[0].Text;

                        _db.SaveChanges();
                    }

                }
                return retPOS?.OrderData?.Tran_ID;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                return null;
            }
        }
        private POSUI GetAccumulatePoints(PaymentModel model, int userId, out int shopId)
        {
            SetDataOrderDetail(model, userId, out var systemData, out int countDoc, out SB_Branch branchModel, out ProductItem[] productItems, out decimal totalPrice, out DiscountItem[] DiscountItems);

            var blueCardModel = _db.SB_BlueCard.FirstOrDefault(b => b.DocNo == model.RefDocNo);

            var paymentItemList = new List<PaymentItem>();
            if (model.CashAmount > 0)
            {
                if (model.PaymentType == Constants.PaymentType.PartailPayment)
                {

                    foreach (var item in model.ListPayment.ToList())
                    {
                        var paymentCash = new PaymentItem
                        {
                            TenderCode = GetTenderCode(item.PaymentType),
                            Price = (decimal)model.CashAmount

                        }; // Cash
                        paymentItemList.Add(paymentCash);
                    }
                }
                else
                {
                    var paymentCash = new PaymentItem
                    {
                        TenderCode = GetTenderCode(model.PaymentType),
                        Price = (decimal)model.CashAmount

                    }; // Cash
                    paymentItemList.Add(paymentCash);
                }

            }

            if (blueCardModel != null)
            {

                var paymentBlueCard = new PaymentItem
                {
                    TenderCode = Constants.TenderCode.BlueCard,
                    TenderType = TenderType.Blue_Card,
                    Code = blueCardModel.CardNumber,
                    Qty = decimal.Parse(blueCardModel.Redeemedpoints),
                    Price = decimal.Parse(blueCardModel.Discount),  // Blue Card
                    ItemReturn = new ItemReturn()
                    {
                        Qty_Balance = blueCardModel.PointsAvailable,  // Point Balance
                        Qty_Used = decimal.Parse(blueCardModel.Redeemedpoints),    // TRN Point
                        Price_Used = decimal.Parse(blueCardModel.Discount),
                    }
                };
                paymentItemList.Add(paymentBlueCard);
            }


            var posModel = new POSUI
            {
                AddressData = new AddressData
                {
                    Method = "InsertTransPOS",
                    MethodParam = MethodParam.IsOrder
                },
                CustomData = new CustomerData
                {
                    Card_No = model.BlueCardSaveNo,
                    BlueCode = model.BlueCardCode
                },
                SystemData = new SystemData
                {
                    MID = branchModel.MID,
                    TID = branchModel.TID,
                    Batch_ID = (int)systemData.BatchID,
                    Stand_ID = countDoc,
                    Order_DateTime = DateTime.Now,
                    Employee_ID = userId.ToString()
                },
                OrderData = new OrderData
                {
                    Redemption_ID = blueCardModel?.Redemption_ID == null ? null : blueCardModel?.Redemption_ID,
                    GrandTotalPrice = totalPrice,
                    SaleMode = SaleMode.TakeAway,
                    PaymentData = new PaymentData
                    {
                        PaymentItem = paymentItemList.ToArray()
                    },
                    OrderDetail = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            TotalPrice = totalPrice,
                            ProductData = new ProductData
                            {
                                ProductItem = productItems
                            }
                        }
                    }.ToArray()
                }
            };
            shopId = systemData.ShopID;
            if (DiscountItems.Any())
            {
                posModel.OrderData.DiscountData = new DiscountData
                {
                    DiscountItem = DiscountItems
                };
            }

            return posModel;
        }
        #endregion

        // SetDataOrderDetail
        private void SetDataOrderDetail(PaymentModel model, int userId,
            out SystemDataBlueCardModel sysData,
            out int countDoc,
            out SB_Branch branchModel,
            out ProductItem[] productItems,
            out decimal totalPrice,
            out DiscountItem[] DiscountItems)
        {
            //var posModel = GetLastBatchIDPOS();
            var dateNowStr = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            sysData = GetDataSystemBlueCard(userId, DateTime.Now.ToString("dd/MM/yyyy"));


            //batchId = sysData;

            var data = sysData;
            int lastStand;
            GetlastStand(new VSmart_MaxStandID
            {
                BatchID = data.BatchID,
                MID = data.MID,
                TID = data.TID
            }, out lastStand);
            countDoc = lastStand;

            var customerModel = _db.SB_Customer.First(c => c.cus_code == model.CustomerCode);
            branchModel = _db.SB_Branch.First();
            productItems = _db.ST_Jobdetail.Where(j => j.doc_no == model.RefDocNo && j.locat_code != null).OrderBy(j => j.Line_no).ToArray().Select(j => new ProductItem
            {
                Seq = j.Line_no,
                ID = j.doc_no_run.ToString(),
                Code = j.pro_code,
                Price = (decimal)j.pro_price,
                ItemType = j.pro_price > 0 ? ProductItemType.Sale : ProductItemType.Issue,
                Qty = (decimal)j.store_qty
            }).ToArray();
            totalPrice = (decimal)_db.ST_Jobdetail.Where(j => j.doc_no == model.RefDocNo).Sum(j => j.pro_amt);
            DiscountItems = _db.ST_Jobdetail.Where(j => j.doc_no == model.RefDocNo && j.locat_code == null).ToArray().Select(j => new DiscountItem
            {
                Seq = j.Line_no,
                ID = j.doc_no_run,
                Code = j.pro_code,
                Price = (decimal)j.pro_price,
                Qty = (decimal)j.store_qty,
            }).ToArray();
        }

        private void GetlastStand(VSmart_MaxStandID data, out int intStand)
        {
            int countDoc;
            var obj = _db.VSmart_MaxStandID.Where(w => w.MID == data.MID && w.TID == data.TID && w.BatchID == data.BatchID)
                .OrderByDescending(o => o.MaxStandID).FirstOrDefault();
            if (obj != null)
            {
                var incStand = new VSmart_MaxStandID
                {
                    MID = data.MID,
                    TID = data.TID,
                    BatchID = data.BatchID,
                    MaxStandID = obj.MaxStandID + 1
                };
                _blueCardService.SaveVSmart_MaxStandID(incStand, true);
                intStand = incStand.MaxStandID;
            }
            else
            {
                var inistand = new VSmart_MaxStandID
                {
                    MID = data.MID,
                    TID = data.TID,
                    BatchID = data.BatchID,
                    MaxStandID = 1
                };
                _blueCardService.SaveVSmart_MaxStandID(inistand, false);
                intStand = inistand.MaxStandID;
            }
        }

        public SystemDataBlueCardModel GetDataSystemBlueCard(int userId, string dateNowStr)
        {
            try
            {

                //var branchModel = _db.SB_Branch.First();
                //  var retPOS = GetLastBatchIDPOS(branchModel.MID, branchModel.TID);
                var batchVSmart = _db.VSmart_BatchDetail.OrderByDescending(x => x.BatchID).FirstOrDefault();

                #region .bak

                /*
                 VSmart_BatchDetail batchVSmart = null;
                if (dateNowStr == "")
                {
                    batchVSmart = _db.VSmart_BatchDetail.OrderByDescending(x => x.BatchID).FirstOrDefault();
                }
                else
                {
                    var tmp = _db.VSmart_BatchDetail.ToArray().Select(s => new
                    {
                        key = s,
                        _openDate = s.OpenDateTime.Value.ToString("dd/MM/yyyy")
                    }).ToList();
                    var ok = tmp.AsEnumerable()
                                .Where(w => w.key.CloseDateTime == null && w._openDate == dateNowStr)
                                    .OrderByDescending(o => o.key.BatchID)
                                        .FirstOrDefault();
                    if (ok != null)
                    {
                        batchVSmart = new VSmart_BatchDetail
                        {
                            MID = ok.key.MID,
                            TID = ok.key.TID,
                            BatchID = ok.key.BatchID,
                            ShopID = ok.key.ShopID
                        };
                    }
                }


                if (batchVSmart != null)
                {
                    return new SystemDataBlueCardModel()
                    {
                        MID = batchVSmart.MID,
                        TID = batchVSmart.TID,
                        BatchID = batchVSmart.BatchID,
                        ShopID = batchVSmart.ShopID
                    };
                }
                else
                {
                    var retPOS = GetLastBatchIDPOS(branchModel.MID, branchModel.TID);
                    _blueCardService.SaveVSmart_BatchDetail(new VSmart_BatchDetail()
                    {
                        MID = retPOS.SystemData.MID,
                        TID = retPOS.SystemData.TID,
                        BatchID = (retPOS.SystemData.Batch_ID + 1),
                        ShopID = branchModel.doc_no_run,
                        OpenDateTime = DateTime.Now,
                        OpenStaffID = userId,
                        UpdateDate = DateTime.UtcNow
                    }, true);

                    return new SystemDataBlueCardModel()
                    {
                        MID = retPOS.SystemData.MID,
                        TID = retPOS.SystemData.TID,
                        BatchID = (retPOS.SystemData.Batch_ID + 1),
                        ShopID = branchModel.doc_no_run
                    };


                }
                 */

                #endregion

                return new SystemDataBlueCardModel
                {
                    MID = batchVSmart.MID,
                    TID = batchVSmart.TID,
                    BatchID = batchVSmart.BatchID,
                    ShopID = batchVSmart.ShopID
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}