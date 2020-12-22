class LazadaModal {
    constructor() {
        this.modalName = "LAZADA"
        this.dtPaymentPaymentList = $('#payment-list')
        this.txtBalance = $('#txtBalance')
        this.txtTotalAmount = $('#TotalAmount')
        this.txtPaymentAmount = $('#PaymentAmount')
        this.txtPaymentLazada = $('#txtPaymentLazada')
        this.txtReferenceLazadaNo = $('#txtReferenceLazadaNo')
        this.btnReceiveMoney = $('#btnLazadaReceiveMoney')
        this.lazadaModal = $('#lazadaModal')
        this.hidDocNo = $('#DocNo')
        this.hidDocCode = $('#DocCode')
        this.myForm = $('#myForm')
        this.txtNote = $('#txtLazadaNote')

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
            me.addRowToDt(me.modalName, me.txtPaymentLazada.val(), me.txtReferenceLazadaNo.val(), me.txtNote.val())
        })

        this.lazadaModal.on('shown.bs.modal', function () {
            me.txtPaymentLazada.val(me.txtBalance.val())
        })

        this.lazadaModal.on('hidden.bs.modal', function () {
            
        })
    }

    addRowToDt(paymentType, money, number, note) {
        const me = this

        $.get(me.addUrl, {
            name: paymentType,
            id: '',
            Code: 'lazada',
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
                'modalName': 'lazadaModal',
                'apprCode': '',
                'bank': '',
                'payFormat': '',
                'cardType': '',
                'crMonth': '',
                'crYear': '',
            }).draw();

            $(`a[title="${paymentType}"]`).addClass('not-active')
            me.indexForm.addBlank()
            me.lazadaModal.modal('toggle');

        })
    }
}