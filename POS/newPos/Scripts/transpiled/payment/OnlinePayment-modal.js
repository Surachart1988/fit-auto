'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var OnlinePaymentModal = function () {
    function OnlinePaymentModal() {
        _classCallCheck(this, OnlinePaymentModal);

        this.modalName = "OnlinePayment";
        this.dtPaymentPaymentList = $('#payment-list');
        this.txtPaymentMoney = $('#txtPaymentMoney');
        this.txtBalance = $('#txtBalance');
        this.txtTotalAmount = $('#TotalAmount');
        this.txtPaymentAmount = $('#PaymentAmount');
        this.txtPaymentOnline = $('#txtPaymentOnline');
        this.txtReferenceOnlineNo = $('#txtReferenceOnlineNo');
        this.btnReceiveMoney = $('#btnOnlineReceiveMoney');
        this.OnlinePaymentModal = $('#OnlinePaymentDetailModal');
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.myForm = $('#myForm');
        this.txtNote = $('#txtOnlineNote');
        this.hdPaymentOnlineType = $('#hd_OnlinePaymentType');
        this.indexForm = null;
        this.addUrl = null;
        this.OnlinePayment = $('#OnlinePayment');
    }

    _createClass(OnlinePaymentModal, [{
        key: 'init',
        value: function init() {
            var me = this;
            me.btnReceiveMoney.prop('disabled', true);
            //this.txtNote.keyup(function (event) {
            //    if (event.keyCode === 13) {
            //        me.btnReceiveMoney.click(); txtReferenceOnlineNo
            //    }
            //});
            this.txtReferenceOnlineNo.keyup(function (event) {
                if ($(this).val().length > 5) {
                    me.btnReceiveMoney.prop('disabled', false);
                } else {
                    me.btnReceiveMoney.prop('disabled', true);
                }
            });

            this.btnReceiveMoney.click(function () {
                me.addRowToDt(me.hdPaymentOnlineType.val(), me.txtPaymentOnline.val(), me.txtReferenceOnlineNo.val(), me.txtNote.val());
            });

            this.OnlinePaymentModal.on('shown.bs.modal', function () {
                me.txtPaymentOnline.val(me.txtPaymentMoney.val());
            });

            this.OnlinePaymentModal.on('hidden.bs.modal', function () {});
        }
    }, {
        key: 'addRowToDt',
        value: function addRowToDt(paymentType, money, number, note) {
            var me = this;

            $.get(me.addUrl, {
                name: paymentType,
                id: '',
                Code: paymentType,
                DocNo: me.hidDocNo.val(),
                DocCode: me.hidDocCode.val(),
                Money: money,
                Note: note,
                OnlinePaymentRefNo: number
            }).done(function (resp) {
                if (!resp.Data) return;

                me.txtPaymentAmount.val(money);
                me.indexForm.setTotal();
                me.indexForm.displayPayment();

                me.OnlinePaymentModal.modal('toggle');
                me.OnlinePayment.modal('toggle');
            });
        }
    }]);

    return OnlinePaymentModal;
}();