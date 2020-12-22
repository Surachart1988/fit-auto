class BlueCardModal {
    constructor() {
        this.modalName = "Redeem Blue Card"
        this.txtBalance = $('#txtBalance')
        this.hidBlueCardNo = $('#BlueCardNo')
        this.hidBlueCardCode = $('#BlueCardCode')
        this.hidBlueCardMoney = $('#BlueCardMoney')
        this.hidBlueCardUsePoint = $('#BlueCardUsePoint')


        this.blueCardRedeemModal = $('#blueCardRedeemModal')
        this.btnReceiveMoney = $('#btnBlueCardReceiveMoney')
        this.txtNote = $('#txtBlueCardNote')
        this.hidDocNo = $('#DocNo')
        this.hidDocCode = $('#DocCode')
        this.txtBlueCardNo = $('#txtBlueCardNo')
        this.txtBlueCardMobile = $('#txtBlueCardMobile')
        this.txtBalancePoint = $('#txtBalancePoint')
        this.txtUsePoint = $('#txtUsePoint')
        this.txtBlueCardMoney = $('#txtBlueCardMoney')
        this.lblBlueCardMobileRedeemIsValid = $('#lblBlueCardMobileRedeemIsValid')
        this.lblBlueCardUsePointRedeemIsValid = $('#lblBlueCardUsePointRedeemIsValid')
        this.txtBlueCardCode = $('#txtBlueCardCode')
        this.indexForm = null
        this.getPointBalanceUrl = null
        this.redeemPointUrl = null
        this.addUrl = null

        this.blueCardSaveModal = $('#blueCardSaveModal')
        this.txtBlueCardSaveName = $('#txtBlueCardSaveName')
        this.txtBlueCardSaveNo = $('#txtBlueCardSaveNo')
        this.hidBlueCardSaveNo = $('#BlueCardSaveNo')
        this.hidBlueCardSaveMobile = $('#BlueCardSaveMobile')
        this.txtBlueCardBalancePoint = $('#txtBlueCardBalancePoint')
        this.txtBlueCardSaveTel = $('#txtBlueCardSaveTel')
        this.lblBlueCardSaveIsValid = $('#lblBlueCardSaveIsValid')
        this.btnSave = $('#btnBlueCardSave')
        this.btnClose = $('#btnClose')
        this.getUrl = null
    }
    init() {
        const me = this


        this.blueCardRedeemModal.on('shown.bs.modal', function () {
            me.txtBlueCardSaveTel.focus()
        })

        this.blueCardRedeemModal.on('hidden.bs.modal', function () {
            me.txtBlueCardNo.val('')
            me.txtBalancePoint.val('')
            me.txtUsePoint.val('')
            me.txtBlueCardMoney.val('')
            me.txtNote.val('')
            me.txtBlueCardCode.val('')
        })

        this.blueCardSaveModal.on('shown.bs.modal', function () {
            me.txtBlueCardSaveTel.focus()
            me.btnSave.prop("disabled", !me.txtBlueCardSaveNo.val())
        })

        this.blueCardSaveModal.on('hidden.bs.modal', function () {
            me.txtBlueCardSaveTel.val('')
            me.txtBlueCardSaveNo.val('')
        })

        this.inputMobile = new Cleave('.input-mobileth', {
            phone: true,
            phoneRegionCode: 'TH',
            delimiter: '-',
        });

        this.inputMobileSave = new Cleave('.input-mobile-save', {
            phone: true,
            phoneRegionCode: 'TH',
            delimiter: '-',
        });


        this.inputCard = new Cleave('.input-card', {
            blocks: [4, 4, 4, 4],
            numericOnly: true,
            uppercase: true,
            delimiter: '-',
        });

        this.inputCardSave = new Cleave('.input-card-save', {
            blocks: [4, 4, 4, 4],
            numericOnly: true,
            uppercase: true,
            delimiter: '-',
        });

        this.inputBalancePoint = new Cleave('.input-balance-point', {
            numeral: true,
            numeralThousandsGroupStyle: 'thousand'
        });

        this.lblBlueCardMobileRedeemIsValid.hide()
        this.txtBlueCardMobile.keyup(function () {
            me.lblBlueCardMobileRedeemIsValid.hide()
            me.txtBalancePoint.val('')
            me.txtUsePoint.prop('readonly', true).val('');
            me.txtBlueCardMoney.prop('readonly', true).val('');
            me.txtBlueCardCode.prop('readonly', true).val('');
            me.txtBlueCardNo.prop('readonly', true).val('')
            if ($(this).val().length > 10 && $(this).val().indexOf('-') < 0) {
                me.lblBlueCardMobileRedeemIsValid.show()
            }
            else if ($(this).val().length == 12 && $(this).val().indexOf('-') == 3) {
                let phone = me.inputMobile.getRawValue()
                me.getPointBalance(phone, '')
            }
            else {
                me.txtBlueCardNo.prop('readonly', false)
            }

        })

        var pointBalanceTime;
        this.txtBlueCardNo.keyup(function () {
            me.txtBalancePoint.val('')
            me.txtUsePoint.prop('readonly', true).val('');
            me.txtBlueCardMoney.prop('readonly', true).val('');
            me.txtBlueCardMobile.prop('readonly', true).val('');
            me.txtBlueCardCode.prop('readonly', true).val('');
            if ($(this).val().length == 19 && $(this).val().indexOf('-') == 4) {
                pointBalanceTime && clearTimeout(pointBalanceTime);
                let cardNo = me.inputCard.getRawValue()
                pointBalanceTime = setTimeout(function () {
                    me.getPointBalance('', cardNo)
                },200)
            }
            else {
                me.txtBlueCardMobile.prop('readonly', false)
            }

        })


        this.btnReceiveMoney.prop('disabled', true)
        $('#blueCardRedeemModal .modal-body input').keyup(() => {
            var empty = $('#blueCardRedeemModal .modal-body input').not(document.getElementById("txtBlueCardMobile")).filter(function () {
                return this.value === "";
            });
            setTimeout(() =>
                me.btnReceiveMoney.prop('disabled', empty.length || $('.invalid').is(":visible"))
                , 100)
        })

        this.lblBlueCardUsePointRedeemIsValid.hide()
        this.txtUsePoint.keyup(function () {
            me.lblBlueCardUsePointRedeemIsValid.hide()
            if (+me.inputBalancePoint.getRawValue() < +me.txtUsePoint.val()) {
                me.lblBlueCardUsePointRedeemIsValid.show()
            }
        })


        this.btnReceiveMoney.click(() => {
            me.addRowToDt(me.modalName, me.inputCard.getRawValue(), me.txtBlueCardMoney.val(), me.txtNote.val(), me.txtUsePoint.val(), me.txtBlueCardCode.val())
        })

        this.lblBlueCardSaveIsValid.hide()
        this.btnSave.prop("disabled", true)
        this.txtBlueCardSaveTel.keyup(function (e) {
            me.lblBlueCardSaveIsValid.hide()
            me.txtBlueCardSaveNo.val('')
            me.hidBlueCardSaveNo.val('')
            if ($(this).val().length > 10 && $(this).val().indexOf('-') < 0) {
                me.lblBlueCardSaveIsValid.show()
            }
            else if ($(this).val().length == 12 ) {
                let phone = me.inputMobileSave.getRawValue()
                me.getBlueCardNo(phone)
            }
        })

        this.txtBlueCardSaveNo.change(function (e) {
            if ($(this).val().length == 19 || $(this).val().indexOf('-') == 4) {
                me.hidBlueCardSaveNo.val(me.inputCardSave.getRawValue())
                me.btnSave.prop("disabled", false)
            }
            else {
                me.hidBlueCardSaveNo.val('')
                me.btnSave.prop("disabled", true)
            }
        })
    }

    //getBlueCardNo(phone) {
    //    const me = this
    //    this.hidBlueCardSaveMobile.val(phone)
    //    $.get(me.getUrl, { phoneNumber: phone }, (resp) => {
    //        if (resp.Code != "00") {
    //            warningAlert(resp.Message)
    //            me.txtBlueCardSaveNo.val('')
    //            me.hidBlueCardSaveNo.val('')
    //            me.btnSave.prop("disabled", true)
    //        }
    //        else {
    //            me.inputCardSave.setRawValue(resp.Data)
    //            me.hidBlueCardSaveNo.val(resp.Data)
    //            me.btnSave.prop("disabled", false)
    //        }

    //        console.log(resp)
    //    })
    //}
    getBlueCardNo(phone) {
        const me = this
        this.hidBlueCardSaveMobile.val(phone)
     
        $.ajax({
            type: "GET",
            url: me.getUrl,
            data: { phoneNumber: phone },
            beforeSend: function () {
                $("#loaderDiv").show();
            },
            success: function (resp) {
             if (resp.Code != "00") {
                warningAlert(resp.Message)
                me.txtBlueCardSaveNo.val('')
                me.hidBlueCardSaveNo.val('')
               me.btnSave.prop("disabled", true)
            }
            else {
                me.inputCardSave.setRawValue(resp.Data)
                me.hidBlueCardSaveNo.val(resp.Data)
                me.btnSave.prop("disabled", false)
            }

                $("#loaderDiv").hide();

            }
        });
           
        
    }
    getPointBalance(phone, cardNo) {
        const me = this
        $.get(me.getPointBalanceUrl, { phoneNumber: phone, cardNo: cardNo }, (resp) => {
            if (resp.Code != "00") {
                warningAlert(resp.Message)
            }
            else {
                me.inputBalancePoint.setRawValue(resp.Data.pointBalance)
                me.inputCard.setRawValue(resp.Data.cardNo)
                me.txtUsePoint.prop('readonly', false);
                me.txtBlueCardMoney.prop('readonly', false);
                me.txtBlueCardCode.prop('readonly', false);
            }

            console.log(resp)
        })
    }

    receiveMoney() {
        const me = this
        $.get(me.getPointBalanceUrl, { phoneNumber: phone, cardNo: cardNo }, (resp) => {
            if (resp.Code != "00") {
                warningAlert(resp.Message)
            }
            else {
                me.inputBalancePoint.setRawValue(resp.Data)
            }

            console.log(resp)
        })
    }

    addRowToDt(paymentType, cardNo, money, note, usePoint, code) {
        const me = this

        me.hidBlueCardNo.val(cardNo)
        me.hidBlueCardCode.val(code)
        me.hidBlueCardMoney.val(money)
        me.hidBlueCardUsePoint.val(usePoint)
        me.inputCardSave.setRawValue(cardNo)
        me.hidBlueCardSaveNo.val(cardNo)

        let data = {
            paymentType: paymentType,
            note: note
        }

        let formValues = FormSerialize.getFormArray(me.indexForm.myForm, data)
        $.post(me.addUrl, formValues).done(function (resp) {
            if (!resp.Data) return

            me.indexForm.dtPayment.row.add({
                'id': resp.Data,
                'paymentType': paymentType,
                'money': money,
                'number': cardNo,
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

            me.indexForm.addBlank()
            $(`a[title="${paymentType}"]`).addClass('not-active')
            me.blueCardRedeemModal.modal('toggle');
        })
    }
}
