'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }



var CreditEdcModal = function () {
    function CreditEdcModal() {
        _classCallCheck(this, CreditEdcModal);

        this.modalName = "เครดิตการ์ด";
        this.txtCreditMonth = $('#txtCreditMonth');
        this.txtCreditYear = $('#txtCreditYear');
        this.txtBalance = $('#txtBalance');
        this.crModal = $('#creditEdcModal');
        this.txtCreditNumber = $('#txtCreditEdcNumber');
        this.txtApprCode = $('#txtApprCodeEdc');
        this.ddBank = $('#ddBank');
        this.ddPaymentFormat = $('#ddPaymentFormat');
        this.ddCardType = $('#ddCardType');
        this.txtPaymentCreditEdc = $('#txtPaymentCreditEdc');
        this.btnReceiveMoney = $('#btnEdcReceiveMoney');
        this.txtNote = $('#txtEdcNote');
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.indexForm = null;
        this.portNo = null;
        this.addUrl = null;
        this.updateUrl = null;
        this.deleteUrl = null;
        this.urlGetTextPostCardEDC = null;

        this.urlSavePaymentEDC = null;
        this.urlProcessEdc = null;
        this.urlAddEdcReceive = null;
        this.urlGetEdcReceive = null;

        this.txtPaymentAmount = $('#txtPaymentMoney');

    }

    _createClass(CreditEdcModal, [{
        key: 'init',
        value: function init() {
            var me = this;

            this.crModal.on('shown.bs.modal', function () {
             
                if (me.indexForm.status == 'add') {
                    me.txtPaymentCreditEdc.val(me.txtBalance.val());
                    me.txtCreditNumber.val('');
                    me.txtApprCode.val('');
                    me.ddBank.val('');
                    me.ddPaymentFormat.val('');
                    me.ddCardType.val('');
                    me.txtNote.val('');
                } else me.txtPaymentCreditEdc.val(me.indexForm.moneyBalance);
            });

            this.crModal.on('hidden.bs.modal', function () {
                me.indexForm.status = 'add';
                me.indexForm.setTotal();
            });

            this.txtPaymentCreditEdc.keyup(function () {
                if (+ $(this).val() < +me.txtBalance) {
                    me.btnReceiveMoney.prop("disable", true);
                } else {
                    me.btnReceiveMoney.prop("disable", false);
                }
            });

            this.btnReceiveMoney.click(function () {
               // $('#loaderDiv').show();
               

                var paymentAmount = me.txtPaymentCreditEdc.val();
                var _vCode = me.hidDocNo.val().substring(me.hidDocNo.length - 4, 4);
               // var _vCode = me.hidDocNo.val();
                $.ajax({
                    type: "POST",
                    url: me.urlAddEdcReceive,
                    async: true,
                    data: {
                        PortNo: me.portNo,
                        Amount: paymentAmount,
                        ProCode: _vCode,
                        DocNo: me.hidDocNo.val()
                    }
                    , success: function (result) {
                        // open EDC Popup IE Tab for suport Chorme
                        if (result == "Success") {
                            //  var urlProcessEdc = me.urlProcessEdc;
                            me.PopupCenter(me.urlProcessEdc, "EDC Connect Process", 500, 400);

                            $.get(me.urlGetEdcReceive, { status: "1" }, function (result) {
                             
                                if (result.data == null || result.data == "") {
                                    warningAlert("ยกเลิกเชื่อมต่อ EDC");
                                } else if (result.data.Status == false) {
                                    warningAlert("ยกเลิกการรับชำระ");
                                } else {
                                    me.ConnectEDCForIE(paymentAmount, _vCode, me.portNo, me.hidDocCode.val(), me.hidDocNo.val(), me.ddPaymentFormat.val(), me.txtNote.val(), result.data.receive_edc);
                                }
                            });

                        } else {
                            warningAlert("ไม่สามารถเชื่อมต่อได้");
                        }
                    }
                });

             
                       
                  

                   // me.ConnectEDCForIE(paymentAmount, _vCode, me.portNo, me.hidDocCode.val(), me.hidDocNo.val(), me.ddPaymentFormat.val(), me.txtNote.val());
                //SendP(paymentAmount, _vCode, 1, paymentAmount, me.PortNo);
                 // ------------------------------------- EDC Connect  Chorme ---------------------------------------------------------
                //  me.ConnectEDC(paymentAmount, _vCode)
             //   me.ConnectEDC(paymentAmount, _vCode, me.hidDocCode.val(), me.hidDocNo.val(), me.ddPaymentFormat.val(), me.txtNote.val());

            });

            me.isValid();
            $('#creditEdcModal input').change(function () {
                me.isValid();
            });
        }
    },
        {
            key: 'checkChild',
            value: function checkChild() {
                if (child.closed) {
                    alert("Child window closed");
                    clearInterval(timer);
                }
            }
        },
        {
            key: 'PopupCenter',
            value: function PopupCenter(url, title, w, h) {
                // Fixes dual-screen position                         Most browsers      Firefox
                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : window.screenX;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : window.screenY;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var systemZoom = width / window.screen.availWidth;
                var left = (width - w) / 2 / systemZoom + dualScreenLeft
                var top = (height - h) / 2 / systemZoom + dualScreenTop

                 window.open(url, null, 'scrollbars=no,resizable=no,status=no,location=no,toolbar=no,menubar=no,toolbar=no, width=' + w / systemZoom + ', height=' + h / systemZoom + ', top=' + top + ', left=' + left);
             //   var timer = setInterval(checkChild, 500);
                // Puts focus on the newWindow
              //  if (window.focus) newWindow.focus();
            }
        }
    ,
        {
            key: 'ConnectEDCForIE',
            //value: function ConnectEDCForIE(paymentAmount, _vCode, PortNo, hidDocCode, hidDocNo, ddPaymentFormat, txtNote) {
            value: function ConnectEDCForIE(paymentAmount, _vCode, PortNo, hidDocCode, hidDocNo, ddPaymentFormat, txtNote, TextReciveEDC) {
                //SendP(vAmount, vCode, vVolume, vPrice, PortNo)
              // var TextReciveEDC = SendP(paymentAmount, _vCode, 1, paymentAmount, PortNo);
                var URL = this.urlSavePaymentEDC;
                            var _data = {
                                TxtData: TextReciveEDC,
                                DocCode: hidDocCode,
                                DocNo: hidDocNo,
                                PaymentFormatId: ddPaymentFormat,
                                Note: txtNote
                            }
                            $.ajax({
                                type: "POST",
                                url: URL,
                                data: _data,
                                beforeSend: function beforeSend() {
                                     $('#loaderDiv').show();
                                },
                                success: function success(result) {
                                    $('#loaderDiv').hide();

                                    if (!result.message) {

                                        //  me.txtPaymentCreditEdc.val(result.data.PaymentCr);
                                        me.txtCreditNumber.val(result.data.CreditNumber);
                                        me.txtCreditMonth.val(result.data.S_ExpiredMonth);
                                        me.txtCreditYear.val(result.data.S_ExpiredYear);
                                        me.txtApprCode.val(result.data.ApprCode);
                                        // me.ddBank.val();
                                        // me.ddPaymentFormat.val();

                                        me.ddCardType.val(result.data.CardTypeCode);
                                        var receive = +parseFloat(me.txtPaymentCreditEdc.val().replace(",", ""));
                                        var balance = +parseFloat(me.txtPaymentAmount.val().replace(",", ""));

                                        if ((balance - receive) <= 0) {
                                            me.txtPaymentAmount.val(balance - receive);

                                            $('#creditEdcModal').modal('hide');
                                            $('body').removeClass('modal-open');
                                            $('.modal-backdrop').remove();
                                            $('#blueCardSaveModal').modal();

                                        }
                                    } else {
                                        warningAlert(result.message);
                                    }
                                }
                            });
                
            }
        },
        {
            key: 'ConnectEDC',
            value: function ConnectEDC(paymentAmount, _vCode, hidDocCode, hidDocNo, ddPaymentFormat, txtNote) {

                var TextReciveEDC = GetTextPost(paymentAmount, _vCode, 1, paymentAmount);
                //  alert(TextReciveEDC);
                var _dataEDC = {
                    PortNo: 'COM5',
                    TextPost: TextReciveEDC
                }

                $.ajax({
                    type: "POST",
                    url: '/EDCReader/SentToEDCCreditCard',
                    data: _dataEDC,
                    beforeSend: function beforeSend() {
                        $('#loaderDiv').show();
                    },
                    success: function success(result) {

                        if (result.seccess) {

                            var _data = {
                                TxtData: result.receiveText,
                                DocCode: hidDocCode,
                                DocNo: hidDocNo,
                                PaymentFormatId: ddPaymentFormat,
                                Note: txtNote
                            }
                            $.ajax({
                                type: "POST",
                                url: '/Payment/SavePaymentCardEDC',
                                data: _data,
                                beforeSend: function beforeSend() {
                                    //  $('#loaderDiv').show();
                                },
                                success: function success(result) {
                                    $('#loaderDiv').hide();

                                    if (!result.message) {

                                        //  me.txtPaymentCreditEdc.val(result.data.PaymentCr);
                                        me.txtCreditNumber.val(result.data.CreditNumber);
                                        me.txtCreditMonth.val(result.data.S_ExpiredMonth);
                                        me.txtCreditYear.val(result.data.S_ExpiredYear);
                                        me.txtApprCode.val(result.data.ApprCode);
                                        // me.ddBank.val();
                                        // me.ddPaymentFormat.val();

                                        me.ddCardType.val(result.data.CardTypeCode);
                                        var receive = +parseFloat(me.txtPaymentCreditEdc.val().replace(",", ""));
                                        var balance = +parseFloat(me.txtPaymentAmount.val().replace(",", ""));

                                        if ((balance - receive) <= 0) {
                                            me.txtPaymentAmount.val(balance - receive);

                                            $('#creditEdcModal').modal('hide');
                                            $('body').removeClass('modal-open');
                                            $('.modal-backdrop').remove();
                                            $('#blueCardSaveModal').modal();

                                        }
                                    } else {
                                        warningAlert(result.message);
                                    }
                                }
                            });

                        } else {
                            $('#loaderDiv').hide();
                            warningAlert(result.message);
                        }


                    }
                });

            }
        },
        {
        key: 'isValid',
        value: function isValid() {
            var check = this.txtCreditNumber.val().length != 19 || this.txtApprCode.val().length != 6 || this.txtPaymentCreditEdc.val() == 0;
          //  this.btnReceiveMoney.prop("disabled", check);
        }
    }, {
        key: 'addRowToDt',
        value: function addRowToDt(id, paymentType, money, number, note, expiredMonth, expiredYear, apprCode, bankCode, cardTypeCode, paymentFormatId) {
            var me = this;

            if (me.indexForm.status == 'edit') {
                var indexes = this.indexForm.dtPayment.rows().eq(0).filter(function (rowIdx) {
                    return me.indexForm.dtPayment.cell(rowIdx, 1).data() === me.modalName ? true : false;
                });

                this.indexForm.dtPayment.row(indexes).remove().draw();
            }
            $.get(me.addUrl, {
                Id: id,
                DocNo: me.hidDocNo.val(),
                DocCode: me.hidDocCode.val(),
                PaymentCr: money,
                CreditNumber: number,
                ExpiredMonth: expiredMonth,
                ExpiredYear: expiredYear,
                ApprCode: apprCode,
                BankCode: bankCode,
                CardTypeCode: cardTypeCode,
                CreditType: me.crType,
                PaymentFormatId: paymentFormatId,
                ConnectType: 'edc'
            }).done(function (resp) {
                if (!resp.Data) return;

                me.indexForm.dtPayment.row.add({
                    'id': resp.Data,
                    'paymentType': paymentType,
                    'money': money,
                    'number': number,
                    'options': 'delete',
                    'note': note,
                    'modalName': 'EdcModal',
                    'apprCode': '',
                    'bank': '',
                    'payFormat': '',
                    'cardType': '',
                    'crMonth': '',
                    'crYear': ''
                }).draw();

                me.indexForm.addBlank();
                me.crModal.modal('toggle');
            });
        }
    }]);

    return CreditEdcModal;
}();