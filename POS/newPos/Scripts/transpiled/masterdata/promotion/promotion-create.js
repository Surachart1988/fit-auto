$(function () {
    initSelect2();
    initDatePicker();
    CheckData();
    clickFunction();
    if ($("input:checkbox[name^='Dealers']") != null) {
        var chkProgrpUsed = $("input:checkbox[name^='Dealers']");
        var allcheck = $("input:checkbox[name^='Dealers']:checked");

        chkProgrpUsed.click(function () {
            if (chkProgrpUsed.length === $("input:checkbox[name^='Dealers']:checked").length) {
                $("#chkall").prop('checked', true);
            } else {
                $("#chkall").prop('checked', false);
            }
        });
        $("#chkall").click(function () {
            var allcheckbox = $("input:checkbox[name^='Dealers']");

            if (!this.checked) {
                allcheckbox.prop('checked', false);
                $("#chkall").prop('checked', false);
            } else {
                allcheckbox.prop('checked', true);
                $("#chkall").prop('checked', true);
            }
        });

        if (chkProgrpUsed.length === allcheck.length) {
            $("#chkall").prop('checked', true);
        } else {
            $("#chkall").prop('checked', false);
        }
    }
    //$("#gv_proBranch").DataTable();
    //$('#gv_proBranch').DataTable({
    //    "columnDefs": [
    //        { "orderable": false, "targets": 0 }
    //    ]
    //});
    //$("#chkall").click(function () {
    //    var allcheckbox = $("#gv_proBranch").DataTable().rows().nodes().to$().find('input[type="checkbox"]');
    //    var allchk = allcheckbox.prop('checked', true);
    //    if (!this.checked) {
    //        allcheckbox.prop('checked', false);
    //    } else {
    //        if (allcheckbox.length === allchk.length) {
    //            $("input:checkbox[name='chkall']").prop('checked', true);
    //        }
    //    }
    //});
    //$('#gv_proBranch tbody input[type="checkbox"]').click(function () {
    //    var allcheckbox = $("#gv_proBranch").DataTable().rows().nodes().to$().find('input[type="checkbox"]');
    //    var dotchk = $("#gv_proBranch").DataTable().rows().nodes().to$().find('input[type="checkbox"]:checked')

    //    if (allcheckbox.length === dotchk.length) {
    //        $("#chkall").prop('checked', true);
    //    } else {
    //        $("#chkall").prop('checked', false);
    //    }
    //});

    if (document.getElementById("rdo_pro_condition_time_id_3") && document.getElementById("rdo_pro_condition_time_id_3").checked) {
        $(".form_det").hide();
    }

    if (document.getElementById("rdo_pro_condition_time_id_4") && document.getElementById("rdo_pro_condition_time_id_4").checked) {
        $(".form_det").show();
    }
    if (document.getElementById("ProConditionTime0") != null) {
        if (document.getElementById("ProConditionTime0").checked) {
            $(".form_det").show();
        }
    }
    if (document.getElementById("ProConditionTime1") != null && document.getElementById("ProConditionTime2") != null) {
        if (document.getElementById("ProConditionTime1").checked || document.getElementById("ProConditionTime2").checked) {
            $(".form_det").show();
        }
        if (document.getElementById("ProConditionTime3").checked) {
            $(".form_det").hide();
        }
        if (document.getElementById("allowmuti_yes").checked) {
            $(".form_allmutipro").show();
            if ($("input:checkbox[name^='PromotionList']:checked").length === $("input:checkbox[name^='PromotionList']").length) { $("input:checkbox[name='chkPromotionAll']").prop('checked', true); }
        }
        if (document.getElementById("allowmuti_no").checked) {
            $(".form_allmutipro").hide();
        }
        $("#allowmuti_yes").click(function (e) {
            $(".form_allmutipro").show();
            //$("input:checkbox[name='chkPromotionAll']").prop('checked', true);
            //$("input:checkbox[name^='PromotionList']").prop('checked', true);
        });
        $("input:checkbox[name^='chkPromotionAll']").click(function (e) {
            if ($("input:checkbox[name^='PromotionList']:checked").length === $("input:checkbox[name^='PromotionList']").length) {
                $("input:checkbox[name='chkPromotionAll']").prop('checked', false);
                $("input:checkbox[name^='PromotionList']").prop('checked', false);
            } else {
                $("input:checkbox[name='chkPromotionAll']").prop('checked', true);
                $("input:checkbox[name^='PromotionList']").prop('checked', true);
            }
        });
        $("input:checkbox[name^='PromotionList']").click(function (e) {
            $("input:checkbox[name='chkPromotionAll']").prop('checked', false);
            if ($("input:checkbox[name^='PromotionList']:checked").length === $("input:checkbox[name^='PromotionList']").length) { $("input:checkbox[name='chkPromotionAll']").prop('checked', true); }
        });
        $("#allowmuti_no").click(function (e) {
            $(".form_allmutipro").hide();
        });
    }
    $("#ProConditionTime0").click(function (e) {
        $(".form_det").show();
    });

    $("#ProConditionTime3").click(function (e) {
        $(".form_det").hide();
    });

    $('.keyInteger').keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $('.keyTwoDecimal').keypress(function (e) {
        if ((e.which != 46 || $(this).val().indexOf('.') != -1) && ((e.which < 48 || e.which > 57) && (e.which != 0 && e.which != 8))) {
            e.preventDefault();
        }
        var text = $(this).val();
        if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2) && (e.which != 0 && e.which != 8) && ($(this)[0].selectionStart >= text.length - 2)) {
            e.preventDefault();
        }
    });
    $("#rdo_pro_condition_time_id_1").click(function (e) {
        document.getElementById("rdo_pro_condition_time_id_4").checked = true
        document.getElementById("rdo_pro_condition_time_id_2").checked = false
        $(".form_det").show();
        for (i = 1; i <= 7; i++) {
            var week = "#cb_week_" + i;
            $(week).attr('disabled', false)
        }
        for (i = 1; i <= 31; i++) {
            var month = "#cb_month_" + i;
            $(month).attr('checked', false)
            $(month).attr('disabled', true)
        }

    });
    $("#rdo_pro_condition_time_id_2").click(function (e) {
        document.getElementById("rdo_pro_condition_time_id_4").checked = true
        document.getElementById("rdo_pro_condition_time_id_1").checked = false
        $(".form_det").show();
        for (i = 1; i <= 7; i++) {
            var week = "#cb_week_" + i;
            $(week).attr('checked', false)
            $(week).attr('disabled', true)
        }
        for (i = 1; i <= 31; i++) {
            var month = "#cb_month_" + i;
            $(month).attr('disabled', false)
        }

    });
    $("#rdo_pro_condition_time_id_3").click(function (e) {
        $(".form_det").hide();
        for (i = 1; i <= 7; i++) {
            var week = "#cb_week_" + i;
            $(week).attr('checked', false)
            $(week).attr('disabled', true)
        }
        for (i = 1; i <= 31; i++) {
            var month = "#cb_month_" + i;
            $(month).attr('checked', false)
            $(month).attr('disabled', true)
        }
    });
    $("#rdo_pro_condition_time_id_4").click(function (e) {
        $(".form_det").show();
        document.getElementById("rdo_pro_condition_time_id_1").checked = false
        document.getElementById("rdo_pro_condition_time_id_2").checked = false
    });

    $("input:checkbox[name^='ConditionWeek']").click(function (event) {
        //if (this.checked) {
        //    alert('checked')
        //} else {
        //    alert('unchecked')
        //}
        if ($("input:checkbox[name^='ConditionWeek']:checked").length > 0) {
            document.getElementById("ProConditionTime1").checked = true;

            //clear
            $("input:checkbox[name^='ConditionMonth']").prop('checked', false);
        }
    });
    $("input:checkbox[name^='ConditionMonth']").click(function (event) {
        //if (this.checked) {
        //    alert('checked')
        //} else {
        //    alert('unchecked')
        //}
        if ($("input:checkbox[name^='ConditionMonth']:checked").length > 0) {
            document.getElementById("ProConditionTime2").checked = true;

            //clear
            $("input:checkbox[name^='ConditionWeek']").prop('checked', false);
        }
    });
});

