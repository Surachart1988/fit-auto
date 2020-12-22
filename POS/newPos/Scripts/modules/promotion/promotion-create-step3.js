$(function () {
    initSelect2();
    $('.onKeysPrice').keypress(function (e) {
        if ((e.which != 46 || $(this).val().indexOf('.') != -1) && ((e.which < 48 || e.which > 57) && (e.which != 0 && e.which != 8))) {
            e.preventDefault();
        }
        var text = $(this).val();
        if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2) && (e.which != 0 && e.which != 8) && ($(this)[0].selectionStart >= text.length - 2)) {
            e.preventDefault();
        }
    });
    $('.onKeysPrice').change(function () {
        var v = parseFloat(this.value);
        this.value = (isNaN(v)) ? '' : v.toFixed(2);
    });
    $('.keyInteger').keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });

    $('[name="pro_give_type_id"]').change(function () {
        $('[name="pro_give_type_detail"]').attr("disabled", true);
        $('[name="pro_give_type_detail"]').val(0);
        if (this.id.substring(this.id.length - 1) === this.value) {
            $('.' + this.id).find('input[type=text]').attr("disabled", false);

        }
    });

    /*if ($('[name="pro_give_type_id"]:checked').length > 0) {
        $('[name="pro_give_type_detail"]').attr("disabled", true);
        var obj = $('[name="pro_give_type_id"]:checked');
        if (obj[0].id.substring(obj[0].id.length - 1) === obj[0].value) {
            $('.' + obj[0].id).find('input[type=text]').attr("disabled", false);
        }
    }*/
    if ($('[name="pro_give_type_id"]') != null) {
        $('[name="pro_give_type_id"]').each(function () {

            if (!$(this)[0].checked) {
                $('.' + $(this)[0].id).find('input[type=text]').val(0);
                //$(this).find('input[type=text]').val(0);
            }
        });
    }

    $('[name="pro_type_id"]').change(function () {
        $('[name="pro_type_detail"]').attr("disabled", true);
        $('[name="pro_type_detail"]').val(0);
        if (this.id.substring(this.id.length - 1) === this.value) {
            $('.' + this.id).find('input[type=text]').attr("disabled", false);

        }
    });

    /*if ($('[name="pro_type_id"]:checked').length > 0) {
        $('[name="pro_type_detail"]').attr("disabled", true);
        var obj2 = $('[name="pro_type_id"]:checked');
        if (obj2[0].id.substring(obj2[0].id.length - 1) === obj2[0].value) {
            $('.' + obj2[0].id).find('input[type=text]').attr("disabled", false);

        }
    }*/

    if (document.getElementById("pro_give_same_buy0") != null) {
        if (document.getElementById("pro_give_same_buy0").checked) {
            $("#div_search_give_view").hide();
        }
        $("#pro_give_same_buy0").click(function (e) {
            $("#div_search_give_view").hide();
        });

    }
    if (document.getElementById("pro_give_same_buy1") != null) {
        if (document.getElementById("pro_give_same_buy1").checked) {
            $("#div_search_give_view").show();
        }
        $("#pro_give_same_buy1").click(function (e) {
            $("#div_search_give_view").show();
        });

    }

    if (document.getElementById("pro_discount_id1") != null) {
        if (document.getElementById("pro_discount_id1").checked) {
            $('[name="pro_discount_num2"]').attr("disabled", true);
            $('[name="pro_discount_rate2"]').attr("disabled", true);
            $('[name="pro_discount_num2"]').val(0); $('[name="pro_discount_rate2"]').val(0);
            $("#pro_discount_unit2").attr("disabled", true);

            $('[name="pro_discount_rate"]').attr("disabled", false);
            $("#pro_discount_unit").attr("disabled", false);
        }
        $("#pro_discount_id1").click(function (e) {
            $('[name="pro_discount_num2"]').attr("disabled", true);
            $('[name="pro_discount_rate2"]').attr("disabled", true);
            $('[name="pro_discount_num2"]').val(0); $('[name="pro_discount_rate2"]').val(0);
            $("#pro_discount_unit2").attr("disabled", true);

            $('[name="pro_discount_rate"]').attr("disabled", false);
            $("#pro_discount_unit").attr("disabled", false);
        });
    }
    if (document.getElementById("pro_discount_id2") != null) {
        if (document.getElementById("pro_discount_id2").checked) {
            $('[name="pro_discount_num2"]').attr("disabled", false);
            $('[name="pro_discount_rate2"]').attr("disabled", false);

            $("#pro_discount_unit2").attr("disabled", false);

            $('[name="pro_discount_rate"]').attr("disabled", true);
            $("#pro_discount_unit").attr("disabled", true);
            $('[name="pro_discount_rate"]').val(0);
        }
        $("#pro_discount_id2").click(function (e) {
            $('[name="pro_discount_num2"]').attr("disabled", false);
            $('[name="pro_discount_rate2"]').attr("disabled", false);
            $("#pro_discount_unit2").attr("disabled", false);

            $('[name="pro_discount_rate"]').attr("disabled", true);
            $("#pro_discount_unit").attr("disabled", true);
            $('[name="pro_discount_rate"]').val(0);
        });
    }

    if (document.getElementById("group_coupon_id0") != null) {
        if (document.getElementById("group_coupon_id0").checked) {
            if ($("#Mode").val() != "c") {
                $("#coupon_code2").attr("disabled", true);
                $("#coupon_code2").val("");
                $("#FileUpload1").attr("disabled", true);
                $("#FileUpload1").val("");
                $("#btnImportCoupon").attr("disabled", true);
                $("#brn_downloadCoupon").attr("disabled", true);
                $("#div_ViewCoupon").hide();

                $("#coupon_code").attr("disabled", true);
                $("#coupon_value_amount").attr("disabled", true);
                $("#coupon_value_percent").attr("disabled", true);

                $("#coupon_value_amount0").attr("disabled", false);
                $("#coupon_value_percent0").attr("disabled", false);
            }
        }
        $("#group_coupon_id0").click(function (e) {
            $("#coupon_code2").attr("disabled", true);
            $("#coupon_code2").val("");
            $("#FileUpload1").attr("disabled", true);
            $("#FileUpload1").val("");
            $("#btnImportCoupon").attr("disabled", true);
            $("#brn_downloadCoupon").attr("disabled", true);
            $("#div_ViewCoupon").hide();

            $("#coupon_code").attr("disabled", true);
            $("#coupon_value_amount").attr("disabled", true);
            $("#coupon_value_percent").attr("disabled", true);
            $("#coupon_code").val("");
            $("#coupon_value_amount").val("");
            $("#coupon_value_percent").val("");

            $("#coupon_value_amount0").attr("disabled", false);
            $("#coupon_value_percent0").attr("disabled", false);
        });
    }
    if (document.getElementById("group_coupon_id1") != null) {
        if (document.getElementById("group_coupon_id1").checked) {
            if ($("#Mode").val() != "c") {
                $("#coupon_code2").attr("disabled", true);
                $("#coupon_code2").val("");
                $("#FileUpload1").attr("disabled", true);
                $("#FileUpload1").val("");
                $("#btnImportCoupon").attr("disabled", true);
                $("#brn_downloadCoupon").attr("disabled", true);
                $("#div_ViewCoupon").hide();

                $("#coupon_value_amount0").attr("disabled", true);
                $("#coupon_value_percent0").attr("disabled", true);

                $("#coupon_code").attr("disabled", false);
                if ($("#coupon_value_amount").val() > 0) {
                    $("#coupon_value_percent").attr("disabled", true);
                }
                if ($("#coupon_value_percent").val() > 0) {
                    $("#coupon_value_amount").attr("disabled", false);
                }
            }
        }
        $("#group_coupon_id1").click(function (e) {
            $("#coupon_code2").attr("disabled", true);
            $("#coupon_code2").val("");
            $("#FileUpload1").attr("disabled", true);
            $("#FileUpload1").val("");
            $("#btnImportCoupon").attr("disabled", true);
            $("#brn_downloadCoupon").attr("disabled", true);
            $("#div_ViewCoupon").hide();

            $("#coupon_value_amount0").attr("disabled", true);
            $("#coupon_value_percent0").attr("disabled", true);
            $("#coupon_value_amount0").val("");
            $("#coupon_value_percent0").val("");

            $("#coupon_code").attr("disabled", false);
            $("#coupon_value_amount").attr("disabled", false);
            $("#coupon_value_percent").attr("disabled", false);
        });
    }
    if (document.getElementById("group_coupon_id2") != null) {
        if (document.getElementById("group_coupon_id2").checked) {
            if ($("#Mode").val() != "c") {
                $("#coupon_code2").attr("disabled", false);
                $("#FileUpload1").attr("disabled", false);
                $("#btnImportCoupon").attr("disabled", false);
                $("#brn_downloadCoupon").attr("disabled", false);
                //$("#div_ViewCoupon").show();
                $("#coupon_value_amount0").attr("disabled", true);
                $("#coupon_value_percent0").attr("disabled", true);
                $("#coupon_value_amount0").val("");
                $("#coupon_value_percent0").val("");

                $("#coupon_code").attr("disabled", true);
                $("#coupon_value_amount").attr("disabled", true);
                $("#coupon_value_percent").attr("disabled", true);
                $("#coupon_code").val("");
                $("#coupon_value_amount").val("");
                $("#coupon_value_percent").val("");
            }
        }
        $("#group_coupon_id2").click(function (e) {
            $("#coupon_code2").attr("disabled", false);
            $("#FileUpload1").attr("disabled", false);
            $("#btnImportCoupon").attr("disabled", false);
            $("#brn_downloadCoupon").attr("disabled", false);

            //$("#div_ViewCoupon").show();
            $("#coupon_value_amount0").attr("disabled", true);
            $("#coupon_value_percent0").attr("disabled", true);
            $("#coupon_value_amount0").val("");
            $("#coupon_value_percent0").val("");

            $("#coupon_code").attr("disabled", true);
            $("#coupon_value_amount").attr("disabled", true);
            $("#coupon_value_percent").attr("disabled", true);
            $("#coupon_code").val("");
            $("#coupon_value_amount").val("");
            $("#coupon_value_percent").val("");
        });
    }
    CheckRowCoupun();
});
function CheckRowCoupun() {

    if ($("#gv_viewCoupon") != null) {
        if ($("#gv_viewCoupon").DataTable().rows().data().length > 0) {
            $("#div_ViewCoupon").show();
        } else {
            $("#div_ViewCoupon").hide();
        }
    }

}

