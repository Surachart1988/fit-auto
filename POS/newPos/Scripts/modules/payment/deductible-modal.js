class DeductibleModal {
    constructor() {
        this.modalName = "หัก ณ ที่จ่าย 3%"
        this.dtPaymentPaymentList = $('#payment-list')
        this.txtBalance = $('#txtBalance')
        this.txtTotalAmount = $('#TotalAmount')
        this.txtPaymentAmount = $('#PaymentAmount')
        this.txtPaymentDeductible = $('#txtPaymentDeductible')
        this.btnReceiveMoney = $('#btnDeductibleReceiveMoney')
        this.deductibleModal = $('#deductibleModal')
        this.txtExtraDiscount = $('#txtExtraDiscount')
        this.hidDocNo = $('#DocNo')
        this.hidDocCode = $('#DocCode')
        this.myForm = $('#myForm')
        this.txtNote = $('#txtDeductibleNote')

        this.indexForm = null
        this.addUrl = null
    }
    init() {
        const me = this

        this.txtNote.keyup((event) => {
            if (event.keyCode === 13) {
                me.btnReceiveMoney.click()
            }
        })

        this.btnReceiveMoney.click(() => {
            me.addRowToDt(me.modalName, me.txtPaymentDeductible.val(), '', me.txtNote.val())
        })

        this.deductibleModal.on('shown.bs.modal', function () {
            me.txtPaymentDeductible.val((((+me.txtTotalAmount.val() * 100 / 107) - +me.txtExtraDiscount.val())*0.03).toFixed(2))
        })

        this.deductibleModal.on('hidden.bs.modal', function () {
            me.indexForm.setTotal()
        })
    }

    addRowToDt(paymentType, money, number, note) {
        const me = this
        $.get(me.addUrl, {
            name: paymentType,
            id: '',
            Code: 'deductible3per',
            DocNo: me.hidDocNo.val(),
            DocCode: me.hidDocCode.val(),
            Money: money,
            Note: note
        }).done(function (resp) {
            if (!resp.Data) return

            me.indexForm.dtPayment.row.add({
                'id': resp.Data,
                'paymentType': paymentType,
                'money': money,
                'number': number,
                'note': note,
                'options': 'delete',
                'modalName': 'deductibleModal',
                'apprCode': '',
                'bank': '',
                'payFormat': '',
                'cardType': '',
                'crMonth': '',
                'crYear': '',
            }).draw();

            $(`a[title="${paymentType}"]`).addClass('not-active')
            me.indexForm.addBlank()
            me.deductibleModal.modal('toggle');
        })
    }
}