initSelect2 = () => {
    $("#ddl_campaign_id").select2({
        theme: "bootstrap",
        width: "100%"
    });
};

initDatePicker = () => {
    var _startDate = new Date();
    var _endDate = new Date(_startDate.getTime());

    $('#pro_start_date').datepicker({
        startDate: _startDate,
        autoclose: true,
        format: "dd/mm/yyyy",
        orientation: "bottom left",
        todayHighlight: true,
        disableTouchKeyboard: true
    }).on('changeDate', function (e) {
        _endDate = new Date(e.date.getTime());
        $('#pro_end_date').datepicker('setStartDate', _endDate);
    });
    $('#pro_end_date').datepicker({
        startDate: _endDate,
        autoclose: true,
        format: "dd/mm/yyyy",
        orientation: "bottom left",
        todayHighlight: true,
        disableTouchKeyboard: true
    });

    $('#pro_start_time').datetimepicker(
        {
            format: 'LT',
            format: 'HH:mm'
        })
        .on('dp.change', function (e) {
            if (e.currentTarget.value >= $('#pro_end_time').val()) {
                $(this).val(e.oldDate._i);
                $('#ProConditionWeekStart').val(e.oldDate._i);
                $('#ProConditionMonthStart').val(e.oldDate._i);
            } else {
                $('#ProConditionWeekStart').val(e.currentTarget.value);
                $('#ProConditionMonthStart').val(e.currentTarget.value);
            }
        });
    $('#pro_end_time').datetimepicker(
        {
            format: 'LT',
            format: 'HH:mm'
        })
        .on('dp.change', function (e) {
            if (e.currentTarget.value <= $('#pro_start_time').val()) {
                $(this).val(e.oldDate._i);
                $('#ProConditionWeekTimeEnd').val(e.oldDate._i);
                $('#ProConditionMonthEnd').val(e.oldDate._i);
            } else {
                $('#ProConditionWeekTimeEnd').val(e.currentTarget.value);
                $('#ProConditionMonthEnd').val(e.currentTarget.value);
            }
        });

    $('#ProConditionWeekStart').datetimepicker(
        {
            format: 'LT',
            format: 'HH:mm'
        })
        .on('dp.change', function (e) {

            if (e.currentTarget.value > $('#pro_start_time').val()) {
                $(this).val(e.oldDate._i);
            }
            if (e.currentTarget.value >= $('#ProConditionWeekTimeEnd').val()) {
                $(this).val(e.oldDate._i);
            }
        });
    $('#ProConditionWeekTimeEnd').datetimepicker(
        {
            format: 'LT',
            format: 'HH:mm'
        })
        .on('dp.change', function (e) {
            if (e.currentTarget.value > $('#pro_end_time').val()) {
                $(this).val(e.oldDate._i);
            }
            if (e.currentTarget.value <= $('#ProConditionWeekStart').val()) {
                $(this).val(e.oldDate._i);
            }
        });

    $('#ProConditionMonthStart').datetimepicker(
        {
            format: 'LT',
            format: 'HH:mm'
        })
        .on('dp.change', function (e) {
            if (e.currentTarget.value > $('#pro_start_time').val()) {
                $(this).val(e.oldDate._i);
            }
            if (e.currentTarget.value >= $('#ProConditionMonthEnd').val()) {
                $(this).val(e.oldDate._i);
            }
        });
    $('#ProConditionMonthEnd').datetimepicker(
        {
            format: 'LT',
            format: 'HH:mm'
        })
        .on('dp.change', function (e) {
            if (e.currentTarget.value > $('#pro_end_time').val()) {
                $(this).val(e.oldDate._i);
            }
            if (e.currentTarget.value <= $('#ProConditionMonthStart').val()) {
                $(this).val(e.oldDate._i);
            }
        });
};

