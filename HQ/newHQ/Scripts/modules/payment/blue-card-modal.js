class BlueCardModal {
    constructor() {
        this.modalName = "Blue Card"
        this.txtBalance = $('#txtBalance')
        this.blueCardNo = $('#BlueCardNo')
        this.blueCardBalancePoint = $('#BlueCardBalancePoint')
        this.blueCardRewardPoint = $('#BlueCardRewardPoint')

        this.blueModal = $('#blueCardModal')
        this.btnReceiveMoney = $('#btnBlueCardReceiveMoney')
        this.txtNote = $('#txtBlueCardNote')
        this.hidDocNo = $('#DocNo')
        this.hidDocCode = $('#DocCode')
        this.txtBlueCardName = $('#txtBlueCardName')
        this.txtBlueCardNo = $('#txtBlueCardNo')
        this.txtBalancePoint = $('#txtBalancePoint')
        this.txtUsePoint = $('#txtUsePoint')
        this.txtBlueCardMoney = $('#txtBlueCardMoney')
        this.indexForm = null

        this.addUrl = null
    }
    init() {
        const me = this


        this.blueModal.on('shown.bs.modal', function () {
            me.txtBlueCardName.val('')
            me.txtBlueCardNo.val('')
            me.txtBalancePoint.val('')
            me.txtUsePoint.val('')
            me.txtBlueCardMoney.val('')
            me.txtNote.val('')
        })

        this.blueModal.on('hidden.bs.modal', function () {

        })

        this.btnReceiveMoney.click(() => {
            me.addRowToDt(me.modalName, me.txtBlueCardNo.val(), me.txtBlueCardMoney.val(), me.txtNote.val(), me.txtBalancePoint.val())
        })

    }

    addRowToDt(paymentType, code, money, note, balancePoint) {
        const me = this

        $.get(me.addUrl, {
            name: paymentType,
            Code: code,
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
                'number': code,
                'note': note,
                'options': 'delete',
                'modalName': 'blueCardModal',
                'apprCode': '',
                'bank': '',
                'payFormat': '',
                'cardType': '',
                'crMonth': '',
                'crYear': '',
            }).draw();

            me.blueCardNo.val(code)
            me.blueCardBalancePoint.val(balancePoint)

            me.indexForm.addBlank()
            $(`a[title="${paymentType}"]`).addClass('not-active')
            me.blueModal.modal('toggle');
        })
    }
}
