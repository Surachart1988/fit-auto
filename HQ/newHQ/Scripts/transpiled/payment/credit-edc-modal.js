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
        this.txtApprCode = $('#txtApprCode');
        this.ddBank = $('#ddBank');
        this.ddPaymentFormat = $('#ddPaymentFormat');
        this.ddCardType = $('#ddCardType');
        this.txtPaymentCreditEdc = $('#txtPaymentCreditEdc');
        this.btnReceiveMoney = $('#btnEdcReceiveMoney');
        this.txtNote = $('#txtEdcNote');
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.indexForm = null;

        this.addUrl = null;
        this.updateUrl = null;
        this.deleteUrl = null;
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

            this.btnReceiveMoney.click(function () {
                var paymentAmount = +me.txtPaymentCreditEdc.val();
                me.indexForm.setTotal();
                var id = '';
                if (me.indexForm.status == 'edit') {
                    id = me.indexForm.id;
                }
                me.addRowToDt(id, me.modalName, paymentAmount, me.txtCreditNumber.val(), me.txtNote.val(), me.txtCreditMonth.val(), me.txtCreditYear.val(), me.txtApprCode.val(), me.ddBank.val(), me.ddCardType.val(), me.ddPaymentFormat.val());
            });

            me.isValid();
            $('#creditEdcModal input').change(function () {
                me.isValid();
            });
        }
    }, {
        key: 'isValid',
        value: function isValid() {
            var check = this.txtCreditNumber.val().length != 19 || this.txtApprCode.val().length != 6 || this.txtPaymentCreditEdc.val() == 0;
            this.btnReceiveMoney.prop("disabled", check);
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