//function ViewProitems(id) {
ViewProitems = (id) => {
    $.ajax({

        type: "GET",
        url: 'Promotion/GetProductitems',
        data: { id: id },
        beforeSend: function () {
            $("#loading").show();
        },
        success: function (data) {
            $("#loading").hide();
            $("#viewproitems_popup").html(data);
            $("#gv_viewpro").DataTable({
                "pageLength": 100
            });
            $('#modal-select-viewpro').modal('toggle');
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Failed to retrieve.');
            $("#loading").hide();
        }
    });
}

//function DeleteRow(id) {
DeleteRow = (id) => {
    confirmDelete("คุณต้องการที่จะยกเลิกโปรโมชั่นนี้หรือไม่?", function (event) {
        //console.log(event);
        if (!event) {
            $.ajax({
                type: 'POST',
                url: 'Promotion/Delete',//'@Url.Action("Delete")',
                data: { id: id },
                datatype: 'json',
                success: function (response) {
                    if (response.status) {
                        window.location.href = 'Promotion'; //'@Url.Action("Index")';
                    } else {
                        warningAlert(response.Message);
                    }
                },
                error: function (msg) {
                    alert(msg.responseText);
                }
            });
        }
    });
}

function initDatePicker() {
    var _startDate = new Date();
    var _endDate = new Date(_startDate.getTime());
    $('#StartDate').datepicker({
        autoclose: true,
        format: 'dd/mm/yyyy',
        orientation: 'bottom left',
        todayHighlight: true,
        disableTouchKeyboard: true
    }).on('changeDate', function (e) {
        _endDate = new Date(e.date.getTime());
        $('#EndDate').datepicker('setStartDate', _endDate);
    });
    $('#EndDate').datepicker({
        startDate: _endDate,
        autoclose: true,
        format: 'dd/mm/yyyy',
        orientation: 'bottom left',
        todayHighlight: true,
        disableTouchKeyboard: true
    });
};

$(document).ready(function () {
    $("table#gv_promotion").parent().css({
        "padding-left": "0px",
        "padding-right": "0px"
    });
    $("#gv_promotion_info").parent().css({
        "padding-left": "0px",
        "padding-right": "0px"
    });
    $("#gv_promotion_paginate").parent().css({
        "padding-left": "0px",
        "padding-right": "0px"
    });
});