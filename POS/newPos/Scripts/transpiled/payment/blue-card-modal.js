'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var BlueCardModal = function () {
    function BlueCardModal() {
        _classCallCheck(this, BlueCardModal);

        this.modalName = "Redeem Blue Card";
        this.txtBalance = $('#txtBalance');
        this.hidBlueCardNo = $('#BlueCardNo');
        this.hidBlueCardCode = $('#BlueCardCode');
        this.hidBlueCardMoney = $('#BlueCardMoney');
        this.hidBlueCardUsePoint = $('#BlueCardUsePoint');

        this.blueCardRedeemModal = $('#blueCardRedeemModal');
        this.btnReceiveMoney = $('#btnBlueCardReceiveMoney');
        this.txtNote = $('#txtBlueCardNote');
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');

        this.hidMIN_Redeem_Point = $('#MIN_Redeem_Point');
        this.hidRatio_Point = $('#Ratio_Point');

        this.txtBlueCardNo = $('#txtBlueCardNo');
        this.txtBlueCardMobile = $('#txtBlueCardMobile');
        this.txtBalancePoint = $('#txtBalancePoint');
        this.txtUsePoint = $('#txtUsePoint');
        this.txtBlueCardMoney = $('#txtBlueCardMoney');
        this.lblBlueCardMobileRedeemIsValid = $('#lblBlueCardMobileRedeemIsValid');
        this.lblBlueCardUsePointRedeemIsValid = $('#lblBlueCardUsePointRedeemIsValid');
        this.lblBlueCardUsePointRedeemIsMinPointValid = $('#lblBlueCardUsePointRedeemIsMinPointValid');
        this.txtBlueCardCode = $('#txtBlueCardCode');
        this.CancelCashReceive = $('#CancelCashReceive');
        this.indexForm = null;
        this.getPointBalanceUrl = null;
        this.redeemPointUrl = null;
        this.addUrl = null;
        this.dtPaymentPaymentList = $('#payment-list');
        this.blueCardSaveModal = $('#blueCardSaveModal');
        this.txtBlueCardSaveName = $('#txtBlueCardSaveName');
        this.txtBlueCardSaveNo = $('#txtBlueCardSaveNo');
        this.hidBlueCardSaveNo = $('#BlueCardSaveNo');
        this.hidBlueCardSaveMobile = $('#BlueCardSaveMobile');
        this.txtBlueCardBalancePoint = $('#txtBlueCardBalancePoint');
        this.txtBlueCardSaveTel = $('#txtBlueCardSaveTel');
        this.lblBlueCardSaveIsValid = $('#lblBlueCardSaveIsValid');
        this.btnSave = $('#btnBlueCardSave');
        this.btnClose = $('#btnClose');
        this.getUrl = null;
        this.getUrl2 = null;
        this.urlPrintReport = null;
        this.txtTotalAmount = $('#TotalAmount');
    }

    _createClass(BlueCardModal, [{
        key: 'init',
        value: function init() {
            var me = this;

            this.blueCardRedeemModal.on('shown.bs.modal', function () {
                me.txtBlueCardSaveTel.focus();
            });

            this.blueCardRedeemModal.on('hidden.bs.modal', function () {
                me.txtBlueCardNo.val('');
                me.txtBalancePoint.val('');
                me.txtUsePoint.val('');
                me.txtBlueCardMoney.val('');
                me.txtNote.val('');
                me.txtBlueCardCode.val('');
            });

            this.blueCardSaveModal.on('shown.bs.modal', function () {
                me.txtBlueCardSaveTel.focus();
                me.btnSave.prop("disabled", !me.txtBlueCardSaveNo.val());
            });

            this.blueCardSaveModal.on('hidden.bs.modal', function () {
                me.txtBlueCardSaveTel.val('');
                me.txtBlueCardSaveNo.val('');
            });

            this.CancelCashReceive.on("click", function () {

                confirmAlert("ต้องการยกเลิกการรับชำระ?", function (event) {
                    if (!event) {

                        $('#PaymentAmount').val('0')
                        $('#ChangeMoney').val('0');
                        $('#CashAmount').val('0');
                        $('#txtBalance').val($('#txtPaymentMoney').val());
                        $('#blueCardSaveModal').modal('hide');
                        $('body').removeClass('modal-open');
                        $('.modal-backdrop').remove();

                    } else {

                    }
                });



            });

            //this.inputMobile = new Cleave('.input-mobile', {
            //    phone: true,
            //    phoneRegionCode: 'TH',
            //    delimiter: '-'
            //});

            //this.inputMobileSave = new Cleave('.input-mobile-save', {
            //    phone: true,
            //    phoneRegionCode: 'TH',
            //    delimiter: '-'
            //});

            //this.inputCard = new Cleave('.input-card', {
            //    blocks: [4, 4, 4, 4],
            //    numericOnly: true,
            //    uppercase: true,
            //    delimiter: '-'
            //});

            this.inputCardSave = new Cleave('.input-card-save', {
                blocks: [4, 4, 4, 4],
                numericOnly: true,
                uppercase: true,
                delimiter: '-'
            });

            this.inputBalancePoint = new Cleave('.input-balance-point', {
                numeral: true,
                numeralThousandsGroupStyle: 'thousand'
            });

            this.lblBlueCardMobileRedeemIsValid.hide();
            this.txtBlueCardMobile.keyup(function () {
                me.lblBlueCardMobileRedeemIsValid.hide();
                me.txtBalancePoint.val('');
                me.txtUsePoint.prop('readonly', true).val('');
                //   me.txtBlueCardMoney.prop('readonly', true).val('');
                //   me.txtBlueCardCode.prop('readonly', true).val('');
                //   me.txtBlueCardNo.prop('readonly', true).val('');
                if ($(this).val().length > 10 && $(this).val().indexOf('-') < 0) {
                    me.lblBlueCardMobileRedeemIsValid.show();
                } else if ($(this).val().length == 12 && $(this).val().indexOf('-') == 3) {
                    var _phone = me.inputMobile.getRawValue();
                    me.getPointBalance(_phone, '');
                } else {
                    //   me.txtBlueCardNo.prop('readonly', false);
                }
            });

            var pointBalanceTime;
            this.txtBlueCardNo.keyup(function () {

                me.txtBalancePoint.val('');
                //    me.txtUsePoint.prop('readonly', true).val('');
                //    me.txtBlueCardMoney.prop('readonly', true).val('');
                //   me.txtBlueCardMobile.prop('readonly', true).val('');
                //   me.txtBlueCardCode.prop('readonly', true).val('');
                if ($(this).val().length == 19 && $(this).val().indexOf('-') == 4) {
                    pointBalanceTime && clearTimeout(pointBalanceTime);
                    var _cardNo = me.inputCard.getRawValue();
                    pointBalanceTime = setTimeout(function () {
                        me.getPointBalance('', _cardNo);
                    }, 200);
                } else {
                    //  me.txtBlueCardMobile.prop('readonly', false);
                }
            });

            this.btnReceiveMoney.prop('disabled', true);
            //$('#blueCardRedeemModal .modal-body input').keyup(function () {
            //    var empty = $('#blueCardRedeemModal .modal-body input').not(document.getElementById("txtBlueCardMobile")).filter(function () {
            //        return this.value === "";
            //    });
            //    setTimeout(function () {
            //        return me.btnReceiveMoney.prop('disabled', empty.length || $('.invalid').is(":visible"));
            //    }, 100);
            //});

            this.lblBlueCardUsePointRedeemIsValid.hide();
            this.txtUsePoint.keyup(function () {
                me.lblBlueCardUsePointRedeemIsValid.hide();
                me.lblBlueCardUsePointRedeemIsMinPointValid.hide();
                var txtUsePoint = +me.txtUsePoint.val();
                var Ratio_Point = +me.hidRatio_Point.val();
                if (+me.inputBalancePoint.getRawValue() < txtUsePoint) {
                    me.lblBlueCardUsePointRedeemIsValid.show();
                    me.btnReceiveMoney.prop('disabled', true);
                } else {
                    if (+me.hidMIN_Redeem_Point.val() > txtUsePoint) {
                        me.lblBlueCardUsePointRedeemIsMinPointValid.show().text('Min Redeem Point = ' + me.hidMIN_Redeem_Point.val());
                    } else {
                        me.txtBlueCardMoney.val(txtUsePoint * Ratio_Point);
                        if (+me.txtBlueCardMoney.val() > 0) {
                            me.btnReceiveMoney.prop('disabled', false);
                        } else {
                            me.btnReceiveMoney.prop('disabled', true);
                        }
                    }
                }


            });

            this.btnReceiveMoney.click(function () {
                me.addRowToDt(me.modalName, me.inputCard.getRawValue(), me.txtBlueCardMoney.val(), me.txtNote.val(), me.txtUsePoint.val(), me.txtBlueCardCode.val());
            });

            //this.lblBlueCardSaveIsValid.hide();
            //this.btnSave.prop("disabled", true);
            //this.txtBlueCardSaveTel.keyup(function (e) {
            //    me.lblBlueCardSaveIsValid.hide();
            //    me.txtBlueCardSaveNo.val('');
            //    me.hidBlueCardSaveNo.val('');
            //    if ($(this).val().length > 10 && $(this).val().indexOf('-') < 0) {
            //        me.lblBlueCardSaveIsValid.show();
            //    } else if ($(this).val().length == 12) {
            //        var _phone2 = me.inputMobileSave.getRawValue();
            //        me.getBlueCardNo(_phone2);
            //    }
            //});

            this.txtBlueCardSaveNo.change(function (e) {
                if ($(this).val().length == 19 || $(this).val().indexOf('-') == 4) {
                    me.hidBlueCardSaveNo.val(me.inputCardSave.getRawValue());
                    me.btnSave.prop("disabled", false);
                } else {
                    me.hidBlueCardSaveNo.val('');
                    me.btnSave.prop("disabled", true);
                }
                me.checkBlueCardActivated(me.inputCardSave.getRawValue());
                
            });
        }

        //getBlueCardNo(phone) {
        //    const me = this
        //    this.hidBlueCardSaveMobile.val(phone)
        //    $.get(me.getUrl, { phoneNumber: phone }, (resp) => {
        //        if (resp.Code != "00") {
        //            warningAlert(resp.Message)
        //            me.txtBlueCardSaveNo.val('')
        //            me.hidBlueCardSaveNo.val('')
        //            me.btnSave.prop("disabled", true)
        //        }
        //        else {
        //            me.inputCardSave.setRawValue(resp.Data)
        //            me.hidBlueCardSaveNo.val(resp.Data)
        //            me.btnSave.prop("disabled", false)
        //        }

        //        console.log(resp)
        //    })
        //}

    }, {
        key: 'checkBlueCardActivated',
        value: function checkBlueCardActivated(cardno) {
            var me = this;

            $.ajax({
                type: "GET",
                url: me.getUrl2,
                data: { cardnumber: cardno },
                beforeSend: function beforeSend() {
                    $("#loaderDiv").show();
                },
                success: function success(resp) {
                    if (resp.Code != "00") {
                        warningAlert(resp.Message);
                        me.btnSave.prop("disabled", true);
                    } else {
                        $('#myForm').submit();
                    }

                    $("#loaderDiv").hide();
                }
            });
        }
    },
    {
        key: 'getBlueCardNo',
        value: function getBlueCardNo(phone) {
            var me = this;
            this.hidBlueCardSaveMobile.val(phone);
            //  alert("getBlueCardNo");
            $.ajax({
                type: "GET",
                url: me.getUrl,
                data: { phoneNumber: phone },
                beforeSend: function beforeSend() {
                    $("#loaderDiv").show();
                },
                success: function success(resp) {
                    if (resp.Code != "00") {
                        warningAlert(resp.Message);
                        me.txtBlueCardSaveNo.val('');
                        me.hidBlueCardSaveNo.val('');
                        me.btnSave.prop("disabled", true);
                    } else {
                        me.inputCardSave.setRawValue(resp.Data);
                        me.hidBlueCardSaveNo.val(resp.Data);
                        me.btnSave.prop("disabled", false);
                    }

                    $("#loaderDiv").hide();
                }
            });
        }
    }, {
        key: 'getPointBalance',
        value: function getPointBalance(phone, cardNo) {
            var me = this;


            $.ajax({
                type: "GET",
                url: me.getPointBalanceUrl,
                data: { phoneNumber: phone, cardNo: cardNo },
                beforeSend: function beforeSend() {
                    $("#loaderDiv").show();
                },
                success: function success(resp) {
                    if (resp.Code != "00") {
                        warningAlert(resp.Message);
                    } else {
                        me.inputBalancePoint.setRawValue(resp.Data.pointBalance);
                        me.inputCard.setRawValue(resp.Data.cardNo);
                        me.hidMIN_Redeem_Point.val(resp.Data.MinRedeemPoint);
                        me.hidRatio_Point.val(resp.Data.RatioPoint);
                        me.txtUsePoint.prop('readonly', false).val('');
                        me.txtBlueCardMoney.val('');
                        me.txtBlueCardCode.prop('readonly', false).val('');

                    }
                    $("#loaderDiv").hide();
                }
            });

            //$.get(me.getPointBalanceUrl, { phoneNumber: phone, cardNo: cardNo }, function (resp) {
            //    if (resp.Code != "00") {
            //        warningAlert(resp.Message);
            //    } else {
            //        me.inputBalancePoint.setRawValue(resp.Data.pointBalance);
            //        me.inputCard.setRawValue(resp.Data.cardNo);
            //        me.txtUsePoint.prop('readonly', false);
            //        me.txtBlueCardMoney.prop('readonly', false);
            //        me.txtBlueCardCode.prop('readonly', false);
            //    }

            //    console.log(resp);
            //});


        }
    }, {
        key: 'receiveMoney',
        value: function receiveMoney() {
            var me = this;
            $.get(me.getPointBalanceUrl, { phoneNumber: phone, cardNo: cardNo }, function (resp) {
                if (resp.Code != "00") {
                    warningAlert(resp.Message);
                } else {
                    me.inputBalancePoint.setRawValue(resp.Data);
                }

                console.log(resp);
            });
        }
    }, {
        key: 'addRowToDt',
        value: function addRowToDt(paymentType, cardNo, money, note, usePoint, code) {
            var me = this;

            me.hidBlueCardNo.val(cardNo);
            me.hidBlueCardCode.val(code);
            me.hidBlueCardMoney.val(money);
            me.hidBlueCardUsePoint.val(usePoint);
            me.inputCardSave.setRawValue(cardNo);
            me.hidBlueCardSaveNo.val(cardNo);

            var data = {
                paymentType: paymentType,
                note: note
            };

            var formValues = FormSerialize.getFormArray(me.indexForm.myForm, data);

            $.ajax({
                type: "POST",
                url: me.addUrl,
                data: formValues,
                beforeSend: function beforeSend() {
                    $("#loaderDiv").show();
                },
                success: function success(resp) {
                    if (resp.Code != "00") {
                        warningAlert(resp.Message)
                        $("#loaderDiv").hide();
                        return
                    }

                    me.indexForm.dtPayment.row.add({
                        'id': resp.Data,
                        'paymentType': paymentType,
                        'money': money,
                        'number': cardNo,
                        'note': note,
                        'options': 'delete',
                        'modalName': 'blueCardModal',
                        'apprCode': '',
                        'bank': '',
                        'payFormat': '',
                        'cardType': '',
                        'crMonth': '',
                        'crYear': ''
                    }).draw();


                    //  me.indexForm.addBlank();
                    $('a[title="' + paymentType + '"]').addClass('not-active');
                    me.indexForm.setTotalPaymentAmount();
                    $("#loaderDiv").hide();

                    me.blueCardRedeemModal.modal('toggle');
                }
            });


            //$.post(me.addUrl, formValues).done(function (resp) {

            //});
        }
    }]);

    return BlueCardModal;
}();