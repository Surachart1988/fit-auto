'use strict';

var _typeof = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; };

function formatNumeric(data) {
    if (!data) return data;
    return data.toLocaleString(undefined, {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    });
}

function formatDate(data) {
    if (!data) return data;
    return moment(data).format('DD/MM/YYYY');
}

function formatDatetime(data) {
    if (!data) return data;
    return moment(data).format('DD/MM/YYYY HH:mm');
}

//function openDocPrint(urlParam) {
//    //var thaibaht = formatThaiBaht(amount.toFixed(2))
//    window.open(urlParam, "MsgWindow", "width=800,height=800");
//    //window.open(urlParam, '_blank', 'toolbar=no', 'scrollbars=yes', 'resizable=no', 'top=10', 'left=10', 'width=900', 'height=800')
//}
function openDocPrint(urlParam) {

    var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : window.screenX;
    var dualScreenTop = window.screenTop != undefined ? window.screenTop : window.screenY;

    var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
    var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

    var systemZoom = width / window.screen.availWidth;
    var left = (width - 1500) / 2 / systemZoom + dualScreenLeft
    var top = (height - 800) / 2 / systemZoom + dualScreenTop
    var newWindow = window.open(urlParam, "MsgWindow", 'scrollbars=yes, width=' + 1500 / systemZoom + ', height=' + 800 / systemZoom + ', top=' + top + ', left=' + left);
}
function openDocFull(urlParam) {
    window.open(urlParam, "MsgWindow", "width=" + screen.availWidth + ",height=" + screen.availHeight + ",scrollbars=yes");
}
function openPopupFull(urlParam) {
    window.open(urlParam, "winsFull", "width=" + screen.availWidth + ",height=" + screen.availHeight + ",scrollbars=yes");
}
function convertNumber(data) {
    var number = data.replace(/\,/g, '');
    return +number;
}

function showAlert(message) {
    $('#alert').text(message);
    $('#alert').show();
}

