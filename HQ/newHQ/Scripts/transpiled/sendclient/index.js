'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var SendClientForm = function () {
    function SendClientForm() {
        _classCallCheck(this, SendClientForm);

        this.status = 'add';
        this.dt = $('#gv_clibranch');
        this.chkheader = $('#chkall');
        this.myForm = $('#myForm');
        this.id = null;
        this.clientUrl = null;
    }

    _createClass(SendClientForm, [{
        key: 'init',
        value: function init() {

            var me = this;
            this.chkheader.click(function () {
                var rows = me.dtClient.rows({ 'search': 'applied' }).nodes();
                
                $('input[type="checkbox"]', rows).prop('checked', this.checked);
                if (this.checked) {
                    me.dtClient.$('tr').addClass('selected');
                }
                else {
                    me.dtClient.$('tr').removeClass('selected');
                }
            });
            $('#gv_clibranch tbody').on('change', 'input[type="checkbox"]', function (e) {
                // If checkbox is not checked
                if (e.type === "change") {
                    if (!this.checked) {
                        var el = me.chkheader.get(0);
                        if (el && el.checked && ('indeterminate' in el)) {

                            el.indeterminate = true;
                        }
                    }
                }
                
            });
            $('#gv_clibranch tbody').on('click', 'tr', function (e) {
                //var $row = $(this),
                //    isSelected = $row.hasClass('selected')
                if ($(this).hasClass('selected')) {
                    $(this).toggleClass('selected')
                        .find(':checkbox').prop('checked', false);
                } else {
                    $(this).toggleClass('selected')
                        .find(':checkbox').prop('checked', true);
                }                
            });
            this.createClientDatatable();
        }
    }, {
            key: 'createClientDatatable',
            value: function createClientDatatable() {
                var me = this;
                this.dtClient = this.dt.DataTable({
                    "dom": '<"pull-left"f><"pull-right"l>tip',
                    columnDefs: [
                        {
                            orderable: false,
                            className: 'select-checkbox',
                            targets: 0
                        }
                    ],
                    select: {
                        style: 'os',
                        selector: 'td:first-child'
                    },
                    order: [
                        [1, 'asc']
                    ],
                    "language": {
                        "search": "ค้นหา :",            
                        "searchPlaceholder": "ชื่อสาขา"
                    },                    
                    "lengthChange": false,
                    "fnDrawCallback": function () {
                        $("input[type='search']").attr("id", "searchBox");
                        $('#searchBox').css("width", "800px").focus();
                    }
                });
                
                
            }
        }
    ]);

    return SendClientForm;
}();