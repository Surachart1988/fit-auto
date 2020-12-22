
class IndexForm {
    constructor() {
        this.dtList = null
        this.columns = null
        this.order = [[0, "desc"]]
        this.searching = false
        this.inputStartDateTime = $('.input-startdatetime')
        this.inputEndDateTime = $('.input-enddatetime')
        this.valueSearch = $('#ValueSearch')
        this.keySearch = $('#KeySearch')
        this.btnSearch = $('#btn_search')
        this.btnClear = $('#btn_clear')
        this.search = $('#searchForm')
        this.getUrl = null
        this.selectUrl = null
        this.tempTap = $('#temp_tab')
        this.historyTab = $('#history_tab')
        this.docClose = $('#DocClose')
    }

    init() {
        const me = this
        if (this.docClose)
            this.changeTapActive(this.docClose.val())

        this.createDatatable()
        this.initDateTimePicker()

        $('input').keypress((e) => {
            if (e.keyCode == 13) {
                me.dt.ajax.reload()
            }
        })

        this.btnSearch.click(() => {
            me.dt.ajax.reload()
        })

        this.btnClear.click(() => {
            me.inputStartDateTime.val(null)
            me.inputEndDateTime.val(null)
            me.valueSearch.val(null)
            me.keySearch.val(0)
            loading.start()
            me.dt.ajax.reload(() => loading.stop())
        })
    }

    initDateTimePicker() {
        const me = this

        if (this.inputStartDateTime && this.inputEndDateTime) return

        let dateTimePickerOptions = {
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

    createDatatable() {
        const me = this
        this.dt = this.dtList.DataTable(
            {
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
                    "data": function (data) {
                        let formValues = FormSerialize.getFormArray(me.search, data)
                        console.log(formValues)
                        return JSON.stringify(formValues);
                    },
                },
                "columns": me.columns,
                "createdRow": function (row, data, dataIndex) {
                    if (data["PaymentStatus"])
                        if (data["PaymentStatus"].indexOf("ยกเลิก") > -1) {
                            $(row).css('background-color', '#f2dede');
                        }
                        else if (data["PaymentStatus"].indexOf("จ่ายแล้ว") > -1) {
                            $(row).css('background-color', '#dff0d8');
                        }
                }
            })

        new $.fn.dataTable.FixedHeader(this.dt);
    }

    tapActive(history) {
        const me = this
        loading.start()
        this.docClose.val(history)
        this.changeTapActive(history);
        this.dt.ajax.reload(() => loading.stop())
    }

    changeTapActive(history) {
        if (history == true || history == 'True') {
            this.historyTab.addClass('active');
            this.tempTap.removeClass('active');
        }
        else {
            this.tempTap.addClass('active');
            this.historyTab.removeClass('active');
        }
    }
}