Cancel = (URL) => {
    console.log(URL);
    confirmAlert('คุณต้องการยกเลิกข้อมูลโปรโมชั่นนี้ใช่ไหม ?', function (event) {
        console.log(event);
        if (!event) {
            window.location.href = URL;
        }
    });
}
$("#btnSaveBranch").click(function (e) {

    var list = []; var values = []; var Item = ""; var value = "";
    //var allcheck = $("input:checkbox[name^='Dealers']:checked");
    $("input:checkbox[name^='Dealers']:checked").each(function () {

        Item = $(this).closest('tr').find("td").eq(1).text().trim();
        list.push(Item);
        //value = $(this).closest('tr').find("td:not([class])").eq(0).find('input').val();
        //values.push(value);
    });

    if (list.length === 0) {
        warningAlert('กรุณาเลือกข้อมูล');
        e.preventDefault();
    } else {
        $('#modal-select-branch').modal('toggle');
    }
});
function CheckData() {
    $("#btnNextStep2").click(function (e) {
        if (document.getElementById("ProConditionTime0").checked) {
            if (!document.getElementById("ProConditionTime1").checked && !document.getElementById("ProConditionTime2").checked) {
                e.preventDefault(); warningAlert("กรุณาระบุ รอบเวลา"); return;
            }
        }
        if ($("#pro_name").val().length === 0) {
            e.preventDefault(); warningAlert("กรุณาระบุ ชื่อโปรโมชั่น"); return;
        }
        if ($("#pro_start_date").val().length === 0) {//$("#pro_start_date").val().length === 0 ? _error++ : 0;
            e.preventDefault(); warningAlert("กรุณาระบุ วันที่เริ่มต้น"); return;
        }
        if ($("#pro_end_date").val().length === 0) {//$("#pro_end_date").val().length === 0 ? _error++ : 0;
            e.preventDefault(); warningAlert("กรุณาระบุ วันที่สิ้นสุด"); return;
        }
        if ($("#campaign_id  option:selected").val().length === 0) {//$("#campaign_id  option:selected").val().length === 0 ? _error++ : 0;
            e.preventDefault(); warningAlert("กรุณาระบุ ชื่อแคมเปญ"); return;
        }
        if ($("input:checkbox[name^='Dealers']:checked").length === 0) {        //$("input:checkbox[name^='Dealers']:checked").length === 0 ? _error++ : 0;
            e.preventDefault(); warningAlert("กรุณาระบุ สาขาที่ร่วมรายการ"); return;
        }
        if (document.getElementById("ProConditionTime1").checked) {
            if ($("input:checkbox[name^='ConditionWeek']:checked").length === 0) {
                e.preventDefault(); warningAlert("กรุณาระบุ รอบสัปดาห์"); return;
            }
        }
        if (document.getElementById("ProConditionTime2").checked) {
            if ($("input:checkbox[name^='ConditionMonth']:checked").length === 0) {
                e.preventDefault(); warningAlert("กรุณาระบุ รอบเดือน"); return;
            }
        }
    });
    //$("#btnNextStep3").click(function (e) {
    //    if ($("input[name='SelectedProGrp']:checked").length > 0) {

    //    } else {
    //        e.preventDefault();
    //    }
    //});
    $("#rbl_pro_price_id_0,#rbl_pro_price_id_1").click(function () {
        $('#btnNextStep6').hide();
        $('#btnNextStep6_Save').show();

    });
    $("#rbl_pro_price_id_2").click(function () {
        $('#btnNextStep6').hide();
        $('#btnNextStep6_Save').show();
    });
    $('#btnNextStep6_Save').click(function (e) {
        var errorCount = 0;
        var errorMsg = "ไม่สามารถบันทึกโปรโมชั่นได้ เนื่องจาก \n";

        /*  if ($("#ddl_productfirstgroup").val() == "") {
              errorCount++;
              errorMsg += "- ไม่ได้ระบุกลุ่มสินค้าสำหรับเงื่อนไขโปรโมชั่น\n";


          }*/

        if ($('#txt_pro_price_total').val() <= 0) {
            errorCount++;
            errorMsg += "- ราคารวมขั้นต่ำของสินค้า ต้องมากกว่า 0 \n";

        }
        if (errorCount > 0) {
            warningAlert(errorMsg);
            e.preventDefault();
        }
    });

    $('#btnNextStep4').click(function (e) {

    });
    $("#btnNextStep5").click(function (e) {
        var isfixedcheck = false;
        if (document.getElementById('rdo_pro_type_id_1').checked == true) {
            isfixedcheck = true;
        }
        else if (document.getElementById('rdo_pro_type_id_2').checked == true) {
            isfixedcheck = true;
        }
        else if (document.getElementById('rdo_pro_type_id_3').checked == true) {
            isfixedcheck = true;
        }
        else if (document.getElementById('rdo_pro_type_id_4').checked == true) {
            isfixedcheck = true;
        }
        if (isfixedcheck == false) {
            e.preventDefault();
        }
        if (document.getElementById('rbl_pro_price_id_2').checked) {
            $('#btnNextStep6').hide();
            $('#btnNextStep6_Save').show();
        } else {
            $('#btnNextStep6').hide();
            $('#btnNextStep6_Save').show();
        }

    });
    $("#btnNextStep6").click(function (e) {
        var isfixedgive_type = false;
        var isfixedgive_product = false;
        var isfixedpro_discount = false;
        if (document.getElementById('rdo_pro_give_type_id_1').checked) {
            isfixedgive_type = true;
        }
        else if (document.getElementById('rdo_pro_give_type_id_2').checked) {
            isfixedgive_type = true;
        }
        else if (document.getElementById('rdo_pro_give_type_id_3').checked) {
            isfixedgive_type = true;
        }
        else if (document.getElementById('rdo_pro_give_type_id_4').checked) {
            isfixedgive_type = true;
        }
        var pro_give_product_same = document.getElementsByName('rbl_pro_give_product_same');
        for (var x = 0; x < pro_give_product_same.length; x++) {
            if (pro_give_product_same[x].checked) {
                isfixedgive_product = true;
            }
        }
        if (document.getElementById('rdo_pro_discount_id_1').checked) {
            isfixedpro_discount = true;
        }
        else if (document.getElementById('rdo_pro_discount_id_2').checked) {
            isfixedpro_discount = true;
        }
        if (isfixedgive_type == false || isfixedgive_product == false || isfixedpro_discount == false) {
            e.preventDefault();
        }
    });

    $("#btnImportCoupon").click(function (e) {
        if ($('#txt_coupon_code').val() == "") {
            warningAlert('กรุณาใส่ กลุ่มรหัสคูปอง');
            e.preventDefault();
        }
    });


}