initSelect2 = () => {
    $("#ddl_productfirstgroup").select2({
        theme: "bootstrap",
        width: "100%"
    });
};


function intitable(Tname, chkheader) {

    var table = $('#' + Tname).DataTable({
        columnDefs: [{
            orderable: false,
            className: 'select-checkbox',
            targets: 0
        }],
        select: {
            style: 'os',
            selector: 'td:first-child'
        },
        order: [
            [1, 'asc']
        ]
    });

    $('#' + chkheader).on('click', function () {
        var rows = table.rows({ 'search': 'applied' }).nodes();
        $('input[type="checkbox"]', rows).prop('checked', this.checked);
    });

    $('#' + Tname + " tbody").on('change', 'input[type="checkbox"]', function () {
        // If checkbox is not checked
        if (!this.checked) {
            var el = $('#' + chkheader).get(0);
            if (el && el.checked && ('indeterminate' in el)) {

                el.indeterminate = true;
            }
        }
    });

}

// กลุ่มสินค้า
intitable("gv_productgrp", "gv_productgrp_CheckBox_all");
$("#btnSaveProdGrp").click(function (e) {

    var list = []; var values = []; var Item = ""; var value = "";
    $("#gv_productgrp").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        Item = $(this).closest('tr').find("td").eq(2).text().trim();
        list.push(Item);
        value = $(this).closest('tr').find("td").eq(1).text().trim();
        values.push(value);
    });

    if (list.length === 0) {
        warningAlert('กรุณาเลือกข้อมูล');
        e.preventDefault();
    } else {
        $.ajax({
            cache: false,
            type: "POST",
            url: "SaveData",
            data: { 'data': values.join(), '_type': "productgrp" },
            success: function (data) {
                $('#modal-select-prodgroup').modal('toggle');
                $("#txt_prodgroup").val(list.join(', '));
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve.');
            }
        });
    }
});

