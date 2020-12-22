class IndexForm {
    constructor() {
        this.status = 'add'
        this.moneyBalance = 0

        this.dtPaymentList = $('#payment-list')
        this.txtBalance = $('#txtBalance')
        this.txtTotalAmount = $('#TotalAmount')
        this.txtTotalDiscount = $('#TotalDiscount')
        this.txtExtraDiscount = $('#txtExtraDiscount')
        this.txtPaymentAmount = $('#PaymentAmount')
        this.txtPaymentCash = $('#txtPaymentCash')
        this.txtCashNote = $('#txtCashNote')
        this.txtChangeMoney = $('#txtChangeMoney')
        this.btnChangeMoney = $('#btnChangeMoney')
        this.btnSubmit = $('#btnSubmit')

        this.blueCardNo = $('#BlueCardNo')
        this.blueCardBalancePoint = $('#BlueCardBalancePoint')
        this.blueCardRewardPoint = $('#BlueCardRewardPoint')

        this.hidDocNo = $('#DocNo')
        this.hidDocCode = $('#DocCode')

        this.hidCashAmount = $('#CashAmount')
        this.hidChangeMoney = $('#ChangeMoney')

        this.cashModal = $('#cashModal')
        this.crModal = $('#creditCardModal')

        this.btnLastDiscount = $('#btnLastDiscount')
        this.txtLastDiscount = $('#txtLastDiscount')
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

        this.dtDiscountList = $('#discount-list')
        this.myForm = $('#myForm')
        this.addDiscountUrl = null
        this.deleteDiscountUrl = null
        this.deletePaymentCreditCardUrl = null
        this.deleteDepositUrl = null
        this.id = null

    }
    init() {
        const me = this
        this.btnSubmit.prop("disabled", true);
        this.createPaymentDatatable()

        this.setTotal()

        this.createDiscountDatatable()

        this.addBlank()

        let dtDiscountData = me.dtDiscount.rows().data()
        for (var i = dtDiscountData.length; i < 3; i++) {
            this.dtDiscount.row.add({
                'name': '',
                'number': '',
                'money': '',
                'id': '',
            }).draw();
        }

        this.btnLastDiscount.prop("disabled", true);

        this.txtLastDiscount.keyup(() => {
            this.btnLastDiscount.prop("disabled", this.txtLastDiscount.val() <= 0);

            if (event.keyCode === 13) {
                me.btnLastDiscount.click()
            }
        })
        this.btnLastDiscount.click(() => {
            me.addExtraDiscount('ส่วนลดท้ายบิล', me.txtLastDiscount.val())
            me.lastDiscountModal.modal('toggle')
        })

        this.lastDiscountModal.on('shown.bs.modal', function () {
            me.txtLastDiscount.focus()
        })

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
                    { data: "money", render: $.fn.dataTable.render.number(',', '.', 2) },
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
                    $.get(me.deleteDiscountUrl, { id: id })
                        .done(function (resp) {
                            if (resp.Code != "00") return
                            me.dtPayment.row(row).remove().draw()
                            $(`a[title="หัก ณ ที่จ่าย 3%"]`).removeClass('not-active')
                            me.setTotalPaymentAmount()
                        })
                    break
                case "Blue Card":
                    $.get(me.deleteDiscountUrl, { id: id })
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
                    $.get(me.deleteDiscountUrl, { id: id })
                        .done(function (resp) {
                            if (resp.Code != "00") return
                            me.dtPayment.row(row).remove().draw()
                            $(`a[title="LAZADA"]`).removeClass('not-active')
                            me.setTotalPaymentAmount()
                        })
                    break
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

    createDiscountDatatable() {
        const me = this
        this.dtDiscount = this.dtDiscountList.DataTable(
            {
                "searching": false,
                "paging": false,
                "ordering": false,
                "scrollY": "14vh",
                "scrollCollapse": true,
                "info": false,
                columns: [
                    { data: "name" },
                    { data: "number", render: $.fn.dataTable.render.number(',', '.', 0) },
                    { data: "money", render: $.fn.dataTable.render.number(',', '.', 2) },
                    {
                        data: 'id',
                        className: "text-center",
                        render: function (data, type, row) {
                            if (data)
                                return '<a href="#" class="remove"><i class="fa fa-trash"></i></a>'
                            return ''
                        }
                    }
                ]

            })

        this.dtDiscountList.on('click', 'a.remove', function (e) {
            let money = me.dtDiscount.row($(this).closest('tr')).data().money
            let name = me.dtDiscount.row($(this).closest('tr')).data().name
            let id = me.dtDiscount.row($(this).closest('tr')).data().id
            $.get(me.deleteDiscountUrl, { id: id })
            $(`a[title="${name}"]`).removeClass('not-active')
            me.processDiscount(-money)
            me.dtDiscount.row($(this).closest('tr')).remove().draw()
            me.setTotalPaymentAmount()
        });
    }

    setTotal() {
        let balance = +this.txtTotalAmount.val() - +this.txtExtraDiscount.val() - +this.txtPaymentAmount.val()

        if (balance < 0) balance = 0
        this.txtBalance.val(balance.toFixed(2))

        this.btnSubmit.prop("disabled", balance > 0);
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

        this.txtPaymentAmount.val(totalPayment.toFixed(2));
        this.setTotal()
        this.displayPayment()
    }

    displayPayment() {
        let datas = this.dtPayment.rows().data()
        if (datas.length > 0) {
            let data = datas.filter((element) => {
                return element.paymentType == 'เงินสด';
            })

            $('.payment-col a,.discount-col a').removeClass('not-active-finish')
            if (data.length > 0) {
                $('a[title="เครดิตการ์ด"]').addClass('not-active-finish')
                $('a[title="เครดิต EDC"]').addClass('not-active-finish')
            }
            else {
                $('a[title="เครดิตการ์ด"]').removeClass('not-active-finish')
                $('a[title="เครดิต EDC"]').removeClass('not-active-finish')
            }

            let data2 = datas.filter((element) => {
                return element.paymentType.indexOf("เครดิต") > -1;
            })

            if (data2.length > 0) {
                $('a[title="เงินสด"]').addClass('not-active-finish')
            }
            else {
                $('a[title="เงินสด"]').removeClass('not-active-finish')
            }

            if (this.txtBalance.val() == 0) {
                $('.payment-col a,.discount-col a').addClass('not-active-finish')
            }
        }
    }

    processDiscount(newDiscount) {
        let extraDiscount = +this.txtExtraDiscount.val()
        extraDiscount += +newDiscount
        this.txtExtraDiscount.val(extraDiscount.toFixed(2))

        let totalDiscount = +this.txtTotalDiscount.val()
        totalDiscount += +newDiscount
        this.txtTotalDiscount.val(totalDiscount.toFixed(2))
        this.setTotal()
    }

    addExtraDiscount(name, bath, percent, code) {
        const me = this
        let money = 0
        if (bath && bath > 0) {
            money = +bath
        } else {
            money = +((this.txtBalance.val() * percent / 100).toFixed(2))
        }

        $.get(me.addDiscountUrl, {
            name: name,
            Code: code,
            DocNo: me.hidDocNo.val(),
            DocCode: me.hidDocCode.val(),
            Money: money
        }).done(function (resp) {
            if (!resp.Data) return

            money = money > +me.txtBalance.val() ? +me.txtBalance.val() : money

            me.dtDiscount.row.add({
                'name': name,
                'number': 1,
                'money': money,
                'id': resp.Data,
            }).draw();

            let indexes = me.dtDiscount.rows().eq(0).filter(function (rowIdx) {
                return me.dtDiscount.cell(rowIdx, 0).data() === '' ? true : false;
            });

            me.dtDiscount.rows(indexes).remove().draw()

            let dtDiscountData = me.dtDiscount.rows().data()
            for (var i = dtDiscountData.length; i < 3; i++) {
                me.dtDiscount.row.add({
                    'name': '',
                    'number': '',
                    'money': '',
                    'id': '',
                }).draw();
            }

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

        for (var i = currentData.length; i < 3; i++) {
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