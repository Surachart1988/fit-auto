'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var PttorModal = function () {
    function PttorModal() {
        _classCallCheck(this, PttorModal);
 
        this.modalName = "PTTOR";
        this.dtPaymentPaymentList = $('#payment-list');
        this.pttorModalIframe = $('#pttorModalIframe');
        //this.txtTotalAmount = $('#TotalAmount');
        //this.txtLastDiscount = $('#LastDiscount');
        //this.txtPaymentAmount = $('#PaymentAmount');
        //this.txtPaymentCash = $('#txtPaymentCash');
        //this.txtChangeMoney = $('#txtChangeMoney');
        //this.btnReceiveMoney = $('#btnCashReceiveMoney');
        //this.btnSubmit = $('#btnSubmit');

        this.hidCashAmount = $('#CashAmount');
        this.hidDocNo = $('#DocNo');
        this.hidRefDocNo = $('#RefDocNo');
        this.modalBodyPttor = $("#modalBodyPttor");
        //this.pttorModal = $('#pttorModal');
        //this.myForm = $('#myForm');
        //this.txtNote = $('#txtCashNote');

        this.indexForm = null;
    }

    _createClass(PttorModal, [{
        key: 'init',
        value: function init() {
            var _this = this;
    
            var me = this;
     
            var loc = window.location;
            var pathName = loc.pathname.substring(0, loc.pathname.lastIndexOf('/') + 1);
            var PathNames = loc.href.substring(0, loc.href.length - ((loc.pathname + loc.search + loc.hash).length - pathName.length));
            var Path = PathNames;
            var Paths = Path.split("/");
            var Pathss = Path.replace(Paths[3] + '/', '');
       

            var UrlPttorBill = Pathss + "/PTT_Client_1/report/rpt_send.aspx?thaibaht=&print_tax=1&print_comp=1&reportname=pttor.rpt&doc_no=" + this.hidDocNo.val() + "&prn_vat=&prn_date=&prn_car_reg=&prn_pay_type=&doc_code=PTTOR&cus_update=&print_price=&branch_no=004";
           // window.open(UrlPttorBill, "PTTOR Receipt", "width=600,height=600,scrollbars=yes");

            //this.pttorModalIframe.attr("src", UrlPttorBill);
           

            //this.txtPaymentCash.keyup(function (event) {
                
            //    _this.setChangeMoney();
              
            //    if (+$(this).val() < +me.txtBalance.val()) {
            //        me.btnReceiveMoney.prop("disabled", true);
            //    } else {
            //        me.btnReceiveMoney.prop("disabled", false);
            //        if (event.keyCode === 13) {
            //            me.btnReceiveMoney.click();
            //        }
            //    }
            //});

            //this.btnReceiveMoney.click(function () {
            //    var cashAmount = +me.txtPaymentCash.val() - +me.txtChangeMoney.val();

            //    me.indexForm.setTotal();
            //    me.addRowToDt(me.modalName, cashAmount, '', me.txtNote.val());
            //});

            //this.pttorModal.on('shown.bs.modal', function () {
            //    if (me.indexForm.status == 'add') me.txtPaymentCash.val('0.00');
            //    me.txtPaymentCash.focus();
            //    me.setChangeMoney();
            //});

            //this.pttorModal.on('hidden.bs.modal', function () {
            //    me.indexForm.status = 'add';
            //    me.indexForm.setTotal();
            //});
        }
    },
       
        {
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
                    'modalName': 'pttorModal',
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
                    'modalName': 'pttorModal',
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
            me.pttorModal.modal('toggle');
        }
    }]);

    return PttorModal;
}();