// ประเภทสินค้า 
$("#btn_progroup_popup").click(function (e) {
    var list = []; var list2 = [];
    var Item = "";

    // กลุ่มสินค้า
    $("#gv_productgrp").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        Item = $(this).closest('tr').find("td").eq(1).text().trim();

        list.push(Item);
    });

    $("#gv_progroup").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        Item = $(this).closest('tr').find("td").eq(1).text().trim();

        list2.push(Item);
    });

    $.ajax({
        cache: false,
        type: "GET",
        url: "GetProgroup",
        data: { 'data': list.join(), 'hasChk': list2.join() },
        success: function (data) {
            $("#progroup_popup").html(data);
            //$("#gv_progroup").DataTable();
            intitable("gv_progroup", "gv_progroup_CheckBox_all");
            $('#modal-select-progroup').modal({ backdrop: 'static', keyboard: false }, 'toggle');
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Failed to retrieve.');
        }
    });
});

// ยี่ห้อสินค้า :
$("#btn_brand_popup").click(function (e) {

    var list = []; var list2 = [];
    var Item = "";

    // ประเภทสินค้า 
    $("#gv_progroup").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        Item = $(this).closest('tr').find("td").eq(1).text().trim();

        list.push(Item);
    });

    $("#gv_probrand").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        Item = $(this).closest('tr').find("td").eq(1).text().trim();

        list2.push(Item);
    });

    $.ajax({
        cache: false,
        type: "GET",
        url: "GetProbrand",
        data: { 'data': list.join(), 'hasChk': list2.join() },
        success: function (data) {
            $("#probrand_popup").html(data);
            //$("#gv_probrand").DataTable();
            intitable("gv_probrand", "gv_probrand_CheckBox_all");
            $('#modal-select-probrand').modal({ backdrop: 'static', keyboard: false }, 'toggle');
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Failed to retrieve.');
        }
    });
});