function btnHide1() {
    $("#btnHide").click();
}

function btnHide2() {
    $("#btnHide").click();
    $("#Button2").click();
}

function btnHide3() {
    $("#Button1").click();
}

function OnChangeProgiveType() {
    var checkBox = document.getElementById("cb_pro_give_same_buy");
    alert(checkBox.checked);
    if (checkBox.checked) {

        var $select = $('#lst_search_pro_code_give').selectize();
        $select[0].selectize.clear();
        $('#div_search_give').hide();
    } else {
        $('#div_search_give').show();
    }
}

function SetMultiSelect() {
    $('[id*=lst_search_pro_code_give]').selectize({
        plugins: ['remove_button'],
        delimiter: ',',
        persist: false,
        create: function (input) {
            return {
                value: input,
                text: input
            }
        }
    });

    $('[id*=ddl_pro_brand]').selectize({
        plugins: ['remove_button'],
        delimiter: ',',
        persist: false,
        create: function (input) {
            return {
                value: input,
                text: input
            }
        }
    });

    $('[id*=ddl_pro_model]').selectize({
        plugins: ['remove_button'],
        delimiter: ',',
        persist: false,
        create: function (input) {
            return {
                value: input,
                text: input
            }
        }
    });

    $('[id*=ddl_pro_size]').selectize({
        plugins: ['remove_button'],
        delimiter: ',',
        persist: false,
        create: function (input) {
            return {
                value: input,
                text: input
            }
        }
    });

    $('[id*=ddl_pro_code]').selectize({
        plugins: ['remove_button'],
        delimiter: ',',
        persist: false,
        create: function (input) {
            return {
                value: input,
                text: input
            }
        }
    });
}

