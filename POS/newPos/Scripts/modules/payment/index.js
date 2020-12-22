class PaymentForm {
    constructor() {
        this.status = 'add'
        this.moneyBalance = 0
        this.txtTotalNumber = $('#TotalNumber')
        this.dtPaymentList = $('#payment-list')
        this.txtBalance = $('#txtBalance')
        this.txtTotalAmount = $('#TotalAmount')
        this.txtTotalDiscount = $('#TotalDiscount')
        this.txtExtraDiscount = $('#txtExtraDiscount')
        this.txtPaymentAmount = $('#PaymentAmount')
        this.txtPaymentCash = $('#txtPaymentCash')
        this.hidPaymentCash = $('#PaymentCash')
        this.txtCashNote = $('#txtCashNote')
        this.txtChangeMoney = $('#txtChangeMoney')
        this.btnChangeMoney = $('#btnChangeMoney')
        this.btnSubmit = $('#btnSubmit')

        this.txtPaymentMoney = $('#txtPaymentMoney')
        this.txtPaymentMoneyCash = $('#txtPaymentMoneyCash')

        this.blueCardNo = $('#BlueCardNo')
        this.blueCardBalancePoint = $('#BlueCardBalancePoint')
        this.blueCardRewardPoint = $('#BlueCardRewardPoint')

        this.hidDocNo = $('#DocNo')
        this.hidDocCode = $('#DocCode')
        this.hidRefDocNo = $('#RefDocNo')

        this.hidCashAmount = $('#CashAmount')
        this.hidChangeMoney = $('#ChangeMoney')
        this.txtPaymentTotal = $('#txtPaymentTotal')

        this.cashModal = $('#cashModal')
        this.crModal = $('#creditCardModal')

        this.blueCardModal = $('#blueCardSaveModal')

        this.btnLastDiscount = $('#btnLastDiscount')
        this.txtLastDiscount = $('#txtLastDiscount')
        this.txtLastDiscountPercent = $('#txtLastDiscountPercent')
        this.rdoUnitLastDiscount1 = $('#rdoUnitLastDiscount1')
        this.rdoUnitLastDiscount2 = $('#rdoUnitLastDiscount2')
        this.lblLastDiscountIsValid = $('#lblLastDiscountIsValid')
        this.lastDiscountModal = $('#lastDiscountModal')

        this.txtPaymentCreditCard = $('#txtPaymentCreditCard')
        this.txtCreditNumber = $('#txtCreditNumber')
        this.txtApprCode = $('#txtApprCodeEdc')
        this.ddBank = $('#ddBank')
        this.ddPaymentFormat = $('#ddPaymentFormat')
        this.ddCardType = $('#ddCardType')
        this.ddCreditMonth = $('#ddCreditMonth')
        this.ddCreditYear = $('#ddCreditYear')
        this.txtCreditCardNote = $('#txtCreditCardNote')

        this.dtDiscountElem = $('#discount-list')
        this.dtProductElem = $('#product-list')
        this.myForm = $('#myForm')
        this.addDiscountUrl = null
        this.deleteDiscountUrl = null
        this.deleteProductPomotionUrl = null
        this.deletePaymentCreditCardUrl = null
        this.addPaymentOtherUrl = null
        this.deletePaymentOtherUrl = null
        this.deleteDepositUrl = null
        this.clearProductListTempUrl = null
        this.id = null

    }
    init() {
        const me = this
        this.btnSubmit.prop("disabled", true)
        this.createPaymentDatatable()

        this.setTotal()

        this.createDiscoundListDatatable()
        this.createProductListDatatable()

        this.addBlank()

        let productListData = me.dtDiscounds.rows().data()

        for (var i = 0; i < productListData.length; i++) {
            if (productListData[i].id) {
                $(`a[title="${productListData[i].name}"]`).addClass('not-active')
            }
        }

        if (productListData.length < 1) {
            this.dtDiscounds.row.add({
                'name': '',
                'number': '',
                'money': '',
                'id': '',
            }).draw()
        }

        this.btnLastDiscount.prop("disabled", true);

        this.txtLastDiscount.keyup(() => {
            let isValid = +me.txtLastDiscount.val() <= 0 || +me.txtLastDiscount.val() > +me.txtBalance.val()
            me.btnLastDiscount.prop("disabled", isValid);
            me.lblLastDiscountIsValid.prop("hidden", +me.txtLastDiscount.val() <= +me.txtBalance.val())
            if (isValid) return

            if (event.keyCode === 13) {
                me.btnLastDiscount.click()
            }
        })

        this.txtLastDiscountPercent.keyup(() => {
            me.txtLastDiscount.val(+me.txtTotalAmount.val() * +me.txtLastDiscountPercent.val() / 100)
            let isValid = +me.txtLastDiscount.val() <= 0 || +me.txtLastDiscount.val() > +me.txtBalance.val()
            me.btnLastDiscount.prop("disabled", isValid);
            me.lblLastDiscountIsValid.prop("hidden", +me.txtLastDiscount.val() <= +me.txtBalance.val())
            if (isValid) return

            if (event.keyCode === 13) {
                me.btnLastDiscount.click()
            }
        })

        this.btnLastDiscount.click(() => {
            me.addExtraDiscount('ส่วนลดอื่นๆ', me.txtLastDiscount.val(), 0, 'DIS00000000','','')
            me.lastDiscountModal.modal('toggle')
        })

        this.lastDiscountModal.on('shown.bs.modal', function () {
            me.txtLastDiscount.focus()
        })

        me.txtLastDiscountPercent.hide()

        this.rdoUnitLastDiscount2.click(() => {
            me.txtLastDiscount.val(0)
            me.txtLastDiscount.hide()
            me.txtLastDiscountPercent.show()
        })

        this.rdoUnitLastDiscount1.click(() => {
            me.txtLastDiscountPercent.val(0)
            me.txtLastDiscountPercent.hide()
            me.txtLastDiscount.show()
        })

        if (me.hidDocCode.val() == "A302") {
            $('.discount-col a').addClass('not-active-finish')
        }

        //window.onbeforeunload = function (e) {
        //    if (!submitted) {
        //        var message = "You have not saved your changes.", e = e || window.event;
        //        if (e) {
        //            e.returnValue = message;
        //        }
        //        $.get(me.clearProductListTempUrl, { docCode: me.hidDocCode.val(), docNo: me.hidDocNo.val(), refDocNo: me.hidRefDocNo.val() }, () => {
        //            return s;
        //        })

        //        return message;
        //    }
        //}

        commaFormSubmit(me.myForm)
    }

    createPaymentDatatable() {
        const me = this
        this.dtPayment = this.dtPaymentList.DataTable(
            {
                "searching": false,
                "paging": false,
                "ordering": false,
                "scrollY": "14vh",
                "scrollCollapse": true,
                "info": false,
                columns: [
                    { data: "id", visible: false },
                    { data: "paymentType" },
                    {
                        data: "money",
                        className: "text-right",
                        render: $.fn.dataTable.render.number(',', '.', 2)
                    },
                    {
                        data: "number",
                        render: function (data, type, row) {
                            if (data) {
                                let dataArr = data.split("-")
                                if (dataArr.length == 4 && data.length == 19) {
                                    return `${dataArr[0]}-${dataArr[1][0] + dataArr[1][1]}XX-XXXX-${dataArr[3]}`
                                }
                                return data
                            }
                            return ''
                        }
                    },
                    {
                        data: "note",
                        render: function (data, type, row) {
                            if (data.length > 9) {
                                let value = data.substring(0, 9);
                                return `${value}..`
                            }
                            return data
                        }
                    },
                    {
                        data: 'options',
                        className: "text-center",
                        render: function (data, type, row) {
                            if (data) {
                                let optionsHtml = ''
                                if (data == 'all')
                                    optionsHtml += '<a href="#" class="edit"><i class="fa fa-edit"></i></a>|<a href="#" class="remove"><i class="fa fa-trash"></i></a>'
                                if (data == 'delete')
                                    optionsHtml += '<a href="#" class="remove"><i class="fa fa-trash"></i></a>'
                                return optionsHtml
                            }
                            return ''
                        }
                    },
                    { data: "modalName", visible: false },
                    { data: "apprCode", visible: false },
                    { data: "bank", visible: false },
                    { data: "payFormat", visible: false },
                    { data: "cardType", visible: false },
                    { data: "crMonth", visible: false },
                    { data: "crYear", visible: false },
                ]

            })

        this.dtPaymentList.on('click', 'a.remove', function (e) {
            let row = $(this).closest('tr')
            let id = me.dtPayment.row(row).data().id
            let paymentType = me.dtPayment.row(row).data().paymentType
            switch (paymentType) {
                case "เงินสด":
                    me.hidCashAmount.val(0)
                    me.hidChangeMoney.val(0)
                    me.dtPayment.row(row).remove().draw()
                    me.setTotalPaymentAmount()
                    me.hidPaymentCash.val(0)
                    break
                case "เครดิตการ์ด":
                    $.get(me.deletePaymentCreditCardUrl, { id: id })
                        .done(function (resp) {
                            if (resp.Code != "00") return
                            me.dtPayment.row(row).remove().draw()
                            me.setTotalPaymentAmount()
                        })
                    break
                case "เงินมัดจำ":
                    $.get(me.deleteDepositUrl, { id: id })
                        .done(function (resp) {
                            if (resp.Code != "00") return
                            me.dtPayment.row(row).remove().draw()
                            me.setTotalPaymentAmount()
                        })
                    break
                case "หัก ณ ที่จ่าย 3%":
                    $.get(me.deletePaymentOtherUrl, { id: id })
                        .done(function (resp) {
                            if (resp.Code != "00") return
                            me.dtPayment.row(row).remove().draw()
                            $(`a[title="หัก ณ ที่จ่าย 3%"]`).removeClass('not-active')
                            me.setTotalPaymentAmount()
                        })
                    break
                case "BlueCardRedeem":
                    $.get(me.deletePaymentOtherUrl, { id: id })
                        .done(function (resp) {
                            if (resp.Code != "00") return
                            me.dtPayment.row(row).remove().draw()
                            me.blueCardNo.val('')
                            me.blueCardBalancePoint.val('')
                            me.blueCardRewardPoint.val('')
                            $(`a[title="Blue Card"]`).removeClass('not-active')
                            me.setTotalPaymentAmount()
                        })
                    break
                case "LAZADA":
                    $.get(me.deletePaymentOtherUrl, { id: id })
                        .done(function (resp) {
                            if (resp.Code != "00") return
                            me.dtPayment.row(row).remove().draw()
                            $(`a[title="LAZADA"]`).removeClass('not-active')
                            me.setTotalPaymentAmount()
                        })
                    break
                //default:
                //    let money = me.dtPayment.row(row).data().money
                //    $.get(me.deleteDiscountUrl, { id: id })
                //        .done(function (resp) {
                //            $(`a[title="${me.dtPayment.row(row).data().number}"]`).removeClass('not-active')
                //            me.processDiscount(-money)
                //            me.dtPayment.row(row).remove().draw()
                //        })
                //    break
            }

        })

        this.dtPaymentList.on('click', 'a.edit', function (e) {

            me.status = 'edit'
            let row = $(this).closest('tr')
            me.id = me.dtPayment.row(row).data().id
            let data = me.dtPayment.row(row).data()
            switch (data.paymentType) {
                case "เงินสด":
                    me.txtPaymentCash.val(data.money)
                    me.txtCashNote.val(data.note)
                    break
                case "เครดิตการ์ด":
                    me.txtPaymentCreditCard.val(data.money)
                    me.txtCreditNumber.val(data.number)
                    me.txtApprCode.val(data.apprCode)
                    me.ddBank.val(data.bank)
                    me.ddPaymentFormat.val(data.payFormat)
                    me.ddCardType.val(data.cardType)
                    me.txtCreditCardNote.val(data.note)
                    me.ddCreditMonth.val(data.crMonth)
                    me.ddCreditYear.val(data.crYear)
                    break
            }
            $(`#${data.modalName}`).modal()
        })
    }

    createProductListDatatable() {
        const me = this
        this.dtProducts = this.dtProductElem.DataTable(
            {
                "searching": false,
                "paging": false,
                "ordering": false,
                "scrollY": "24vh",
                "scrollCollapse": true,
                "info": false,
                columns: [
                    {
                        data: "name",
                        width: "50%"
                    },
                    {
                        data: "number",
                        className: "text-center",
                        width: "15%",
                        render: $.fn.dataTable.render.number(',', '.', 0)
                    },
                    {
                        data: "money",
                        className: "text-right-modify",
                        width: "35%",
                        render: $.fn.dataTable.render.number(',', '.', 2)
                    },
                    {
                        data: 'id',
                        width: "10%",
                        className: "text-center",
                        render: function (data, type, row) {
                            if (data)
                                return '<a href="#" class="remove"><i class="fa fa-trash"></i></a>'
                            return ''
                        }
                      
                    }
                ]
            })
    }

    createDiscoundListDatatable() {
        const me = this
        this.dtDiscounds = this.dtDiscountElem.DataTable(
            {
                "searching": false,
                "paging": false,
                "ordering": false,
                "scrollY": "10vh",
                "scrollCollapse": true,
                "info": false,
                columns: [
                    {
                        data: "name",
                        width: "50%"
                    },
                    {
                        data: "number",
                        className: "text-center",
                        width: "15%",
                        render: $.fn.dataTable.render.number(',', '.', 0)
                    },
                    {
                        data: "money",
                        width: "25%",
                        className: "text-right-modify",
                        render: $.fn.dataTable.render.number(',', '.', 2)
                    },
                    {
                        data: 'id',
                        width: "10%",
                        className: "text-center",
                        render: function (data, type, row) {
                            if (data)
                                return '<a href="#" class="remove"><i class="fa fa-trash"></i></a>'
                            return ''
                        }
                    }
                ]

            })

        this.dtDiscountElem.on('click', 'a.remove', function (e) {
            let money = me.dtDiscounds.row($(this).closest('tr')).data().money
            let name = me.dtDiscounds.row($(this).closest('tr')).data().name
            let id = me.dtDiscounds.row($(this).closest('tr')).data().id
            $.get(me.deleteDiscountUrl, { id: id, docCode: me.hidDocCode.val() })
            $(`a[title="${name}"]`).removeClass('not-active')

            if (name == "ส่วนลดอื่นๆ")
                me.otherDiscount(-money)
            else {
                me.processDiscount(-money)
                //me.txtTotalNumber.val(+me.txtTotalNumber.val() - 1)
            }
            me.dtDiscounds.row($(this).closest('tr')).remove().draw()
            me.setTotalPaymentAmount()
        });

     
    }

    setTotal() {
        this.txtPaymentMoney.val((+this.txtTotalAmount.val() - +this.txtExtraDiscount.val() - +this.txtTotalDiscount.val()).toFixed(2))
        this.txtPaymentMoneyCash.val((+this.txtTotalAmount.val() - +this.txtExtraDiscount.val() - +this.txtTotalDiscount.val()).toFixed(2))
        let balance = +this.txtPaymentMoney.val() - +this.txtPaymentAmount.val()

        if (balance < 0) balance = 0
        this.txtBalance.val(balance.toFixed(2))
        this.hidPaymentCash.val((+this.txtPaymentCash.val()).toFixed(2))
        this.btnSubmit.prop("disabled", balance > 0)
    }

    setTotalPaymentAmount() {
        const me = this
        let datas = this.dtPayment.rows().data()
        let totalPayment = 0
        for (var i = 0; i < datas.length; i++) {
            let value = datas[i].money
            if (value && value.toString().indexOf(',') > -1)
                value = value.replace(/\,/g, '')
            let money = +value
            totalPayment += money
        }

        this.txtPaymentAmount.val(totalPayment.toFixed(2))
        this.setTotal()
        this.displayPayment()
    }

    displayPayment() {
        //let datas = this.dtPayment.rows().data()
        //if (datas.length > 0) {
        //let data = datas.filter((element) => {
        //    return element.paymentType == 'เงินสด';
        //})

        $('.payment-col a,.discount-col a').removeClass('not-active-finish')
        //if (data.length > 0) {
        //    $('a[title="เครดิตการ์ด"]').addClass('not-active-finish')
        //    $('a[title="เครดิต EDC"]').addClass('not-active-finish')
        //}
        //else {
        //    $('a[title="เครดิตการ์ด"]').removeClass('not-active-finish')
        //    $('a[title="เครดิต EDC"]').removeClass('not-active-finish')
        //}

        //let data2 = datas.filter((element) => {
        //    return element.paymentType.indexOf("เครดิต") > -1;
        //})

        //if (data2.length > 0) {
        //    $('a[title="เงินสด"]').addClass('not-active-finish')
        //}
        //else {
        //    $('a[title="เงินสด"]').removeClass('not-active-finish')
        //}

        if (this.txtBalance.val() == 0) {
            $('.payment-col a,.discount-col a').addClass('not-active-finish')
            this.blueCardModal.modal()
        }


        //}
    }

    otherDiscount(newDiscount) {
        let extraDiscount = +this.txtExtraDiscount.val()
        extraDiscount += +newDiscount
        this.txtExtraDiscount.val(extraDiscount.toFixed(2))
        this.setTotal()
    }

    processDiscount(newDiscount) {
        let totalDiscount = +this.txtTotalDiscount.val()
        totalDiscount += +newDiscount
        this.txtTotalDiscount.val(totalDiscount.toFixed(2))
        this.setTotal()
    }

    addExtraDiscount(name, bath, percent, code) {
        if ($(`a[title="${name}"]`).hasClass('not-active')) return
        const me = this
        let money = 0
        if (bath && bath > 0) {
            money = +bath
        } else {
            money = (+this.txtTotalAmount.val() * percent / 100).toFixed(2)//+(((+this.txtTotalAmount.val() / (1 + 0.07)) * percent / 100).toFixed(2))
        }

        $.get(me.addDiscountUrl, {
            name: name,
            Code: code,
            DocNo: me.hidDocNo.val(),
            DocCode: me.hidDocCode.val(),
            ReferenceNo: me.hidRefDocNo.val(),
            Money: money
        }).done(function (resp) {
            if (!resp.Data) {
                alert(resp.Data)
                return
            }

            //me.txtTotalNumber.val(+me.txtTotalNumber.val() + 1)
            money = money > +me.txtBalance.val() ? +me.txtBalance.val() : money

            me.dtDiscounds.row.add({
                'name': name,
                'number': 1,
                'money': money,
                'id': resp.Data,
            }).draw();

            let indexes = me.dtDiscounds.rows().eq(0).filter(function (rowIdx) {
                return me.dtDiscounds.cell(rowIdx, 0).data() === '' ? true : false;
            });

            me.dtDiscounds.rows(indexes).remove().draw()

            let dtDiscoundData = me.dtDiscounds.rows().data()
            for (var i = dtDiscoundData.length; i < 3; i++) {
                me.dtDiscounds.row.add({
                    'name': '',
                    'number': '',
                    'money': '',
                    'id': '',
                }).draw();
            }
            if (name == "ส่วนลดอื่นๆ")
                me.otherDiscount(money)
            else
                me.processDiscount(money)

            $(`a[title="${name}"]`).addClass('not-active')
        });
    }

    addBlank() {
        const me = this

        let indexes = me.dtPayment.rows().eq(0).filter(function (rowIdx) {
            return me.dtPayment.cell(rowIdx, 1).data() === '' ? true : false;
        });
        this.dtPayment.rows(indexes).remove().draw()

        let currentData = me.dtPayment.rows().data()

        for (var i = currentData.length; i < 1; i++) {
            me.dtPayment.row.add({
                'id': '',
                'paymentType': '',
                'money': '',
                'number': '',
                'note': '',
                'options': '',
                'modalName': '',
                'apprCode': '',
                'bank': '',
                'payFormat': '',
                'cardType': '',
                'crMonth': '',
                'crYear': '',
            }).draw()
        }

        this.setTotalPaymentAmount()
    }
}