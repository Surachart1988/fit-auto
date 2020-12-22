class PromotionModal {
    constructor() {
        this.modalName = "เช็คโปรโมชั่น"
        this.dtPromotionElem = $('#promotion-list')
        this.dtPromotionGiveElem = $('#promotion-give-list')
        this.modal = $('#checkPromotionModal')
        this.btnPromotionConfirm = $('#btnPromotionConfirm')
        this.promotionList = $('#promotionList')
        this.promotionDetails = $('#promotionDetails')
        this.promotionName = $('#promotionName')
        this.promotionDetailsName = $('#promotionDetailsName')
        this.txtTotalAmount = $('#TotalAmount')
        this.txtTotalNumber = $('#TotalNumber')

        this.hidDocNo = $('#DocNo')
        this.hidDocCode = $('#DocCode')
        this.hidRefDocNo = $('#RefDocNo')
        this.txtBalance = $('#txtBalance')
        this.giveData = []

        this.rowData = []
        this.getUrl = null
        this.addGiveUrl = null
        this.addDiscountUrl = null
        this.indexForm = null
        this.pageDetailsNo = 0
    }
    init() {
        const me = this

        this.modal.on('shown.bs.modal', function () {
            !me.dtPromotionList && me.createPromotionDatatable()

        })

        this.modal.on('hidden.bs.modal', function () {

        })

        this.promotionDetails.hide()
        this.btnPromotionConfirm.click(() => {
            //!me.dtPromotionGive && me.createPromotionDetailsDatatable()
            let rows = me.dtPromotionList.rows('.selected').data()
            for (var i = 0; i < rows.length; i++) {
                let row = rows[i]
                if (row.ProductGiveName)
                    me.addPromotionGive(row.ProductGiveName, row.Money, row.ProductGiveCode, row.Number)
                me.addPromotionDiscount(row.Name, +row.Discount * +row.Number, row.Code, row.Id)
            }
            me.dtPromotionList.rows('.selected').remove().draw()
        })
    }

    createPromotionDatatable() {
        const me = this
        this.dtPromotionList = this.dtPromotionElem.DataTable(
            {
                select: {
                    style: 'multi'
                },
                "scrollY": "40vh",
                'columns': [
                    {
                        data: "No",
                        "className": "text-center",
                    },
                    {
                        data: "Code",
                        "className": "text-center",
                    },
                    {
                        data: "Name",
                    },
                    {
                        data: "Type",
                        "className": "text-left",
                    },
                    {
                        data: "ProductDetail",
                        "className": "text-left",
                    },
                    {
                        data: "ProductGiveName",
                    },
                    {
                        data: "Number",
                        "className": "text-center",
                        render: $.fn.dataTable.render.number(',', '.', 0)
                    },
                    {
                        data: "Money",
                        "className": "text-right",
                        "render": function (data, type, row) {
                            return formatNumeric(+data - +row.Discount)
                        }
                    },
                    {
                        data: "ProductGiveCode",
                        visible: false
                    },
                    {
                        data: "Discount",
                        visible: false
                    },
                    {
                        data: "Id",
                        visible: false
                    }
                ]
            })

        $('#promotion-list tbody').on('click', 'tr', function () {
            if ($(this).hasClass('selected')) {
                //me.dt.$('tr.selected').removeClass('selected');
                $(this).removeClass('selected')
            }
            else {
                $(this).addClass('selected');
            }
        })
    }

    addPromotionDiscount(name, money, pmCode, id) {
        const me = this

        $.get(me.addDiscountUrl, {
            name: name,
            DocNo: me.hidDocNo.val(),
            DocCode: me.hidDocCode.val(),
            ReferenceNo: me.hidRefDocNo.val(),
            Money: money,
            ProductGiveCode: pmCode,
            Id: id
        }).done(function (resp) {
            if (!resp.Data) {
                alert(resp.Data)
                return
            }
            money = money > +me.txtBalance.val() ? +me.txtBalance.val() : money
            me.indexForm.processDiscount(money)
            me.modal.modal('toggle')
        });
    }

    addPromotionGive(name, money, code, number) {
        const me = this

        $.get(me.addGiveUrl, {
            name: name,
            Code: code,
            DocNo: me.hidDocNo.val(),
            DocCode: me.hidDocCode.val(),
            ReferenceNo: me.hidRefDocNo.val(),
            Money: money,
            Number: number

        }).done(function (resp) {
            if (!resp.Data) {
                alert(resp.Massage)
                return
            }
            money = money > +me.txtBalance.val() ? +me.txtBalance.val() : money
            me.indexForm.dtProducts.row.add({
                'name': name,
                'number': number,
                'money': money,
                'id': resp.Data,
            }).draw();

            me.txtTotalAmount.val((+me.txtTotalAmount.val() + (+money * +number)).toFixed(2))
            me.txtTotalNumber.val(+me.txtTotalNumber.val() + +number)
            me.indexForm.setTotal()
        });
    }

    //createPromotionDetailsDatatable() {
    //    const me = this
    //    this.dtPromotionGive = this.dtPromotionGiveElem.DataTable(
    //        {
    //            data: me.giveData,
    //            "scrollX": "78vw",
    //            "scrollY": "35vh",
    //            'columns': [
    //                {
    //                    data: "Code"
    //                },
    //                {
    //                    data: "Name",
    //                    "width": "20%"
    //                },
    //                {
    //                    data: "Type"
    //                },
    //                {
    //                    data: "Brand"
    //                },
    //                {
    //                    data: "Gen"
    //                },
    //                {
    //                    data: "Size"
    //                },
    //                {
    //                    data: "Price",
    //                    "className": "text-right",
    //                    render: $.fn.dataTable.render.number(',', '.', 2)
    //                },
    //                {
    //                    data: "StoreName"
    //                },
    //                {
    //                    data: "StockCurrent",
    //                    "className": "text-center",
    //                    "width": "4%"
    //                },
    //                {
    //                    data: "Id",
    //                    "className": "text-center",
    //                    "width": "10%",
    //                    "render": function (data, type, full) {
    //                        return `<input type="number" class="form-control" id="${data.Code}-${data.Store}">`
    //                    }
    //                }
    //            ]
    //        })
    //}

}