function formatThaiBaht(Number) {
    //ตัดสิ่งที่ไม่ต้องการทิ้งลงโถส้วม
    for (var i = 0; i < Number.length; i++) {
        Number = Number.replace(",", ""); //ไม่ต้องการเครื่องหมายคอมมาร์
        Number = Number.replace(" ", ""); //ไม่ต้องการช่องว่าง
        Number = Number.replace("บาท", ""); //ไม่ต้องการตัวหนังสือ บาท
        Number = Number.replace("฿", ""); //ไม่ต้องการสัญลักษณ์สกุลเงินบาท
    }
    //สร้างอะเรย์เก็บค่าที่ต้องการใช้เอาไว้
    var TxtNumArr = new Array("ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ");
    var TxtDigitArr = new Array("", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน");
    var BahtText = "";
    //ตรวจสอบดูซะหน่อยว่าใช่ตัวเลขที่ถูกต้องหรือเปล่า ด้วย isNaN == true ถ้าเป็นข้อความ == false ถ้าเป็นตัวเลข
    if (isNaN(Number)) {
        return "ข้อมูลนำเข้าไม่ถูกต้อง";
    } else {
        //ตรวสอบอีกสักครั้งว่าตัวเลขมากเกินความต้องการหรือเปล่า
        if (Number - 0 > 9999999.9999) {
            return "ข้อมูลนำเข้าเกินขอบเขตที่ตั้งไว้";
        } else {
            //พรากทศนิยม กับจำนวนเต็มออกจากกัน (บาปหรือเปล่าหนอเรา พรากคู่เขา)
            Number = Number.split(".");
            //ขั้นตอนต่อไปนี้เป็นการประมวลผลดูกันเอาเองครับ แบบว่าขี้เกียจจะจิ้มดีดแล้ว อิอิอิ
            if (Number[1].length > 0) {
                Number[1] = Number[1].substring(0, 2);
            }
            var NumberLen = Number[0].length - 0;
            for (var i = 0; i < NumberLen; i++) {
                var tmp = Number[0].substring(i, i + 1) - 0;
                if (tmp != 0) {
                    if (i == NumberLen - 1 && tmp == 1) {
                        BahtText += "เอ็ด";
                    } else if (i == NumberLen - 2 && tmp == 2) {
                        BahtText += "ยี่";
                    } else if (i == NumberLen - 2 && tmp == 1) {
                        BahtText += "";
                    } else {
                        BahtText += TxtNumArr[tmp];
                    }
                    BahtText += TxtDigitArr[NumberLen - i - 1];
                }
            }
            BahtText += "บาท";
            if (Number[1] == "0" || Number[1] == "00") {
                BahtText += "ถ้วน";
            } else {
                var DecimalLen = Number[1].length - 0;
                for (var i = 0; i < DecimalLen; i++) {
                    var tmp = Number[1].substring(i, i + 1) - 0;
                    if (tmp != 0) {
                        if (i == DecimalLen - 1 && tmp == 1) {
                            BahtText += "เอ็ด";
                        } else if (i == DecimalLen - 2 && tmp == 2) {
                            BahtText += "ยี่";
                        } else if (i == DecimalLen - 2 && tmp == 1) {
                            BahtText += "";
                        } else {
                            BahtText += TxtNumArr[tmp];
                        }
                        BahtText += TxtDigitArr[DecimalLen - i - 1];
                    }
                }
                BahtText += "สตางค์";
            }
            return BahtText;
        }
    }
}

function formatDate(data) {
    if (!data) return data;
    return moment(data).format('DD/MM/YYYY');
}

function datetimepickerInit() {
    if ($('.input-datetime') && $('.input-datetime').length > 0) {
        $('.input-datetime').datetimepicker({
            format: 'DD/MM/YYYY',
            widgetPositioning: {
                horizontal: 'auto',
                vertical: 'bottom'
            }
        });
    }
}

function select2Init() {
    $('.dd-search').select2();
}

var FormSerialize = function () {
    return {
        getFormArray: function getFormArray($form, data) {
            var unindexed_array = $form.serializeArray();

            var indexed_array = data == null ? {} : data;

            var indexed_array2 = new Array();

            for (var unindex in unindexed_array) {
                if (indexed_array2.length == 0) indexed_array2.push(unindexed_array[unindex]);
                for (var index in indexed_array2) {
                    //check object.name ที่ซ้ำกันเพื่อไม่ให้ save ลงตัวแปรที่ไว้กรอง data
                    if (indexed_array2[index].name == unindexed_array[unindex].name) {
                        break;
                    } else if (index == indexed_array2.length - 1) {
                        indexed_array2.push(unindexed_array[unindex]);
                        break;
                    }
                    //end
                }
            }

            //map array เป็น object เพือนำไป postdata
            $.map(indexed_array2, function (n, i) {
                indexed_array[n['name']] = n['value'];
            });
            //end

            return indexed_array;
        },

        getFormStackingObjectsArray: function getFormStackingObjectsArray($form, data, objName) {

            var unindexed_array = $form.serializeArray();

            var indexed_array2 = new Array();

            if (objName != null) {
                $.map(data, function (mval, mname) {
                    if (typeof mval === '[object Array]') {
                        console.log('ok');
                    } else {
                        if ((typeof mval === 'undefined' ? 'undefined' : _typeof(mval)) === 'object') {
                            $.map(mval, function (sval, sname) {
                                if ((typeof sval === 'undefined' ? 'undefined' : _typeof(sval)) === 'object') {
                                    $.map(sval, function (val, name) {
                                        unindexed_array.push({ name: objName + '.' + mname + '[' + sname + '].' + name, value: val });
                                    });
                                } else unindexed_array.push({ name: objName + '.' + mname + '.' + sname, value: sval });
                            });
                        } else unindexed_array.push({ name: objName + '.' + mname, value: mval });
                    }
                });
            }

            return unindexed_array;
        }
    };
}();

String.prototype.replaceArray = function (find, replace) {
    var replaceString = this;
    if (!replaceString) return replaceString;
    var regex;
    for (var i = 0; i < find.length; i++) {
        replaceString = replaceString.replace(find[i], replace[i]);
    }
    return replaceString;
};

function SetAutocomplete(input, output, getUrl, dataSearch) {
    input.autocomplete({
        source: function source(request, response) {
            $.ajax({
                url: getUrl,
                datatype: "json",
                data: dataSearch,
                success: function success(data) {
                    response($.map(data, function (val, item) {
                        return {
                            label: val.Name,
                            value: val.id
                        };
                    }));
                }
            });
        },
        select: function select(event, ui) {
            output.val(ui.item.value);
        }
    });
}

function SetSelector(getUrl, select) {
    $.ajax({
        url: getUrl,
        datatype: "json",
        success: function success(data) {
            var options;
            if (select.prop) {
                options = select.prop('options');
            } else {
                options = select.attr('options');
            }
            $('option', select).remove();

            $.each(data, function (val, text) {
                options[options.length] = new Option(text.Name, text.Id);
            });
        }
    });
}

function SetSelectorByJsonResponseModel(getUrl, select, afterEvent) {
    $.ajax({
        url: getUrl,
        datatype: "json",
        success: function success(resp) {
            if (resp.Code == '00') {
                var options;
                if (select.prop) {
                    options = select.prop('options');
                } else {
                    options = select.attr('options');
                }
                $('option', select).remove();

                $.each(resp.Data, function (val, text) {
                    options[options.length] = new Option(text.Name, text.Id);
                });

                afterEvent && afterEvent();
            } else alert(resp.Code + ',' + resp.Message + ': \n' + resp.Data);
        }
    });
}

function SetTextByJsonResponseModel(getUrl, txt, afterEvent) {
    $.ajax({
        url: getUrl,
        datatype: "json",
        success: function success(resp) {
            if (resp.Code == '00') {
                txt.val(resp.Data);

                afterEvent && afterEvent();
            } else alert(resp.Code + ',' + resp.Message + ': \n' + resp.Data);
        }
    });
}

var inputName = [];

$(document).ready(function () {
    jQuery.ajaxSettings.traditional = true;

    var x = window.matchMedia("(max-width: 767px)");
    reSizeSm(x);
    x.addListener(reSizeSm);

    window.onbeforeunload = function (event) {
        loading.start();
    };

    $.event.special.inputchange = {
        setup: function setup() {
            var self = this,
                val;
            $.data(this, 'timer', window.setInterval(function () {
                val = self.value;
                if ($.data(self, 'cache') != val) {
                    $.data(self, 'cache', val);
                    $(self).trigger('inputchange');
                }
            }, 20));
        },
        teardown: function teardown() {
            window.clearInterval($.data(this, 'timer'));
        },
        add: function add() {
            $.data(this, 'cache', this.value);
        }

        //datetimepickerInit()
        //select2Init()
    }; if ($.fn.dataTable) {
        $.extend($.fn.dataTable.defaults, {
            language: {
                "processing": "กำลังโหลดข้อมุล กรุณารอสักครู่...",
                "zeroRecords": "ไม่พบข้อมูล",
                "info": "แสดงรายการที่ _START_ ถึง _END_ จากทั้งหมด _TOTAL_ รายการ",
                "emptyTable": "ไม่พบข้อมูลที่ค้นหา",
                "infoEmpty": "ไม่มีรายการ",
                "paginate": {
                    "first": "หน้าแรก",
                    "last": "หน้าสุดท้าย",
                    "next": "หน้าถัดไป",
                    "previous": "ก่อนหน้า"
                }
            }
        });
    }

    $('.modal').on('shown.bs.modal', function () {
        $('.icon-bar').css('top', '50px');
    });

    var numberInteger = $('.number-Integer');
    if (numberInteger.length > 0) {
        numberInteger.autoNumeric('init', { mDec: '0' });
    }

    $(".percent").length > 0 && $(".percent").prop("type", "text").autoNumeric('init', { vMax: '100', vMin: '0', mDec: '2' });

    var numberInputs = $('input[type="number"]');
    if (numberInputs.length > 0) {
        numberInputs.prop("type", "text");
        numberInputs.autoNumeric('init', { mDec: '0' });
    }
    $(".numberonly").bind('keypress', function (e) {
        if (e.keyCode == '9' || e.keyCode == '16') {
            return;
        }
        var code;
        if (e.keyCode) code = e.keyCode;
        else if (e.which) code = e.which;
        if (e.which == 46)
            return false;
        if (code == 8 || code == 46)
            return true;
        if (code < 48 || code > 57)
            return false;
        if (code != 46 && code > 31
            && (code < 48 || code > 57))
            return false;
    });

    //Disable paste
    $(".numberonly").bind("paste", function (e) {
        e.preventDefault();
    });

    $(".numberonly").bind('mouseenter', function (e) {
        var val = $(this).val();
        if (val != '0') {
            val = val.replace(/[^0-9]+/g, "")
            $(this).val(val);
        }
    });

    $(".30day").bind('keypress', function (e) {

        var keyCode = e.which ? e.which : e.keyCode

        if (!(keyCode >= 48 && keyCode <= 57)) {
            return false;
        }
    });
    $(".30day").keyup(function () {
        if ($(this).val() > 30) {
            $(this).val('30');
        }
        if ($(this).val().length > 2) {
            $(this).val('');
        }
    });
    var moneyInputs = $('.money');
    if (moneyInputs.length > 0) {
        moneyInputs.autoNumeric('init', { vMax: '9999999', vMin: '0', mDec: '2' });
    }

    (function ($) {
        var originalVal = $.fn.val;
        inputName = [];
        moneyInputs.each(function () {
            inputName.push($(this).attr('name'));
        });
        numberInputs.each(function () {
            inputName.push($(this).attr('name'));
        });
        $.fn.val = function (value) {

            if (arguments.length >= 1) {
                // setter invoked, do processing
                if (value && $.isNumeric(value) && +value >= 1000 && inputName.indexOf(this.attr('name')) > -1) value = value.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
                return originalVal.call(this, value);
            }
            if (originalVal.call(this) && originalVal.call(this).indexOf(',') > -1) return originalVal.call(this).replace(/\,/g, '');
            //getter invoked do processing
            return originalVal.call(this);
        };
    })(jQuery);
});

function reSizeSm(x) {
    if (x.matches) {
        $('.hidden-xs-more').addClass('readmore hidden');
    } else {
        $('.hidden-xs-more').removeClass('readmore hidden');
    }
}

function commaFormSubmit(myForm) {
    myForm.submit(function (event) {
        inputName.forEach(function (name) {
            if (document.getElementsByName(name)[0]) document.getElementsByName(name)[0].value = $("[name='" + name + "']").val();
        });
        return true;
    });
}

function warningAlert(massage) {
    swal({
        text: massage,
        icon: '../Content/img/ICON/warning-icon.png',
        type: "warning",
        imageHeight: 150,
        padding: 10,
        button: "ตกลง",
        allowOutsideClick: false,
        closeOnClickOutside: false
    })
}
function downloadAlert(message) {
    swal({
        html: true,
        icon: '../Content/img/ICON/warning-icon.png',
        text: message,
        buttons: {
            cancel: "Cancel",
            catch: {
                text: "Download",
                value: "download",
            },
        },
    })
        .then((value) => {
            switch (value) {
                case "download":
                    swal({
                        html: true,
                        title: 'Download Excel',
                        icon: 'success',
                    });
                    //var objButton = document.getElementById("btnExport");
                    //objButton.click();
                    $.post("ExportToExcelSheet").done(function (data) {
                        document.getElementById('my_iframeFail_Update').src = "Download/?file=" + data.fileName;
                    });
                    break;

                default:
                    swal({
                        text: "กรุณาเลือกข้อมูลไฟล์เพื่อทำการนำข้อมูลเข้าใหม่อีกครั้ง",
                        icon: '../Content/img/ICON/warning-icon.png'
                    });
                    //swal("กรุณาเลือกข้อมูลไฟล์เพื่อทำการนำข้อมูลเข้าใหม่อีกครั้ง");
                    return false;
            }
        });
}
function successAlert(title, massage) {
    swal({
        title: title,//'บันทึกข้อมูลสำเร็จ',
        text: massage,
        icon: 'success',
        timer: 1000,
    })
}
function successAlertWithUrl(massage, url) {
    swal({
        title: 'บันทึกข้อมูลสำเร็จ',
        text: massage,
        icon: 'success',
        type: "success"
    }).then(function () {

        window.location.href = url;
    });
}
function confirmAlert(massage, functional) {
    swal({
        text: massage,
        icon: '../Content/img/ICON/warning-icon.png',
        buttons: true,
        buttons: [
            'ตกลง',
            'ยกเลิก'
        ],
        allowOutsideClick: false,
        closeOnClickOutside: false
    }).then(functional)

}
function confirmDelete(massage, functional) {
    swal({
        text: massage,
        icon: '../Content/img/ICON/warning-icon.png',
        buttons: true,
        buttons: [
            'ตกลง',
            'ยกเลิก'
        ],
        allowOutsideClick: false,
        closeOnClickOutside: false
    }).then(functional)

}