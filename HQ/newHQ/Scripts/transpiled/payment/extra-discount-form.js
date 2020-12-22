'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var ExtraDiscountForm = function () {
    function ExtraDiscountForm() {
        _classCallCheck(this, ExtraDiscountForm);

        this.ddValueType = $('#valueType');
        this.lblUnit = $('#unit');
        this.txtBaht = $('#Baht');
        this.txtPrecent = $('#Percents');
        this.myForm = $('#myForm');
    }

    _createClass(ExtraDiscountForm, [{
        key: 'init',
        value: function init() {
            var me = this;
            if (this.txtBaht.val() == 0) this.ddValueType.val(1);
            this.ValueTypeChange();
            this.ddValueType.change(function () {
                me.ValueTypeChange();
            });

            commaFormSubmit(me.myForm);
        }
    }, {
        key: 'ValueTypeChange',
        value: function ValueTypeChange() {
            if (this.ddValueType.val() == 0) {
                this.txtBaht.show();
                this.txtPrecent.val('').hide();
                this.lblUnit.text('บาท');
            } else {
                this.txtBaht.val('').hide();
                this.txtPrecent.show();
                this.lblUnit.text('%');
            }
        }
    }]);

    return ExtraDiscountForm;
}();