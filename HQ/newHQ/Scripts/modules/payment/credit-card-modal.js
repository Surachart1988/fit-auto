class CreditCardModal {
    constructor() {
        this.modalName = "เครดิตการ์ด"
        this.ddCreditMonth = $('#ddCreditMonth')
        this.ddCreditYear = $('#ddCreditYear')
        this.txtBalance = $('#txtBalance')

        this.crModal = $('#creditCardModal')
        this.txtCreditNumber = $('#txtCreditNumber')
        this.txtApprCode = $('#txtApprCodeEdc')
        this.ddBank = $('#ddBank')
        this.ddPaymentFormat = $('#ddPaymentFormat')
        this.ddCardType = $('#ddCardType')
        this.txtPaymentCreditCard = $('#txtPaymentCreditCard')
        this.btnReceiveMoney = $('#btnCreditCardReceiveMoney')
        this.txtNote = $('#txtCreditCardNote')
        this.hidDocNo = $('#DocNo')
        this.hidDocCode = $('#DocCode')
        this.indexForm = null

        this.crType = null
        this.addUrl = null
        this.updateUrl = null
        this.deleteUrl = null
    }
    init() {
        const me = this

        let yearNow = (new Date()).getFullYear()
        this.ddCreditYear.children().remove();
        for (var i = yearNow; i < yearNow + 10; i++) {
            this.ddCreditYear[0].add(new Option(i.toString(), i.toString()));
        }
        this.setCreditExpired()
        this.ddCreditYear.change(() => {
            me.setCreditExpired()
        })

        this.crModal.on('shown.bs.modal', function () {
            if (me.indexForm.status == 'add') {
                me.txtPaymentCreditCard.val(me.txtBalance.val())
            }
        })

        this.crModal.on('hidden.bs.modal', function () {
            me.indexForm.status = 'add'
            me.indexForm.setTotal()
            me.txtCreditNumber.val('')
            me.txtApprCode.val('')
            me.txtNote.val('')

            let crSelect = $('#creditCardModal select')
            for (var i = 0; i < crSelect.length; i++) {
                me.resetSelectElement(crSelect[0])
            }

            //me.ddCreditYear.val($("#ddCreditYear option:first").val()).change()
            //me.ddCreditMonth.val($("#ddCreditMonth option:first").val()).change()
            //me.ddBank.val($("#ddBank option:first").val()).change()
            //me.ddPaymentFormat.val($("#ddPaymentFormat option:first").val()).change()
            //me.ddCardType.val($("#ddCardType option:first").val()).change()
        })

        var cleave = new Cleave('.input-credit-card', {
            creditCard: true,
            delimiter: '-',
            onCreditCardTypeChanged: function (type) {
                me.crType = type
                $('#crIcon').removeClass()
                if (type && type != 'unknown')
                    $('#crIcon').addClass(`fa fa-cc-${type}`)
            }
        });

        this.btnReceiveMoney.click(() => {
            let paymentAmount = +me.txtPaymentCreditCard.val()
            me.indexForm.setTotal()
            let id = ''
            if (me.indexForm.status == 'edit') {
                id = me.indexForm.id
            }
            me.addRowToDt(id,me.modalName, paymentAmount, me.txtCreditNumber.val(), me.txtNote.val(), me.ddCreditMonth.val(), me.ddCreditYear.val(), me.txtApprCode.val(), me.ddBank.val(), me.ddCardType.val(), me.ddPaymentFormat.val())
            
        })

        me.isValid()
        $('#creditCardModal input').keyup(() => {
            me.isValid()
        })

    }

    resetSelectElement(selectElement) {
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

    isValid() {
        let check = this.txtCreditNumber.val().length != 19 || this.txtApprCode.val().length != 6 || this.txtPaymentCreditCard.val() == 0
        this.btnReceiveMoney.prop("disabled", check);
    }

    setCreditExpired() {
        let yearNow = (new Date()).getFullYear()
        let monthNow = (new Date()).getMonth()

        this.ddCreditMonth.children().remove();
        for (var i = yearNow == this.ddCreditYear.val() ? monthNow + 1 : 1; i < 13; i++) {
            this.ddCreditMonth[0].add(new Option(this.pad(i), this.pad(i)));
        }
    }

    pad(d) {
        return (d < 10) ? '0' + d.toString() : d.toString();
    }

    addRowToDt(id,paymentType, money, number, note, expiredMonth, expiredYear, apprCode, bankCode, cardTypeCode, paymentFormatId) {
        const me = this

        
        let url = me.indexForm.status == 'edit' ? me.updateUrl : me.addUrl
        $.get(url, {
            Id:id,
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
                let indexes = me.indexForm.dtPayment.rows().eq(0).filter(function (rowIdx) {
                    return me.indexForm.dtPayment.cell(rowIdx, 0).data() === id ? true : false;
                });

                me.indexForm.dtPayment.row(indexes).remove().draw()
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
                'crYear': expiredYear,
            }).draw();

            me.indexForm.addBlank()
            me.crModal.modal('toggle');
        })
    }
}
