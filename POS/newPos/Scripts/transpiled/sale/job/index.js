'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _get = function get(object, property, receiver) { if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var JobIndex = function (_IndexForm) {
    _inherits(JobIndex, _IndexForm);

    function JobIndex() {
        _classCallCheck(this, JobIndex);

        var _this = _possibleConstructorReturn(this, (JobIndex.__proto__ || Object.getPrototypeOf(JobIndex)).call(this));

        return _this;
    }

    _createClass(JobIndex, [{
        key: 'init',
        value: function init() {
            var _this2 = this;

            this.columns = [
                {
                    "data": "doc_no",
                    "render": function render(data, type, row) {
                        return "<a href=\"" + _this2.editUrl + "?id=" + row.doc_no + "&mode=v\" >" +
                            "<img src='Content/img/ICON/icdotg.gif' >&nbsp;" + row.doc_no + "</a>";
                    }
                },
                {
                    "data": "doc_date",
                    "className": "text-center"
                },
                {
                    "data": "cus_code"
                },
                {
                    "data": "cus_name"
                },
                {
                    "data": "car_reg",
                    "className": "text-center"
                },
                {
                    "data": "Qty",
                    "className": "text-center"
                },
                {
                    "data": "job_amt",
                    "className": "text-right",
                    "render": $.fn.dataTable.render.number(',', '.', 2)
                },
                {
                    "data": "doc_close",
                    "className": "text-center",
                    "render": function render(data, type, row) {
                        if (row.doc_close === "True") {
                            return "<img src='Content/img/ICON/check.gif' width='14' height='13'>";
                        } else {
                            return "<img src='Content/img/ICON/uncheck.gif' width='14' height='13'>";
                        }
                    }
                },
                {
                    "data": "doc_cancel",
                    "className": "text-center",
                    "render": function render(data, type, row) {
                        if (row.doc_cancel === "True") {
                            return "<span style='color: red;'>ยกเลิก</span>";
                        } else {
                            return "-";
                        }
                    }
                },
                {
                    "data": "doc_no",
                    "className": "text-center",
                    "orderable": false,
                    "render": function render(data, type, row) {
                        if (row.doc_cancel === "True" || row.doc_close === "True") {
                            return "-";
                        }
                        else {
                            return "<a href=\"" + _this2.editUrl + "?id=" + data + "\" >" +
                                "<img src='Content/img/ICON/edit.png' height='20' width='20' title='แก้ไข'></a>";
                        }
                    }
                },
                {
                    "data": "doc_no",
                    "className": "text-center",
                    "orderable": false,
                    "render": function render(data, type, row) {
                        if (row.doc_cancel !== "True" || row.doc_close !== "True") {
                            return "<a href=\"" + _this2.editUrl + "?id=" + data + "\" >" +
                                "<img src='Content/img/ICON/cancel_icon.png' height='20' width='20' title='ยกเลิก'></a > ";
                        }
                        else {
                            return "-";
                        }
                    }
                }
            ];

            this.dtList = $('#gv_job');
            //this.order = [[0, "asc"]];
            _get(JobIndex.prototype.__proto__ || Object.getPrototypeOf(JobIndex.prototype), 'init', this).call(this);
        }
    }, {
        key: 'create',
        value: function create(url) {
            location.href = ''
        }
    }]);

    return JobIndex;
}(IndexForm);