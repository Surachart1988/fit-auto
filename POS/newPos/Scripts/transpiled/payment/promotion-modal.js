'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var PromotionModal = function () {
    function PromotionModal() {
        _classCallCheck(this, PromotionModal);

        this.modalName = "เช็คโปรโมชั่น";
        this.dtPromotionElem = $('#promotion-list');
        this.dtProductList = $('#product-list');
        this.dtPromotionGiveElem = $('#promotion-give-list');
        this.modal = $('#checkPromotionModal');
        this.btnPromotionConfirm = $('#btnPromotionConfirm');
        this.promotionList = $('#promotionList');
        this.promotionDetails = $('#promotionDetails');
        this.promotionName = $('#promotionName');
        this.promotionDetailsName = $('#promotionDetailsName');
        this.txtTotalAmount = $('#TotalAmount');
        this.txtTotalNumber = $('#TotalNumber');
        this.txtExtraDiscount = $('#txtExtraDiscount');
        this.TmpRowRedraw = 0;
        this.hidDocNo = $('#DocNo');
        this.hidDocCode = $('#DocCode');
        this.hidRefDocNo = $('#RefDocNo');
        this.txtBalance = $('#txtBalance');
        this.giveData = [];

        this.rowData = [];
        this.getUrl = null;
        this.addGiveUrl = null;
        this.checkPromotionGiveUrl = null;
        this.getCheckCouponUrl = null;
        this.addDiscountUrl = null;
        this.indexForm = null;
        this.pageDetailsNo = 0;
    }

    _createClass(PromotionModal, [{
        key: 'init',
        value: function init() {
            var me = this;

            this.modal.on('shown.bs.modal', function () {

                !me.dtPromotionList && me.createPromotionDatatable();
                me.dtPromotionList.columns.adjust().draw();
            });

            this.modal.on('hidden.bs.modal', function () {

            });

            this.promotionDetails.hide();

            this.btnPromotionConfirm.click(function () {
                var CountProductListRow = me.dtProductList.length;
                //debugger
                //  me.createPromotionDatatable();
                var rows = me.dtPromotionList.rows('.selected').data();
                var model = [];
                for (var i = 0; i < rows.length; i++) {

                    var row = rows[i];

                    var CashReceive = +$('#txtPaymentMoney').val();

                    if (row.ProductGiveCode) {
                        model.push(
                            {
                                Name: row.Name + " : " + row.ProductGiveName,
                                Code: row.ProductGiveCode,//+ "," + row.Code,
                                DocNo: me.hidDocNo.val(),
                                DocCode: me.hidDocCode.val(),
                                ReferenceNo: me.hidRefDocNo.val(),
                                Money: (row.give_same_buy === "False" && row.PromotionType === "3") ? row.Money : -row.Money,
                                Number: row.Number,
                                Product_Ref_Code: row.Product_Ref_Code,
                                PromotionType: row.PromotionType,
                                give_same_buy: row.give_same_buy,

                                tmp_No: row.No,
                                tmp_Code: row.Code,
                                tmp_Name: row.Name,
                                tmp_Type: row.Type,
                                tmp_ProductDetail: row.ProductDetail,
                                tmp_ProductGiveName: row.ProductGiveName,
                                tmp_Number: row.Number,
                                tmp_Money: row.Money,
                                tmp_ProductGiveCode: row.ProductGiveCode,
                                tmp_PromotionType: row.PromotionType,
                                tmp_Discount: row.Discount,
                                tmp_CouponId: "",
                                tmp_CouponCode: "",
                                tmp_CouponCalType: "",
                                tmp_Product_Ref_Code: row.Product_Ref_Code,
                                tmp_give_same_buy: row.give_same_buy
                            }
                        );
                        //me.addPromotionGive(row.Name, -row.Money, row.ProductGiveCode + "," + row.Code, row.Number, row.ProductGiveName, row.Product_Ref_Code, row.PromotionType, row.give_same_buy);
                    }
                    else if (row.Discount) {
                        model.push(
                            {
                                Name: row.Name + " : " + row.ProductGiveName,
                                Code: row.Code,
                                DocNo: me.hidDocNo.val(),
                                DocCode: me.hidDocCode.val(),
                                ReferenceNo: me.hidRefDocNo.val(),
                                Money: row.Money,//(row.give_same_buy === "False" && row.PromotionType === "3") ? row.Money : -row.Money,
                                Number: row.Number,
                                Product_Ref_Code: row.Product_Ref_Code,
                                PromotionType: row.PromotionType,
                                give_same_buy: row.give_same_buy,

                                tmp_No: row.No,
                                tmp_Code: row.Code,
                                tmp_Name: row.Name,
                                tmp_Type: row.Type,
                                tmp_ProductDetail: row.ProductDetail,
                                tmp_ProductGiveName: row.ProductGiveName,
                                tmp_Number: row.Number,
                                tmp_Money: row.Money,
                                tmp_ProductGiveCode: row.ProductGiveCode,
                                tmp_PromotionType: row.PromotionType,
                                tmp_Discount: row.Discount,
                                tmp_CouponId: "",
                                tmp_CouponCode: "",
                                tmp_CouponCalType: "",
                                tmp_Product_Ref_Code: row.Product_Ref_Code,
                                tmp_give_same_buy: row.give_same_buy
                            }
                        );
                        //me.addPromotionGive(row.Name, -row.Money, row.Code, row.Number, row.ProductGiveName, row.Product_Ref_Code, row.PromotionType, row.give_same_buy);
                    }
                    else if (row.CouponId) {


                        // CalCouponType = 1 ส่วนลด (%), 2 = ส่วนลด (บาท)
                        if (row.CouponCalType == "1") {
                            var Monney = CashReceive * (+row.Money / 100);
                            me.addPromotionGive(row.Name, -Monney, row.CouponId, row.Number, row.ProductGiveName, row.Product_Ref_Code, row.PromotionType, '');


                        } else if (row.CouponCalType == "2") {
                            me.addPromotionGive(row.Name, -row.Money, row.CouponId, row.Number, row.ProductGiveName, row.Product_Ref_Code, row.PromotionType, '');

                        }

                    }
                    //me.addPromotionDiscount(row.Name, +row.Discount * +row.Number, row.Code, row.Id);
                }
                if (model.length > 0) {
                    //var PromotionAndDiscountModals = {
                    //    model: list
                    //}
                    var tmpmodel = model;
                    model = JSON.stringify({ 'model': model });
                    $.ajax({
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        type: 'POST',
                        url: me.checkPromotionGiveUrl,
                        data: model,
                        beforeSend: function beforeSend() {
                            $('#loaderDiv').show();
                        },
                        success: function success(item) {
                            $('#loaderDiv').hide();

                            switch (item.result) {
                                case 0: me.addPromotionGive(tmpmodel);
                                    break;
                                case 1: warningAlert("โปรโมชั่น " + item.detail.Name + " จำนวนของแถมไม่พอ");
                                    break;
                                case 2: warningAlert("โปรโมชั่น " + item.detail.Name + " ไม่สามารถใช้ร่วมกับโปรโมชั่นอื่นได้");
                                    break;
                            }
                        }

                    });

                }
                //  var child = this.dtPromotionList.row('tr.selected').child;
                // child.hide();
                //  me.dtPromotionList.row('tr.selected').child.hide();
                //me.dtPromotionList.rows('.selected').remove().draw();
            });

        }
    }, {
        key: 'createPromotionDatatable',
        value: function createPromotionDatatable() {
            var me = this;
            this.dtPromotionList = this.dtPromotionElem.DataTable({
                select: {
                    style: 'multi'
                },
                "scrollY": "40vh",
                'columns': [
                    { data: "No", "className": "text-center" },
                    { data: "Code", "className": "text-center", visible: false },
                    { data: "Type", "className": "text-left", visible: false },
                    { data: "Name", visible: false },
                    { data: "ProductDetail", "className": "text-left" },
                    { data: "ProductGiveName" },
                    { data: "Number", "className": "text-center", render: $.fn.dataTable.render.number(',', '.', 0) },
                    { data: "Money", "className": "text-right", "render": $.fn.dataTable.render.number(',', '.', 2), visible: false },
                    { data: "ProductGiveCode", visible: false },
                    { data: "PromotionType", visible: false },
                    { data: "Discount", visible: false },
                    { data: "CouponId", visible: false },
                    { data: "CouponCode", visible: false },
                    { data: "CouponCalType", visible: false },
                    { data: "Product_Ref_Code", visible: false },
                    { data: "give_same_buy", visible: false }
                ]
            });

            $('#promotion-list tbody').on('click', 'tr', function (e) {



                if ($(this).hasClass('selected')) {
                    //me.dt.$('tr.selected').removeClass('selected');
                    $(this).removeClass('selected');
                } else {
                    var row = me.dtPromotionList.rows(this).data();
                    if (row[0].PromotionType == "4") {
                        $(this).addClass('selected');
                        $('#CouponId').val(row[0].CouponId);
                        $('#CheckCoupon').val("False");

                        $('#CouponModal').modal('show');

                    } else {
                        $(this).addClass('selected');
                    }
                }
            });
            $('#CouponCode1').keyup(function (e) {
                if ($(this).val().length > 0) {
                    if (e.keyCode === 13) {
                        $('#btnCheckCoupon').click();
                    }
                    $('#btnCheckCoupon').prop("disabled", false);
                } else {
                    $('#btnCheckCoupon').prop("disabled", true);
                }
            });

            $('#btnCheckCoupon1').on("click", function () {


                var _data = { CouponId: $('#CouponId').val(), CouponCode: $('#CouponCode').val() };
                var _url = me.getCheckCouponUrl;

                $.ajax({
                    type: "GET",
                    url: _url,
                    data: _data,
                    beforeSend: function beforeSend() {
                        $('#loaderDiv').show();
                    },
                    success: function success(result) {
                        $('#loaderDiv').hide();
                        if (result.Coupon == "False") {
                            warningAlert("ไม่สามารถเชื่อมต่อ HQ ได้");
                            $('#CouponCode').val("");

                        } else if (result.Coupon == "1") {
                            warningAlert("รหัสคูปองไม่ถูกต้อง");
                            $('#CouponCode').val("");
                        }
                        else if (result.Coupon == "2") {
                            warningAlert("คูปองนี้ หมดอายุแล้ว");
                            $('#CouponCode').val("");
                        } else if (result.Coupon == "3") {
                            warningAlert("คูปองนี้ ครบจำนวนแล้ว");
                            $('#CouponCode').val("");
                        } else if (result.Coupon == "true") {
                            $('#CheckCoupon').val("True");
                            $('#CouponModal').modal('hide');
                        }

                    }
                });
            });
            $('#CouponModal1').on('shown.bs.modal', function () {
                $('#CouponCode').val("");
                $('#CouponCode').focus();
                $('#CouponCode').click();

            });
            $('#CouponModal1').on('hidden.bs.modal', function () {
                if ($('#CheckCoupon').val() == "False") {
                    var CouponId = $('#CouponId').val();
                    $('#promotion-list tbody').find("." + CouponId).removeClass('selected');
                }
            });
        }
    }, {
        key: 'addPromotionDiscount',
        value: function addPromotionDiscount(name, money, pmCode, id) {
            var me = this;

            $.get(me.addDiscountUrl, {
                name: name,
                DocNo: me.hidDocNo.val(),
                DocCode: me.hidDocCode.val(),
                ReferenceNo: me.hidRefDocNo.val(),
                Money: money,
                ProductGiveCode: pmCode,
                Id: id
            }).done(function (resp) {
                if (!resp.Data) {
                    alert(resp.Data);
                    return;
                }
                money = money > +me.txtBalance.val() ? +me.txtBalance.val() : money;
                me.indexForm.processDiscount(money);
                me.modal.modal('toggle');
            });
        }
    }, {
        key: 'addPromotionGive',
        value: function addPromotionGive(model) {
            var me = this;

            model = JSON.stringify({ 'model': model });

            $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: me.addGiveUrl,
                data: model,
                success: function (data) {
                    me.indexForm.dtProducts.clear();
                    var numberConstructor = 0;
                    $.each(data, function (index, item) {
                        //resultDiv.append($('<li/>', { text: item.name }));
                        item.Money = item.Money > +me.txtBalance.val() ? +me.txtBalance.val() : item.Money;
                        //$("#product-list > tbody > tr ").eq(0).after(
                        //    "<tr><td>" + name + "</td><td class=' text-center'>" + number + "</td><td class='text-right-modify'>" + money + "</td><td class=' text-center-modify'>" + (number * money) + "</td><td class='text-center'><a href='#' class='remove  text-center'><i class='fa fa-trash'></i></a></td></tr>");
                        var number;
                        if (item.Id != null) {
                            number = item.Id + (item.give_same_buy === false && item.PromotionType === "3" ? ",free" : "");
                        }
                        me.indexForm.dtProducts.row.add({
                            'name': item.Name,
                            'number': item.Number,
                            'money': item.Money,
                            'sum_money': (item.Number * item.Money),

                            'id': number,

                            'tmp_No': item.tmp_No,
                            'tmp_Code': item.tmp_Code,
                            'tmp_Name': item.tmp_Name,
                            'tmp_Type': item.tmp_Type,
                            'tmp_ProductDetail': item.tmp_ProductDetail,
                            'tmp_ProductGiveName': item.tmp_ProductGiveName,
                            'tmp_Number': item.tmp_Number,
                            'tmp_Money': item.tmp_Money,
                            'tmp_ProductGiveCode': item.tmp_ProductGiveCode,
                            'tmp_PromotionType': item.tmp_PromotionType,
                            'tmp_Discount': item.tmp_Discount,
                            'tmp_CouponId': item.tmp_CouponId,
                            'tmp_CouponCode': item.tmp_CouponCode,
                            'tmp_CouponCalType': item.tmp_CouponCalType,
                            'tmp_Product_Ref_Code': item.tmp_Product_Ref_Code,
                            'tmp_give_same_buy': item.tmp_give_same_buy
                        }, 1).draw();

                        me.dtPromotionList.rows('.selected').remove().draw();

                        item.Money = (item.Money * item.Number);
                        if (item.PromotionType === '1' || item.PromotionType === '2') {
                            me.txtExtraDiscount.val(+me.txtExtraDiscount.val() + (+item.Money * -1));
                        }
                        if (item.give_same_buy === false && item.PromotionType === "3") {
                            me.txtTotalAmount.val(me.indexForm.RoundUnit((+me.txtTotalAmount.val() + (+item.Money))));
                        }
                        if (item.give_same_buy === true && item.PromotionType === "3") {
                            if (Math.sign(item.Money) === -1) {
                                me.txtExtraDiscount.val(+me.txtExtraDiscount.val() + (+item.Money * -1));
                            }
                            else {
                                me.txtTotalAmount.val(me.indexForm.RoundUnit((+me.txtTotalAmount.val() + (+item.Money))));
                            }
                        }
                        numberConstructor += item.Number;
                    });
                    me.txtTotalNumber.val(+numberConstructor);

                    me.indexForm.setTotal();

                    me.modal.modal('hide');
                },
                failure: function (response) {
                    $('#result').html(response);
                }
            });

        }
        /*value: function addPromotionGive(name, money, code, number, product_give_name, product_Ref_Code, promotionType, give_same_buy) {
            var me = this;
            //  money = (money * number);
            if (give_same_buy === "False" && promotionType === "3") {
                money = (money * -1)
            }
            name = name + " : " + product_give_name;
            $.get(me.addGiveUrl, {
                name: name,
                Code: code,
                DocNo: me.hidDocNo.val(),
                DocCode: me.hidDocCode.val(),
                ReferenceNo: me.hidRefDocNo.val(),
                Money: money,
                Number: number,
                Product_Ref_Code: product_Ref_Code,
                PromotionType: promotionType

            }).done(function (resp) {
                if (!resp.Data) {
                    alert(resp.Massage);
                    return;
                }

                money = money > +me.txtBalance.val() ? +me.txtBalance.val() : money;
                //$("#product-list > tbody > tr ").eq(0).after(
                //    "<tr><td>" + name + "</td><td class=' text-center'>" + number + "</td><td class='text-right-modify'>" + money + "</td><td class=' text-center-modify'>" + (number * money) + "</td><td class='text-center'><a href='#' class='remove  text-center'><i class='fa fa-trash'></i></a></td></tr>");
                me.indexForm.dtProducts.row.add({
                    'name': name,
                    'number': number,
                    'money': money,
                    'sum_money': (number * money),
                    'id': resp.Data + (give_same_buy === "False" && promotionType === "3" ? ",free" : "")
                }, 1).draw();
                //var StartLine = 0;
                //var RowCount = $("#product-list > tbody > tr ").length - 1;
                //me.TmpRowRedraw++;
                //for (var ii = 0; ii < me.TmpRowRedraw; ii++) {

                //    var Row1 = $("#product-list > tbody >  tr:eq(" + StartLine + ")");
                //    var Row2 = $("#product-list > tbody > tr:eq(" + RowCount + ")");
                //    Row1.after(Row2);
                //    StartLine++;
                //}
                //me.indexForm.dtProducts.row.add({
                //    'name': name,
                //    'number': number,
                //    'money': money,
                //    'sum_money': (number * money),
                //    'id': resp.Data
                //}).draw();

                me.dtPromotionList.rows('.selected').remove().draw();
                // me.dtPromotionList.rows('.selected').child.hide();

                //  number = money < 0 ? 0 : number;
                money = (money * number);
                if (promotionType == '1' || promotionType == '2') {
                    me.txtExtraDiscount.val(+me.txtExtraDiscount.val() + (+money * -1));
                }
                if (give_same_buy === "False" && promotionType === "3") {

                    //var balance = me.indexForm.RoundUnit((+$('#txtPaymentMoney').val() + (+money)));
                    //$('#txtPaymentMoney').val(balance);
                    //$('#txtBalance').val(balance);
                    //$('#txtPaymentMoney').val(balance);
                    //$('#txtPaymentMoneyCash').val(balance);
                    me.txtTotalAmount.val(me.indexForm.RoundUnit((+me.txtTotalAmount.val() + (+money))));
                }

                me.txtTotalNumber.val(+me.txtTotalNumber.val() + +number);
                me.indexForm.setTotal();

                me.modal.modal('hide');
            });
        }*/

    }]);

    return PromotionModal;
}();