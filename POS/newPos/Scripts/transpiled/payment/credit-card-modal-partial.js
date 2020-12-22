'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var CreditCardModalPartial = function () {
    function CreditCardModalPartial() {
        _classCallCheck(this, CreditCardModalPartial);

        this.modalName = "เครดิตการ์ด";
        this.ddCreditMonth = $('#ddPartialCreditMonth');
        this.ddCreditYear = $('#ddPartialCreditYear');
        this.txtBalance = $('#txtPaymentBalance');
        this.crModal = $('#PartialcreditCardModal');
        this.txtCreditNumberIsValid = $('#txtPartialCreditNumberIsValid');
        this.txtCreditNumber = $('#txtPartialCreditNumber');
        this.txtApprCode = $('#txtPartialApprCode');
        this.txtApprCodeIsValid = $('#txtPartialApprCodeIsValid');
        this.ddBank = $('#ddPartialBank');
        this.ddPaymentFormat = $('#ddPartialPaymentFormat');
        this.ddCardType = $('#ddPartialCardType');
        this.txtPaymentCreditCard = $('#txtPartialPaymentCreditCard');
        this.btnReceiveMoney = $('#btnPartialCreditCardReceiveMoney');
        this.lblbank = $('#lblPartialbank');
        this.lblpaymentformat = $('#lblPartialpaymentformat');
        this.lblddCardType = $('#lblPartialCardType');
        this.txtNote = $('#txtPartialCreditCardNote');
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.indexForm = null;

        this.crType = null;
        this.addUrl = null;
        this.updateUrl = null;
        this.deleteUrl = null;
    }

    _createClass(CreditCardModalPartial, [{
        key: 'init',
        value: function init() {
            var me = this;
            this.lblbank.hide();
            this.lblpaymentformat.hide();
            this.lblddCardType.hide();

            var yearNow = new Date().getFullYear();
            this.ddCreditYear.children().remove();
            for (var i = yearNow; i < yearNow + 10; i++) {
                this.ddCreditYear[0].add(new Option(i.toString(), i.toString()));
            }
            this.setCreditExpired();
            this.ddCreditYear.change(function () {
                me.setCreditExpired();
            });
            this.ddBank.change(function () {
                var bank_code = me.ddBank.val();

                $("#PartialcreditCardModal #ddPartialCardType option").removeClass("hide_option");
                if (bank_code != "-") {
                    $("#PartialcreditCardModal #ddPartialCardType option").not("[bank_code='" + bank_code + "']").addClass("hide_option");
                    me.lblbank.hide();
                } else {
                    me.lblbank.show();
                }
                me.isValid();
            });
            this.ddPaymentFormat.change(function () {
                var paymenttype = me.ddPaymentFormat.val();

                if (paymenttype != "0") {
                    me.lblpaymentformat.hide();
                } else {
                    me.lblpaymentformat.show();
                }
                me.isValid();
            });
            this.ddCardType.change(function () {
                var cardtype = me.ddCardType.val();

                if (cardtype != "") {
                    me.lblddCardType.hide();
                } else {
                    me.lblddCardType.show();
                }
                me.isValid();
            });
            this.crModal.on('shown.bs.modal', function () {
                me.txtPaymentCreditCard.val(me.txtBalance.val());
            });

            this.crModal.on('hidden.bs.modal', function () {
                //me.indexForm.status = 'add';
                //me.indexForm.setTotal();
                //me.txtCreditNumber.val('');
                //me.txtApprCode.val('');
                //me.txtNote.val('');

                //var crSelect = $('#PartialcreditCardModal select');
                //for (var i = 0; i < crSelect.length; i++) {
                //    me.resetSelectElement(crSelect[0]);
                //}


            });
            this.txtCreditNumberIsValid.hide();
            var cleave = new Cleave('.input-credit-card2', {
                creditCard: true,
                delimiter: '-',
                onCreditCardTypeChanged: function onCreditCardTypeChanged(type) {
                    me.crType = type;
                    $('#crPartialIcon').removeClass();
                    if (type && type != 'unknown' && type != 'uatp') {
                        $('#crPartialIcon').addClass('fa fa-cc-' + type);
                        $('#crTypeCreditPartial').val(type);
                    } else {
                        me.txtCreditNumberIsValid.text('หมายเลขบัตรไม่ถูกต้อง');
                        me.txtCreditNumberIsValid.show();
                    }
                }
            });

            this.txtApprCodeIsValid.hide();
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
            $('#PartialcreditCardModal input').keyup(function () {
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
                this.ddBank.val() === "-" ||
                this.ddPaymentFormat.val() === "0" ||
                this.ddCardType.val() === "";
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

                me.indexForm.addBlank();
                me.crModal.modal('toggle');
            });
        }
    }]);

    return CreditCardModalPartial;
}();