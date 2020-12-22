"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _get = function get(object, property, receiver) { if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var PaymentList = function (_IndexForm) {
    _inherits(PaymentList, _IndexForm);

    function PaymentList() {
        _classCallCheck(this, PaymentList);

        var _this = _possibleConstructorReturn(this, (PaymentList.__proto__ || Object.getPrototypeOf(PaymentList)).call(this));

        _this.editUrl = null;
        _this.deleteUrl = null;
        return _this;
    }

    _createClass(PaymentList, [{
        key: "init",
        value: function init() {
            var _this2 = this;

            this.columns = [{ "data": "Code" }, { "data": "Name" }, { "data": "ProgroupName" }, { "data": "CustypeName" }, {
                "data": "Baht",
                "render": function render(data, type, row) {
                    if (!data || data == 0) return row.Percents + ' %';
                    return data + ' บาท';
                }
            }, { "data": "RankNo" }, {
                "data": "Id",
                "className": "text-center",
                "orderable": false,
                "render": function render(data, type, row) {
                    if (type === 'display') {
                        return "<a href=\"" + _this2.editUrl + "?id=" + data + "\" class=\"edit\"><i class=\"fa fa-edit\"></i></a>|<a href=\"" + _this2.deleteUrl + "?id=" + data + "\" class=\"remove\"><i class=\"fa fa-trash\"></i></a>";
                    }
                    return data;
                }
            }];

            this.dtList = $('#extra-discount-list');
            this.searching = true;
            _get(PaymentList.prototype.__proto__ || Object.getPrototypeOf(PaymentList.prototype), "init", this).call(this);
        }
    }]);

    return PaymentList;
}(IndexForm);