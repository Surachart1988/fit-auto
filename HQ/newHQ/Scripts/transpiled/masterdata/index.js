'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var MasterDataForm = function () {
    function MasterDataForm() {
        _classCallCheck(this, MasterDataForm);


        this.createUrl = null;
        this.form = null;
    }

    _createClass(MasterDataForm, [{
        key: 'init',
        value: function init() {
            var me = this;

            $('#btnIrredeem').click(function () {
                var _data = $('form').serialize();
                $.ajax({
                    url: me.createUrl,
                    type: "POST",
                    data: _data
                }).done(function (result) {
                    if (!result.success) {
                        warningAlert(result.Message);
                    } else {
                        successAlertWithUrl(result.Message, result.url);
                    }
                }).fail(function (x, a, e) {
                    warningAlert(e);
                });
            });
        }

    }
    ]);

    return MasterDataForm;
}();