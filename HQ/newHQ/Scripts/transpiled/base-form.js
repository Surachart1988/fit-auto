'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var _Form = function () {
    function _Form() {
        _classCallCheck(this, _Form);
        this.btnConnect = $('#btnConnect');
        this.btnSendCliDetail = $('#btnsendclientdetail');
        this.ddl_province = $('#add_provid');
        this.ddl_amphur = $('#add_amphur_id');
        this.ddl_tumbol = $('#add_tumbol_id');
    }

    _createClass(_Form, [{
        key: 'init',
        value: function init() {
            var me = this;

            if ($('.input-telephone').length > 0) {
                this.inputTelephone = new Cleave('.input-telephone', {
                    phone: true,
                    phoneRegionCode: 'TH',
                    delimiter: '-'
                });
            }
            if ($('.input-fax').length > 0) {
                this.inputFax = new Cleave('.input-fax', {
                    phone: true,
                    phoneRegionCode: 'TH',
                    delimiter: '-'
                });
            }

            me.ddl_province.change(function () {
                me.getOpDataAmphur();
                me.getOpDataTumbol();
                me.getOpDataZipCode();
            });

            me.ddl_amphur.change(function () {
                me.getOpDataTumbol();
                me.getOpDataZipCode();
            });

            me.ddl_tumbol.change(function () {
                me.getOpDataZipCode();
            });

            this.btnConnect.click(function () {
                var _url = "";

                if (this.value != "") {

                    _url = new URL(this.value).origin + "/FIT_POS/api/POSApi";

                    $.ajax({
                        url: _url,
                        beforeSend: function beforeSend() {
                            $("#loading").show();
                        },
                        success: function success(result) {
                            $("#loading").hide();
                            successAlert("เชื่อมต่อระบบ POS สำเร็จ");
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            $("#loading").hide();
                            warningAlert("ไม่สามารถเชื่อมต่อระบบ POS ได้");
                        }
                    });
                }
                else {
                    warningAlert("ไม่สามารถเชื่อมต่อระบบ POS ได้");
                }
            });

            me.btnSendCliDetail.click(function () {

                if (me.btnSendCliDetail != null) {
                    var model = {
                        act: this.value,
                        Detail_Id: $(this).attr("data-id"),
                        BranchList: [{
                            dealercode: $(this).attr("data-dealercode"),
                            plant_no: $(this).attr("data-plant_no"),
                            DealerName: $(this).attr("data-DealerName"),
                            http_path: $(this).attr("data-url"),
                            IsCheck: true
                        }]
                    };

                    $.ajax({
                        type: 'POST',
                        url: me.sendUrl,
                        data: JSON.stringify({ 'model': model }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        beforeSend: function beforeSend() {
                            $("#loading").show();
                        },
                        success: function success(result) {
                            $("#loading").hide();
                            if (!result.SendStatus) {
                                warningAlert(result.error_massage);
                            }
                            else {
                                successAlert("นำข้อมูลออกไปสาขาที่ต้องการเรียบร้อยแล้ว");
                            }
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            $("#loading").hide();
                            warningAlert(thrownError);
                        }
                    });
                }

            });
        }
    }, {
        key: 'getOpDataAmphur',
        value: function getOpDataAmphur() {
            var me = this;
            $.ajax({
                url: me.hqUrl + 'api/HQApi/GetddlAmphur',
                type: "GET",
                dataType: "JSON",
                data: { province_id: me.ddl_province.val() },
                success: function (data) {
                    $("#add_amphur_id").html("");
                    $.each(data, function (i, rows) {
                        $("#add_amphur_id").append(
                            $('<option></option>').val(rows.amphur_id).html(rows.amphur_name));
                    });
                }
            });

        }
    }
        , {
        key: 'getOpDataTumbol',
        value: function getOpDataTumbol() {
            var me = this;
            $.ajax({
                url: me.hqUrl + 'api/HQApi/GetddlTumbol',
                type: "GET",
                dataType: "JSON",
                data: { amphur_id: me.ddl_amphur.val(), province_id: me.ddl_province.val() },
                success: function (data) {
                    $("#add_tumbol_id").html("");
                    $.each(data, function (i, rows) {
                        $("#add_tumbol_id").append(
                            $('<option></option>').val(rows.tambol_id).html(rows.tambol_name));
                    });
                }
            });
        }
    }
        , {
        key: 'getOpDataZipCode',
        value: function getOpDataZipCode() {
            var me = this;
            $.ajax({
                url: me.hqUrl + 'api/HQApi/GetddlZipCode',
                type: "GET",
                dataType: "JSON",
                data: { amphur_id: me.ddl_amphur.val(), province_id: me.ddl_province.val() },
                success: function (data) {
                    $("#add_zip").html("");
                    $.each(data, function (i, rows) {
                        $("#add_zip").append(
                            $('<option></option>').val(rows.zip_id).html(rows.zip_code));
                    });
                }
            });
        }
    }
    ]);


    return _Form;
}();