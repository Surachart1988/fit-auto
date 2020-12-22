'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var CashModal = function () {
    function CashModal() {
        _classCallCheck(this, CashModal);

        this.modalName = "เงินสด";
        this.dtPaymentPaymentList = $('#payment-list');
        this.txtBalance = $('#txtBalance');
        this.txtTotalAmount = $('#TotalAmount');
        this.txtLastDiscount = $('#LastDiscount');
        this.txtPaymentAmount = $('#PaymentAmount');
        this.txtPaymentCash = $('#txtPaymentCash');
        this.txtChangeMoney = $('#txtChangeMoney');
        this.btnReceiveMoney = $('#btnCashReceiveMoney');
        this.btnSubmit = $('#btnSubmit');

        this.hidCashAmount = $('#CashAmount');
        this.hidChangeMoney = $('#ChangeMoney');
        this.cashModal = $('#cashModal');
        this.myForm = $('#myForm');
        this.txtNote = $('#txtCashNote');

        this.indexForm = null;
    }

    _createClass(CashModal, [{
        key: 'init',
        value: function init() {
            var _this = this;

            var me = this;

            this.txtPaymentCash.keyup(function (event) {
                if (event.keyCode === 13) {
                    me.btnReceiveMoney.click();
                }
                _this.setChangeMoney();
            });

            this.btnReceiveMoney.click(function () {
                var cashAmount = +me.txtPaymentCash.val() - +me.txtChangeMoney.val();

                me.indexForm.setTotal();
                me.addRowToDt(me.modalName, cashAmount, '', me.txtNote.val());
            });

            this.cashModal.on('shown.bs.modal', function () {
                if (me.indexForm.status == 'add') me.txtPaymentCash.val(me.txtBalance.val());
                me.txtPaymentCash.focus();
                me.setChangeMoney();
            });

            this.cashModal.on('hidden.bs.modal', function () {
                me.indexForm.status = 'add';
                me.indexForm.setTotal();
            });
        }
    }, {
        key: 'setChangeMoney',
        value: function setChangeMoney() {
            var me = this;
            var changeMoney = 0;
            if (me.indexForm.status == 'edit') {
                var data = 0;
                var row = this.indexForm.dtPayment.rows().data().filter(function (element) {
                    return element.paymentType == me.modalName;
                });
                if (row.length > 0) {
                    data = row[0].money;
                }

                changeMoney = +me.txtPaymentCash.val() - (+me.txtBalance.val() + data);
            } else {
                changeMoney = +me.txtPaymentCash.val() - +me.txtBalance.val();
            }

            if (changeMoney < 0) changeMoney = 0;
            me.txtChangeMoney.val(changeMoney.toFixed(2));
        }
    }, {
        key: 'addRowToDt',
        value: function addRowToDt(paymentType, money, number, note) {
            var me = this;
            var oldMoney = 0;
            var datas = this.indexForm.dtPayment.rows().data();
            if (datas.length > 0) {
                var data = datas.filter(function (element) {
                    return element.paymentType == me.modalName;
                });

                if (data.length > 0) {
                    var indexes = this.indexForm.dtPayment.rows().eq(0).filter(function (rowIdx) {
                        return me.indexForm.dtPayment.cell(rowIdx, 1).data() === me.modalName ? true : false;
                    });
                    oldMoney = this.indexForm.dtPayment.row(indexes).data().money;
                    this.indexForm.dtPayment.row(indexes).remove().draw();
                }
            }

            if (me.indexForm.status == 'edit') {
                this.indexForm.dtPayment.row.add({
                    'id': '',
                    'paymentType': paymentType,
                    'money': money,
                    'number': number,
                    'note': note,
                    'options': 'all',
                    'modalName': 'cashModal',
                    'apprCode': '',
                    'bank': '',
                    'payFormat': '',
                    'cardType': '',
                    'crMonth': '',
                    'crYear': ''
                }).draw();
            } else {
                this.indexForm.dtPayment.row.add({
                    'id': '',
                    'paymentType': paymentType,
                    'money': money + oldMoney,
                    'number': number,
                    'note': note,
                    'options': 'all',
                    'modalName': 'cashModal',
                    'apprCode': '',
                    'bank': '',
                    'payFormat': '',
                    'cardType': '',
                    'crMonth': '',
                    'crYear': ''
                }).draw();
            }

            this.hidCashAmount.val(money);
            this.hidChangeMoney.val(me.txtChangeMoney.val());

            me.indexForm.addBlank();
            me.cashModal.modal('toggle');
        }
    }]);

    return CashModal;
}();