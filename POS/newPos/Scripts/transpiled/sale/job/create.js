'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var JobForm = function () {
    function JobForm() {
        _classCallCheck(this, JobForm);
        this.doc_no = $('#doc_no');
        //this.btnConnect = $('#btnConnect');
        //this.txthttp_path = $('#http_path');
        this.btnAddProdSetOrder = $('#btnaddprodset');
        this.btnAddProdOrder = $('#btnaddprod');
        this.btnSearchModal = $('#btn_search');
        this.btnClearModal = $('#btn_clear');
        this.btnSearch2Modal = $('#btn_search2');
        this.btnClear2Modal = $('#btn_clear2');
        this.txtSearchProd = $('#keysearch');
        this.txtSearchProdSet = $('#prodSetSearch');
        this.form = $('#myForm');

        this.ddl_prodGrpCode = $('#product_group_code');
        this.ddl_proGrpCode = $('#progroup_code');
        this.ddl_prodBrandCode = $('#pro_brand_code');
        this.ddl_prodModelCode = $('#pro_model_code');
        this.ddl_prodSizeCode = $('#pro_size_code');
        this.inputStartDateTime = $('#StartDate');
        this.inputEndDateTime = $('#EndDate');

        this.getCarRegListUrl = null;
        this.a_CarReg = $('#a_CarReg');
        this.a_Product = $('#a_Product');
        this.a_Customer = $('#a_Customer');

        this.productSetForm = $('#productsetjob-form');
        this.prodsetdetailModal = $('#prodsetdetail-modal');
        this.prodstockModal = $('#prodstockonline-modal');
        this.carregModal = $('#car_reg-modal');
        this.customerModal = $('#customer-modal');
        this.productJobModal = $('#product_job-modal');
        this.proSelectLocatJobModal = $('#prodselectlocat-modal');

        this.dtJobTempList = $('#gv_jobtemp');

        this.dtProductDetailList = $('#gv_productdetail-list');
        this.dtProductLocatList = $('#gv_productlocat-list');
        this.dtProductLocatDotList = $('#gv_productlocatDot-list');
        this.dtProductSetList = $('#gv_productsetjob-list');
        this.dtProductSetDetailList = $('#gv_prodsetdetail-list');
        this.dtStockList = $('#gv_stockonline-list');

        this.car_reg = $('#car_reg');
        this.car_province = $('#car_province');
        this.Car_Brand = $('#Car_Brand');
        this.Car_model = $('#Car_model');
        this.car_mileage = $('#car_mileage');
        this.cus_code = $('#cus_code');
        this.cus_type = $('#cus_type');
        this.km_perday = $('#km_perday');
        this.cus_name = $('#cus_name');
        this.job_contact = $('#job_contact');
        this.job_conttel = $('#job_conttel');
        this.invoice_type = $('#invoice_type');

        this.first_contdate = $('#first_contdate');
        this.last_contdate = $('#last_contdate');
        this.first_mileage = $('#first_mileage');
        this.last_mileage = $('#last_mileage');
        this.km_perday = $('#km_perday');
        this.indexForm = null;

        this.pro_code = $('#pro_code');
        this.pro_tname = $('#pro_tname');
        this.locat_code = $('#locat_code');
        this.locat_name = $('#locat_name');
        this.sale_unit_code = $('#sale_unit_code');
        this.dot_id = $('#dot_id');
        this.dot_name = $('#dot_name');
        this.store_qty = $('#store_qty');
        this.pro_ohqty = $('#pro_ohqty');
        this.pro_qty = $('#pro_qty');

        this.pro_price = $('#pro_price');
        this.pro_amt = $('#pro_amt');
        this.io_by = $('#io_by');
        this.job_ps_code = $('#doc_ps_code');

        this.is_proset = $('#is_proset');
        this.ps_gen_id = $('#ps_gen_id');
        this.ps_code = $('#ps_code');
        this.ps_name = $('#ps_name');

        this.vat_mrate = $('#vat_mrate');
        this.job_totalamt = $('#job_totalamt');
        this.job_amt = $('#job_amt');
        this.job_vatamt = $('#job_vatamt');
        this.job_netamt = $('#job_netamt');

        this.txtjob_amt = $('#txtjob_amt');
        this.txtjob_vatamt = $('#txtjob_vatamt');
        this.txtjob_netamt = $('#txtjob_netamt');

        this.hdnProdPanel = $('#hdnProdPanel');
    }

    _createClass(JobForm, [{
        key: 'init',
        value: function init() {
            var me = this;

            //me.car_reg.focus(); me.pro_code.focus();

            me.indexForm.getOpDataSaleUnitCode();

            let opts = {
                custom: {

                    equalscar: function ($el) {
                        if ($el.val() === "") {
                            me.a_Product.prop("disabled", true);
                            return "error"
                        }
                        else {
                            me.a_Product.prop("disabled", false);
                        }
                    },
                    hasproduct: function ($el) {
                        if ($el.val() === "") {
                            me.btnAddProdOrder.prop("disabled", true);
                            return "error"
                        }
                        else {
                            me.btnAddProdOrder.prop("disabled", false);
                        }
                    },
                    noqty: function ($el) {
                        if ($el.val() === "") {
                            me.btnAddProdOrder.prop("disabled", true);
                            return "error"
                        }
                        else {
                            me.btnAddProdOrder.prop("disabled", false);
                        }
                    },
                    zeroqty: function ($el) {
                        if ($el.val() === "0") {
                            me.btnAddProdOrder.prop("disabled", true);
                            return "error"
                        }
                        else {
                            if ($el.val() !== "")
                                me.btnAddProdOrder.prop("disabled", false);
                        }
                    },
                    morethanstock: function ($el) {
                        var qty = parseInt($el.val())
                        if (qty > 0 && me.pro_code.val() !== "") {
                            if (me.pro_ohqty.val() !== "") {

                                var proQty = parseInt(me.pro_ohqty.val());
                                if ((proQty - qty) < 0) {
                                    me.btnAddProdOrder.prop("disabled", true);
                                    return "error"
                                }
                                else {
                                    me.btnAddProdOrder.prop("disabled", false);
                                }
                            }
                            if (me.pro_qty.val() !== "") {
                                var ProdotQty = parseInt(me.pro_qty.val());
                                if ((ProdotQty - qty) < 0) {
                                    me.btnAddProdOrder.prop("disabled", true);
                                    return "error"
                                }
                                else {
                                    me.btnAddProdOrder.prop("disabled", false);
                                }
                            }

                            if (me.dtJobTempList.DataTable().rows().data().length > 0) {
                                var numberOfRows = me.dtJobTempList.DataTable().rows().data().length;
                                var useStockTotal = 0;
                                for (var i = 0; i < numberOfRows; i++) {

                                    if (me.dtjobtemp.row(i).nodes().to$().css('color') !== "rgb(255, 0, 0)") {
                                        var d = me.dtjobtemp.row(i).data();
                                        if (d.pro_stock !== "0") {// not service
                                            if (parseInt(me.dot_id.val()) > 0) {
                                                if (d.pro_code === me.pro_code.val()
                                                    && d.dot_id === parseInt(me.dot_id.val())
                                                    //&& d.ps_code === parseInt(me.ps_code.val())
                                                ) {
                                                    useStockTotal += parseInt(d.store_qty);
                                                }
                                            }
                                            else {
                                                if (d.pro_code === me.pro_code.val() /*&& d.ps_code !== parseInt(me.ps_code.val())*/) {
                                                    useStockTotal += parseInt(d.store_qty);
                                                }
                                            }
                                        }
                                    }
                                }
                                var total = parseInt(useStockTotal) + qty;
                                if (me.pro_ohqty.val() !== "") {
                                    if ((proQty - total) < 0) {
                                        me.btnAddProdOrder.prop("disabled", true);
                                        return "error"
                                    }
                                    else {
                                        me.btnAddProdOrder.prop("disabled", false);
                                    }
                                }
                                if (me.pro_qty.val() !== "") {
                                    if ((ProdotQty - total) < 0) {
                                        me.btnAddProdOrder.prop("disabled", true);
                                        return "error"
                                    }
                                    else {
                                        me.btnAddProdOrder.prop("disabled", false);
                                    }
                                }
                            }
                        }
                    },
                    equals: function ($el) {

                        if (me.car_reg.val() !== "-") {
                            if ($el.val() === "0") {
                                return "error"
                            }
                            else {
                                var isErr = me.calAvgMilePerDay();
                                if (!isErr) {
                                    me.km_perday.val(0);
                                    return "error"
                                }
                            }
                        }
                    }

                }
            }

            this.a_Product.click(function () {
                me.openSearchModel('product');
                $('.nav-tabs a[href="#search_product"]').click();
                me.ddl_prodGrpCode.val("");
                me.ddl_proGrpCode.val("");
                me.ddl_prodBrandCode.val("");
                me.ddl_prodModelCode.val("");
                me.ddl_prodSizeCode.val("");
                me.indexForm.getOpDataProdGrpCode();
                me.indexForm.getOpDataProGrpCode();
                me.indexForm.getOpDataProBrandCode();
                me.indexForm.getOpDataProModelCode();
                me.indexForm.getOpDataProSizeCode();
                me.txtSearchProd.val("");

                if ($.fn.DataTable.isDataTable('#gv_product-list')) {
                    me.indexForm.dtProductList.DataTable().destroy();
                }
                //me.createDatatableProduct();
                var _procolumns = [];
                _procolumns = [
                    {
                        "data": 'pro_code',
                        "render": function render(data, type, row) {

                            if (row.pro_stock === "0") {
                                return '<a href="#" data-dismiss="modal" class="service_selected">' + row.pro_code + '</a>';
                            }
                            else {
                                if (row.pro_ohqty > 0) {
                                    return '<a href="#" class="proselect_locat">' + row.pro_code + '</a>';
                                }
                                else {
                                    return row.pro_code;
                                }
                            }
                        }
                    },
                    { "data": "Part_No", width: "8%" },
                    { "data": "pro_tname", width: "34%" },
                    { "data": "progroup_name", width: "10%" },
                    { "data": "probrand_name", width: "10%" },
                    { "data": "promodel_name", width: "10%" },
                    { "data": "prosize_name", width: "10%" },
                    { "data": "pro_ohqty", width: "8%", className: "text-right" },
                    {
                        "data": "pro_code",
                        "className": "text-center",
                        "orderable": false,
                        "render": function render(data, type, row) {
                            return '<a href="#" class="online_stock"><img src="/Content/img/ICON/BTSEMP.GIF" ></a>';
                        }
                    }
                ];
                me.indexForm.createDatatableProduct(me.posUrl + 'api/Product/ProductList?cus_code=' + me.cus_code.val() + '&cus_type=' + me.cus_type.val(), _procolumns);
            });

            this.a_CarReg.click(function () {
                me.openSearchModel('car');
            });

            this.a_Customer.click(function () {
                me.openSearchModel('cus');
            });

            this.btnAddProdOrder.click(function () {
                var model = {
                    doc_no: me.doc_no.val(),
                    //doc_code: me.doc_code.val(),
                    pro_code: me.pro_code.val(),
                    dot_id: me.dot_id.val(),
                    pro_name: me.pro_tname.val(),
                    sale_unit_code: me.sale_unit_code.val(),
                    locat_code: me.locat_code.val(),
                    store_qty: me.store_qty.val(),
                    pro_price: me.pro_price.val(),
                    pro_amt: me.pro_amt.val(),
                    io_by: me.io_by.val(),
                    ps_code: me.job_ps_code.val(),
                    mode: $(this).attr("data-mode")
                };

                if ($('#is_proset').val() === "true") {
                    confirmAlertForProductSet("สินค้ารหัส " + me.pro_code.val() + " มีการ Set การขายไว้ในสินค้าชุด " + me.ps_name.val(), function (event) {
                        if (!event) {
                            me.addProductJobOrder(model);
                        }
                        else {
                            me.openSearchModel('product');
                            $('.nav-tabs a[href="#search_productset"]').click();
                            me.dtpdSet.ajax.reload(function (json) {
                                var indexes = me.dtpdSet.rows().eq(0).filter(function (rowIdx) {
                                    return me.dtpdSet.cell(rowIdx, 0).data() === me.ps_code.val() ? true : false;
                                });
                                me.dtpdSet.rows(indexes).nodes().to$().click()
                            });
                        }
                    });
                }
                else {
                    me.addProductJobOrder(model);
                }

            });

            this.btnAddProdSetOrder.click(function (e) {
                if (me.dtJobTempList.DataTable().rows().data().length > 0) {
                    var numberOfRows = me.dtpddetail.rows().data().length;
                    var _error = 0
                    for (var i = 0; i < numberOfRows; i++) {
                        var useStockTotal = 0; var pro_qty = 0;
                        var usePsStockTotal = 0;
                        var tblprodset = me.dtpddetail.row(i).data();
                        var tblprodset_dotid = 0;
                        if (tblprodset.pro_stock !== "0") {// not service

                            if (tblprodset.ddlobj.length > 0) {
                                tblprodset.ddlobj
                                    .filter(function (z, index) {
                                        if (z.pro_code === tblprodset.ps_pro_code && z.is_selected) {
                                            if (z.is_selected) {
                                                pro_qty = parseInt(z.pro_qty);
                                                tblprodset_dotid = z.dot_id;
                                            }
                                        }
                                    });
                            }

                            me.dtpddetail.rows().data()
                                .filter(function (_items, index) {
                                    if (_items.pro_stock !== "0") {
                                        if (_items.ps_pro_code === tblprodset.ps_pro_code && tblprodset.ddlobj.length > 0) {
                                            _items.ddlobj
                                                .filter(function (z2, index) {
                                                    if (z2.pro_code === tblprodset.ps_pro_code && z2.dot_id === tblprodset_dotid) {
                                                        if (z2.is_selected) {
                                                            usePsStockTotal += parseInt(_items.ps_qty);
                                                        }
                                                    }
                                                });
                                        }
                                        else {
                                            if (_items.ps_pro_code === tblprodset.ps_pro_code) {
                                                usePsStockTotal += parseInt(_items.ps_qty);
                                            }
                                        }
                                    }
                                });

                            for (var j = 0; j < me.dtjobtemp.rows().data().length; j++) {

                                var tbljoborder = me.dtjobtemp.row(j).data();

                                if (tbljoborder.pro_stock !== "0") {// not service

                                    if (tbljoborder.dot_id > 0) { // dot stock
                                        if (tblprodset.ps_pro_code === tbljoborder.pro_code &&
                                            tblprodset_dotid === parseInt(tbljoborder.dot_id)) {
                                            useStockTotal += parseInt(tbljoborder.store_qty); //break;
                                        }
                                        {
                                            //else {
                                            //    if (e.pro_code === tblprodset.ps_pro_code && e.is_selected) {
                                            //        if (e.is_selected) {
                                            //            pro_qty = parseInt(e.pro_qty); //break;
                                            //        }
                                            //    }
                                            //}
                                        }
                                    }
                                    else {
                                        if (tblprodset.ps_pro_code === tbljoborder.pro_code) {                                                    //&& tblprodset.ps_code !== parseInt(tbljoborder.ps_code)) {
                                            useStockTotal += parseInt(tbljoborder.store_qty);
                                        }
                                        {
                                            //for (var k = 0; k < tblprodset.ddlobj.length; k++) {
                                            //    var e = tblprodset.ddlobj[k];
                                            //    if (e.pro_code === tbljoborder.pro_code &&
                                            //        e.dot_id === parseInt(tbljoborder.dot_id)) {

                                            //        if (e.is_selected) {
                                            //            pro_qty = parseInt(e.pro_qty);
                                            //            useStockTotal += parseInt(tbljoborder.store_qty); //break;
                                            //        }
                                            //    }
                                            //    else {
                                            //        if (e.pro_code === tblprodset.ps_pro_code && e.is_selected) {
                                            //            if (e.is_selected) {
                                            //                pro_qty = parseInt(e.pro_qty); //break;
                                            //            }
                                            //        }
                                            //    }
                                            //}
                                        }
                                    }
                                }
                            }
                            var total = parseInt(useStockTotal) + usePsStockTotal;//tblprodset.ps_qty;
                            if (tblprodset.ddlobj.length === 0) {
                                if ((tblprodset.pro_qoh - total) < 0) {
                                    me.dtpddetail.row(i).nodes().to$().css('color', 'Red');
                                    ++_error;
                                    me.dtpddetail.row(i).nodes().to$().find('td:eq(6)').html('ไม่สามารถขายสินค้าจำนวนที่มากกว่าสินค้าคลัง').css('color', 'Red'); //break;
                                }
                                else {
                                    me.dtpddetail.row(i).nodes().to$().removeAttr('style');
                                    me.dtpddetail.row(i).nodes().to$().find('td:eq(6)').removeAttr('style');
                                }
                            }
                            else {
                                //var pro_qty = parseInt(me.dtpddetail.row(i).nodes().to$().find('label').val());
                                if ((pro_qty - total) < 0) {
                                    me.dtpddetail.row(i).nodes().to$().css('color', 'Red');
                                    ++_error;
                                    me.dtpddetail.row(i).nodes().to$().find('td:eq(6)').html('ไม่สามารถขายสินค้าจำนวนที่มากกว่าสินค้าคลัง').css('color', 'Red'); //break;
                                }
                                else {
                                    me.dtpddetail.row(i).nodes().to$().removeAttr('style');
                                    me.dtpddetail.row(i).nodes().to$().find('td:eq(6)').removeAttr('style');
                                }
                            }
                        }
                    }
                    if (_error === 0) {
                        me.addProductSetJobOrder(me.dtpddetail.rows().data().toArray()); $("#btnproductset").click();
                    }
                }
                else {
                    me.addProductSetJobOrder(me.dtpddetail.rows().data().toArray()); $("#btnproductset").click();
                }
            });

            this.btnSearchModal.click(function () {
                me.indexForm.dtProduct.ajax.reload();
            });

            this.btnSearch2Modal.click(function () {
                me.dtpdSet.ajax.reload();
            });

            this.btnClearModal.click(function () {
                me.ddl_prodGrpCode.val("");
                me.ddl_proGrpCode.val("");
                me.ddl_prodBrandCode.val("");
                me.ddl_prodModelCode.val("");
                me.ddl_prodSizeCode.val("");
                me.indexForm.getOpDataProdGrpCode();
                me.indexForm.getOpDataProGrpCode();
                me.indexForm.getOpDataProBrandCode();
                me.indexForm.getOpDataProModelCode();
                me.indexForm.getOpDataProSizeCode();
                me.txtSearchProd.val("");
                me.indexForm.dtProduct.ajax.reload();
            });

            this.btnClear2Modal.click(function () {
                me.txtSearchProdSet.val("");
                me.inputStartDateTime.val("");
                me.inputEndDateTime.val("");
                me.dtpdSet.ajax.reload();
            });

            me.ddl_prodGrpCode.change(function () {
                me.ddl_proGrpCode.val("");
                me.indexForm.getOpDataProGrpCode();
                me.ddl_prodBrandCode.val("");
                me.ddl_prodModelCode.val("");
                me.ddl_prodSizeCode.val("");
                me.indexForm.getOpDataProBrandCode();
                me.indexForm.getOpDataProModelCode();
                me.indexForm.getOpDataProSizeCode();
                me.indexForm.dtProduct.ajax.reload();
            });

            me.ddl_proGrpCode.change(function () {
                me.ddl_prodBrandCode.val("");
                me.indexForm.getOpDataProBrandCode();
                me.ddl_prodModelCode.val("");
                me.ddl_prodSizeCode.val("");
                me.indexForm.getOpDataProModelCode();
                me.indexForm.getOpDataProSizeCode();
                me.indexForm.dtProduct.ajax.reload();
            });

            me.ddl_prodBrandCode.change(function () {
                me.ddl_prodModelCode.val("");
                me.indexForm.getOpDataProModelCode();
                me.ddl_prodSizeCode.val("");
                me.indexForm.getOpDataProSizeCode();
                me.indexForm.dtProduct.ajax.reload();
            });

            me.ddl_prodModelCode.change(function () {
                me.ddl_prodSizeCode.val("");
                me.indexForm.getOpDataProSizeCode();
                me.indexForm.dtProduct.ajax.reload();
            });

            me.ddl_prodSizeCode.change(function () {
                me.indexForm.dtProduct.ajax.reload();
            });

            //this.productJobModal.on('hidden.bs.modal', function () {
            //    $("body").css("padding-right", "0");
            //});
            this.carregModal.on('shown.bs.modal', function () {
                me.indexForm.dtCar.ajax.reload();
            });

            this.customerModal.on('shown.bs.modal', function () {
                me.indexForm.dtCus.ajax.reload();
            });

            $(document.body).on("click", "a[data-toggle]", function (event) {

                switch (this.getAttribute("aria-controls")) {
                    case "search_productset":
                        if (!$.fn.DataTable.isDataTable('#gv_productsetjob-list')) {
                            //$('#gv_productsetjob-list').DataTable().destroy();
                            me.createDatatableProductSet();
                        }

                        me.initDateTimePicker();
                        break;
                    //case "search_product":
                    //    if (!$.fn.DataTable.isDataTable('#gv_productjob-list')) {
                    //        me.createDatatableProduct();
                    //    }
                    //    else {
                    //        $('#gv_productsetjob-list').DataTable().destroy(); me.createDatatableProduct();
                    //    }

                    //    break;
                }
            });

            $(document).on('click', '[data-dismiss="modal"]', function (event) {
                if (!$(this).hasClass('btn btn-danger') && !$(this).hasClass('close')) {
                    me.productJobModal.modal('hide');
                }
            });

            this.proSelectLocatJobModal.on('hidden.bs.modal', function (e) {
                if (!$("body").hasClass("modal-open") && me.productJobModal.hasClass('in')) {
                    $("body").addClass("modal-open");
                }
            });

            this.prodsetdetailModal.on('shown.bs.modal', function (e) {
                let opts = {
                    custom: {
                        selectedot: function ($el) {
                            //var matchValue = $el.data("equals")
                            if ($el.val() === "0") {
                                return "error"
                            }
                        }
                    }
                }
                $(this).find('form').validator(opts)
                $('#btnaddprodset').prop("disabled", $('#_addprodset').hasClass("disabled"));

                var _error = 0;
                $('#gv_prodsetdetail-list').DataTable().rows().data()
                    .filter(function (_items, index) {
                        if (_items.pro_stock !== "0") {
                            if (_items.pro_qoh === 0) {
                                ++_error;
                                this.row().nodes().to$().css('color', 'Red');
                                this.row().nodes().to$().find('td:eq(6)').html('ไม่สามารถขายสินค้าเนื่องจากจำนวนในคลังสินค้ามีไม่พอ').css('color', 'Red');
                            }
                        }
                    });
                if (_error > 0) {
                    $("#btnaddprodset").prop("disabled", true);
                }
                $(this).find('form').validator(opts).on('submit', function (e) {
                    if (e.isDefaultPrevented()) {
                        // To do
                    } else {
                        // To do
                    }
                })
            });

            this.prodsetdetailModal.on('hidden.bs.modal', function (e) {
                if (!$("body").hasClass("modal-open") && me.productJobModal.hasClass('in')) {
                    $("body").addClass("modal-open");
                }
                $(this).find('form').off('submit').validator('destroy')
            });

            this.prodstockModal.on('hidden.bs.modal', function (e) {
                if (!$("body").hasClass("modal-open") && me.productJobModal.hasClass('in')) {
                    $("body").addClass("modal-open");
                }
            });

            me.indexForm.dtProductList.on('click', 'a.service_selected', function (e) {
                var obj = me.indexForm.dtProduct.row($(this).closest('tr')).data();
                me.btnAddProdOrder.text('เพิ่มรายการ');
                me.btnAddProdOrder.attr('data-mode', 'add');
                me.btnAddProdOrder.removeClass("btn btn-warning").addClass("btn btn-success");
                me.updateProductJobOrder(obj);
            });

            me.indexForm.dtProductList.on('click', 'a.proselect_locat', function (e) {
                var obj = me.indexForm.dtProduct.row($(this).closest('tr')).data();

                if ($.fn.DataTable.isDataTable(me.dtProductDetailList)) {
                    me.dtProductDetailList.DataTable().destroy();
                }
                $('#div_gvprolocat').attr("hidden", true);
                $('#div_gvprolocatDot').attr("hidden", true);

                if ($.fn.DataTable.isDataTable(me.dtProductLocatList)) {
                    me.dtProductLocatList.DataTable().destroy();
                }
                if ($.fn.DataTable.isDataTable(me.dtProductLocatDotList)) {
                    me.dtProductLocatDotList.DataTable().destroy();
                }
                me.createDatatableProductDetail(obj);

                me.proSelectLocatJobModal.modal({ backdrop: 'static', keyboard: false });
                $("#lblpro_code_name").text(obj.pro_code + ' ' + '(' + obj.pro_tname + ')');
            });

            me.indexForm.dtProductList.on('click', 'a.online_stock', function (e) {
                var obj = me.indexForm.dtProduct.row($(this).closest('tr')).data();

                if ($.fn.DataTable.isDataTable(me.dtStockList)) {
                    me.dtStockList.DataTable().destroy();
                }
                me.createDatatableStock(obj);

                me.prodstockModal.modal({ backdrop: 'static', keyboard: false });
                $("#lblpro_code").text(obj.pro_code);
            });

            me.indexForm.createDatatableCar();

            me.indexForm.createDatatableCus();

            me.indexForm.dtCustomerList.on('click', 'tr', function (e) {
                var obj = me.indexForm.dtCus.row($(this).closest('tr')).data();
                me.genJOrderCode();
                me.updateJobOrder(obj);
                me.car_mileage.attr('readonly', 'readonly');
                me.customerModal.modal('hide');
                me.car_reg.focus();
            });

            me.indexForm.dtCarRegList.on('click', 'tr', function (e) {
                var obj = me.indexForm.dtCar.row($(this).closest('tr')).data();
                me.genJOrderCode();
                me.updateJobOrder(obj);
                me.car_mileage.removeAttr('readonly');
                me.carregModal.modal('hide');
                me.car_mileage.focus();
            });

            this.createDatatableJobTemp();

            me.form.validator(opts).on('submit', function (e) {
                if (e.isDefaultPrevented()) {
                    // handle the invalid form...
                } else {
                    // everything looks good!
                }
            });

            me.form.validator('validate')
        }
    },
    {
        key: 'reset',
        value: function reset(rows, isvalid) {
            var me = this;
            me.btnAddProdOrder.text('เพิ่มรายการ');
            me.btnAddProdOrder.attr('data-mode', 'add');
            me.btnAddProdOrder.removeClass("btn btn-warning").addClass("btn btn-success");

            me.pro_code.val("");
            me.pro_tname.val("");
            me.locat_code.val("");
            me.locat_name.val("");
            me.sale_unit_code.val(0);
            me.dot_id.val("");
            me.dot_name.val("");
            me.store_qty.val("");
            me.pro_ohqty.val("");
            me.pro_qty.val("");
            me.pro_price.val("");
            me.pro_amt.val("");
            me.job_ps_code.val("");
            me.io_by.val("");

            me.hdnProdPanel.val(rows);

            me.pro_code.attr('data-validate', isvalid);
            me.store_qty.attr('data-validate', isvalid);
            me.form.validator('update');

            me.form.validator('validate');
        }
    },
    {
        key: 'genJOrderCode',
        value: function genJOrderCode() {
            var me = this;
            $.get(me.getGenCodeUrl, function (j0CD) {

                me.doc_no.val(j0CD);

                me.dtjobtemp.destroy();

                me.createDatatableJobTemp();

                me.reset("", 'true');

            });
        }
    },
    {
        key: 'calAvgMilePerDay',
        value: function calAvgMilePerDay() {
            var me = this;
            var a = "";
            var b = "";
            var c = "";
            if (me.car_mileage.val() === "") {
                return false;
            }
            a = parseInt(me.car_mileage.val());
            b = parseInt(me.last_mileage.val());
            var date1 = new Date(me.last_contdate.val().split('/')[1] + '/' + me.last_contdate.val().split('/')[0] + '/' + me.last_contdate.val().split('/')[2]);// Format MM/DD/YYYY
            var date2 = new Date(me.dateNow);// Format MM/DD/YYYY
            var timeDiff = Math.abs(date2.getTime() - date1.getTime());
            var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
            c = diffDays;

            if (c <= 0) {
                c = 1;
            }

            if (Number.parseFloat((a - b) / c) < 0) {
                return false;
            } else {
                if (a != b) {
                    me.km_perday.val(Number.parseFloat((a - b) / c).toFixed(2));
                    return true;
                } else {
                    me.km_perday.val(1); return true;
                }
            }
        }
    },
    {
        key: 'openSearchModel',
        value: function openSearchModel(type) {
            var me = this;
            switch (type) {
                case "car": this.carregModal.modal(); break;
                case "cus": this.customerModal.modal(); break;
                case "product": this.productJobModal.modal(); break;
            }
        }
    },
    {
        key: 'createDatatableJobTemp',
        value: function createDatatableJobTemp() {
            var me = this;
            this.dtjobtemp = me.dtJobTempList.DataTable({
                "bLengthChange": false,
                "bDestroy": true,
                "bSort": false,
                "searching": false,
                "paging": false,
                "info": false,
                "oLanguage": {
                    "sEmptyTable": "ไม่พบข้อมูล"
                },
                "ajax": {
                    "url": me.getJobOrderUrl,
                    "type": "POST",
                    "data": { doc_no: me.doc_no.val() },
                    "error": function (e) {
                        if (e) {
                            var $empty = me.dtProductSetDetailList.find('.dataTables_empty');
                            if ($empty) $empty.html('ไม่มีพบข้อมูล')
                        }
                    },
                    "dataSrc": function (result) {
                        return result
                    }
                },
                "columns": [
                    { "data": 'pro_code' },
                    { "data": "locat_dot_name", "className": "text-center" },
                    { "data": "pro_name" },
                    { "data": "sale_unit_name", "className": "text-center" },
                    { "data": "locat_name" },
                    { "data": "store_qty", "className": "text-center" },
                    { "data": "pro_price", "className": "text-right", "render": $.fn.dataTable.render.number(',', '.', 2) },
                    { "data": "pro_amt", "className": "text-right", "render": $.fn.dataTable.render.number(',', '.', 2) },
                    { "data": "io_by" },
                    {
                        "data": "pro_code",
                        "className": "text-center",
                        "orderable": false,
                        "render": function render(data, type, row) {
                            if (row.ps_code === 0) {
                                if (row.pro_code.indexOf("PS") !== -1) {//str1.indexOf(str2) != -1
                                    return '<a href="#" class="del" title="ลบ"><i class="fa fa-trash"></i></a>';
                                }
                                else {
                                    return '<a href="#" class="edit" title="แก้ไข"><i class="fa fa-pencil"></i></a>&nbsp;|&nbsp;<a href="#" class="del" title="ลบ"><i class="fa fa-trash"></i></a>';
                                }
                            }
                            else {
                                return '<a href="#" class="edit" title="แก้ไข"><i class="fa fa-pencil"></i></a>';
                            }
                        }
                    },
                    {
                        "data": "pro_code",
                        "className": "text-center",
                        "orderable": false,
                        "render": function render(data, type, row) {
                            if (row.pro_code.indexOf("PS") !== -1) {
                                return '';
                            }
                            else {
                                return '<a href="#" class="online_stock"><img src="/Content/img/ICON/BTSEMP.GIF" ></a>';
                            }
                        }
                    },
                    { data: "dot_id", visible: false },
                    { data: "sale_unit_code", visible: false },
                    { data: "locat_code", visible: false },
                    { data: "ps_code", visible: false }
                ],
                drawCallback: function () {
                    var nettotal = 0;
                    me.dtJobTempList.DataTable().rows().data()
                        .filter(function (_items, index) {
                            nettotal += _items.pro_amt;
                        });
                    var vat_radio = me.vat_mrate.val() / 100
                    var vat_rate = 1 + vat_radio
                    var sumtotal = nettotal / vat_rate;
                    me.job_totalamt.val(sumtotal);
                    me.job_amt.val(sumtotal);
                    me.txtjob_amt.val(me.indexForm.RoundUnit(sumtotal));

                    var sumvat = nettotal - sumtotal;
                    me.job_vatamt.val(me.indexForm.RoundUnit(sumvat));
                    me.txtjob_vatamt.val(me.indexForm.RoundUnit(sumvat));

                    var sum_nettotal = sumtotal + sumvat;
                    me.job_netamt.val(me.indexForm.RoundUnit(sum_nettotal));
                    me.txtjob_netamt.val(me.indexForm.RoundUnit(sum_nettotal));
                }
            });

            this.dtJobTempList.on('click', 'a.edit', function (e) {
                var obj = me.dtjobtemp.row($(this).closest('tr')).data();
                me.dtjobtemp.$("tr").removeAttr('style');
                $(this).closest('tr').css('color', 'Red');
                me.btnAddProdOrder.text('แก้ไขรายการ');
                me.btnAddProdOrder.removeClass("btn btn-success").addClass("btn btn-warning");
                me.btnAddProdOrder.attr('data-mode', 'edit');
                me.updateProductJobOrder(obj);
            });

            this.dtJobTempList.on('click', 'a.del', function (e) {
                var obj = me.dtjobtemp.row($(this).closest('tr')).data();

                $.ajax({
                    type: 'POST',
                    url: me.delProdUrl,
                    data: JSON.stringify({ 'model': obj }),

                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function beforeSend() {
                        $("#loading").show();
                    },
                    success: function success(result) {
                        if (result > 0) {

                            me.dtjobtemp.ajax.reload(function (json) {

                                $("#loading").hide();

                                if (obj.pro_code === me.pro_code.val()) {
                                    me.btnAddProdOrder.prop("disabled", true);
                                    me.btnAddProdOrder.text('เพิ่มรายการ');
                                    me.btnAddProdOrder.attr('data-mode', 'add');
                                    me.btnAddProdOrder.removeClass("btn btn-warning").addClass("btn btn-success");

                                    me.pro_code.val("");
                                    me.pro_tname.val("");
                                    me.locat_code.val("");
                                    me.locat_name.val("");
                                    me.sale_unit_code.val(0);
                                    me.dot_id.val("");
                                    me.dot_name.val("");
                                    me.store_qty.val("");
                                    me.pro_ohqty.val("");
                                    me.pro_qty.val("");
                                    me.pro_price.val("");
                                    me.pro_amt.val("");
                                    me.job_ps_code.val("");
                                    me.io_by.val("");


                                    me.pro_code.attr('data-validate', 'false');
                                    me.store_qty.attr('data-validate', 'false');
                                }
                                if (obj.pro_code.indexOf("PS") !== -1 && me.ps_code.val() !== "0") {
                                    me.btnAddProdOrder.prop("disabled", true);
                                    me.btnAddProdOrder.text('เพิ่มรายการ');
                                    me.btnAddProdOrder.attr('data-mode', 'add');
                                    me.btnAddProdOrder.removeClass("btn btn-warning").addClass("btn btn-success");

                                    me.pro_code.val("");
                                    me.pro_tname.val("");
                                    me.locat_code.val("");
                                    me.locat_name.val("");
                                    me.sale_unit_code.val(0);
                                    me.dot_id.val("");
                                    me.dot_name.val("");
                                    me.store_qty.val("");
                                    me.pro_ohqty.val("");
                                    me.pro_qty.val("");
                                    me.pro_price.val("");
                                    me.pro_amt.val("");
                                    me.job_ps_code.val("");
                                    me.io_by.val("");


                                    me.pro_code.attr('data-validate', 'false');
                                    me.store_qty.attr('data-validate', 'false');
                                }
                                me.hdnProdPanel.val(me.dtJobTempList.DataTable().rows().data().length);

                                if (me.dtJobTempList.DataTable().rows().data().length === 0) {
                                    me.hdnProdPanel.val("");
                                    me.pro_code.attr('data-validate', 'true');
                                    me.store_qty.attr('data-validate', 'true');
                                }
                                else {
                                    var indexes = null;
                                    if (me.btnAddProdOrder.attr("data-mode") === "edit") {
                                        indexes = me.dtjobtemp.rows().eq(0).filter(function (rowIdx) {
                                            return me.dtjobtemp.cell(rowIdx, 0).data() === me.pro_code.val() ? true : false;
                                        });
                                        me.dtjobtemp.rows(indexes).nodes().to$().css('color', 'Red');
                                    }
                                }
                                me.form.validator('update');

                                me.form.validator('validate');

                            });
                            //me.dtjobtemp.destroy();
                            //me.createDatatableJobTemp();
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        $("#loading").hide();
                        warningAlert(thrownError);
                    }
                });
                /*
                $.get(me.delProdUrl, { pro_code: obj.pro_code, doc_no: me.doc_no.val() })
                    .done(function (result) {
                        if (result > 0) {
                            me.dtjobtemp.ajax.reload(function (json) {

                                if (obj.pro_code === me.pro_code.val()) {
                                    me.pro_code.val("");
                                    me.pro_tname.val("");
                                    me.locat_code.val("");
                                    me.locat_name.val("");
                                    me.sale_unit_code.val(0);
                                    me.dot_id.val("");
                                    me.dot_name.val("");
                                    me.store_qty.val("");
                                    me.pro_ohqty.val("");
                                    me.pro_qty.val("");
                                    me.pro_price.val("");
                                    me.pro_amt.val("");
                                    me.ps_code.val("");
                                    me.io_by.val("");
                                    me.btnAddProdOrder.prop("disabled", true);
                                    me.btnAddProdOrder.text('เพิ่มรายการ');
                                    me.btnAddProdOrder.attr('data-mode', 'add');
                                    me.btnAddProdOrder.removeClass("btn btn-warning").addClass("btn btn-success");
                                    me.pro_code.attr('data-validate', 'false');
                                    me.store_qty.attr('data-validate', 'false');
                                }

                                me.hdnProdPanel.val(me.dtJobTempList.DataTable().rows().data().length);

                                if (me.dtJobTempList.DataTable().rows().data().length === 0) {
                                    me.hdnProdPanel.val("");
                                    me.pro_code.attr('data-validate', 'true');
                                    me.store_qty.attr('data-validate', 'true');
                                }
                                //else {
                                //    me.pro_code.attr('data-validate', 'false');
                                //    me.store_qty.attr('data-validate', 'false');
                                //}
                                me.form.validator('update');

                                me.form.validator('validate');

                            });
                            //me.dtjobtemp.destroy();
                            //me.createDatatableJobTemp();

                        }
                    })
                    .fail(function (e) {
                        warningAlert(e);
                    });*/
            });

            this.dtJobTempList.on('click', 'a.online_stock', function (e) {
                var obj = me.indexForm.dtProduct.row($(this).closest('tr')).data();

                if ($.fn.DataTable.isDataTable(me.dtStockList)) {
                    me.dtStockList.DataTable().destroy();
                }
                me.createDatatableStock(obj);

                me.prodstockModal.modal({ backdrop: 'static', keyboard: false });
                $("#lblpro_code").text(obj.pro_code);
            });
        }
    },

    {
        key: 'createDatatableProductDetail',
        value: function createDatatableProductDetail(obj) {
            var me = this;
            this.dtpdjbdetail = this.dtProductDetailList.DataTable({
                "bLengthChange": false,
                "bDestroy": true,
                "bSort": false,
                "searching": false,
                "paging": false,
                "info": false,
                "oLanguage": {
                    "sEmptyTable": "ไม่พบข้อมูลสินค้า"
                },
                "ajax": {
                    "url": me.posUrl + 'api/Product/ProductDetailList?cus_code=' + me.cus_code.val() + '&cus_type=' + me.cus_type.val(),
                    "data": { '': obj.pro_code },
                    "type": "POST",
                    "error": function (e) {
                        if (e) {
                            var $empty = me.dtProductSetDetailList.find('.dataTables_empty');
                            if ($empty) $empty.html('ไม่มีข้อมูลสินค้า')
                        }
                    },
                    "dataSrc": function (result) {
                        me.createDatatableProductLocat(result);
                        return result.map(value => value.Product);
                    }
                },
                "columns": [
                    { "data": 'pro_code' },
                    { "data": "pro_ven_code" },
                    { "data": "pro_tname" },
                    { "data": "progroup_name", width: "10%" },
                    { "data": "probrand_name", width: "10%" },
                    { "data": "promodel_name", width: "10%" },
                    { "data": "prosize_name", width: "10%" },
                    { "data": "pro_ohqty", width: "8%", className: "text-center" }
                ]
            });
        }
    },
    {
        key: 'createDatatableProductLocat',
        value: function createDatatableProductLocat(obj) {
            var me = this;
            var prod = obj.map(value => value.Product)[0].progroup_code;
            var table = "";
            var datasrc = null;
            var _columns = [];
            if (prod === "9001") {
                table = "gv_productlocatDot-list";
                datasrc = obj.map(value => value.ProductlocatDot);
                datasrc = datasrc.reduce(function (obj, v) {

                    return v;
                }, {})
                _columns = [
                    {
                        "data": 'dot_name',
                        "className": "text-center",
                        "render": function render(data, type, row) {
                            return '<a href="#"  class="locatselect">' + row.dot_name + '</a>';//data-dismiss="modal"
                        }
                    },
                    { "data": "pro_qty", "className": "text-center" }
                ];
                $('#div_gvprolocatDot').removeAttr("hidden")
            }
            else {
                table = "gv_productlocat-list";
                datasrc = obj.map(value => value.Productlocat);
                _columns = [
                    {
                        "data": 'locat_name',
                        "className": "text-center",
                        "render": function render(data, type, row) {
                            return '<a href="#"  class="locatselect">' + row.locat_name + '</a>';//data-dismiss="modal"
                        }
                    },
                    { "data": "pro_qoh", className: "text-center" }
                ];
                $('#div_gvprolocat').removeAttr("hidden")
            }

            this.dtpdlocat = $('#' + table).DataTable({
                "bLengthChange": false,
                "bDestroy": true,
                "bSort": false,
                "searching": false,
                "paging": false,
                "info": false,
                "oLanguage": {
                    "sEmptyTable": "ไม่พบข้อมูล"
                },

                "columns": _columns,
                "data": datasrc
            });

            $('#' + table).on('click', 'a.locatselect', function (e) {
                var objPro_detail = me.dtpdjbdetail.row().data();
                var objLocat = me.dtpdlocat.row($(this).closest('tr')).data();

                if (objLocat !== undefined) {
                    if (me.dtJobTempList.DataTable().rows().data().length > 0) {
                        var numberOfRows = me.dtJobTempList.DataTable().rows().data().length;
                        var useStockTotal = 0;
                        for (var i = 0; i < numberOfRows; i++) {

                            var d = me.dtjobtemp.row(i).data();
                            if (d.pro_stock !== "0") {// not service
                                if (objLocat.dot_id === undefined || objLocat.dot_id === 0 || objLocat.dot_id === null) {
                                    if (d.pro_code === objPro_detail.pro_code)
                                    //&& d.ps_code !== parseInt(me.ps_code.val())) 
                                    {
                                        useStockTotal += parseInt(d.store_qty);
                                    }
                                }
                                else {
                                    if (d.pro_code === objPro_detail.pro_code
                                        && d.dot_id === parseInt(objLocat.dot_id)
                                        //&& d.ps_code === parseInt(objPro_detail.ps_code.val())
                                    ) {
                                        useStockTotal += parseInt(d.store_qty);
                                    }
                                }
                            }
                        }
                        var total = parseInt(useStockTotal) + 1;
                        if (objLocat.dot_id === undefined || objLocat.dot_id === 0 || objLocat.dot_id === null) {
                            if ((objPro_detail.pro_ohqty - total) < 0) {
                                $(this).closest('tr').css('color', 'Red');
                                $(this).closest('tr').find('td:eq(0)').html('ไม่สามารถขายสินค้าจำนวนที่มากกว่าสินค้าคลัง').css('color', 'Red');
                            }
                            else {
                                me.updateProductJobOrder($.extend(objPro_detail, objLocat));
                                me.btnAddProdOrder.text('เพิ่มรายการ');
                                me.btnAddProdOrder.attr('data-mode', 'add');
                                me.btnAddProdOrder.removeClass("btn btn-warning").addClass("btn btn-success");
                                //me.form.validator('validate')
                                $('#btnprolocat').click();
                            }
                        }
                        else {
                            if ((objLocat.pro_qty - total) < 0) {
                                $(this).closest('tr').css('color', 'Red');
                                $(this).closest('tr').find('td:eq(0)').html('ไม่สามารถขายสินค้าจำนวนที่มากกว่าสินค้าคลัง').css('color', 'Red');
                            }
                            else {
                                me.updateProductJobOrder($.extend(objPro_detail, objLocat));
                                me.btnAddProdOrder.text('เพิ่มรายการ');
                                me.btnAddProdOrder.attr('data-mode', 'add');
                                me.btnAddProdOrder.removeClass("btn btn-warning").addClass("btn btn-success");
                                //me.form.validator('validate')
                                $('#btnprolocat').click();
                            }
                        }
                    }
                    else {
                        me.updateProductJobOrder($.extend(objPro_detail, objLocat));
                        me.btnAddProdOrder.text('เพิ่มรายการ');
                        me.btnAddProdOrder.attr('data-mode', 'add');
                        me.btnAddProdOrder.removeClass("btn btn-warning").addClass("btn btn-success");
                        //me.form.validator('validate')
                        $('#btnprolocat').click();
                    }
                }
            });
        }
    },
    {
        key: 'createDatatableProductSet',
        value: function createDatatableProductSet() {
            var me = this;
            this.dtpdSet = this.dtProductSetList.DataTable({
                "bLengthChange": false,
                "pageLength": 20,
                "processing": true,
                "serverSide": true,
                "searching": false,
                "ajax": {
                    "url": me.posUrl + 'api/Product/ProductSetList',
                    "type": "POST",
                    "contentType": 'application/json',
                    "data": function data(_data) {
                        var formValues = FormSerialize.getFormArray(me.productSetForm, _data);
                        return JSON.stringify(formValues);
                    },
                    error: function error(jqXHR, exception) {
                        setTimeout(function () {
                            return (
                                me.dtpdSet.ajax.url(me.posUrl + 'api/Product/ProductSetList').load()
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
                    { "data": 'ps_code' },
                    { "data": "ps_name" },
                    { "data": "ps_startdate" },
                    { "data": "ps_enddate" },
                    //{
                    //    "data": "ps_code",
                    //    "className": "text-center",
                    //    "orderable": false,
                    //    "render": function render(data, type, row) {
                    //        return '<a href="#" class="proset_detail">เลือกรายการ</a>';
                    //    }
                    //}
                ]
            });
            this.dtProductSetList.on('click', 'tr', function (e) {
                var obj = me.dtpdSet.row($(this).closest('tr')).data();

                if ($.fn.DataTable.isDataTable(me.dtProductSetDetailList)) {
                    me.dtProductSetDetailList.DataTable().destroy();
                }
                if (obj !== undefined) {
                    me.createDatatableProductSetDetail(obj);

                    me.prodsetdetailModal.modal({ backdrop: 'static', keyboard: false });
                    $("#lblps_code_name").text(obj.ps_code + ' ' + '(' + obj.ps_name + ')');
                }

            });
            //this.dtProductSetList.on('click', 'a.proset_detail', function (e) {
            //    var obj = me.dtpdSet.row($(this).closest('tr')).data();
            //    me.createDatatableProductSetDetail(obj);

            //    me.prodsetdetailModal.modal({ backdrop: 'static', keyboard: false });
            //    $("#lblps_code_name").text(obj.ps_code + ' ' + '(' + obj.ps_name + ')');
            //});

        }
    },
    {
        key: 'createDatatableProductSetDetail',
        value: function createDatatableProductSetDetail(obj) {
            var me = this;
            this.dtpddetail = this.dtProductSetDetailList.DataTable({
                "bLengthChange": false,
                "pageLength": 20,
                "oLanguage": {
                    "sEmptyTable": "ไม่พบข้อมูลสินค้าชุด หรือ จำนวนสินค้าในคลังหมด"
                },
                "ajax": {
                    "url": me.posUrl + 'api/Product/ProductSetDetailList?ps_gen_id=' + obj.ps_gen_id + '&ps_code=' + obj.ps_code,
                    "type": "POST",
                    "error": function (e) {
                        if (e) {
                            var $empty = me.dtProductSetDetailList.find('.dataTables_empty');
                            if ($empty) $empty.html('ไม่มีข้อมูลสินค้าชุด หรือ จำนวนสินค้าในคลังหมด')
                        }
                    },
                    "dataSrc": function (result) {
                        return result
                    }
                },
                "columns": [
                    { "data": 'ps_line_no' },
                    { "data": "ps_pro_code" },
                    { "data": "pro_name" },
                    {
                        "data": "locat_dot_name",
                        "className": "text-center",
                        "render": function render(data, type, row) {
                            if (row.ddlobj.length > 0) {
                                var $select = $("<select class='form-control dot_ddl' data-selectedot-error = 'กรุณาระบุ DOT' data-selectedot = '0' data-error = 'กรุณาระบุ DOT' required><option value='0'>เลือก DOT</option></select>", {
                                });
                                $.each(row.ddlobj, function (k, v) {

                                    var $option = $("<option></option>", {
                                        "text": v.dot_name,
                                        "value": v.dot_id
                                    });
                                    if (v.is_selected) {
                                        $option.attr("selected", "selected");
                                    }
                                    $select.append($option);
                                });

                                return $("<div class='form-group row has-feedback'>" +
                                    $select.prop("outerHTML") +
                                    "<span class='glyphicon form-control-feedback' aria-hidden='true'></span>" +
                                    "<div class='help-block with-errors'></div>" +
                                    "</div>").prop("outerHTML");
                            }
                            else { return "-"; }
                        }
                    },
                    { "data": "locat_name", "className": "text-center" },
                    { "data": "pro_qoh", "className": "text-center" },
                    {
                        "data": "pro_qty",
                        "className": "text-center",
                        "render": function render(data, type, row) {
                            if (row.ddlobj.length > 0) {
                                var $label = $("<label></label>", {
                                });
                                $.each(row.ddlobj, function (k, v) {

                                    if (v.is_selected) {
                                        $label.append(v.pro_qty);
                                    }
                                });

                                return $label.prop("outerHTML");
                            }
                            else { return "-"; }
                        }
                    },
                    { "data": "ps_qty", "className": "text-center" },
                    { "data": "ps_price", "className": "text-right", "render": $.fn.dataTable.render.number(',', '.', 2) }
                ],
                initComplete: function () {

                    $('#gv_prodsetdetail-list tbody').on('change', 'select.dot_ddl', function () {

                        var seledot = $(this).find(":selected").val();

                        //$(this).find('option').removeAttr('selected');
                        var row = $('#gv_prodsetdetail-list').DataTable().row($(this).closest('tr'));

                        var data = row.data();
                        if (data !== undefined) {
                            data.ddlobj.filter(function (value, index) {
                                if (value.dot_id === parseInt(seledot)) {
                                    value.is_selected = true;
                                    return
                                }
                                else {
                                    value.is_selected = false;
                                }
                            });

                            row.invalidate().draw(false);

                            me.prodsetdetailModal.find('form').validator('update');
                            me.prodsetdetailModal.find('form').validator('validate');

                            $('#btnaddprodset').prop("disabled", $('#_addprodset').hasClass("disabled"));
                            var _error = 0;
                            $('#gv_prodsetdetail-list').DataTable().rows().data()
                                .filter(function (_items, index) {
                                    if (_items.pro_stock !== "0") {
                                        if (_items.pro_qoh === 0) {
                                            ++_error;
                                            this.row().nodes().to$().css('color', 'Red');
                                            this.row().nodes().to$().find('td:eq(6)').html('ไม่สามารถขายสินค้าเนื่องจากจำนวนในคลังสินค้ามีไม่พอ').css('color', 'Red');
                                        }
                                    }
                                });
                            if (_error > 0) {
                                $("#btnaddprodset").prop("disabled", true);
                            }
                        }
                    });
                }
            });
        }
    },
    {
        key: 'createDatatableStock',
        value: function createDatatableStock(obj) {
            var me = this;
            this.dts = this.dtStockList.DataTable({
                "bLengthChange": false,
                "stateSave": true,
                "bDestroy": true,
                "pageLength": 20,
                "ajax": {
                    "url": me.hqUrl + 'api/Product/GetStockOnline',
                    "data": {
                        pro_code: obj.pro_code,
                        state: 'oh'
                    },
                    "error": function (e) {
                        if (e) {
                            var $empty = me.dtStockList.find('.dataTables_empty');
                            if ($empty) $empty.html('ไม่สามารถเชื่อมต่อ HQ ได้')
                        }
                    },
                    "dataSrc": function (d) {
                        return d
                    }
                },
                "columns": [
                    { "data": 'dealercode' },
                    { "data": "DealerName" },
                    { "data": "pro_ohqty" }
                ]
            });
        }
    },
    {
        key: 'addProductJobOrder',
        value: function addProductJobOrder(model) {
            var me = this;

            $.ajax({
                type: 'POST',
                url: me.addProdUrl,
                data: JSON.stringify({ 'model': model }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function beforeSend() {
                    $("#loading").show();
                },
                success: function success(result) {
                    $("#loading").hide();
                    if (result > 0) {
                        //me.dtjobtemp.destroy();
                        //me.createDatatableJobTemp();

                        me.dtjobtemp.ajax.reload(function (json) {

                            me.btnAddProdOrder.prop("disabled", true);

                            me.reset(me.dtJobTempList.DataTable().rows().data().length, 'false');

                        });

                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $("#loading").hide();
                    warningAlert(thrownError);
                }
            });
        }
    },
    {
        key: 'addProductSetJobOrder',
        value: function addProductSetJobOrder(model) {
            var me = this;
            $.ajax({
                type: 'POST',
                url: me.addProdSetUrl,
                data: JSON.stringify({ 'model': model, 'doc_no': me.doc_no.val() }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function beforeSend() {
                    $("#loading").show();
                },
                success: function success(result) {
                    $("#loading").hide();
                    if (result > 0) {

                        me.dtjobtemp.ajax.reload(function (json) {

                            me.btnAddProdOrder.prop("disabled", true);

                            me.reset(me.dtJobTempList.DataTable().rows().data().length, 'false');

                        });

                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $("#loading").hide();
                    warningAlert(thrownError);
                }
            });
        }
    },
    {
        key: 'updateJobOrder',
        value: function updateJobOrder(model) {
            var me = this;
            me.cus_type.val(model.custype_code);
            me.cus_code.val(model.cus_code);
            me.car_reg.val(model.car_reg === null ? "-" : model.car_reg);
            me.car_province.val(model.car_reg === null ? "" : model.add_province);
            me.Car_Brand.val(model.car_reg === null ? "" : model.car_brand);
            me.Car_model.val(model.car_reg === null ? "" : model.car_model);
            me.last_mileage.val(model.last_mileage);
            me.km_perday.val(model.car_reg === null ? 1 : 0);
            me.cus_name.val(model.cus_name);
            me.job_contact.val(model.cus_name);
            me.job_conttel.val(model.add_mobile);
            me.invoice_type.val(model.custype_code);
            me.car_mileage.val(0);
            me.first_contdate.val(model.first_contdate);
            me.first_mileage.val(model.first_mileage);
            if (model.last_mileage === null || model.last_mileage === 0) {
                model.last_mileage = model.first_mileage;
            }
            if (model.last_contdate === null || model.last_contdate === "") {
                model.last_contdate = model.first_contdate;
            }
            me.last_contdate.val(model.last_contdate);
            me.form.validator('validate')
        }
    },
    {
        key: 'updateProductJobOrder',
        value: function updateProductJobOrder(model) {
            var me = this;

            me.pro_code.val(model.pro_code);
            me.pro_tname.val(model.pro_tname);
            me.locat_code.val(model.locat_code);
            me.locat_name.val(model.locat_name);
            me.sale_unit_code.val(model.sale_unit_code);
            me.dot_id.val(model.dot_id);
            me.dot_name.val(model.dot_name);

            me.store_qty.val(model.store_qty);
            if (model.pro_stock === "0") {
                me.pro_ohqty.val("");
                me.pro_qty.val("");
            }
            else {
                if (model.dot_id === undefined || model.dot_id === 0 || model.dot_id === null) {
                    me.pro_ohqty.val(model.pro_ohqty);
                    me.pro_qty.val("");
                }
                else {
                    me.pro_qty.val(model.pro_qty);
                    me.pro_ohqty.val("");
                }
            }


            me.pro_price.val(model.pro_price_retail);
            me.pro_amt.val(model.pro_price_retail);


            me.job_ps_code.val(model.ps_code);

            me.is_proset.val(model.is_proset);
            me.ps_gen_id.val(model.ps_gen_id);
            me.ps_code.val(model.ps_code);
            me.ps_name.val(model.ps_name);

            if (me.store_qty.val() === "") {
                me.store_qty.val(1);
            }
            if (me.pro_price.val() === "") {
                me.pro_price.val(0);
            }
            if (me.pro_amt.val() === "") {
                me.pro_amt.val(0);
            }

            me.pro_code.attr('data-validate', 'true');
            me.store_qty.attr('data-validate', 'true');
            me.form.validator('update');

            me.form.validator('validate');
            //if (model.pro_stock === "0") {
            //    me.pro_price.val(model.pro_price_retail);
            //    me.pro_amt.val(model.pro_price_retail);
            //}
            //else {
            //    me.pro_price.val(model.pro_price);
            //    me.pro_amt.val(model.pro_amt);
            //}
        }
    },
    {
        key: 'initDateTimePicker',
        value: function initDateTimePicker() {
            var me = this;
            var _startDate = new Date();
            var _endDate = new Date(_startDate.getTime());
            me.inputStartDateTime.datepicker({
                autoclose: true,
                format: 'dd/mm/yyyy',
                orientation: 'bottom left',
                todayHighlight: true,
                disableTouchKeyboard: true
            }).on('changeDate', function (e) {
                _endDate = new Date(e.date.getTime());
                me.inputEndDateTime.datepicker('setStartDate', _endDate);
            });
            me.inputEndDateTime.datepicker({
                startDate: _endDate,
                autoclose: true,
                format: 'dd/mm/yyyy',
                orientation: 'bottom left',
                todayHighlight: true,
                disableTouchKeyboard: true
            });
        }
    }
    ]);


    return JobForm;
}();