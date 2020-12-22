'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var LazadaModal = function () {
    function LazadaModal() {
        _classCallCheck(this, LazadaModal);

        this.modalName = "LAZADA";
        this.dtPaymentPaymentList = $('#payment-list');
        this.txtBalance = $('#txtBalance');
        this.txtTotalAmount = $('#TotalAmount');
        this.txtPaymentAmount = $('#PaymentAmount');
        this.txtPaymentLazada = $('#txtPaymentLazada');
        this.txtReferenceLazadaNo = $('#txtReferenceLazadaNo');
        this.btnReceiveMoney = $('#btnLazadaReceiveMoney');
        this.lazadaModal = $('#lazadaModal');
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.myForm = $('#myForm');
        this.txtNote = $('#txtLazadaNote');

        this.indexForm = null;
        this.addUrl = null;
    }

    _createClass(LazadaModal, [{
        key: 'init',
        value: function init() {
            var me = this;

            this.txtNote.keyup(function (event) {
                if (event.keyCode === 13) {
                    me.btnReceiveMoney.click();
                }
            });

            this.btnReceiveMoney.click(function () {
                me.addRowToDt(me.modalName, me.txtPaymentLazada.val(), me.txtReferenceLazadaNo.val(), me.txtNote.val());
            });

            this.lazadaModal.on('shown.bs.modal', function () {
                me.txtPaymentLazada.val(me.txtBalance.val());
            });

            this.lazadaModal.on('hidden.bs.modal', function () {});
        }
    }, {
        key: 'addRowToDt',
        value: function addRowToDt(paymentType, money, number, note) {
            var me = this;

            $.get(me.addUrl, {
                name: paymentType,
                id: '',
                Code: 'lazada',
                DocNo: me.hidDocNo.val(),
                DocCode: me.hidDocCode.val(),
                Money: money,
                Note: note
            }).done(function (resp) {
                if (!resp.Data) return;

                me.indexForm.dtPayment.row.add({
                    'id': resp.Data,
                    'paymentType': paymentType,
                    'money': money,
                    'number': number,
                    'note': note,
                    'options': 'delete',
                    'modalName': 'lazadaModal',
                    'apprCode': '',
                    'bank': '',
                    'payFormat': '',
                    'cardType': '',
                    'crMonth': '',
                    'crYear': ''
                }).draw();

                $('a[title="' + paymentType + '"]').addClass('not-active');
                me.indexForm.addBlank();
                me.lazadaModal.modal('toggle');
            });
        }
    }]);

    return LazadaModal;
}();