function clickFunction() {
    $(function () {
        $('#rdo_allow_muti_promotion_yes').click(function () {
            if ($(this).is(':checked')) {
                $("#divPromotion").show();
                document.getElementById('chkPromotionAll').checked = true;
                ClickCheckAll('chkPromotionAll', 'chkPromotionList');
            }
        });
        $('#rdo_allow_muti_promotion_no').click(function () {
            if ($(this).is(':checked')) {
                $("#divPromotion").hide();
                document.getElementById('chkPromotionAll').checked = false;
                ClickUncheckAll('chkPromotionList');
            }
        });
    });
}

function ClickCheckAll(CheckBoxID, CheckBoxListID) {
    var rows = document.getElementById(CheckBoxListID).getElementsByTagName("tbody")[0].getElementsByTagName("tr");
    var columns = document.getElementById(CheckBoxListID).getElementsByTagName("tbody")[0].getElementsByTagName("td");
    for (var x = 0; x < columns.length; x++) {
        if (document.getElementById(CheckBoxID).checked) {
            document.getElementById(CheckBoxListID + "_" + x).checked = true;
        } else {
            document.getElementById(CheckBoxListID + "_" + x).checked = false;
        }
    }
}

function ClickUncheckAll(CheckBoxListID) {
    var columns = document.getElementById(CheckBoxListID).getElementsByTagName("tbody")[0].getElementsByTagName("td");
    for (var x = 0; x < columns.length; x++) {
        document.getElementById(CheckBoxListID + "_" + x).checked = false;
    }
}