'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var BlueCardModal = function () {
    function BlueCardModal() {
        _classCallCheck(this, BlueCardModal);

        this.modalName = "Redeem Blue Card";

        this.bluecardModal = $('#bluecard-modal');
        this.blueCardRedeemModal = $('#blueCardRedeemModal');
        this.btnReceiveMoney = $('#btnBlueCardReceiveMoney');
        this.txtBlueCardNo = $('#txtBlueCardNo');
        this.txtBlueCardMobile = $('#txtBlueCardMobile');
        this.txtBalancePoint = $('#txtBalancePoint');
        this.txtUsePoint = $('#txtUsePoint');
        this.txtBlueCardMoney = $('#txtBlueCardMoney');
        this.lblBlueCardMobileRedeemIsValid = $('#lblBlueCardMobileRedeemIsValid');
        this.lblBlueCardUsePointRedeemIsValid = $('#lblBlueCardUsePointRedeemIsValid');
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
        this.CheckRegisterBlueCardUrl = null;

        this.UrlRegisterBlueCard = null;
        this.inputThaiID = $('.input-thai-idcard');
        this.inputMobile = $('.input-mobile');
        this.inputCard = $('.input-blue-card');

        this.ReSendOrderBlueCardUrl = null;
        this.btnReSendOrderBlueCard = $('#btnReSendOrderBlueCard');
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
                me.txtBlueCardNo.prop('readonly', false).val('');
                me.txtBlueCardMobile.prop('readonly', false).val('');
                me.txtBalancePoint.val('');
                $('#bluecard').modal('toggle');
            });

            // ----------------------- Blue Card Resend --------------------

            this.btnReSendOrderBlueCard.click(function () {
                me.ReSendOrderBlueCard();
            });

            //---------------- blue card register -----------------------


            $('#btnConfirmBlueCardRegister').click(function () {
                confirmAlert("ยืนยันการสมัคร Blue Card ?", function (event) {
                    if (!event) {
                        var _data = $('form').serialize();

                        $.ajax({
                            type: "POST",
                            url: me.UrlRegisterBlueCard,
                            data: _data,
                            beforeSend: function beforeSend() {
                                $("#loaderDiv2").show();
                            },
                            success: function success(result) {
                                if (result.Code != "00") {
                                    warningAlert(result.Message);
                                } else {
                                    me.bluecardModal.modal('toggle');
                                    $('#bluecard').modal('toggle');
                                    successAlert(result.Message);
                                    $('.modal-backdrop').remove();
                                }

                                $("#loaderDiv2").hide();
                            }
                        });


                    }

                })
            });
            this.bluecardModal.on('hidden.bs.modal', function () {
                document.getElementById("register").reset();
                $('#bluecard').modal('toggle');
            });



            this.inputMobile = new Cleave('.input-mobile', {
                phone: true,
                phoneRegionCode: 'TH',
                delimiter: '-',
            });


            this.inputThaiID = new Cleave('.input-thai-idcard', {
                numericOnly: true,
                blocks: [1, 4, 7, 1],
                delimiters: ["-", "-", "-", ""]
            });
            this.inputCard = new Cleave('.input-blue-card', {
                blocks: [4, 4, 4, 4],
                numericOnly: true,
                uppercase: true,
                delimiter: '-'
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
                    }
                });
            });

            this.inputMobile = new Cleave('.input-mobileth', {
                phone: true,
                phoneRegionCode: 'TH',
                delimiter: '-',
            });



            this.inputCard = new Cleave('.input-card', {
                blocks: [4, 4, 4, 4],
                numericOnly: true,
                uppercase: true,
                delimiter: '-'
            });

            $('#ThaiIDCard').keyup(function () {

                if ($(this).val().length == 16 && $(this).val().indexOf('-') > 0) {

                    $.ajax({
                        type: "GET",
                        url: me.CheckRegisterBlueCardUrl,
                        data: { TypeCheck: 'ThaiID', IDCheck: $(this).val() },
                        beforeSend: function beforeSend() {
                            $("#loaderDiv").show();
                        },
                        success: function success(resp) {
                            if (resp.Success == true) {
                                $('#ThaiIDCardMarkSuccess').show()
                                $('#ThaiIDCardMarkFail').hide()
                                $('#ThaiIDCardCheck').val("True");
                                $('#MoblieNumber').prop("readonly", false);
                                me.validateBlueCardRegister();
                            } else {
                                $('#ThaiIDCardMarkSuccess').hide()
                                $('#ThaiIDCardMarkFail').show()
                                $('#ThaiIDCardCheck').val("False");
                                $('#MoblieNumber').prop("readonly", true);
                                warningAlert(resp.Message);
                            }

                            $("#loaderDiv").hide();
                        }
                    });



                } else {
                    $('#ThaiIDCardMarkSuccess').hide()
                    $('#ThaiIDCardMarkFail').hide()
                    $('#ThaiIDCardCheck').val("False");

                }
            });

            $('#MoblieNumber').keyup(function () {
                if ($(this).val().length == 12 && $(this).val().indexOf('-') > 0) {

                    $.ajax({
                        type: "GET",
                        url: me.CheckRegisterBlueCardUrl,
                        data: { TypeCheck: 'PhoneNumber', IDCheck: $(this).val(), ThaiID: $('#ThaiIDCard').val() },
                        beforeSend: function beforeSend() {
                            $("#loaderDiv").show();
                        },
                        success: function success(resp) {
                            if (resp.Success == true) {
                                $('#MoblieSuccess').show()
                                $('#MoblieFalil').hide()
                                $('#MoblieCardCheck').val("True");
                                me.validateBlueCardRegister();
                            } else {
                                $('#MoblieSuccess').hide()
                                $('#MoblieFalil').show()
                                $('#MoblieCardCheck').val("False");
                                warningAlert(resp.Message);
                            }

                            $("#loaderDiv").hide();
                        }
                    });

                } else {

                    $('#MoblieSuccess').hide()
                    $('#MoblieFalil').hide()
                    $('#MoblieCardCheck').val("False");
                }
            });
            $('#CardNumber').change(function () {
                if ($(this).val().length == 19 && $(this).val().indexOf('-') > 0) {
                    $.ajax({
                        type: "GET",
                        url: me.CheckRegisterBlueCardUrl,
                        data: { TypeCheck: 'BlueCardCode', IDCheck: $(this).val() },
                        beforeSend: function beforeSend() {
                            $("#loaderDiv").show();
                        },
                        success: function success(resp) {
                            if (resp.Success == true) {
                                $('#BlueCardSuccess').show()
                                $('#BlueCardFail').hide()
                                $('#CardNumberCheck').val("True");
                                me.validateBlueCardRegister();
                            } else {
                                $('#BlueCardSuccess').hide()
                                $('#BlueCardFail').show()
                                $('#CardNumberCheck').val("False");
                                warningAlert(resp.Message);
                            }

                            $("#loaderDiv").hide();
                        }
                    });
                } else {
                    $('#BlueCardSuccess').hide()
                    $('#BlueCardFail').hide()
                    $('#CardNumberCheck').val("False");


                }
            });

            this.txtBlueCardMobile.keyup(function () {
                me.lblBlueCardMobileRedeemIsValid.hide();
                me.txtBalancePoint.val('');
                me.txtUsePoint.prop('readonly', true).val('');
                //   me.txtBlueCardMoney.prop('readonly', true).val('');
                //  me.txtBlueCardCode.prop('readonly', true).val('');
                //    me.txtBlueCardNo.prop('readonly', true).val('');
                if ($(this).val().length > 10 && $(this).val().indexOf('-') < 0) {
                    me.lblBlueCardMobileRedeemIsValid.show();
                } else if ($(this).val().length == 12 && $(this).val().indexOf('-') == 3) {
                    var _phone = me.inputMobile.getRawValue();
                    me.getPointBalance(_phone, '');
                } else {
                    //     me.txtBlueCardNo.prop('readonly', false);
                }
            });

            this.txtBlueCardNo.change(function () {
                me.txtBalancePoint.val('');
                me.txtUsePoint.prop('readonly', true).val('');
                // me.txtBlueCardMoney.prop('readonly', true).val('');
                //  me.txtBlueCardMobile.prop('readonly', true).val('');
                //  me.txtBlueCardCode.prop('readonly', true).val('');
                if ($(this).val().length == 19 && $(this).val().indexOf('-') == 4) {
                    var _cardNo = me.inputCard.getRawValue();
                    me.getPointBalance('', _cardNo);

                } else {
                    //    me.txtBlueCardMobile.prop('readonly', false);
                }
            });
            this.txtBlueCardSaveTel.keyup(function (e) {
                me.lblBlueCardSaveIsValid.hide();
                me.txtBlueCardSaveNo.val('');
                me.hidBlueCardSaveNo.val('');
                if ($(this).val().length > 10 && $(this).val().indexOf('-') < 0) {
                    me.lblBlueCardSaveIsValid.show();
                } else if ($(this).val().length == 12) {
                    var _phone2 = me.inputMobileSave.getRawValue();
                    //  me.getBlueCardNo(_phone2);
                }
            });

            this.txtBlueCardSaveNo.keyup(function (e) {
                if ($(this).val().length == 19 || $(this).val().indexOf('-') == 4) {
                    me.hidBlueCardSaveNo.val(me.inputCardSave.getRawValue());
                    me.btnSave.prop("disabled", false);
                } else {
                    me.hidBlueCardSaveNo.val('');
                    me.btnSave.prop("disabled", true);
                }
            });
        }



    }, {
        key: 'validateBlueCardRegister',
        value: function validateBlueCardRegister() {
            debugger
            if ($('#ThaiIDCardCheck').val() == "True" && $('#CardNumberCheck').val() == "True" && $('#MoblieCardCheck').val() == "True") {
                $('#btnConfirmBlueCardRegister').prop("disabled", false)
            } else {
                $('#btnConfirmBlueCardRegister').prop("disabled", true)
            }

            // $('#btnConfirmBlueCardRegister').prop("disabled", false);
        }

    }, {
        key: 'formatNumber',
        value: function formatNumber(num) {
            return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
        }
    },
    {
        key: 'getBlueCardNo',
        value: function getBlueCardNo(phone) {
            var me = this;
            this.hidBlueCardSaveMobile.val(phone);
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

                        me.txtBalancePoint.val(me.formatNumber(resp.Data.pointBalance));
                        me.txtBlueCardNo.val(resp.Data.cardNo);

                    }
                    $("#loaderDiv").hide();
                }
            });


        }
    },
    {
        key: 'CheckRegisterBlueCard',
        value: function CheckRegisterBlueCard(_TypeCheck, _IDCheck) {
            var me = this;
            $.ajax({
                type: "GET",
                url: me.CheckRegisterBlueCardUrl,
                data: { TypeCheck: _TypeCheck, IDCheck: _IDCheck },
                beforeSend: function beforeSend() {
                    $("#loaderDiv").show();
                },
                success: function success(resp) {
                    if (resp.Code != "00") {
                        warningAlert(resp.Message);
                    } else {

                        me.txtBalancePoint.val(me.formatNumber(resp.Data.pointBalance));
                        me.txtBlueCardNo.val(resp.Data.cardNo);

                    }
                    $("#loaderDiv").hide();
                }
            });


        }
    }
        ,
    {
        key: 'ReSendOrderBlueCard',
        value: function ReSendOrderBlueCard() {
            var me = this;
            $.ajax({
                type: "GET",
                url: me.ReSendOrderBlueCardUrl,
                data: null,
                beforeSend: function beforeSend() {
                    $("#loaderDiv").show();
                },
                success: function success(resp) {
                    if (resp.Code != "00") {
                        warningAlert(resp.Message);
                    } else {
                        successAlert();
                        var count = +resp.CountNotSuccess;
                        //  $('#CountNotSuccess').val(count);
                        $('mark').text(count);
                        if (count == 0) {
                            me.btnReSendOrderBlueCard.prop('disabled', true);
                        } else {
                            me.btnReSendOrderBlueCard.prop('disabled', false);
                        }
                    }
                    $("#loaderDiv").hide();
                }
            });


        }
    }
    ]);

    return BlueCardModal;
}();