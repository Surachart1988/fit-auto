class DepositModal {
    constructor() {
        this.modalName = "เงินมัดจำ"
        this.txtBalance = $('#txtBalance')
        this.depositModal = $('#depositModal')
        this.btnReceiveMoney = $('#btnDepositReceiveMoney')
        this.txtNote = $('#txtDepositNote')
        this.hidDocNo = $('#DocNo')
        this.hidDocCode = $('#DocCode')
        this.hidCustomerCode = $('#CustomerCode')
        this.txtPaymentDeposit = $('#txtPaymentDeposit')
        this.ddDepositNo = $('#ddDepositNo')
        this.txtCustomerName = $('#txtCustomerName')
        this.depositModels = []
        this.indexForm = null

        this.getUrl = null
        this.addUrl = null
        this.deleteUrl = null
    }
    init() {
        const me = this

        this.depositModal.on('shown.bs.modal', function () {
            me.setDepositNo()
        })

        this.depositModal.on('hidden.bs.modal', function () {

        })

        this.btnReceiveMoney.click(function () {
            let row = me.depositModels[me.ddDepositNo.val()]
            me.addRowToDt(me.modalName, row.DepositNo, row.Money, me.txtNote.val())
        })

        this.ddDepositNo.change(() => {
            let row = me.depositModels[me.ddDepositNo.val()]
            me.txtCustomerName.val(row.CustomerName)
            me.txtPaymentDeposit.val(row.Money)
        })

        this.txtNote.keyup((event) => {
            if (event.keyCode === 13) {
                me.btnReceiveMoney.click()
            }
        })
    }

    setDepositNo() {
        const me = this

        me.ddDepositNo.children().remove();
        $.get(me.getUrl, {
            CustomerCode: me.hidCustomerCode.val(),
            docNo: me.hidDocNo.val()
        }).done(function (resp) {
            if (resp.Code == "00") {
                me.depositModels = resp.Data
                for (var i = 0; i < me.depositModels.length; i++) {
                    me.ddDepositNo[0].add(new Option(me.depositModels[i].DepositNo, i))
                }
                let row = me.depositModels[me.ddDepositNo.val()]
                if (row) {
                    me.txtCustomerName.val(row.CustomerName)
                    me.txtPaymentDeposit.val(row.Money)
                }
            }
        })
    }

    addRowToDt(paymentType, depositNo, money, note) {
        const me = this

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
                'crYear': '',
            }).draw();

            me.indexForm.addBlank()
            me.depositModal.modal('toggle')
        })
    }
}
