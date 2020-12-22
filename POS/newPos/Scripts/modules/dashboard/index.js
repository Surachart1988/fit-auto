class DashboardForm {
    constructor() {
        this.getNotificationsUrl = null
        this.getSearchListUrl = null
        this.getSearchListHqUrl = null
        this.CheckCustomerCarDataUrl = null
        this.dots = $('.dots')
        this.btnSearchModal = $('#btn-search-modal')
        this.txtSearchModal = $('#txt-search-modal')
        this.searchModal = $('#search-modal')
        this.dtSearchList = $('#search-list')
        this.searchForm = $('#search-modal-form')
        this.txtValueSearch = $('#ValueSearch')
        this.ddKeySearch = $('#KeySearch')
        this.clientUrl = null
        this.hqUrl = null
        this.addDiscountUrl = null
        this.deleteDiscountUrl = null
    }

    init() {
        const me = this
        this.clientUrl = $('#client-url').val()
        this.hqUrl = $('#hq-url').val()
        var bar = new Morris.Bar({
            element: 'bar-chart',
            resize: true,
            data: [
                { y: '', a: 0 },
                { y: 'item A', a: 100 },
                { y: 'item B', a: 75 },
                { y: 'item C', a: 50 },
                { y: 'item E', a: 75 },
                { y: 'item F', a: 50 },
                { y: 'item G', a: 75 },
                { y: 'item H', a: 100 },
            ],
            barColors: ['#363167'],
            xkey: 'y',
            xLabelAngle: 70,
            ykeys: ['a'],
            labels: ['items'],
            hideHover: 'false'
        });
        this.reload()
        this.setMarks()

        this.searchForm.on('keyup keypress', function (e) {
            var keyCode = e.keyCode || e.which;
            if (keyCode === 13) {
                e.preventDefault();
                return false;
            }
        });

        this.btnSearchModal.click(() => {
            me.openSearchModel()
        })

        this.txtValueSearch.keydown((e) => {
            me.searchVehicleCustomer()
        })

        this.ddKeySearch.change(() => {
            me.searchVehicleCustomer()
        })

        this.txtSearchModal.keydown((e) => {
            var code = e.keyCode || e.which;
            if (code == 13) { //Enter keycode
                me.openSearchModel()
            }
        })

        this.searchModal.on('shown.bs.modal', function () {
            me.dt.ajax.reload()
        })

        this.createDatatable()
        $('.btn-group-2').hide()
        $('#btn-group-1').show()
    }

    searchVehicleCustomer() {
        const me = this
        clearTimeout($.data(me, 'timer'));
        var wait = setTimeout(() => me.dt.ajax.reload(
            function (json) {
                if (json) console.log(json)
                if ($('#search-list tbody tr')[0].innerText != 'ไม่พบข้อมูลที่ค้นหา' && $('#search-list tbody tr').length == 1)
                    $('#search-list tbody tr').click()
            }
        ), 500);
        $(this).data('timer', wait);
    }

    openSearchModel() {
        const me = this
        this.txtValueSearch.val(this.txtSearchModal.val())
        this.searchModal.modal()
    }

    reload() {
        const me = this
        setTimeout(function () {
            $.get(me.getNotificationsUrl,
                function (data) {
                    if (data.Code == "00") {
                        me.setMarks(data.Data)
                    }
                    me.reload()
                })
        }, 10000)
    }

    setMarks(data) {
        this.dots.each(function (index, dot) {
            if (dot.id) {
                let mark = $(`#${dot.id} mark`)
                let lable = $(`#${dot.id} label`)

                if (data) {
                    for (let i = 0; i < data.length; i++) {
                        if (data[i].Name === lable[0].innerHTML.replace(/\s/g, '')) {
                            if (mark[0].innerHTML == data[i].Value) return

                            mark[0].innerHTML = data[i].Value
                            mark.css("-webkit-animation-name", "bounce");
                            mark.css("animation-name", "bounce");

                            setTimeout(function () {
                                mark.css("-webkit-animation-name", "");
                                mark.css("animation-name", "");
                            }, 2000)
                        }
                    }
                }

                if (mark && mark[0].innerHTML <= 0) mark[0].hidden = true;
            }
        })
    }

    createDatatable() {
        const me = this
        this.dt = this.dtSearchList.DataTable(
            {
                "bLengthChange": false,
                "pageLength": 20,
                "processing": true,
                "serverSide": true,
                "searching": false,
                "scrollX": true,
                "scrollY": "44vh",
                "scrollCollapse": true,
                "ajax": {
                    "url": me.getSearchListHqUrl,
                    "type": "POST",
                    "contentType": 'application/json',
                    "data": function (data) {
                        let formValues = FormSerialize.getFormArray(me.searchForm, data)
                        $('.btn-group-2').hide()
                        $('#btn-group-1').show()
                        return JSON.stringify(formValues);
                    },
                    error: function (jqXHR, exception) {
                        setTimeout(()=>
                        //confirmAlert('ไม่สามารถเชื่อมต่อ HQ ได้ ต้องการค้นหาบน POS หรือไม่', (event) => {
                        //    if (!event)
                                me.dt.ajax.url(me.getSearchListUrl).load()
                            //else
                            //    me.dt.ajax.reload()
                       // })
                        , 3000)
                    },
                    timeout: 10000
                },
                "errMode": 'none',
                "columns": [
                    { "data": 'TypeName' },
                    { "data": 'License' },
                    { "data": "VehicleProvince" },
                    { "data": "CustomerCode" },
                    { "data": "CustomerName" },
                    { "data": "Brand" },
                    { "data": "Generation" },
                    { "data": "Color" },
                    { "data": "LastMileage" },
                    { "data": "BlueCard" },
                    { "data": "Tel" },
                    {
                        "data": "LastContdate"
                    },
                ]
            })

        $('#KeySearch').change(() => {
            var column = me.dt.column(9);
            if ($('#KeySearch').val() == '1') {
                column.visible(false);
            }
            else {
                column.visible(true);
            }
        })

        $('#search-list tbody').on('click', 'tr', function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
                $('.btn-group-2').hide()
                $('#btn-group-1').show()
            }
            else {
                me.dt.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                $('.btn-group-2').show()
                $('#btn-group-1').hide()

                let row = me.dt.row('.selected').data()
                if (row.License) {
                    $('#btn-next-service').show()
                    $('#btn-vehicle').show()
                }
                else {
                    $('#btn-next-service').hide()
                    $('#btn-vehicle').hide()
                }
            }
        })

        $('#btn-profile').click(function () {
            let row = me.dt.row('.selected').data()
            openDocPrint(`${me.clientUrl}/qr_03_customer.asp?encoder=1&cus_code=${row.CustomerCode}&menu=qr&act=view`)
        })

        $('#btn-vehicle').click(function () {
            let row = me.dt.row('.selected').data()
            if (row.License) {
                openDocPrint(`${me.clientUrl}/qr_03_custcar.asp?encoder=1&car_provid=${row.VehicleProvinceId}&car_reg=${row.License}&menu=qr&act=view&cus_code=${row.CustomerCode}`)
            }
            else {
                openDocPrint(`${me.clientUrl}/qr_02_custcar.asp?cus_code=${row.CustomerCode}`)
            }
        })

        $('#btn-used-history').click(function () {
            let row = me.dt.row('.selected').data()
            if (row.License) {
                openDocPrint(`${me.clientUrl}/qr_03_services.asp?encoder=1&car_provid=${row.VehicleProvinceId}&car_reg=${row.License}`)
            }
            else {
                openDocPrint(`${me.clientUrl}/qr_02_services.asp?cus_code=${row.CustomerCode}`)
            }
        })

        $('#btn-money-history').click(function () {
            let row = me.dt.row('.selected').data()
            if (row.License) {
                openDocPrint(`${me.clientUrl}/qr_03_finance.asp?encoder=1&car_provid=${row.VehicleProvinceId}&car_reg=${row.License}&cus_code=${row.CustomerCode}`)
            }
            else {
                openDocPrint(`${me.clientUrl}/qr_02_finance.asp?cus_code=${row.CustomerCode}`)
            }
        })

        $('#btn-product').click(function () {
            let row = me.dt.row('.selected').data()
            if (row.License) {
                openDocPrint(`${me.clientUrl}/qr_03_product.asp?encoder=1&car_provid=${row.VehicleProvinceId}&car_reg=${row.License}`)
            }
            else {
                openDocPrint(`${me.clientUrl}/qr_02_product.asp?cus_code=${row.CustomerCode}`)
            }
        })

        $('#btn-next-service').click(function () {
            let row = me.dt.row('.selected').data()
            openDocPrint(`${me.clientUrl}/qr_03_next_services.asp?encoder=1&car_provid=${row.VehicleProvinceId}&car_reg=${row.License}`)
        })

        $('#btn-new-sale-quote').click(function () {
            let row = me.dt.row('.selected').data()
            $.get(me.CheckCustomerCarDataUrl, row, function (resp) {
                if (resp.Code == "00") {
                    if (row.License) {
                        $.redirect('./Home/ClassicAsp?AspFile=rt_pr_new.asp',
                            {
                                AspFile: `rt_pr_new.asp?encoder=1&cus_code=${row.CustomerCode}&car_reg=${row.License}&car_chasis=${row.Chassis}`,
                            })
                    }
                    else {
                        $.redirect('./Home/ClassicAsp?AspFile=rt_pr_new.asp',
                            {
                                AspFile: `rt_pr_new.asp?encoder=1&cus_code=${row.CustomerCode}`,
                            })
                    }
                }
                console.error(resp.Message)
            })
        })

        $('#btn-new-deposit').click(function () {
            let row = me.dt.row('.selected').data()
            $.get(me.CheckCustomerCarDataUrl, row, function (resp) {
                if (resp.Code == "00") {
                    $.redirect('./Home/ClassicAsp?AspFile=rt_dp_new.asp',
                        {
                            AspFile: `rt_dp_new.asp?cus_code=${row.CustomerCode}`,
                        })
                }
                console.error(resp.Message)
            })
        })

        $('#btn-new-sale-order').click(function () {
            let row = me.dt.row('.selected').data()
            $.get(me.CheckCustomerCarDataUrl, row, function (resp) {
                if (resp.Code == "00") {
                    if (row.License) {
                        $.redirect('./Home/ClassicAsp?AspFile=startjob_rt_new.asp',
                            {
                                AspFile: `startjob_rt_new.asp?encoder=1&cus_code=${row.CustomerCode}&car_reg=${row.License}&car_chasis=${row.Chassis}`,
                            })
                    }
                    else {
                        $.redirect('./Home/ClassicAsp?AspFile=rt_pr_new.asp',
                            {
                                AspFile: `startjob_rt_new.asp?encoder=1&cus_code=${row.CustomerCode}`,
                            })
                    }
                }
                console.error(resp.Message)
            })
        })

        $('#btn-new-customer-car').click(function () {
            let row = me.dt.row('.selected').data()
            let branchNo = $('#branch-no').val()
            let userId = $('#user-id').val()
            let dealerCode = $('#dealer-code').val()
            openDocFull(`${me.clientUrl}/bs_cust_new_client.asp?status_add=AddCus&branch_no=${branchNo}&act=add&user_id=${userId}&dealercode=${dealerCode}&page_back=close`)
        })

        $('#btn-new-customer').click(function () {
            let row = me.dt.row('.selected').data()
            let branchNo = $('#branch-no').val()
            let userId = $('#user-id').val()
            let dealerCode = $('#dealer-code').val()
            openDocFull(`${me.clientUrl}/bs_cust_new_client.asp?&branch_no=${branchNo}&act=add&user_id=${userId}&dealercode=${dealerCode}&page_back=close`)
        })

        $('#btn-new-car').click(function () {
            let row = me.dt.row('.selected').data()
            let branchNo = $('#branch-no').val()
            let userId = $('#user-id').val()
            let dealerCode = $('#dealer-code').val()

            $.get(me.CheckCustomerCarDataUrl, row, function (resp) {
                if (resp.Code == "00")
                    openDocFull(`${me.clientUrl}/bs_custcar_client.asp?cus_code=${row.CustomerCode}&user_id=${userId}&dealercode=${dealerCode}&act=add&page_back=close`)
                else console.error(resp.Message)
            })
        })
    }
}