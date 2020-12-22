'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var DepositModal = function () {
    function DepositModal() {
        _classCallCheck(this, DepositModal);

        this.modalName = "เงินมัดจำ";
        this.txtBalance = $('#txtBalance');
        this.depositModal = $('#depositModal');
        this.btnReceiveMoney = $('#btnDepositReceiveMoney');
        this.txtNote = $('#txtDepositNote');
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.hidCustomerCode = $('#CustomerCode');
        this.txtPaymentDeposit = $('#txtPaymentDeposit');
        this.ddDepositNo = $('#ddDepositNo');
        this.txtCustomerName = $('#txtCustomerName');
        this.depositModels = [];
        this.indexForm = null;

        this.getUrl = null;
        this.addUrl = null;
        this.deleteUrl = null;
    }

    _createClass(DepositModal, [{
        key: 'init',
        value: function init() {
            var me = this;

            me.setDepositNo();

            this.depositModal.on('shown.bs.modal', function () {
               
                me.setDepositNo();
            });

            this.depositModal.on('hidden.bs.modal', function () {
                me.setDepositNo();
            });

            this.btnReceiveMoney.click(function () {
                var row = me.depositModels[me.ddDepositNo.val()];
                me.addRowToDt(me.modalName, row.DepositNo, row.Money, me.txtNote.val());
            });

            this.ddDepositNo.change(function () {
                var row = me.depositModels[me.ddDepositNo.val()];
                me.txtCustomerName.val(row.CustomerName);
                me.txtPaymentDeposit.val(row.Money);
            });

            this.txtNote.keyup(function (event) {
                if (event.keyCode === 13) {
                    me.btnReceiveMoney.click();
                }
            });

          //   me.setDepositNo();

        }
    }, {
        key: 'setDepositNo',
        value: function setDepositNo() {
            var me = this;
         
            me.ddDepositNo.children().remove();
            $.get(me.getUrl, {
                CustomerCode: me.hidCustomerCode.val(),
                docNo: me.hidDocNo.val()
            }).done(function (resp) {
         
                if (resp.Code == "00") {
                    me.depositModels = resp.Data;
                    for (var i = 0; i < me.depositModels.length; i++) {
                        me.ddDepositNo[0].add(new Option(me.depositModels[i].DepositNo, i));
                    }
                    var row = me.depositModels[me.ddDepositNo.val()];
                    if (row) {
                        me.txtCustomerName.val(row.CustomerName);
                        me.txtPaymentDeposit.val(row.Money);
                        me.btnReceiveMoney.prop("disabled", false);
                    } else {
                        $(`a[title="${me.modalName}"]`).addClass('not-active')
                         me.btnReceiveMoney.prop("disabled", true);
                    }
                   
                } 

               

            });
        }
    }, {
        key: 'addRowToDt',
        value: function addRowToDt(paymentType, depositNo, money, note) {
            var me = this;

            $.get(me.addUrl, {
                DocNo: me.hidDocNo.val(),
                DocCode: me.hidDocCode.val(),
                DepositNo: depositNo,
                Money: money,
                Note: note
            }).done(function (resp) {
                if (!resp.Data) return;

                me.indexForm.dtPayment.row.add({
                    'id': resp.Data,
                    'paymentType': paymentType,
                    'money': money,
                    'number': depositNo,
                    'note': note,
                    'options': 'delete',
                    'modalName': 'depositModal',
                    'apprCode': '',
                    'bank': '',
                    'payFormat': '',
                    'cardType': '',
                    'crMonth': '',
                    'crYear': ''
                }).draw();

                me.indexForm.addBlank();
                me.depositModal.modal('toggle');
            });
        }
    }]);

    return DepositModal;
}();