// รุ่นสินค้าสินค้า :
$("#btn_model_popup").click(function (e) {

    var list = []; var list2 = [];
    var Item = "";

    // ยี่ห้อสินค้า
    $("#gv_probrand").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        Item = $(this).closest('tr').find("td").eq(1).text().trim();

        list.push(Item);
    });

    $("#gv_promodel").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        Item = $(this).closest('tr').find("td").eq(1).text().trim();

        list2.push(Item);
    });

    $.ajax({
        cache: false,
        type: "GET",
        url: "GetPromodel",
        data: { 'data': list.join(), 'hasChk': list2.join() },
        beforeSend: function () {
            $("#loading").show();
        },
        success: function (data) {
            $("#loading").hide();
            $("#promodel_popup").html(data);
            //$("#gv_promodel").DataTable();
            intitable("gv_promodel", "gv_promodel_CheckBox_all");
            $('#modal-select-promodel').modal({ backdrop: 'static', keyboard: false }, 'toggle');
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Failed to retrieve.');
            $("#loading").hide();
        }
    });
});

// ขนาดสินค้า :
$("#btn_size_popup").click(function (e) {

    var list = []; var list2 = [];
    var Item = "";

    // รุ่นสินค้าสินค้า
    $("#gv_promodel").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        Item = $(this).closest('tr').find("td").eq(1).text().trim();

        list.push(Item);
    });

    $("#gv_prosize").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        Item = $(this).closest('tr').find("td").eq(1).text().trim();

        list2.push(Item);
    });

    $.ajax({
        cache: false,
        type: "GET",
        url: "GetProSize",
        data: { 'data': list.join(), 'hasChk': list2.join() },
        beforeSend: function () {
            $("#loading").show();
        },
        success: function (data) {
            $("#loading").hide();
            $("#prosize_popup").html(data);
            //$("#gv_prosize").DataTable();
            intitable("gv_prosize", "gv_prosize_CheckBox_all");
            $('#modal-select-prosize').modal({ backdrop: 'static', keyboard: false }, 'toggle');
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Failed to retrieve.');
            $("#loading").hide();
        }
    });
});

