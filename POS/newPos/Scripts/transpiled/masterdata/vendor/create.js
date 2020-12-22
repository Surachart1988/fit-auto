'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var VendorForm = function () {
    function VendorForm() {
        _classCallCheck(this, VendorForm);

        this.btnConnect = $('#btnConnect');
        this.txthttp_path = $('#http_path');
        this.form = $('#myForm');
        this.selectproid = $('#add_providselect');
        this.selectamphurid = $('#add_amphur_idselect');
        this.selecttumbolid = $('#add_tumbol_idselect');
        this.selectzip = $('#add_zipselect');
        
        
    }

    _createClass(VendorForm, [{
        key: 'init',
        value: function init() {
            var me = this;

            me.indexForm.getOpDataProvince(me.selectproid.val());
            me.indexForm.getOpDataAmphur(me.selectproid.val(), me.selectamphurid.val());
            me.indexForm.getOpDataTumbol(me.selectproid.val(), me.selectamphurid.val(), me.selecttumbolid.val());
            me.indexForm.getOpDataZipCode(me.selectproid.val(), me.selectamphurid.val(), me.selectzip.val());
            

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


    return VendorForm;
}();

$(function () {
    taxbranchidreq();
    $('#contact_fdate').datepicker({
        autoclose: true,
        format: "dd/mm/yyyy",
        orientation: "bottom left",
        todayHighlight: true,
        disableTouchKeyboard: true
    });
    $('#cancel_date').datepicker({
        autoclose: true,
        format: "dd/mm/yyyy",
        orientation: "bottom left",
        todayHighlight: true,
        disableTouchKeyboard: true
    });

    $('.keyInteger').keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $(".keyNoInteger").keyup(function (e) {
        var regex = /^[a-zA-Z@]+$/;
        if (regex.test(this.value) !== true)
            this.value = this.value.replace(/[^a-zA-Z@]+/, '');
    });


    $("#tax_branch").change(function () {
        var tb = $("#tax_branch").val()
        if (tb === "สาขา") {
            $("#tax_branch_id").prop('disabled', false);
            $("#tax_branch_id").prop('required', true);
        } else {
            $("#tax_branch_id").val("");
            $("#tax_branch_id").prop('disabled', true);
            $("#tax_branch_id").prop('required', false);

        }
    });
    function taxbranchidreq() {
        var tb = $("#tax_branch").val()
        var m = $("#Mode").val();
        if (tb === "สาขา") {
            if (m == "v") {
                $("#tax_branch_id").prop('disabled', true);
            } else {
                $("#tax_branch_id").prop('disabled', false);
            }
            $("#tax_branch_id").prop('required', true);
        } else {
            $("#tax_branch_id").prop('disabled', true);
            $("#tax_branch_id").prop('required', false);
        }
    }

});



