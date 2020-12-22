'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var PaymentForm = function () {
    function PaymentForm() {
        _classCallCheck(this, PaymentForm);

        this.status = 'add';
        this.moneyBalance = 0;
        this.txtTotalNumber = $('#TotalNumber');
        this.dtPaymentList = $('#payment-list');

        this.txtBalance = $('#txtBalance');
        this.txtTotalAmount = $('#TotalAmount');
        this.txtTotalDiscount = $('#TotalDiscount');
        this.txtExtraDiscount = $('#txtExtraDiscount');
        this.txtPaymentAmount = $('#PaymentAmount');
        this.txtPaymentCash = $('#txtPaymentCash');
        this.txtPaymentPttor = $('#txtPaymentPttor');
        this.hidPaymentCash = $('#PaymentCash');
        this.txtCashNote = $('#txtCashNote');
        this.txtChangeMoney = $('#txtChangeMoney');
        this.btnChangeMoney = $('#btnChangeMoney');
        this.btnSubmit = $('#btnSubmit');
        this.btnCheckDigitCoupon = $('#btnCheckCouponDigit');
        this.txtPaymentMoney = $('#txtPaymentMoney');
        this.txtPaymentMoneyCash = $('#txtPaymentMoneyCash');
        this.btnBack = $("#btnBack");
        this.blueCardNo = $('#BlueCardNo');
        this.blueCardBalancePoint = $('#BlueCardBalancePoint');
        this.blueCardRewardPoint = $('#BlueCardRewardPoint');

        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.hidRefDocNo = $('#RefDocNo');
        this.hidCustTypeCode = $('#CustTypeCode');

        this.hidCashAmount = $('#CashAmount');
        this.hidChangeMoney = $('#ChangeMoney');
        this.txtPaymentTotal = $('#txtPaymentTotal');

        this.cashModal = $('#cashModal');
        this.pttorModal = $('#pttorModal');
        this.crModal = $('#creditCardModal');
        this.ID_pttorModal = $("#ID_pttorModal");
        this.ID_cdsModal = $("#ID_cdsModal");
        this.blueCardModal = $('#blueCardSaveModal');

        this.btnLastDiscount = $('#btnLastDiscount');
        this.txtLastDiscount = $('#txtLastDiscount');
        this.txtLastDiscountPercent = $('#txtLastDiscountPercent');
        this.rdoUnitLastDiscount1 = $('#rdoUnitLastDiscount1');
        this.rdoUnitLastDiscount2 = $('#rdoUnitLastDiscount2');
        this.lblLastDiscountIsValid = $('#lblLastDiscountIsValid');
        this.lastDiscountModal = $('#lastDiscountModal');

        this.txtPaymentCreditCard = $('#txtPaymentCreditCard');
        this.txtCreditNumber = $('#txtCreditNumber');
        this.txtApprCode = $('#txtApprCodeEdc');
        this.ddBank = $('#ddBank');
        this.ddPaymentFormat = $('#ddPaymentFormat');
        this.ddCardType = $('#ddCardType');
        this.ddCreditMonth = $('#ddCreditMonth');
        this.ddCreditYear = $('#ddCreditYear');
        this.txtCreditCardNote = $('#txtCreditCardNote');

        this.dtDiscountElem = $('#discount-list');
        this.dtProductElem = $('#product-list');



        this.myForm = $('#myForm');
        this.Cancel = $('#Cancel');
        this.addDiscountUrl = null;
        this.deleteDiscountUrl = null;
        this.deleteProductPomotionUrl = null;
        this.deletePaymentCreditCardUrl = null;
        this.addPaymentOtherUrl = null;
        this.deletePaymentOtherUrl = null;
        this.deleteDepositUrl = null;
        this.clearProductListTempUrl = null;
        this.id = null;
        this.RoundUnitType = null;
        this.getCheckCouponUrl = null;
        this.CheckCouponDigitUrl = null;
        this.CheckEdcStatusUrl = null;
        this.StartEdcCheck = null;

        this.TimerStart = $("#start");
        this.TimerStop = $("#stop");
        this.TimerReset = $("#reset");

        this.checkEdcStatus = $("#checkEdcStatus");
        this.StartEdcCheck = $("#StartEdcCheck");
        this.promotionForm = null;
        this.deletePaymentCashUrl = null;
        this.clientUrl = null;
    }

    _createClass(PaymentForm, [{

        key: 'init',
        value: function init() {

            var me = this;
            this.clientUrl = $('#client-url').val()
            this.btnSubmit.prop("disabled", true);
            this.createPaymentDatatable();

            this.setTotal();

            this.createDiscoundListDatatable();
            this.createProductListDatatable();

            this.addBlank();
            this.UseCoupon();

            var productListData = me.dtDiscounds.rows().data();
            for (var i = 0; i < productListData.length; i++) {
                if (productListData[i].id) {
                    $('a[title="' + productListData[i].name + '"]').addClass('not-active');
                }
            }

            if (productListData.length < 1) {
                this.dtDiscounds.row.add({
                    'name': '',
                    'type': '',
                    'number': '',
                    'money': '',
                    'id': ''
                }).draw();
            }

            this.btnLastDiscount.prop("disabled", true);

            this.txtLastDiscount.keyup(function () {
                var isValid = +me.txtLastDiscount.val() <= 0 || +me.txtLastDiscount.val() > +me.txtBalance.val();
                me.btnLastDiscount.prop("disabled", isValid);
                me.lblLastDiscountIsValid.prop("hidden", +me.txtLastDiscount.val() <= +me.txtBalance.val());
                if (isValid) return;

                if (event.keyCode === 13) {
                    me.btnLastDiscount.click();
                }
            });

            this.txtLastDiscountPercent.keyup(function () {
                me.txtLastDiscount.val(+me.txtPaymentMoney.val() * +me.txtLastDiscountPercent.val() / 100);
                var isValid = +me.txtLastDiscount.val() <= 0 || +me.txtLastDiscount.val() > +me.txtBalance.val();
                me.btnLastDiscount.prop("disabled", isValid);
                me.lblLastDiscountIsValid.prop("hidden", +me.txtLastDiscount.val() <= +me.txtBalance.val());
                if (isValid) return;

                if (event.keyCode === 13) {
                    me.btnLastDiscount.click();
                }
            });

            this.btnLastDiscount.click(function () {
                me.addExtraDiscount('ส่วนลดอื่นๆ', me.txtLastDiscount.val(), 0, 'DIS00000000', "", "");
                me.lastDiscountModal.modal('toggle');
            });

            this.lastDiscountModal.on('shown.bs.modal', function () {
                me.txtLastDiscount.focus();
            });

            me.txtLastDiscountPercent.hide();

            this.ID_pttorModal.click(function () {
                //var base_url = window.location.origin;
                //var port = ":" + location.port;
                //var UrlPttorBill = base_url.replace(port, "") + "/PTT_Client_1/report/rpt_send.aspx?thaibaht=&print_tax=1&print_comp=1&reportname=pttor.rpt&doc_no=" + me.hidDocNo.val() + "&prn_vat=&prn_date=&prn_car_reg=&prn_pay_type=&doc_code=PTTOR&cus_update=&print_price=&branch_no=004";
                //var UrlPttorBillOnHost = "/PTT_Client_1/report/rpt_send.aspx?thaibaht=&print_tax=1&print_comp=1&reportname=pttor.rpt&doc_no=" + me.hidDocNo.val() + "&prn_vat=&prn_date=&prn_car_reg=&prn_pay_type=&doc_code=PTTOR&cus_update=&print_price=&branch_no=004";

                //window.open(UrlPttorBillOnHost, "PTTOR Receipt", "width=500,height=500,scrollbars=yes");
                //me.Cancel.val(true);
                me.myForm.submit()
            });
            this.ID_cdsModal.click(function () {
                //$('#Cancel').val(true);
                $('#myForm').submit()
            });

            this.checkEdcStatus.click(function () {
                var _url = me.StartEdcCheck;
                var _data = { DocCode: me.hidDocCode.val(), DocNo: me.hidRefDocNo.val() };

                //  alert(_url);
                $.ajax({
                    type: "GET",
                    url: _url,
                    data: _data,
                    beforeSend: function beforeSend() {
                        //$('#loaderDiv').show();
                    },
                    success: function success(result) {
                        //$('#loaderDiv').hide();        
                        //alert(result.Data);		
                        console.log("checkEdcStatus" + result.Data);
                        if (result.Data == 1) {

                            //
                            $("#blueCardSaveModal").modal("hide");
                            //$("#modalEdcCheck").modal("show");

                        }
                        else if (result.Data >= 2) {
                            me.TimerStop.click();
                            me.TimerReset.click();

                            if ($('#PartialPayment').hasClass('show')) {
                                $('#PartialPayment').modal('hide');
                                $('body').removeClass('modal-open');
                                $('.modal-backdrop').remove();
                            }

                            me.hidCashAmount.val(me.txtTotalAmount.val());
                            $("#blueCardSaveModal").modal("show");
                            //$("#modalEdcCheck").modal("hide");
                            //$("#modalEdcCheck").modal("hide");
                        }
                    }
                    //success: function success(result) {
                    //    //$('#loaderDiv').hide();        
                    //    //alert(result.Data);		
                    //    console.log("checkEdcStatus" + result.Data);
                    //    if (result.Data >= 2) {
                    //        me.TimerStop.click();
                    //        me.TimerReset.click();
                    //        $("#blueCardSaveModal").modal("show");
                    //        //$("#modalEdcCheck").modal("hide");
                    //        //$("#modalEdcCheck").modal("hide");
                    //    }
                    //}

                });
            });
            this.btnCheckDigitCoupon.click(function () {
                var CouponName = $('#CouponName').val();
                var PromotionCode = $('#PromotionCode').val(); // pro_id
                var CouponId = $('#CouponId').val();
                var CouponBath = $('#CouponBath').val();
                var CouponPercent = $('#CouponPercent').val();
                var CouponDigit = $('#CouponDigit').val();
                var txtCouponDigit = $('#txtCouponDigit').val().trim();

                if (txtCouponDigit.length > 0) {

                    var _url = me.CheckCouponDigitUrl;
                    var _data = { PromotionCode: PromotionCode, DocNo: me.hidRefDocNo.val(), CouponGrp: CouponId, CouponDigit: txtCouponDigit };
                    $.ajax({
                        type: "GET",
                        url: _url,
                        data: _data,
                        beforeSend: function beforeSend() {
                            $('#loaderDiv').show();
                        },
                        success: function success(result) {
                            $('#loaderDiv').hide();

                            switch (result) {
                                case 0: warningAlert("ไม่สามารถใช้คูปองนี้ได้");
                                    break;
                                case 1: me.addExtraDiscount(CouponName, CouponBath, CouponPercent, PromotionCode, CouponId, txtCouponDigit);
                                    $('#PassCouponDigit').modal('toggle');
                                    break;
                                case 2: warningAlert("ไม่สามารถใช้คูปองนี้ได้เนื่องจากคูปองนี้ถูกใช้ไปแล้ว");
                                    break;
                                case 3: warningAlert("รหัสคูปองไม่ถูกต้อง");
                                    break;
                                case 500: warningAlert("ไม่มีคูปองนี้อยู่ในระบบ");
                                    break;
                            }
                        }

                    });
                } else {
                    warningAlert("รหัสคูปองไม่ถูกต้อง");
                }


            });

            this.rdoUnitLastDiscount2.click(function () {
                //me.txtLastDiscount.val(0);
                me.txtLastDiscount.hide();
                me.txtLastDiscountPercent.val(me.txtLastDiscount.val())
                me.txtLastDiscount.val(+me.txtPaymentMoney.val() * +me.txtLastDiscountPercent.val() / 100);
                me.txtLastDiscountPercent.show();
            });

            this.rdoUnitLastDiscount1.click(function () {
                //me.txtLastDiscountPercent.val(0);
                me.txtLastDiscountPercent.hide();
                me.txtLastDiscount.val(me.txtLastDiscountPercent.val())
                me.txtLastDiscount.show();
            });

            if (me.hidDocCode.val() == "PTTOR") {

                $('a[href="#cashModal"]').addClass("not-active");
                $('a[href="#lazadaModal"]').addClass("not-active");
                $('#ID_creditEdcModal').addClass("not-active");
                $('a[href="#qrCodeModal"]').addClass("not-active");
                $('a[href="#lazadaModal"]').addClass("not-active");
                $('a[href="#PartialPayment"]').addClass("not-active");
                $('a[href="#OnlinePayment"]').addClass("not-active");
                $('a[href="#cdsModal"]').addClass("not-active");
                $('a[href="#creditCardModal"]').addClass("not-active");

            }
            else if (me.hidDocCode.val() == "T101" ||
                me.hidDocCode.val() == "T102" ||
                me.hidDocCode.val() == "T103" ||
                me.hidDocCode.val() == "T104") {

                $('a[href="#cashModal"]').addClass("not-active");
                $('a[href="#lazadaModal"]').addClass("not-active");

                $('#ID_creditEdcModal').addClass("not-active");
                $('a[href="#qrCodeModal"]').addClass("not-active");
                $('a[href="#lazadaModal"]').addClass("not-active");
                $('a[href="#PartialPayment"]').addClass("not-active");
                $('a[href="#pttorModal"]').addClass("not-active");
                $('a[href="#OnlinePayment"]').addClass("not-active");
                $('a[href="#creditCardModal"]').addClass("not-active");
            } else {
                $('a[href="#cdsModal"]').addClass("not-active");
                $('a[href="#pttorModal"]').addClass("not-active");
            }

            //CDS Customer 


            if (me.hidDocCode.val() == "A302") {
                $('.discount-col a').addClass('not-active-finish');
            }

            //window.onbeforeunload = function (e) {
            //    if (!submitted) {
            //        var message = "You have not saved your changes.",
            //            e = e || window.event;
            //        if (e) {
            //            e.returnValue = message;
            //        }
            //        $.get(me.clearProductListTempUrl, { docCode: me.hidDocCode.val(), docNo: me.hidDocNo.val(), refDocNo: me.hidRefDocNo.val() }, function () {
            //            return "";
            //        });

            //        return message;
            //    }
            //};

            commaFormSubmit(me.myForm);


        }
    }, {
        key: 'createPaymentDatatable',
        value: function createPaymentDatatable() {
            var me = this;
            this.dtPayment = this.dtPaymentList.DataTable({
                "searching": false,
                "paging": false,
                "ordering": false,
                "scrollY": "14vh",
                "scrollCollapse": true,
                "info": false,
                columns: [
                    { data: "id", visible: false },
                    { data: "paymentType" },
                    { data: "money", className: "text-right", render: $.fn.dataTable.render.number(',', '.', 2) },
                    {
                        data: "number", render: function render(data, type, row) {
                            if (data) {
                                var dataArr = data.split("-");
                                if (dataArr.length == 4 && data.length == 19) {
                                    return dataArr[0] + '-' + (dataArr[1][0] + dataArr[1][1]) + 'XX-XXXX-' + dataArr[3];
                                }
                                return data;
                            }
                            return '';
                        }
                    },
                    {
                        data: "note",
                        render: function render(data, type, row) {
                            if (data.length > 9) {
                                var value = data.substring(0, 9);
                                return value + '..';
                            }
                            return data;
                        }
                    },
                    {
                        data: 'options',
                        className: "text-center",
                        render: function render(data, type, row) {
                            if (data) {
                                var optionsHtml = '';
                                if (data == 'all') optionsHtml += '<a href="#" class="edit"><i class="fa fa-edit"></i></a>|<a href="#" class="remove"><i class="fa fa-trash"></i></a>';
                                if (data == 'delete') optionsHtml += '<a href="#" class="remove"><i class="fa fa-trash"></i></a>';
                                return optionsHtml;
                            }
                            return '';
                        }
                    },
                    { data: "modalName", visible: false },
                    { data: "apprCode", visible: false },
                    { data: "bank", visible: false },
                    { data: "payFormat", visible: false },
                    { data: "cardType", visible: false },
                    { data: "crMonth", visible: false },
                    { data: "crYear", visible: false }
                ]
            });

            this.dtPaymentList.on('click', 'a.remove', function (e) {
                var row = $(this).closest('tr');
                var id = me.dtPayment.row(row).data().id;
                var paymentType = me.dtPayment.row(row).data().paymentType;

                switch (paymentType) {
                    case "เงินสด":

                        $.get(me.deletePaymentCashUrl, { id: id }).done(function (resp) {
                            if (resp.Code != "00") return;
                            me.hidCashAmount.val(0);
                            me.hidChangeMoney.val(0);
                            me.dtPayment.row(row).remove().draw();
                            me.setTotalPaymentAmount();
                            me.hidPaymentCash.val(0);
                        });


                        break;
                    case "เครดิตการ์ด":
                        $.get(me.deletePaymentCreditCardUrl, { id: id }).done(function (resp) {
                            if (resp.Code != "00") return;
                            me.dtPayment.row(row).remove().draw();
                            me.setTotalPaymentAmount();
                        });
                        break;
                    case "เงินมัดจำ":
                        $.get(me.deleteDepositUrl, { id: id }).done(function (resp) {
                            if (resp.Code != "00") return;
                            me.dtPayment.row(row).remove().draw();
                            me.setTotalPaymentAmount();
                        });
                        break;
                    case "หัก ณ ที่จ่าย 3%":
                        $.get(me.deletePaymentOtherUrl, { id: id }).done(function (resp) {
                            if (resp.Code != "00") return;
                            me.dtPayment.row(row).remove().draw();
                            $('a[title="\u0E2B\u0E31\u0E01 \u0E13 \u0E17\u0E35\u0E48\u0E08\u0E48\u0E32\u0E22 3%"]').removeClass('not-active');
                            me.setTotalPaymentAmount();
                        });
                        break;
                    case "BlueCardRedeem":
                        $.get(me.deletePaymentOtherUrl, { id: id }).done(function (resp) {
                            if (resp.Code != "00") return;
                            me.dtPayment.row(row).remove().draw();
                            me.blueCardNo.val('');
                            me.blueCardBalancePoint.val('');
                            me.blueCardRewardPoint.val('');
                            $('a[title="Blue Card"]').removeClass('not-active');
                            me.setTotalPaymentAmount();
                        });
                        break;
                    case "LAZADA":
                        $.get(me.deletePaymentOtherUrl, { id: id }).done(function (resp) {
                            if (resp.Code != "00") return;
                            me.dtPayment.row(row).remove().draw();
                            $('a[title="LAZADA"]').removeClass('not-active');
                            me.setTotalPaymentAmount();
                        });
                        break;
                    //default:
                    //    let money = me.dtPayment.row(row).data().money
                    //    $.get(me.deleteDiscountUrl, { id: id })
                    //        .done(function (resp) {
                    //            $(`a[title="${me.dtPayment.row(row).data().number}"]`).removeClass('not-active')
                    //            me.processDiscount(-money)
                    //            me.dtPayment.row(row).remove().draw()
                    //        })
                    //    break
                }
            });

            this.dtPaymentList.on('click', 'a.edit', function (e) {

                me.status = 'edit';
                var row = $(this).closest('tr');
                me.id = me.dtPayment.row(row).data().id;
                var data = me.dtPayment.row(row).data();

                switch (data.paymentType) {
                    case "เงินสด":
                        me.txtPaymentCash.val(data.money);
                        me.txtPaymentPttor.val(data.money);
                        me.txtCashNote.val(data.note);
                        break;
                    case "เครดิตการ์ด":
                        me.txtPaymentCreditCard.val(data.money);
                        me.txtCreditNumber.val(data.number);
                        me.txtApprCode.val(data.apprCode);
                        me.ddBank.val(data.bank);
                        me.ddPaymentFormat.val(data.payFormat);
                        me.ddCardType.val(data.cardType);
                        me.txtCreditCardNote.val(data.note);
                        me.ddCreditMonth.val(data.crMonth);
                        me.ddCreditYear.val(data.crYear);
                        break;
                }
                $('#' + data.modalName).modal();
            });
        }
    }, {
        key: 'createProductListDatatable',
        value: function createProductListDatatable() {
            var me = this;
            this.dtProducts = this.dtProductElem.DataTable({
                "searching": false,
                "paging": false,
                "ordering": false,
                "scrollY": "24vh",
                "scrollCollapse": true,
                "info": false,
                "width": "100%",
                columns: [
                    { data: "name", width: "40%" },
                    { data: "number", className: "text-center", width: "10%", render: $.fn.dataTable.render.number(',', '.', 0) },
                    { data: "money", className: "text-center", width: "20%", render: $.fn.dataTable.render.number(',', '.', 2) },
                    { data: 'sum_money', width: "20%", className: "text-center", render: $.fn.dataTable.render.number(',', '.', 2) },
                    {
                        data: 'id', width: "10%", className: "text-center", render: function render(data, type, row) {

                            if (data) return '<a href="#" class="remove text-center"><i class="fa fa-trash"></i></a>';
                            return '';
                        }
                    }
                    , { data: "tmp_No", visible: false }
                    , { data: "tmp_Code", visible: false }
                    , { data: "tmp_Name", visible: false }
                    , { data: "tmp_Type", visible: false }
                    , { data: "tmp_ProductDetail", visible: false }
                    , { data: "tmp_ProductGiveName", visible: false }
                    , { data: "tmp_Number", visible: false }
                    , { data: "tmp_Money", visible: false }
                    , { data: "tmp_ProductGiveCode", visible: false }
                    , { data: "tmp_PromotionType", visible: false }
                    , { data: "tmp_Discount", visible: false }
                    , { data: "tmp_CouponId", visible: false }
                    , { data: "tmp_CouponCode", visible: false }
                    , { data: "tmp_CouponCalType", visible: false }
                    , { data: "tmp_Product_Ref_Code", visible: false }
                    , { data: "tmp_give_same_buy", visible: false }
                ]
            });
            this.dtProductElem.on('click', 'a.remove', function (e) {
                //  alert();
                var money = me.dtProducts.row($(this).closest('tr')).data().money;
                var name = me.dtProducts.row($(this).closest('tr')).data().name;
                var id = me.dtProducts.row($(this).closest('tr')).data().id;
                var number = +me.dtProducts.row($(this).closest('tr')).data().number;

                var _data = {
                    'No': me.dtProducts.row($(this).closest('tr')).data().tmp_No,
                    'Code': me.dtProducts.row($(this).closest('tr')).data().tmp_Code,
                    'Name': me.dtProducts.row($(this).closest('tr')).data().tmp_Name,
                    'Type': me.dtProducts.row($(this).closest('tr')).data().tmp_Type,
                    'ProductDetail': me.dtProducts.row($(this).closest('tr')).data().tmp_ProductDetail,
                    'ProductGiveName': me.dtProducts.row($(this).closest('tr')).data().tmp_ProductGiveName,
                    'Number': me.dtProducts.row($(this).closest('tr')).data().tmp_Number,
                    'Money': me.dtProducts.row($(this).closest('tr')).data().tmp_Money,
                    'ProductGiveCode': me.dtProducts.row($(this).closest('tr')).data().tmp_ProductGiveCode,
                    'PromotionType': me.dtProducts.row($(this).closest('tr')).data().tmp_PromotionType,
                    'Discount': me.dtProducts.row($(this).closest('tr')).data().tmp_Discount,
                    'CouponId': "",
                    'CouponCode': "",
                    'CouponCalType': "",
                    'Product_Ref_Code': me.dtProducts.row($(this).closest('tr')).data().tmp_Product_Ref_Code,
                    'give_same_buy': me.dtProducts.row($(this).closest('tr')).data().tmp_give_same_buy
                };

                var _isFree = 0;
                if (id.split(',').length > 1) {
                    _isFree++;
                    id = id.substring(0, id.lastIndexOf(","));
                }

                $.get(me.deleteProductPomotionUrl, { id: id, docCode: me.hidDocCode.val() }
                ).done(function (delRows) {
                    if (delRows === 0) {
                        alert(delRows);
                        return;
                    } else {
                        me.promotionForm.dtPromotionList.row.add(_data, 1).draw();
                    }
                });

                var getThisTotal = me.txtPaymentMoney.val().replace(",", "");
                var returnVal = parseFloat(getThisTotal) - parseFloat(money);
                if (_isFree > 0) {
                    var _freeAmount = parseFloat(me.txtTotalAmount.val().replace(",", "")) - parseFloat(money);
                    me.txtTotalAmount.val(_freeAmount.toFixed(2));
                }
                if (_data.give_same_buy === true && _data.PromotionType === "3") {
                    if (Math.sign(money) === 1) {
                        var _amount = parseFloat(me.txtTotalAmount.val().replace(",", "")) - parseFloat(money);
                        me.txtTotalAmount.val(_amount.toFixed(2));
                    }
                }
                me.txtPaymentMoney.val(returnVal.toFixed(2))

                me.dtProducts.row($(this).closest('tr')).remove().draw();

                me.txtTotalNumber.val(+me.txtTotalNumber.val() - number)
                // --------- case ลบส่วนลด ------------------
                if (money < 0) {
                    me.txtExtraDiscount.val(+me.txtExtraDiscount.val() + +money);
                }
                me.setTotalPaymentAmount();
                me.setTotal();

            });
        }
    }, {
        key: 'createDiscoundListDatatable',
        value: function createDiscoundListDatatable() {
            var me = this;
            this.dtDiscounds = this.dtDiscountElem.DataTable({
                "searching": false,
                "paging": false,
                "ordering": false,
                "scrollY": "10vh",
                "scrollCollapse": true,
                "info": false,
                columns: [
                    { data: "name", width: "50%" },
                    { data: "type", visible: false },
                    { data: "number", className: "text-center", width: "15%", render: $.fn.dataTable.render.number(',', '.', 0) },
                    { data: "money", width: "25%", className: "text-center", render: $.fn.dataTable.render.number(',', '.', 2) },
                    {
                        data: 'id', width: "10%", className: "text-center", render: function render(data, type, row) {
                            if (data) return '<a href="#" class="remove"><i class="fa fa-trash"></i></a>';
                            return '';
                        }
                    }
                ]
            });

            this.dtDiscountElem.on('click', 'a.remove', function (e) {
                var money = me.dtDiscounds.row($(this).closest('tr')).data().money;
                var name = me.dtDiscounds.row($(this).closest('tr')).data().name;
                var id = me.dtDiscounds.row($(this).closest('tr')).data().id;
                var type = me.dtDiscounds.row($(this).closest('tr')).data().type;

                $.get(me.deleteDiscountUrl, { id: id, DocNo: me.hidDocNo.val(), docCode: me.hidDocCode.val(), money: money });
                $('a[title="' + name + '"]').removeClass('not-active');

                if (name == "ส่วนลดอื่นๆ" || type != "coupon") me.otherDiscount(-money); else {
                    me.processDiscount(-money);
                    //me.txtTotalNumber.val(+me.txtTotalNumber.val() - 1)
                }
                me.dtDiscounds.row($(this).closest('tr')).remove().draw();
                me.setTotalPaymentAmount();
            });
        }
    },
    {
        key: 'RoundUnit',
        value: function RoundUnit(value) {
            var RoundUnitType = this.RoundUnitType;
            var result = 0;
            if (RoundUnitType == "1") {
                result = Math.round(value);
            } else if (RoundUnitType == "2") {
                var tmp = (value - Math.floor(value));
                if (tmp <= 0.50)
                    result = Math.floor(value);
                else
                    result = Math.round(value);
            } else {
                result = value.toFixed(2);
            }
            return parseFloat(result).toFixed(2);
        }
    },

    {
        key: 'setTotal',
        value: function setTotal() {

            var paymentMoney = this.RoundUnit((+this.txtTotalAmount.val() - +this.txtExtraDiscount.val() - +this.txtTotalDiscount.val()));
            //  alert(paymentMoney);
            this.txtPaymentMoney.val(paymentMoney);

            //this.txtPaymentMoneyCash.val((+this.txtTotalAmount.val() - +this.txtExtraDiscount.val() - +this.txtTotalDiscount.val()).toFixed(2));
            //  this.txtPaymentMoneyCash.val(this.RoundUnit(paymentMoney));
            // this.txtPaymentMoneyPttor.val(this.RoundUnit(+this.txtTotalAmount.val() - +this.txtExtraDiscount.val() - +this.txtTotalDiscount.val()));

            var balance = +this.txtPaymentMoney.val() - +this.txtPaymentAmount.val();

            if (balance < 0) balance = 0;


            this.txtBalance.val(this.RoundUnit(balance));
            this.txtPaymentMoney.val(this.RoundUnit(balance));
            this.txtPaymentMoneyCash.val(this.RoundUnit(balance));
            //---------------- Edit Day 2019-06-14 ---------------------------

            //  this.txtTotalAmount.val(this.RoundUnit(balance));
            // this.txtBalance.val(balance.toFixed(2));
            //   this.hidPaymentCash.val((+this.txtPaymentCash.val()).toFixed(2));
            this.hidPaymentCash.val(this.RoundUnit(+this.txtPaymentCash.val()));
            this.btnSubmit.prop("disabled", balance > 0);
        }
    }, {
        key: 'setTotalPaymentAmount',
        value: function setTotalPaymentAmount() {
            var me = this;
            var datas = this.dtPayment.rows().data();
            var totalPayment = 0;
            for (var i = 0; i < datas.length; i++) {

                var value = datas[i].money;
                if (value && value.toString().indexOf(',') > -1) value = value.replace(/\,/g, '');
                var money = +value;
                totalPayment += money;

            }

            this.txtPaymentAmount.val(totalPayment.toFixed(2));
            this.setTotal();
            this.displayPayment();
        }
    }, {
        key: 'displayPayment',
        value: function displayPayment() {
            //let datas = this.dtPayment.rows().data()
            //if (datas.length > 0) {
            //let data = datas.filter((element) => {
            //    return element.paymentType == 'เงินสด';
            //})

            $('.payment-col a,.discount-col a').removeClass('not-active-finish');
            //if (data.length > 0) {
            //    $('a[title="เครดิตการ์ด"]').addClass('not-active-finish')
            //    $('a[title="เครดิต EDC"]').addClass('not-active-finish')
            //}
            //else {
            //    $('a[title="เครดิตการ์ด"]').removeClass('not-active-finish')
            //    $('a[title="เครดิต EDC"]').removeClass('not-active-finish')
            //}

            //let data2 = datas.filter((element) => {
            //    return element.paymentType.indexOf("เครดิต") > -1;
            //})

            //if (data2.length > 0) {
            //    $('a[title="เงินสด"]').addClass('not-active-finish')
            //}
            //else {
            //    $('a[title="เงินสด"]').removeClass('not-active-finish')
            //}

            if (this.txtBalance.val() == 0) {

                if (this.hidDocCode.val() == 'A302') {
                    $('#myForm').submit();
                } else {
                    $('.payment-col a,.discount-col a').addClass('not-active-finish');
                    this.blueCardModal.modal();
                }

            }

            //}
        }
    }, {
        key: 'otherDiscount',
        value: function otherDiscount(newDiscount) {
            var extraDiscount = +this.txtExtraDiscount.val();
            extraDiscount += +newDiscount;
            this.txtExtraDiscount.val(extraDiscount.toFixed(2));
            this.setTotal();
        }
    }, {
        key: 'processDiscount',
        value: function processDiscount(newDiscount) {
            var totalDiscount = +this.txtTotalDiscount.val();
            totalDiscount += +newDiscount;
            this.txtTotalDiscount.val(totalDiscount.toFixed(2));
            this.setTotal();
        }
    }, {
        key: 'addExtraDiscount',
        value: function addExtraDiscount(name, bath, percent, code, _CouponId, _CouponCode) {
            if ($('a[title="' + name + '"]').hasClass('not-active')) return;
            var me = this;
            var money = 0;
            if (bath && bath > 0) {
                money = +bath;
            } else {
                money = (+this.txtPaymentMoney.val() * percent / 100).toFixed(2); //+(((+this.txtTotalAmount.val() / (1 + 0.07)) * percent / 100).toFixed(2))
            }
            var type = "";
            if (_CouponId != "") {
                type = "coupon";
            }

            $.get(me.addDiscountUrl, {
                name: name,
                Code: code,
                DocNo: me.hidDocNo.val(),
                DocCode: me.hidDocCode.val(),
                ReferenceNo: me.hidRefDocNo.val(),
                Money: money,
                CouponId: _CouponId,
                CouponCode: _CouponCode,
                CustTypeCode: me.hidCustTypeCode.val()
            }).done(function (resp) {
                if (!resp.Data) {
                    alert(resp.Data);
                    return;
                }

                //me.txtTotalNumber.val(+me.txtTotalNumber.val() + 1)
                money = money > +me.txtBalance.val() ? +me.txtBalance.val() : money;

                me.dtDiscounds.row.add({
                    'name': name,
                    'type': type,
                    'number': 1,
                    'money': money,
                    'id': resp.Data
                }).draw();

                var indexes = me.dtDiscounds.rows().eq(0).filter(function (rowIdx) {
                    return me.dtDiscounds.cell(rowIdx, 0).data() === '' ? true : false;
                });

                me.dtDiscounds.rows(indexes).remove().draw();

                var dtDiscoundData = me.dtDiscounds.rows().data();
                for (var i = dtDiscoundData.length; i < 3; i++) {
                    me.dtDiscounds.row.add({
                        'name': '',
                        'type': type,
                        'number': '',
                        'money': '',
                        'id': ''
                    }).draw();
                }
                //   if (name == "ส่วนลดอื่นๆ") me.otherDiscount(money); else me.processDiscount(money);
                if (_CouponId != "") me.processDiscount(money); else me.otherDiscount(money);

                $('a[title="' + name + '"]').addClass('not-active');
            });
        }
    },
    {
        key: 'addBlank',
        value: function addBlank() {
            var me = this;

            var indexes = me.dtPayment.rows().eq(0).filter(function (rowIdx) {
                return me.dtPayment.cell(rowIdx, 1).data() === '' ? true : false;
            });
            this.dtPayment.rows(indexes).remove().draw();

            var currentData = me.dtPayment.rows().data();

            for (var i = currentData.length; i < 1; i++) {
                me.dtPayment.row.add({
                    'id': '',
                    'paymentType': '',
                    'money': '',
                    'number': '',
                    'note': '',
                    'options': '',
                    'modalName': '',
                    'apprCode': '',
                    'bank': '',
                    'payFormat': '',
                    'cardType': '',
                    'crMonth': '',
                    'crYear': ''
                }).draw();
            }

            this.setTotalPaymentAmount();
        }
    },

    {
        key: 'UseCoupon',
        value: function UseCoupon() {
            var me = this;
            $('#CouponCode').keyup(function (e) {
                if ($(this).val().length > 0) {
                    if (e.keyCode === 13) {
                        $('#btnCheckCoupon').click();
                    }
                    $('#btnCheckCoupon').prop("disabled", false);
                } else {
                    $('#btnCheckCoupon').prop("disabled", true);
                }
            });
            $("#ID_creditEdcModal").removeAttr("href");

            $("#ID_creditEdcModal").click(function () {
                var doc_no = me.hidDocNo.val();
                var doc_code = me.hidDocCode.val();
                var doc_no2 = me.hidRefDocNo.val();
                var money = me.txtPaymentMoney.val();
                var base_url = window.location.origin;

                var port = ":" + location.port;
                var Url = base_url.replace(port, "");
                var Url1 = me.clientUrl + "/EDC_payment_index.asp?allparams=docno_" + doc_no + "__doccode_" + doc_code + "__docno2_" + doc_no2 + "__Money_" + money;

                // var winFeature =    'location=no,toolbar=no,menubar=no,scrollbars=yes,resizable=yes';            
                var _url = me.CheckEdcStatusUrl;
                //=====set flag edc = 1 =======
                var _data = { DocCode: doc_code, DocNo: doc_no2, Url: Url1 };
                $.ajax({
                    type: "POST",
                    url: _url,
                    data: _data,
                    beforeSend: function beforeSend() {
                        $('#loaderDiv').show();
                    },
                    success: function success(result) {

                        console.log(result);
                        $('#loaderDiv').hide();
                        if (result.Data == 1) {
                            //==== if set edc complete ====//
                            me.TimerStart.click();

                            location.href = "ie:" + Url1;

                            //$('#modalEdcCheck').modal({
                            //    backdrop: 'static',
                            //    keyboard: false
                            //});
                            //$("#modalEdcCheck").modal("show");
                        } else if (result.Data == 2) {
                            alert("หน้าต่าง EDC ถูกเปิดอยู่ กรุณาทำรายการ หรือยกเลิกรายการ"); location.reload();
                        }

                    },
                    error: function (e) {

                        console.log("There was an error with your request...");
                        console.log("error: " + JSON.stringify(e));
                    }
                });

            });
            $("#btnCloseModalEdc").click(function () {
                me.TimerStop.click();
                me.TimerReset.click();
                location.reload();
            });
            $('#btnCheckCoupon').on("click", function () {


                var _couponCode = $('#CouponCode').val();
                var _url = me.getCheckCouponUrl;
                var _data = { CouponCode: _couponCode, DocNo: me.hidRefDocNo.val() };
                $.ajax({
                    type: "GET",
                    url: _url,
                    data: _data,
                    beforeSend: function beforeSend() {
                        $('#loaderDiv').show();
                    },
                    success: function success(result) {
                        $('#loaderDiv').hide();

                        if (result.Coupon == "False") {
                            warningAlert("ไม่สามารถเชื่อมต่อ HQ ได้");
                            $('#CouponCode').val("");

                        } else if (result.Coupon.PromotionCode == null) {
                            warningAlert("รหัสคูปองไม่ถูกต้อง");
                        } else {
                            if (result.Coupon.CanUseCoupon == "true") {
                                me.addExtraDiscount(result.Coupon.PromotionName, result.Coupon.DiscountAmount, result.Coupon.DiscountPercen, result.Coupon.PromotionCode, "", _couponCode);
                                $('#PartialCoupon').modal('toggle');
                            } else {
                                warningAlert("ไม่สามารถใช้คูปองนี้ได้");
                            }

                        }

                    }
                });
            });
            $('#PartialCoupon').on('shown.bs.modal', function () {
                $('#CouponCode').val("");
                $('#CouponCode').focus();
                $('#CouponCode').click();

            });
            $('#PartialCoupon').on('hidden.bs.modal', function () {
                $('#CouponCode').val("");
            });
        }
    }
        ,
    {
        key: 'SetModalCouponDigit',
        value: function SetModalCouponDigit(Name, Baht, Percents, Code, CouponId, PassDigit) {
            $('#CouponName').val(Name);
            $('#PromotionCode').val(Code);
            $('#CouponId').val(CouponId);
            $('#CouponBath').val(Baht);
            $('#CouponPercent').val(Percents);
            $('#CouponDigit').val(PassDigit);
            $('#txtCouponDigit').val('');

            $('#PassCouponDigit').modal('show');

        }
    }



    ]);

    return PaymentForm;
}();