// เลือกสินค้า
$("#btn_code_popup").click(function (e) {
    var list = [];
    var list2 = [];
    var list3 = [];
    var list4 = [];
    var list5 = [];
    var list6 = [];
    var Item = "";

    // กลุ่มสินค้า
    $("#gv_productgrp").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        Item = $(this).closest('tr').find("td").eq(1).text().trim();

        list.push(Item);
    });
    // ประเภทสินค้า
    $("#gv_progroup").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {

        //Item = $(this).closest('tr').find("td").eq(1).text().trim();

        list2.push($(this).closest('tr').find("td").eq(1).text().trim());
    });
    // ยี่ห้อสินค้า
    $("#gv_probrand").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {
        if (this.checked) {
            $(this).closest('tr').find("td").map(function () {
                //Item = $(this).closest('tr').find("td").eq(1).text().trim();
                list3.push($(this).closest('tr').find("td").eq(1).text().trim());
            });
            //list3.push(Item);
        }
    });
    // รุ่นสินค้าสินค้า
    $("#gv_promodel").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {
        if (this.checked) {
            $(this).closest('tr').find("td").map(function () {
                Item = $(this).closest('tr').find("td").eq(1).text().trim();
                list4.push($(this).closest('tr').find("td").eq(1).text().trim());
            });
            //list4.push(Item);
        }
    });
    // ขนาดสินค้า
    $("#gv_prosize").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {
        if (this.checked) {
            $(this).closest('tr').find("td").map(function () {
                //Item = $(this).closest('tr').find("td").eq(1).text().trim();
                list5.push($(this).closest('tr').find("td").eq(1).text().trim());
            });
            //list5.push(Item);
        }
    });
    // ค้นหาสินค้า :
    $("#gv_procode").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {
        if (this.checked) {
            $(this).closest('tr').find("td").map(function () {
                //Item = $(this).closest('tr').find("td").eq(1).text().trim();
                list6.push($(this).closest('tr').find("td").eq(1).text().trim());
            });
            //list6.push(Item);
        }
    });
    $.ajax({
        cache: false,
        type: "GET",
        url: "GetProduct",
        data: { 'productgrp': list.join(), 'progroup': list2.join(), 'probrand': list3.join(), 'promodel': list4.join(), 'prosize': list5.join(), 'procode': list6.join() },
        beforeSend: function () {
            $("#loading").show();
        },
        //data: { data },
        //data: JSON.stringify(data1),
        //contentType: "application/json; charset=utf-8",
        //dataType: "json",
        success: function (data) {
            $("#loading").hide();
            $("#procode_popup").html(data);
            //$("#gv_procode").DataTable();
            intitable("gv_procode", "gv_procode_CheckBox_all");
            $('#modal-select-procode').modal({ backdrop: 'static', keyboard: false }, 'toggle');
            //$("#txt_pro_code").val(values.join(', '));
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Failed to retrieve.');
            $("#loading").hide();
        }
    });

});

