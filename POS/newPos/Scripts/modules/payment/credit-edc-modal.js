class CreditEdcModal {
    constructor() {
        this.modalName = "เครดิตการ์ด"
        this.txtCreditMonth = $('#txtCreditMonth')
        this.txtCreditYear = $('#txtCreditYear')
        this.txtBalance = $('#txtBalance')

        this.crModal = $('#creditEdcModal')
        this.txtCreditNumber = $('#txtCreditEdcNumber')
        this.txtApprCode = $('#txtApprCodeEdc')
        this.ddBank = $('#ddBank')
        this.ddPaymentFormat = $('#ddPaymentFormat')
        this.ddCardType = $('#ddCardType')
        this.txtPaymentCreditEdc = $('#txtPaymentCreditEdc')
        this.btnReceiveMoney = $('#btnEdcReceiveMoney')
        this.txtNote = $('#txtEdcNote')
        this.hidDocNo = $('#DocNo')
        this.hidDocCode = $('#DocCode')
        this.indexForm = null

        this.addUrl = null
        this.updateUrl = null
        this.deleteUrl = null
    }
    init() {
        const me = this

        this.crModal.on('shown.bs.modal', function () {
            if (me.indexForm.status == 'add') {
                me.txtPaymentCreditEdc.val(me.txtBalance.val())
                me.txtCreditNumber.val('')
                me.txtApprCode.val('')
                me.ddBank.val('')
                me.ddPaymentFormat.val('')
                me.ddCardType.val('')
                me.txtNote.val('')
            } else
                me.txtPaymentCreditEdc.val(me.indexForm.moneyBalance)
        })

        this.crModal.on('hidden.bs.modal', function () {
            me.indexForm.status = 'add'
            me.indexForm.setTotal()
        })

        this.btnReceiveMoney.click(() => {
            let paymentAmount = +me.txtPaymentCreditEdc.val()
            me.indexForm.setTotal()
            let id = ''
            if (me.indexForm.status == 'edit') {
                id = me.indexForm.id
            }
            me.addRowToDt(id,me.modalName, paymentAmount, me.txtCreditNumber.val(), me.txtNote.val(), me.txtCreditMonth.val(), me.txtCreditYear.val(), me.txtApprCode.val(), me.ddBank.val(), me.ddCardType.val(), me.ddPaymentFormat.val())
            
        })

        me.isValid()
        $('#creditEdcModal input').change(() => {
            me.isValid()
        })

    }

    isValid() {
        let check = this.txtCreditNumber.val().length != 19 || this.txtApprCode.val().length != 6 || this.txtPaymentCreditEdc.val() == 0
        this.btnReceiveMoney.prop("disabled", check);
    }

    addRowToDt(id,paymentType, money, number, note, expiredMonth, expiredYear, apprCode, bankCode, cardTypeCode, paymentFormatId) {
        const me = this

        if (me.indexForm.status == 'edit') {
            let indexes = this.indexForm.dtPayment.rows().eq(0).filter(function (rowIdx) {
                return me.indexForm.dtPayment.cell(rowIdx, 1).data() === me.modalName ? true : false;
            });

            this.indexForm.dtPayment.row(indexes).remove().draw()
        }
        $.get(me.addUrl, {
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
            CreditType: me.crType,
            PaymentFormatId: paymentFormatId,
            ConnectType: 'edc'
        }).done(function (resp) {
            if (!resp.Data) return;

            me.indexForm.dtPayment.row.add({
                'id': resp.Data,
                'paymentType': paymentType,
                'money': money,
                'number': number,
                'options': 'delete',
                'note': note,
                'modalName': 'EdcModal',
                'apprCode': '',
                'bank': '',
                'payFormat': '',
                'cardType': '',
                'crMonth': '',
                'crYear': '',
            }).draw();

            me.indexForm.addBlank()
            me.crModal.modal('toggle');
        })
    }
}
