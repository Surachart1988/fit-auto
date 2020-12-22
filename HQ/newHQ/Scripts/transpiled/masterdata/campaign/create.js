'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var CampaignForm = function () {
    function CampaignForm() {
        _classCallCheck(this, CampaignForm);

        this.btnConnect = $('#btnConnect');
        this.txthttp_path = $('#http_path');
        this.form = $('#myForm');
    }

    _createClass(CampaignForm, [{
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
            let opts = {
                custom: {
                    equals: function ($el) {
                        //var matchValue = $el.data("equals")
                        if ($el.val() === "0") {
                            return "error"
                        }
                    }
                }
            }
            me.form.validator(opts).on('submit', function (e) {
                if (e.isDefaultPrevented()) {
                    // handle the invalid form...
                } else {
                    // everything looks good!
                }
            });
        }
    }]);


    return CampaignForm;
}();