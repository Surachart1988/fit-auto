'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _get = function get(object, property, receiver) { if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var MessagePage = function (_IndexForm) {
    _inherits(MessagePage, _IndexForm);

    function MessagePage() {
        _classCallCheck(this, MessagePage);

        var _this = _possibleConstructorReturn(this, (MessagePage.__proto__ || Object.getPrototypeOf(MessagePage)).call(this));

        _this.new = $('#new');
        _this.promotion = $('#promotion');
        _this.docType = $('#DocType');
        return _this;
    }

    _createClass(MessagePage, [{
        key: 'init',
        value: function init() {
            var _this2 = this;

            var me = this;
            if (this.docType.val() == 1) {
                me.new.addClass('active');
            } else if (this.docType.val() == 2) {
                me.promotion.addClass('active');
            }

            this.new.click(function () {
                me.promotion.removeClass('active');
                me.new.addClass('active');
                me.docType.val(1);
                me.dt.ajax.reload();
            });

            this.promotion.click(function () {
                me.new.removeClass('active');
                me.promotion.addClass('active');
                me.docType.val(2);
                me.dt.ajax.reload();
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
            }, { "data": "Name" }, { "data": "StatusName" }, {
                "data": "Id",
                "className": "text-center",
                "orderable": false,
                "render": function render(data, type, row) {
                    if (type === 'display') {
                        return '<a href="' + _this2.selectUrl + '?id=' + data + '" class="edit"><i class="fa fa-edit"></i></a>';
                    }
                    return data;
                }
            }];

            this.dtList = $('#message-list');
            this.searching = true;
            _get(MessagePage.prototype.__proto__ || Object.getPrototypeOf(MessagePage.prototype), 'init', this).call(this);
        }
    }, {
        key: 'create',
        value: function create(url) {
            location.href = url + "?docType=" + this.docType.val();
        }
    }]);

    return MessagePage;
}(IndexForm);