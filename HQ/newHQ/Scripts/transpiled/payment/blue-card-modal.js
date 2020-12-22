'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var BlueCardModal = function () {
    function BlueCardModal() {
        _classCallCheck(this, BlueCardModal);

        this.modalName = "Blue Card";
        this.txtBalance = $('#txtBalance');
        this.blueCardNo = $('#BlueCardNo');
        this.blueCardBalancePoint = $('#BlueCardBalancePoint');
        this.blueCardRewardPoint = $('#BlueCardRewardPoint');

        this.blueModal = $('#blueCardModal');
        this.btnReceiveMoney = $('#btnBlueCardReceiveMoney');
        this.txtNote = $('#txtBlueCardNote');
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.txtBlueCardName = $('#txtBlueCardName');
        this.txtBlueCardNo = $('#txtBlueCardNo');
        this.txtBalancePoint = $('#txtBalancePoint');
        this.txtUsePoint = $('#txtUsePoint');
        this.txtBlueCardMoney = $('#txtBlueCardMoney');
        this.indexForm = null;

        this.addUrl = null;
    }

    _createClass(BlueCardModal, [{
        key: 'init',
        value: function init() {
            var me = this;

            this.blueModal.on('shown.bs.modal', function () {
                me.txtBlueCardName.val('');
                me.txtBlueCardNo.val('');
                me.txtBalancePoint.val('');
                me.txtUsePoint.val('');
                me.txtBlueCardMoney.val('');
                me.txtNote.val('');
            });

            this.blueModal.on('hidden.bs.modal', function () {});

            this.btnReceiveMoney.click(function () {
                me.addRowToDt(me.modalName, me.txtBlueCardNo.val(), me.txtBlueCardMoney.val(), me.txtNote.val(), me.txtBalancePoint.val());
            });
        }
    }, {
        key: 'addRowToDt',
        value: function addRowToDt(paymentType, code, money, note, balancePoint) {
            var me = this;

            $.get(me.addUrl, {
                name: paymentType,
                Code: code,
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
                    'number': code,
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

                me.blueCardNo.val(code);
                me.blueCardBalancePoint.val(balancePoint);

                me.indexForm.addBlank();
                $('a[title="' + paymentType + '"]').addClass('not-active');
                me.blueModal.modal('toggle');
            });
        }
    }]);

    return BlueCardModal;
}();