'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _get = function get(object, property, receiver) { if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var MessageModal = function (_IndexForm) {
    _inherits(MessageModal, _IndexForm);

    function MessageModal() {
        _classCallCheck(this, MessageModal);

        var _this = _possibleConstructorReturn(this, (MessageModal.__proto__ || Object.getPrototypeOf(MessageModal)).call(this));

        _this.new = $('#newsAll');
        _this.promotion = $('#promotionsAll');
        _this.docType = $('#DocType');
        _this.lblHeadName = $('#lblHeadName');
        return _this;
    }

    _createClass(MessageModal, [{
        key: 'init',
        value: function init() {
            var _this2 = this;

            var me = this;
            this.docType.val(0);
            this.new.click(function () {
                me.docType.val(1);
                me.dt.ajax.reload();
                me.lblHeadName.text("ข่าวสาร");
            });

            this.promotion.click(function () {
                me.docType.val(2);
                me.dt.ajax.reload();
                me.lblHeadName.text("โปรโมชั่น");
            });

            this.columns = [{
                "data": 'Id',
                "type": 'date-euro',
                "render": function render(data, type, row) {
                    if (type === 'display') {
                        return formatDate(row.StartDate) + ' - ' + formatDate(row.EndDate);
                    }
                    return data;
                }
            }, {
                "data": "Name",
                visible: false
            }, {
                "data": "StatusName",
                //visible: false
            }, { "data": "Content" }, {
                "data": "FileName",
                "className": "text-center",
                "orderable": false,
                "render": function render(data, type, row) {
                    if (type === 'display' && data) {
                        return '<a href="Javascript:openDocFull(\'' + (_this2.selectUrl + data) + '\')" class="edit" style="font-size: 5vh;"><i class="fa fa-file-pdf-o"></i></a>';
                    }
                    return 'ไม่พบไฟล์';
                }
            }];

            this.dtList = $('#message-modal-list');
            this.searching = true;
            _get(MessageModal.prototype.__proto__ || Object.getPrototypeOf(MessageModal.prototype), 'init', this).call(this);
        }
    }]);

    return MessageModal;
}(IndexForm);