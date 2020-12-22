'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _get = function get(object, property, receiver) { if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var CampaignIndex = function (_IndexForm) {
    _inherits(CampaignIndex, _IndexForm);

    function CampaignIndex() {
        _classCallCheck(this, CampaignIndex);

        var _this = _possibleConstructorReturn(this, (CampaignIndex.__proto__ || Object.getPrototypeOf(CampaignIndex)).call(this));

        return _this;
    }

    _createClass(CampaignIndex, [{
        key: 'init',
        value: function init() {
            var _this2 = this;

            this.columns = [
                {
                    "data": "campaign_id"
                },
                {
                    "data": "campaign_name",
                },
                {
                    "data": "deleted",
                    "className": "text-center",
                    "render": function render(data, type, row) {
                                if (row.deleted === true) {
                                    return '<img src="Content/img/ICON/icon_cancel.png" style="width:20px;">';
                                }
                                if (row.deleted === false) {
                                    return '<img src="Content/img/ICON/icon_allow_true.png" style="width:20px;">';
                                }
                            }
                },
                {
                    "data": "campaign_id",
                    "className": "text-center",
                    "orderable": false,
                    "render": function render(data, type, row) {
                            return "<a href=\"" + _this2.editUrl + "?id=" + data + "\" >" +
                                "<img src='Content/img/ICON/edit.png' height='20' width='20' title='แก้ไข'></a>";
                        }
                },
                {
                    "data": "campaign_id",
                    "className": "text-center",
                    "orderable": false,
                    "render": function render(data, type, row) {
                        if (row.deleted === false) {
                            return "<a href='#' class='del' title='ลบ'><img src='Content/img/ICON/cancel_icon.png' height='20' width='20' title='ยกเลิก'></a>";
                        }
                        return ""
                        
                            //return "<a href='#' onclick=DeleteRow('" + data + "') class='remove'>" +
                            //        "<img src='Content/img/ICON/cancel_icon.png' height='20' width='20' title='ยกเลิก'></a > ";
                    }
                }
            ];

            this.dtList = $('#gv_campaign');
            this.order = [[0, "desc"]];
            _get(CampaignIndex.prototype.__proto__ || Object.getPrototypeOf(CampaignIndex.prototype), 'init', this).call(this);
        }
    }, {
        key: 'create',
        value: function create(url) {
            location.href = ''
        }
    }]);

    return CampaignIndex;
}(IndexForm);