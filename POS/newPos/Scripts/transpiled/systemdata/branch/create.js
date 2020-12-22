'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var BranchForm = function () {
    function BranchForm() {
        _classCallCheck(this, BranchForm);

        this.btnConnect = $('#btnConnect');
        this.txthttp_path = $('#http_path');
        this.form = $('#myForm');
    }

    _createClass(BranchForm, [{
        key: 'init',
        value: function init() {
            var me = this;

            me.txthttp_path.change(function () {
                if (this) {
                    if (me.btnConnect != null) {
                        me.btnConnect.val(this.value);
                    }
                }
            })

            me.form.validator().on('submit', function (e) {
                if (e.isDefaultPrevented()) {
                    // handle the invalid form...
                } else {
                    // everything looks good!
                }
            });
        }
    }]);


    return BranchForm;
}();