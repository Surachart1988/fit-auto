'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var IndexForm = function () {
    function IndexForm() {
        _classCallCheck(this, IndexForm);

        this.dtList = null;
        this.columns = null;
        this.order = [[0, "desc"]];
        this.searching = false;
        this.inputStartDateTime = $('.input-startdatetime');
        this.inputEndDateTime = $('.input-enddatetime');
        this.valueSearch = $('#ValueSearch');
        this.keySearch = $('#KeySearch');
        this.btnSearch = $('#btn_search');
        this.btnClear = $('#btn_clear');
        this.search = $('#searchForm');
        this.searchMModal = $('#message-modal');
        this.getUrl = null;
        this.selectUrl = null;
        this.tempTap = $('#temp_tab');
        this.historyTab = $('#history_tab');
        this.docClose = $('#DocClose');
    }

    _createClass(IndexForm, [{
        key: 'init',
        value: function init() {
            var me = this;
            if (this.docClose) this.changeTapActive(this.docClose.val());

            this.createDatatable();
            this.initDateTimePicker();

            $('input').keypress(function (e) {
                if (e.keyCode == 13) {
                    me.dt.ajax.reload();
                }
            });

            this.btnSearch.click(function () {
                me.dt.ajax.reload();
            });
            this.searchMModal.on('hidden.bs.modal', function () {
                $('#message-modal-list').DataTable().search('');
            });
            this.btnClear.click(function () {
                me.inputStartDateTime.val(null);
                me.inputEndDateTime.val(null);
                me.valueSearch.val(null);
                me.keySearch.val(0);
                loading.start();
                me.dt.ajax.reload(function () {
                    return loading.stop();
                });
            });
        }
    }, {
        key: 'initDateTimePicker',
        value: function initDateTimePicker() {
            var me = this;

            if (this.inputStartDateTime && this.inputEndDateTime) return;

            var dateTimePickerOptions = {
                format: 'DD/MM/YYYY',
                locale: 'th',
                useCurrent: false
            };

            this.inputStartDateTime.datetimepicker(dateTimePickerOptions);
            this.inputEndDateTime.datetimepicker(dateTimePickerOptions);

            this.inputStartDateTime.on("dp.change", function (e) {
                me.inputEndDateTime.data("DateTimePicker").minDate(e.date);
            });
            this.inputEndDateTime.on("dp.change", function (e) {
                me.inputStartDateTime.data("DateTimePicker").maxDate(e.date);
            });
        }
    }, {
        key: 'createDatatable',
        value: function createDatatable() {
            var me = this;
            this.dt = this.dtList.DataTable({
                "bLengthChange": false,
                "pageLength": 20,
                "processing": true,
                "serverSide": true,
                "searching": me.searching,
                "order": me.order,
                "responsive": true,
                "ajax": {
                    "url": me.getUrl,
                    "type": "POST",
                    "contentType": 'application/json',
                    "data": function data(_data) {
                        var formValues = FormSerialize.getFormArray(me.search, _data);
                        return JSON.stringify(formValues);
                    }
                },
                "columns": me.columns,
                "createdRow": function createdRow(row, data, dataIndex) {
                    if (data["PaymentStatus"]) if (data["PaymentStatus"].indexOf("ยกเลิก") > -1) {
                        $(row).css('background-color', '#f2dede');
                    } else if (data["PaymentStatus"].indexOf("จ่ายแล้ว") > -1) {
                        $(row).css('background-color', '#dff0d8');
                    }
                }
            });

            new $.fn.dataTable.FixedHeader(this.dt);

            //this.dtList.on('click', 'a.del', function (e) {
            //    var obj = me.dt.row($(this).closest('tr')).data();
            //    confirmDelete("คุณต้องการที่จะยกเลิกข้อมูลนี้หรือไม่?", function (event) {
            //        //console.log(event);
            //        if (!event) {
            //            $.ajax({
            //                type: 'POST',
            //                url: me.delUrl,
            //                data: JSON.stringify({ 'model': obj }),

            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json",
            //                beforeSend: function beforeSend() {
            //                    $("#loading").show();
            //                },
            //                success: function success(result) {
            //                    if (result > 0) {
            //                        $("#loading").hide();
            //                        successAlert("ลบข้อมูลนี้สำเร็จ");
            //                        setTimeout(function () { window.location.href = me.indexUrl }, 1000);


            //                    }
            //                    else {
            //                        $("#loading").hide();
            //                        warningAlert("ไม่พบข้อมูล");
            //                    }
            //                },
            //                error: function (xhr, ajaxOptions, thrownError) {
            //                    $("#loading").hide();
            //                    warningAlert(thrownError);
            //                }
            //            });
            //        }
            //    });

            //});
        }
    }, {
        key: 'tapActive',
        value: function tapActive(history) {
            var me = this;
            loading.start();
            this.docClose.val(history);
            this.changeTapActive(history);
            this.dt.ajax.reload(function () {
                return loading.stop();
            });
        }
    }, {
        key: 'changeTapActive',
        value: function changeTapActive(history) {
            if (history == true || history == 'True') {
                this.historyTab.addClass('active');
                this.tempTap.removeClass('active');
            } else {
                this.tempTap.addClass('active');
                this.historyTab.removeClass('active');
            }
        }
    }]);

    return IndexForm;
}();