'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var CreditEdcModalPartial = function () {
    function CreditEdcModalPartial() {
        _classCallCheck(this, CreditEdcModalPartial);

        this.modalName = "เครดิตการ์ด";
        this.txtCreditMonth = $('#txtPartialCrediEdctMonth');
        this.txtCreditYear = $('#txtPartialCreditEdcYear');
        this.txtBalance = $('#txtPaymentBalance');

        this.crModal = $('#PartialcreditEdcModal');
        this.txtCreditNumber = $('#txtPartialCreditEdcNumber');
        this.txtApprCode = $('#txtPartialApprCodeEdc');
        this.ddBank = $('#ddPartialBankEdc');
        this.ddPaymentFormat = $('#ddPartialPaymentFormatEdc');
        this.ddCardType = $('#ddPartialCardTypeEdc');
        this.txtPaymentCreditEdc = $('#txtPartialPaymentCreditEdc');
        this.btnReceiveMoney = $('#btnPartialEdcReceiveMoney');
        this.txtNote = $('#txtPartialEdcNote');
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.hidRefDocNo = $('#RefDocNo');
        this.txtTotalAmount = $('#TotalAmount');
        this.indexForm = null;
        this.CheckEdcStatusUrl = null;
        this.addUrl = null;
        this.updateUrl = null;
        this.deleteUrl = null;
        this.clientUrl = null;

        this.TimerStart = $("#start");
        this.TimerStop = $("#stop");
        this.TimerReset = $("#reset");
    }

    _createClass(CreditEdcModalPartial, [{
        key: 'init',
        value: function init() {
            var me = this;
            this.clientUrl = $('#client-url').val()
            this.creditEdc();
            //this.crModal.on('hidden.bs.modal', function () {
            //   me.indexForm.status = 'add';
            //  me.indexForm.setTotal();
            //});

            //this.btnReceiveMoney.click(function () {
            //    var paymentAmount = +me.txtPaymentCreditEdc.val();
            //    me.indexForm.setTotal();
            //    var id = '';
            //    if (me.indexForm.status == 'edit') {
            //        id = me.indexForm.id;
            //    }
            //    me.addRowToDt(id, me.modalName, paymentAmount, me.txtCreditNumber.val(), me.txtNote.val(), me.txtCreditMonth.val(), me.txtCreditYear.val(), me.txtApprCode.val(), me.ddBank.val(), me.ddCardType.val(), me.ddPaymentFormat.val());
            //});

            //me.isValid();
            //$('#PartialcreditEdcModal input').change(function () {
            //    me.isValid();
            //});
        }
    },
    {
        key: 'isValid',
        value: function isValid() {
            var check = this.txtCreditNumber.val().length != 19 || this.txtApprCode.val().length != 6 || this.txtPaymentCreditEdc.val() == 0;
            this.btnReceiveMoney.prop("disabled", check);
        }
    },
    {
        key: 'creditEdc',
        value: function creditEdc() {
            var me = this;

            me.crModal.removeAttr("href");

            me.crModal.click(function () {
                var doc_no = me.hidDocNo.val();
                var doc_code = me.hidDocCode.val();
                var doc_no2 = me.hidRefDocNo.val();
                var money = me.txtBalance.val();
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

        }
    },
    {
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
    }
    ]);

    return CreditEdcModalPartial;
}();