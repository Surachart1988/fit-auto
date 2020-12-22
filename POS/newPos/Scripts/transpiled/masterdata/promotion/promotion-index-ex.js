ProItems = (id) => {
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