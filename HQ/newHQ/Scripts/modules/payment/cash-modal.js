class CashModal {
    constructor() {
        this.modalName = "เงินสด"
        this.dtPaymentPaymentList = $('#payment-list')
        this.txtBalance = $('#txtBalance')
        this.txtTotalAmount = $('#TotalAmount')
        this.txtLastDiscount = $('#LastDiscount')
        this.txtPaymentAmount = $('#PaymentAmount')
        this.txtPaymentCash = $('#txtPaymentCash')
        this.txtChangeMoney = $('#txtChangeMoney')
        this.btnReceiveMoney = $('#btnCashReceiveMoney')
        this.btnSubmit = $('#btnSubmit')

        this.hidCashAmount = $('#CashAmount')
        this.hidChangeMoney = $('#ChangeMoney')
        this.cashModal = $('#cashModal')
        this.myForm = $('#myForm')
        this.txtNote = $('#txtCashNote')

        this.indexForm = null
    }
    init() {
        const me = this

        this.txtPaymentCash.keyup((event) => {
            if (event.keyCode === 13) {
                me.btnReceiveMoney.click()
            }
            this.setChangeMoney()
        })

        this.btnReceiveMoney.click(() => {
            let cashAmount = +me.txtPaymentCash.val() - +me.txtChangeMoney.val()

            me.indexForm.setTotal()
            me.addRowToDt(me.modalName, cashAmount, '', me.txtNote.val())
        })

        this.cashModal.on('shown.bs.modal', function () {
            if (me.indexForm.status == 'add')
                me.txtPaymentCash.val(me.txtBalance.val())
            me.txtPaymentCash.focus();
            me.setChangeMoney()
        })

        this.cashModal.on('hidden.bs.modal', function () {
            me.indexForm.status = 'add'
            me.indexForm.setTotal()
        })
    }

    setChangeMoney() {
        const me = this
        let changeMoney = 0
        if (me.indexForm.status == 'edit') {
            let data = 0
            let row = this.indexForm.dtPayment.rows().data().filter((element) => {
                return element.paymentType == me.modalName;
            })
            if (row.length > 0) {
                data = row[0].money
            }

            changeMoney = +me.txtPaymentCash.val() - (+me.txtBalance.val() + data)
        } else {
            changeMoney = +me.txtPaymentCash.val() - +me.txtBalance.val()
        }

        if (changeMoney < 0) changeMoney = 0
        me.txtChangeMoney.val(changeMoney.toFixed(2))
    }

    addRowToDt(paymentType, money, number, note) {
        const me = this
        let oldMoney = 0
        let datas = this.indexForm.dtPayment.rows().data()
        if (datas.length > 0) {
            let data = datas.filter((element) => {
                return element.paymentType == me.modalName;
            })

            if (data.length > 0) {
                let indexes = this.indexForm.dtPayment.rows().eq(0).filter(function (rowIdx) {
                    return me.indexForm.dtPayment.cell(rowIdx, 1).data() === me.modalName ? true : false;
                });
                oldMoney = this.indexForm.dtPayment.row(indexes).data().money
                this.indexForm.dtPayment.row(indexes).remove().draw()
            }
        }

        if (me.indexForm.status == 'edit') {
            this.indexForm.dtPayment.row.add({
                'id':'',
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
                'crYear': '',
            }).draw();
        } else {
            this.indexForm.dtPayment.row.add({
                'id':'',
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
                'crYear': '',
            }).draw();
        }

        this.hidCashAmount.val(money)
        this.hidChangeMoney.val(me.txtChangeMoney.val())

        me.indexForm.addBlank()
        me.cashModal.modal('toggle');
    }
}