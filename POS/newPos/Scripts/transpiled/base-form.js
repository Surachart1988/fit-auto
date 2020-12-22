'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var _Form = function () {
    function _Form() {
        _classCallCheck(this, _Form);
        this.btnConnect = $('#btnConnect');
        this.btnConnEdc = $('#btnConnEDC');
        this.btnSendCliDetail = $('#btnsendclientdetail');
        this.ddl_province = $('#add_provid');
        this.ddl_amphur = $('#add_amphur_id');
        this.ddl_tumbol = $('#add_tumbol_id');
        this.ddl_saleUnitCode = $('#sale_unit_code');
        this.ddl_prodGrpCode = $('#product_group_code');
        this.ddl_proGrpCode = $('#progroup_code');
        this.ddl_prodBrandCode = $('#pro_brand_code');
        this.ddl_prodModelCode = $('#pro_model_code');
        this.ddl_prodSizeCode = $('#pro_size_code');

        this.carRegForm = $('#car_reg-form');
        this.customerForm = $('#customer-form');
        this.productForm = $('#product-form');
        this.dtCustomerList = $('#gv_customer-list');
        this.dtCarRegList = $('#gv_carreg-list');
        this.dtProductList = $('#gv_product-list');
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
                me.ddl_amphur.val("0");
                me.ddl_tumbol.val("0");
                me.add_zip.val("0");
                me.getOpDataAmphur(me.ddl_province.val(), me.ddl_amphur.val());
                me.getOpDataTumbol(me.ddl_province.val(), me.ddl_amphur.val(), me.ddl_tumbol.val());
                me.getOpDataZipCode(me.ddl_province.val(), me.ddl_amphur.val(), me.add_zip.val());
            });

            me.ddl_amphur.change(function () {
                me.ddl_tumbol.val("0");
                me.add_zip.val("0");
                me.getOpDataTumbol(me.ddl_province.val(), me.ddl_amphur.val(), me.ddl_tumbol.val());
                me.getOpDataZipCode(me.ddl_province.val(), me.ddl_amphur.val(), me.add_zip.val());
            });

            me.ddl_tumbol.change(function () {
                me.getOpDataZipCode(me.ddl_province.val(), me.ddl_amphur.val(), me.add_zip.val());
            });

            this.btnConnEdc.click(function () {
                me.checkConnEDC($("#card_port_no").val());
            });

            this.btnConnect.click(function () {
                var _url = "";

                if (this.value != "") {

                    _url = new URL(this.value).origin + "/FIT_HQ/api/HqApi";

                    $.ajax({
                        url: _url,
                        beforeSend: function beforeSend() {
                            $("#loading").show();
                        },
                        success: function success(result) {
                            $("#loading").hide();
                            successAlert("เชื่อมต่อระบบ HQ สำเร็จ");
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            $("#loading").hide();
                            warningAlert("ไม่สามารถเชื่อมต่อระบบ HQ ได้");
                        }
                    });
                }
                else {
                    warningAlert("ไม่สามารถเชื่อมต่อระบบ HQ ได้");
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
    },
    {
        key: 'createDatatableCus',
        value: function createDatatableCus() {
            var me = this;
            this.dtCus = this.dtCustomerList.DataTable({
                "dom": '<"pull-left"f><"pull-right"l>tip',
                "bLengthChange": false,
                "pageLength": 20,
                "processing": true,
                "serverSide": true,
                //"searching": false,
                //"scrollX": true,
                //"scrollY": "44vh",
                //"scrollCollapse": true,
                "ajax": {
                    "url": me.posUrl + 'api/Customer/CustomerList',
                    "type": "POST",
                    "contentType": 'application/json',
                    "data": function data(_data) {
                        var formValues = FormSerialize.getFormArray(me.customerForm, _data);
                        return JSON.stringify(formValues);
                    },
                    error: function error(jqXHR, exception) {
                        setTimeout(function () {
                            return (
                                me.dt2.ajax.url(me.posUrl + 'api/Customer/CustomerList').load()
                            );
                        }
                            //else
                            //    me.dt.ajax.reload()
                            // })
                            , 3000);
                    },
                    timeout: 10000
                },
                "columns": [
                    { "data": 'cus_code' },
                    { "data": "pre_name" },
                    { "data": "cus_name" },
                    { "data": "custype_name" },
                    { "data": "credit_limit", className: "text-right", render: $.fn.dataTable.render.number(',', '.', 2) },
                    { "data": "credit_bal", className: "text-right", render: $.fn.dataTable.render.number(',', '.', 2) }
                ],
                "language": {
                    "search": "คำค้นหา :",
                    "searchPlaceholder": "รหัสลูกค้า/ชื่อ-สกุล/ประเภทลูกค้า"
                },
                "fnDrawCallback": function () {
                    //$("input[type='search']").attr("id", "searchCus");
                    //$('#searchCus').css("width", "800px").focus();

                    $("input[type='search']").css("width", "800px").focus();
                }
            });
        }
    },
    {
        key: 'createDatatableCar',
        value: function createDatatableCar() {
            var me = this;
            this.dtCar = this.dtCarRegList.DataTable({
                "dom": '<"pull-left"f><"pull-right"l>tip',
                "bLengthChange": false,
                "pageLength": 20,
                "processing": true,
                "serverSide": true,
                //"searching": false,
                //"scrollX": true,
                //"scrollY": "44vh",
                //"scrollCollapse": true,
                "ajax": {
                    "url": me.posUrl + 'api/Customer/CarRegList',
                    "type": "POST",
                    "contentType": 'application/json',
                    "data": function data(_data) {
                        var formValues = FormSerialize.getFormArray(me.carRegForm, _data);
                        return JSON.stringify(formValues);
                    },
                    error: function error(jqXHR, exception) {
                        setTimeout(function () {
                            return (
                                me.dt.ajax.url(me.posUrl + 'api/Customer/CarRegList').load()
                            );
                        }
                            //else
                            //    me.dt.ajax.reload()
                            // })
                            , 3000);
                    },
                    timeout: 10000
                },
                "columns": [
                    { "data": 'car_reg' },
                    { "data": "add_province" },
                    { "data": "cus_name" },
                    { "data": "add_mobile" },
                    { "data": "car_brand" },
                    { "data": "car_model" },
                    { "data": "car_color" },
                ],
                "language": {
                    "search": "คำค้นหา :",
                    "searchPlaceholder": "เลขทะเบียน/จังหวัด/ชื่อ-สกุล/โทรศัพท์มือถือ/ยี่ห้อ/รุ่น/สี"
                },
                "fnDrawCallback": function () {
                    $("input[type='search']").attr("id", "searchCar");
                    $('#searchCar').css("width", "800px").focus();
                }
            });
        }
    },
    {
        key: 'createDatatableProduct',
        value: function createDatatableProduct(_url, _columns) {
            var me = this;
            this.dtProduct = this.dtProductList.DataTable({
                //"bDestroy": true,

                "bLengthChange": false,
                "pageLength": 20,
                "processing": true,
                "serverSide": true,
                "searching": false,
                //"scrollX": true,
                //"scrollY": "44vh",
                //"scrollCollapse": true,
                "ajax": {
                    "url": _url,
                    "type": "POST",
                    "contentType": 'application/json',
                    "data": function data(_data) {
                        var formValues = FormSerialize.getFormArray(me.productForm, _data);
                        return JSON.stringify(formValues);
                    },
                    error: function error(jqXHR, exception) {
                        setTimeout(function () {
                            return (
                                me.dtProduct.ajax.url(_url).load()
                            );
                        }
                            //else
                            //    me.dt.ajax.reload()
                            // })
                            , 3000);
                    },
                    timeout: 10000
                },
                "columns": _columns
            });
        }
    },
    {
        key: 'RoundUnit',
        value: function RoundUnit(value) {
            var me = this;
            var RoundUnitType = me.RoundUnitType;
            var result = 0;
            if (RoundUnitType == "1") {
                result = Math.round(value);
            } else if (RoundUnitType == "2") {
                var tmp = (value - Math.floor(value));
                if (tmp <= 0.50)
                    result = Math.floor(value);
                else
                    result = Math.round(value);
            } else {
                result = value.toFixed(2);
            }
            return parseFloat(result).toFixed(2);
        }
    },
    {
        key: 'checkConnEDC',
        value: function checkConnEDC(portName) {
            var me = this;

            $.ajax({
                type: 'POST',
                url: me.posUrl + 'api/POSApi/ConnectedEDC',
                data: "=" + portName,
                beforeSend: function beforeSend() {
                    $("#loading").show();
                },
                success: function success(o) {
                    $("#loading").hide();
                    if (!o.jresult.IsOpened) {
                        warningAlert("เชื่อมต่อพอร์ตไม่ถูกต้อง กรุณาเลือกพอร์ตใหม่");
                    }
                    else {
                        successAlert("เชื่อมต่อระบบ HQ สำเร็จ");
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $("#loading").hide();
                    warningAlert("เชื่อมต่อพอร์ตไม่ถูกต้อง กรุณาเลือกพอร์ตใหม่");
                }
            });
        }
        },
        {
            key: 'getOpDataProvince',
            value: function getOpDataProvince(selectproid) {
                var me = this;
                $.ajax({
                    url: me.posUrl + 'api/PosApi/GetddlProvince',
                    type: "GET",
                    dataType: "JSON",
                    success: function (data) {
                        $("#add_provid").html("");
                        $.each(data, function (i, rows) {
                            $("#add_provid").append(
                                $('<option></option>').val(rows.prov_id).html(rows.prov_name));
                        });
                        if (selectproid != "" && selectproid != "0") {
                            $("#add_provid").val(selectproid);
                        }

                    }
                });

            }
        },
    {
        key: 'getOpDataAmphur',
        value: function getOpDataAmphur(selectproid, selectamphurid) {
            var me = this;
            $.ajax({
                url: me.posUrl + 'api/PosApi/GetddlAmphur',
                type: "GET",
                dataType: "JSON",
                data: { province_id: selectproid },
                success: function (data) {
                    $("#add_amphur_id").html("");
                    $.each(data, function (i, rows) {
                        $("#add_amphur_id").append(
                            $('<option></option>').val(rows.amphur_id).html(rows.amphur_name));
                    });
                    if (selectamphurid != "" && selectamphurid != "0") {
                        $("#add_amphur_id").val(selectamphurid);
                    }
                }
            });

        }
    },
    {
        key: 'getOpDataTumbol',
        value: function getOpDataTumbol(selectproid, selectamphurid, selecttumbolid) {
            var me = this;
            $.ajax({
                url: me.posUrl + 'api/PosApi/GetddlTumbol',
                type: "GET",
                dataType: "JSON",
                data: { amphur_id: selectamphurid, province_id: selectproid },
                success: function (data) {
                    $("#add_tumbol_id").html("");
                    $.each(data, function (i, rows) {
                        $("#add_tumbol_id").append(
                            $('<option></option>').val(rows.tambol_id).html(rows.tambol_name));
                    });
                    if (selecttumbolid != "" && selecttumbolid != "0") {
                        $("#add_tumbol_id").val(selecttumbolid);
                    }
                }
            });
        }
    },
    {
        key: 'getOpDataZipCode',
        value: function getOpDataZipCode(selectproid, selectamphurid, selectzip) {
            var me = this;
            $.ajax({
                url: me.posUrl + 'api/PosApi/GetddlZipCode',
                type: "GET",
                dataType: "JSON",
                data: { amphur_id: selectamphurid, province_id: selectproid },
                success: function (data) {
                    $("#add_zip").html("");
                    $.each(data, function (i, rows) {
                        $("#add_zip").append(
                            $('<option></option>').val(rows.zip_id).html(rows.zip_code));
                    });
                    if (selectzip != "" && selectzip != "0") {
                        $("#add_zip").val(selectzip);
                    }
                }
            });
        }
    },
    {
        key: 'getOpDataProdGrpCode',
        value: function getOpDataProdGrpCode() {
            var me = this;
            $.ajax({
                url: me.posUrl + 'api/PosApi/GetddlProdGrpCode',
                type: "GET",
                dataType: "JSON",
                success: function (data) {
                    me.ddl_prodGrpCode.html("");
                    $.each(data, function (i, rows) {
                        me.ddl_prodGrpCode.append(
                            $('<option></option>').val(rows.product_group_code).html(rows.product_group_name));
                    });
                }
            });

        }
    },
    {
        key: 'getOpDataProGrpCode',
        value: function getOpDataProGrpCode() {
            var me = this;
            $.ajax({
                url: me.posUrl + 'api/PosApi/GetddlProGrpCode',
                type: "GET",
                dataType: "JSON",
                data: { prodgrp_code: me.ddl_prodGrpCode.val() },
                success: function (data) {
                    me.ddl_proGrpCode.html("");
                    $.each(data, function (i, rows) {
                        me.ddl_proGrpCode.append(
                            $('<option></option>').val(rows.progroup_code).html(rows.progroup_name));
                    });
                }
            });
        }
    },
    {
        key: 'getOpDataProBrandCode',
        value: function getOpDataProBrandCode() {
            var me = this;
            $.ajax({
                url: me.posUrl + 'api/PosApi/GetddlProBrandCode',
                type: "GET",
                dataType: "JSON",
                data: { progroupCode: me.ddl_proGrpCode.val() },
                success: function (data) {
                    me.ddl_prodBrandCode.html("");
                    $.each(data, function (i, rows) {
                        me.ddl_prodBrandCode.append(
                            $('<option></option>').val(rows.pro_brand_code).html(rows.pro_brand));
                    });
                }
            });
        }
    },
    {
        key: 'getOpDataProModelCode',
        value: function getOpDataProModelCode() {
            var me = this;
            $.ajax({
                url: me.posUrl + 'api/PosApi/GetddlProModelCode',
                type: "GET",
                dataType: "JSON",
                data: { probrandCode: me.ddl_prodBrandCode.val() },
                success: function (data) {
                    me.ddl_prodModelCode.html("");
                    $.each(data, function (i, rows) {
                        me.ddl_prodModelCode.append(
                            $('<option></option>').val(rows.pro_model_code).html(rows.pro_model));
                    });
                }
            });
        }
    },
    {
        key: 'getOpDataProSizeCode',
        value: function getOpDataProSizeCode() {
            var me = this;
            $.ajax({
                url: me.posUrl + 'api/PosApi/GetddlProSizeCode',
                type: "GET",
                dataType: "JSON",
                data: { promodelCode: me.ddl_prodModelCode.val() },
                success: function (data) {
                    me.ddl_prodSizeCode.html("");
                    $.each(data, function (i, rows) {
                        me.ddl_prodSizeCode.append(
                            $('<option></option>').val(rows.pro_size_code).html(rows.size_name));
                    });
                }
            });
        }
    },
    {
        key: 'getOpDataSaleUnitCode',
        value: function getOpDataSaleUnitCode() {
            var me = this;
            $.ajax({
                url: me.posUrl + 'api/Product/GetddlSaleUnitCode',
                type: "GET",
                success: function (data) {
                    me.ddl_saleUnitCode.html("");
                    $.each(data, function (i, rows) {
                        me.ddl_saleUnitCode.append(
                            $('<option></option>').val(rows.unit_code).html(rows.unit_name));
                    });
                }
            });
        }
    }
    ]);


    return _Form;
}();