$("#btn_gift_popup").click(function (e) {
    var list = [];
    var Item = "";
    // ค้นหาสินค้า :
    $("#gv_progivecode").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked').each(function () {
        if (this.checked) {
            $(this).closest('tr').find("td").map(function () {
                Item = $(this).closest('tr').find("td").eq(1).text().trim();
            });
            list.push(Item);
        }
    });
    $.ajax({
        cache: false,
        type: "GET",
        url: "GetProductGift",
        data: { 'procode': list.join() },
        beforeSend: function () {
            $("#loading").show();
        },
        //data: { data },
        //data: JSON.stringify(data1),
        //contentType: "application/json; charset=utf-8",
        //dataType: "json",
        success: function (data) {
            $("#loading").hide();
            $("#progivecode_popup").html(data);
            //$("#gv_progivecode").DataTable();
            intitable("gv_progivecode", "gv_progivecode_CheckBox_all");
            $('#modal-select-progivecode').modal({ backdrop: 'static', keyboard: false }, 'toggle');
            //$("#txt_pro_code").val(values.join(', '));
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Failed to retrieve.');
            $("#loading").hide();
        }
    });
});

$("#btnNextStep6_Save").click(function (e) {

    let _error = 0;
    parseFloat($("#pro_price_total").val()) === 0 ? _error++ : 0;

    if (_error > 0) {
        e.preventDefault();
        warningAlert("ไม่สามารถบันทึกโปรโมชั่นได้ เนื่องจาก ราคารวมขั้นต่ำของสินค้า ต้องมากกว่า 0");
    }
});


if ($("input:checkbox[name^='ProGrpUsedDetailsList']") != null) {
    var chkProgrpUsed = $("input:checkbox[name^='ProGrpUsedDetailsList']:not(input:checkbox[name='ProGrpUsedDetailsList[0].IsCheck'])");
    var allcheck = $("input:checkbox[name^='ProGrpUsedDetailsList']:not(input:checkbox[name='ProGrpUsedDetailsList[0].IsCheck']):checked")//$("input:checkbox[name^='ProGrpUsedDetailsList']:checked");

    chkProgrpUsed.click(function () {
        if (chkProgrpUsed.length === allcheck.length) {
            $("#ProGrpUsedDetailsList_0__IsCheck").prop('checked', true);
        } else {
            $("#ProGrpUsedDetailsList_0__IsCheck").prop('checked', false);
        }
    });
    $("#ProGrpUsedDetailsList_0__IsCheck").click(function () {
        var allcheckbox = $("input:checkbox[name^='ProGrpUsedDetailsList']");

        if (!this.checked) {
            allcheckbox.prop('checked', false);
            $("#ProGrpUsedDetailsList_0__IsCheck").prop('checked', false);
        } else {
            allcheckbox.prop('checked', true);
            $("#ProGrpUsedDetailsList_0__IsCheck").prop('checked', true);
        }
    });

    if (chkProgrpUsed.length === allcheck.length) {
        $("#ProGrpUsedDetailsList_0__IsCheck").prop('checked', true);
    } else {
        $("#ProGrpUsedDetailsList_0__IsCheck").prop('checked', false);
    }
}

$("#btnImportCoupon").click(function (e) {
    var coupon_code = $("#coupon_code2").val();
    if (coupon_code.length === 0) {
        e.preventDefault();
        warningAlert("กรุณาระบุกลุ่มรหัสคูปอง");
        return;
    }

    formdata = new FormData();
    if ($("#FileUpload1")[0].files.length > 0) {
        formdata.append($("#FileUpload1")[0].files[0].name, $("#FileUpload1")[0].files[0]);
        formdata.append('_code', coupon_code);

        $.ajax({
            url: "ImportCoupon",
            type: "POST",
            datatype: "JSON",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (result) {
                $("#div_ViewCoupon").html(result);
                $("#gv_viewCoupon").DataTable();
                CheckRowCoupun();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                e.preventDefault();
                warningAlert("มีกลุ่มรหัสคูปอง " + thrownError + " นี้อยู่แล้วในระบบ");
            }
        });
    }
});

function DownloadTemplateCoupon() {

    var port = window.location.port == "" ? "" : ":" + window.location.port;
    var url = window.location.protocol + "//" + window.location.hostname + port + "/PTT_HQ/TemplateCoupon/TemplateCoupon.xlsx";
    //var url = '';
    document.getElementById('my_iframe').src = url;

}