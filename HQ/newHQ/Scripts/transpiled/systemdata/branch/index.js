'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _get = function get(object, property, receiver) { if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var BranchIndex = function (_IndexForm) {
    _inherits(BranchIndex, _IndexForm);

    function BranchIndex() {
        _classCallCheck(this, BranchIndex);

        var _this = _possibleConstructorReturn(this, (BranchIndex.__proto__ || Object.getPrototypeOf(BranchIndex)).call(this));

        return _this;
    }

    _createClass(BranchIndex, [{
        key: 'init',
        value: function init() {
            var _this2 = this;

            this.columns = [
                {
                    "data": "dealercode",
                    "render": function render(data, type, row) {
                        return "<a href=\"" + _this2.editUrl + "?id=" + row.doc_no_run + "&mode=v\" >" + row.dealercode + "</a>";
                    }
                },
                {
                    "data": "plant_no"
                },
                {
                    "data": "branch_name",
                    "render": function render(data, type, row) {
                        return "<a title=\"" + row.branch_name + "\" href=\"" + _this2.editUrl + "?id=" + row.doc_no_run + "&mode=v\" >" + (row.branch_name.length > 50 ? row.branch_name.substring(0, 45) : row.branch_name) + "</a>";
                    }
                },
                {
                    "data": "add_province",
                    "className": "text-center"
                },
                {
                    "data": "add_tel",
                    "className": "text-center"
                },
                {
                    "data": "sold_to",
                    "className": "text-center"
                },
                {
                    "data": "ship_to",
                    "className": "text-center"
                },
                {
                    "data": "doc_no_run",
                    "className": "text-center",
                    "orderable": false,
                    "render": function render(data, type, row) {
                        if (row.flag_hq === "True") {
                            return "<span style='color: #2E92CF;'>-</span>";
                        } else {
                            return "<a href=\"" + _this2.settingUrl + "?id=" + data + "\" style='cursor: pointer;'>" +
                                "<img src='Content/img/ICON/icon_setting.gif' height='20' width='20' title='แก้ไข'></a>";
                        }
                    }
                },
                {
                    "data": "doc_no_run",
                    "className": "text-center",
                    "orderable": false,
                    "render": function render(data, type, row) {
                        return "<a href=\"" + _this2.editUrl + "?id=" + data + "\" >" +
                            "<img src='Content/img/ICON/edit.png' height='20' width='20' title='แก้ไข'></a>";
                    }
                }
            ];

            this.dtList = $('#gv_branch');
            this.order = [[0, "asc"]];
            _get(BranchIndex.prototype.__proto__ || Object.getPrototypeOf(BranchIndex.prototype), 'init', this).call(this);
        }
    }, {
        key: 'create',
        value: function create(url) {
            location.href = ''
        }
    }]);

    return BranchIndex;
}(IndexForm);