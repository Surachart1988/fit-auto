'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _get = function get(object, property, receiver) { if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var PromotionForm = function (_IndexForm) {
    _inherits(PromotionForm, _IndexForm);

    function PromotionForm() {
        _classCallCheck(this, PromotionForm);

        var _this = _possibleConstructorReturn(this, (PromotionForm.__proto__ || Object.getPrototypeOf(PromotionForm)).call(this));

        return _this;
    }

    _createClass(PromotionForm, [{
        key: 'init',
        value: function init() {
            var _this2 = this;

            this.columns = [
                {
                    "data": "pro_name",
                    "render": function render(data, type, row) {
                        return "<a href=\"" + _this2.viewDetail + "?id=" + row.pro_id + "&mode=v\" >" + row.pro_name + "</a>";
                    }
                },
                {
                    "data": "pro_id",
                    "className": "text-center",
                    "render": function render(data, type, row) {
                        return "<a href=\"" + _this2.viewCondition + "?id=" + row.pro_id + "&mode=c\" >เงื่อนไข</a>";
                    }
                },
                {
                    "data": "pro_start_date",
                    "className": "text-center"
                },
                {
                    "data": "pro_end_date",
                    "className": "text-center"
                },
                {
                    "data": "Status",// deleted = false = 0 = เปิดการใช้งาน, true = 1 = ปิดการใช้งาน
                    "className": "text-center",
                    "render": function render(data, type, row) {
                        if (row.deleted === true) {
                            return '<img src="Content/img/ICON/icon_cancel.png" style="width:20px;">';
                        }
                        if (row.check_expired === "No" && row.used_promotion === "No") {
                            return '<img src="Content/img/ICON/icon_not_uesd.png" style="width:20px;">';
                        }
                        if (row.check_expired === "No" && row.allow_promotion === true) {
                            return '<img src="Content/img/ICON/icon_allow_true.png" style="width:20px;">';
                        }
                        if (row.check_expired === "No" && row.allow_promotion === false) {
                            return '<img src="Content/img/ICON/icon_allow_false.png" style="width:20px;">';
                        }
                        if (row.check_expired === "Yes") {
                            return '<img src="Content/img/ICON/icon_expired.png" style="width:20px;">';
                        }
                        return data;
                    }
                },
                {
                    "data": "pro_id",
                    "className": "text-center",
                    "orderable": false,
                    "render": function render(data, type, row) {
                        return "<a onclick=ProItems('" + data + "')  style='cursor: pointer;'>" +
                            "<img src='Content/img/ICON/search.png' height='20' width='20' title='ดูสินค้า'></a>";
                        //return "<a href=\"view?id=" + row.pro_id + "\" ><img src='Content/img/ICON/search.png' height='20' width='20' title='ดูสินค้า'></a>";
                    }
                }
            ];

            this.dtList = $('#gv_promotion');
            this.order = [[2, "desc"]];
            _get(PromotionForm.prototype.__proto__ || Object.getPrototypeOf(PromotionForm.prototype), 'init', this).call(this);
        }
    }, {
        key: 'create',
        value: function create(url) {
            location.href = url + "?docType=" + this.docType.val();
        }
    }]);

    return PromotionForm;
}(IndexForm);