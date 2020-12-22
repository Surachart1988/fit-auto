'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _get = function get(object, property, receiver) { if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var VendorIndex = function (_IndexForm) {
    _inherits(VendorIndex, _IndexForm);

    function VendorIndex() {
        _classCallCheck(this, VendorIndex);

        var _this = _possibleConstructorReturn(this, (VendorIndex.__proto__ || Object.getPrototypeOf(VendorIndex)).call(this));

        return _this;
    }

    _createClass(VendorIndex, [{
        key: 'init',
        value: function init() {
            var _this2 = this;

            this.columns = [
                {
                    "data": "ven_code",
                    "render": function render(data, type, row) {
                        return "<a href=\"" + _this2.editUrl + "?id=" + row.ven_code + "&mode=v\" >" + row.ven_code + "</a>";
                    }
                },
                {
                    "data": "ven_name",
                    "render": function render(data, type, row) {
                        return "<a href=\"" + _this2.editUrl + "?id=" + row.ven_code + "&mode=v\" >" + row.ven_name + "</a>";
                    }
                },
                {
                    "data": "add_tel",
                    "className": "text-center"
                },
                {
                    "data": "contact_name",
                },
                {
                    "data": "cancel_date",
                    "className": "text-center",
                    "render": function render(data, type, row) {
                        if (row.cancel_date != "" && row.cancel_date !== null) {
                            return '<img src="Content/img/ICON/icon_cancel.png" style="width:20px;">';
                        }
                        if (row.cancel_date === null || row.cancel_date == "") {
                            return '<img src="Content/img/ICON/icon_allow_true.png" style="width:20px;">';
                        }
                    }
                }
            ];

            this.dtList = $('#gv_vencode');
            this.order = [[0, "desc"]];
            _get(VendorIndex.prototype.__proto__ || Object.getPrototypeOf(VendorIndex.prototype), 'init', this).call(this);
        }
    }, {
        key: 'create',
        value: function create(url) {
            location.href = ''
        }
    }]);

    return VendorIndex;
}(IndexForm);