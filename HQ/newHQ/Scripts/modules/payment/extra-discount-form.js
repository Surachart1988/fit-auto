class ExtraDiscountForm {
    constructor() {
        this.ddValueType = $('#valueType')
        this.lblUnit = $('#unit')
        this.txtBaht = $('#Baht')
        this.txtPrecent = $('#Percents')
        this.myForm = $('#myForm')
    }

    init() {
        const me = this
        if (this.txtBaht.val() == 0)
            this.ddValueType.val(1)
        this.ValueTypeChange()
        this.ddValueType.change(() => {
            me.ValueTypeChange()
        })

        commaFormSubmit(me.myForm)
    }

    ValueTypeChange() {
        if (this.ddValueType.val() == 0) {
            this.txtBaht.show()
            this.txtPrecent.val('').hide()
            this.lblUnit.text('บาท')
        }
        else {
            this.txtBaht.val('').hide()
            this.txtPrecent.show()
            this.lblUnit.text('%')
        }
    }
}