'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var CreditCardModal = function () {
    function CreditCardModal() {
        _classCallCheck(this, CreditCardModal);

        this.modalName = "เครดิตการ์ด";
        this.ddCreditMonth = $('#ddCreditMonth');
        this.ddCreditYear = $('#ddCreditYear');
        this.txtBalance = $('#txtBalance');
        this.crModal = $('#creditCardModal');
        this.txtCreditNumberIsValid = $('#txtCreditNumberIsValid');
        this.txtCreditNumber = $('#txtCreditNumber');
        this.txtApprCode = $('#txtApprCode');
        this.txtApprCodeIsValid = $('#txtApprCodeIsValid');
        this.lblbank = $('#lblbank');
        this.lblpaymentformat = $('#lblpaymentformat');
        this.lblddCardType = $('#lblddCardType');
        this.ddBank = $('#ddBank');
        this.hidCashAmount = $('#CashAmount');
        this.ddBankCreditModel = $('#creditCardModal #ddBank');
        this.ddCardTypeCreditModel = $('#creditCardModal #ddCardType');
        this.ddPaymentFormatModel = $('#creditCardModal #ddPaymentFormat');
        this.ddCardTypeCreditModelOptions = $('#creditCardModal #ddCardType option');
        this.ddPaymentFormat = $('#ddPaymentFormat');
        this.ddCardType = $('#ddCardType');
        this.txtPaymentCreditCard = $('#txtPaymentCreditCard');
        this.btnReceiveMoney = $('#btnCreditCardReceiveMoney');
        this.txtNote = $('#txtCreditCardNote');
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.indexForm = null;

        this.crType = null;
        this.addUrl = null;
        this.updateUrl = null;
        this.deleteUrl = null;
        this.txtTotalAmount = $('#TotalAmount');
    }

    _createClass(CreditCardModal, [{
        key: 'init',
        value: function init() {
            var me = this;
            this.lblbank.hide();
            this.lblpaymentformat.hide();
            this.lblddCardType.hide();
            this.txtCreditNumberIsValid.hide();
            this.txtApprCodeIsValid.hide();

            var yearNow = new Date().getFullYear();
            this.ddCreditYear.children().remove();
            for (var i = yearNow; i < yearNow + 10; i++) {
                this.ddCreditYear[0].add(new Option(i.toString(), i.toString()));
            }
            this.setCreditExpired();
            this.ddCreditYear.change(function () {
                me.setCreditExpired();
            });

            this.ddBankCreditModel.change(function () {
                var bank_code = me.ddBankCreditModel.val();

                $("#creditCardModal #ddCardType option").removeClass("hide_option");
                if (bank_code != "-") {
                    $("#creditCardModal #ddCardType option").not("[bank_code='" + bank_code + "']").addClass("hide_option");
                    me.lblbank.hide();
                } else {
                    me.lblbank.show();
                }
                me.isValid();
            });

            this.ddPaymentFormatModel.change(function () {
                var paymenttype = me.ddPaymentFormatModel.val();

                if (paymenttype != "0") {
                    me.lblpaymentformat.hide();
                } else {
                    me.lblpaymentformat.show();
                }
                me.isValid();
            });

            this.ddCardTypeCreditModel.change(function () {
                var cardtype = me.ddCardTypeCreditModel.val();

                if (cardtype != "") {
                    me.lblddCardType.hide();
                } else {
                    me.lblddCardType.show();
                }
                me.isValid();
            });

            this.crModal.on('shown.bs.modal', function () {
                if (me.indexForm.status == 'add') {
                    me.txtPaymentCreditCard.val(me.txtBalance.val());
                }
            });

            this.crModal.on('hidden.bs.modal', function () {
                me.indexForm.status = 'add';
                me.indexForm.setTotal();
                me.txtCreditNumber.val('');
                me.txtApprCode.val('');
                me.txtNote.val('');

                var crSelect = $('#creditCardModal select');
                for (var i = 0; i < crSelect.length; i++) {
                    me.resetSelectElement(crSelect[0]);
                }

                //me.ddCreditYear.val($("#ddCreditYear option:first").val()).change()
                //me.ddCreditMonth.val($("#ddCreditMonth option:first").val()).change()
                //me.ddBank.val($("#ddBank option:first").val()).change()
                //me.ddPaymentFormat.val($("#ddPaymentFormat option:first").val()).change()
                //me.ddCardType.val($("#ddCardType option:first").val()).change()
            });

            var cleave = new Cleave('.input-credit-card', {
                creditCard: true,
                delimiter: '-',
                onCreditCardTypeChanged: function onCreditCardTypeChanged(type) {
                    me.crType = type;
                    $('#crIcon').removeClass();
                    if (type && type != 'unknown' && type != 'uatp') {
                        $('#crIcon').addClass('fa fa-cc-' + type);
                    } else {
                        me.txtCreditNumberIsValid.text('หมายเลขบัตรไม่ถูกต้อง');
                        me.txtCreditNumberIsValid.show();
                    }
                }
            });

            var cleave = new Cleave('.input-number', {
                numeral: true,
                numeralDecimalMark: ',',
                delimiter: ''

            });

            this.btnReceiveMoney.click(function () {
                var paymentAmount = +me.txtPaymentCreditCard.val();
                //   me.indexForm.setTotal();
                var id = '';
                if (me.indexForm.status == 'edit') {
                    id = me.indexForm.id;
                }
                var getddCardType = $("#creditCardModal select[id='ddCardType']").val();
                //alert(getddCardType);
                //alert(me.ddCardType.val());
                me.addRowToDt(id, me.modalName, paymentAmount, me.txtCreditNumber.val(), me.txtNote.val(), me.ddCreditMonth.val(), me.ddCreditYear.val(), me.txtApprCode.val(), me.ddBank.val(), getddCardType, me.ddPaymentFormat.val());
            });

            this.txtApprCode.keyup(function () {
                if (me.txtApprCode.val().length < 6) {
                    me.txtApprCodeIsValid.show();
                } else me.txtApprCodeIsValid.hide();
            });

            this.txtCreditNumber.keyup(function () {
                if (me.txtCreditNumber.val().length < 19 && me.crType && me.crType != 'unknown' && me.crType != 'uatp') {
                    me.txtCreditNumberIsValid.text('หมายเลขบัตรไม่ครบ');
                    me.txtCreditNumberIsValid.show();
                } else if (me.crType && me.crType != 'unknown' && me.crType != 'uatp') me.txtCreditNumberIsValid.hide();
            });

            me.isValid();

            $('#creditCardModal input').keyup(function () {
                me.isValid();
            });
        }
    }, {
        key: 'resetSelectElement',
        value: function resetSelectElement(selectElement) {
            var options = selectElement.options;

            // Look for a default selected option
            for (var i = 0, iLen = options.length; i < iLen; i++) {

                if (options[i].defaultSelected) {
                    selectElement.selectedIndex = i;
                    return;
                }
            }

            // If no option is the default, select first or none as appropriate
            selectElement.selectedIndex = 0; // or -1 for no option selected
        }
    }, {
        key: 'isValid',
        value: function isValid() {
            var check = this.txtCreditNumber.val().length != 19 ||
                this.txtApprCode.val().length != 6 ||
                this.txtPaymentCreditCard.val() == 0 ||
                this.ddBankCreditModel.val() === "-" ||
                this.ddPaymentFormatModel.val() === "0" ||
                this.ddCardTypeCreditModel.val() === "";
            this.btnReceiveMoney.prop("disabled", check);
        }
    }, {
        key: 'setCreditExpired',
        value: function setCreditExpired() {
            var yearNow = new Date().getFullYear();
            var monthNow = new Date().getMonth();

            this.ddCreditMonth.children().remove();
            for (var i = yearNow == this.ddCreditYear.val() ? monthNow + 1 : 1; i < 13; i++) {
                this.ddCreditMonth[0].add(new Option(this.pad(i), this.pad(i)));
            }
        }
    }, {
        key: 'pad',
        value: function pad(d) {
            return d < 10 ? '0' + d.toString() : d.toString();
        }
    }, {
        key: 'addRowToDt',
        value: function addRowToDt(id, paymentType, money, number, note, expiredMonth, expiredYear, apprCode, bankCode, cardTypeCode, paymentFormatId) {
            var me = this;

            var url = me.indexForm.status == 'edit' ? me.updateUrl : me.addUrl;
            $.get(url, {
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
                PaymentFormatId: paymentFormatId,
                CreditType: me.crType,
                ConnectType: 'card'
            }).done(function (resp) {
                if (!resp.Data) return;

                if (me.indexForm.status == 'edit') {
                    var indexes = me.indexForm.dtPayment.rows().eq(0).filter(function (rowIdx) {
                        return me.indexForm.dtPayment.cell(rowIdx, 0).data() === id ? true : false;
                    });

                    me.indexForm.dtPayment.row(indexes).remove().draw();
                }

                me.indexForm.dtPayment.row.add({
                    'id': resp.Data,
                    'paymentType': paymentType,
                    'money': money,
                    'number': number,
                    'options': 'all',
                    'note': note,
                    'modalName': 'creditCardModal',
                    'apprCode': apprCode,
                    'bank': bankCode,
                    'payFormat': paymentFormatId,
                    'cardType': cardTypeCode,
                    'crMonth': expiredMonth,
                    'crYear': expiredYear
                }).draw();
                me.hidCashAmount.val(money);
                me.indexForm.setTotalPaymentAmount();

                me.crModal.modal('toggle');
            });
        }
    }]);

    return CreditCardModal;
}();