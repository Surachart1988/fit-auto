'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

$('#Name').bind('paste', function (e) {
    var data = e.originalEvent.clipboardData.getData('Text');
    if (data.length >= 99) {
        alert("สามารถกรอกตัวอักษรได้ไม่เกิน 100 ตัวอักษร");
        var StrCut = $('#Name').val().substring(0, 99);
        $('#Name').val(StrCut);
        return false;
    } else {
        return true;
    }
});
$("#Name").keydown(function (e) {
    var isOk = false;
    // Here we need not backspace keycode = 8 and the delete keycode 46
    isOk = (event.keyCode == 8 || event.keyCode == 46) ? true : false;

    if (($(this).val().length >= 99) && (!isOk)) {
        alert("สามารถกรอกตัวอักษรได้ไม่เกิน 100 ตัวอักษร");
        return false;
    }


});

$("input[type='submit']").click(function () {

    var sizeMB = parseFloat($("#hdfFilesSize").val());
    if ($("#Name").val().length >= 100) {
        alert(NotOverMsg);
        return false;
    }

    if (sizeMB >= 4) {
        alert("ไม่อนุญาต ให้อัพโหลดไฟล์ที่มีขนาดใหญ่กว่า 4mb");
        return false;
    }
    return true;

});

$('#Files').bind('change', function () {
    if (this.files[0].size) {
        $("#filesSize").text();
        //  alert(this.files[0].size);
        var sizeB = this.files[0].size;
        var sizeKB = sizeB / 1000;
        var sizeMB = sizeKB / 1000;
        if (sizeKB < 1000) {
            $("#filesSize").text("File size : " + sizeKB.toFixed(2).toString() + " kb");
        }
        if (sizeKB >= 1000) {
            $("#filesSize").text("File size : " + sizeMB.toFixed(2).toString() + " mb");
        }
        $("#hdfFilesSize").val(sizeMB);
    } else {
        $("#filesSize").text("");
        //  alert('not select');
    }
    //this.files[0].size gets the size of your file.


});
var MessageForm = function () {
    function MessageForm() {
        _classCallCheck(this, MessageForm);

        this.dateRange = $('#DateRange');
        this.startDate = $('#StartDate');
        this.endDate = $('#EndDate');
        this.myForm = $('#myForm');
        this.content = $('#Content');
    }

    _createClass(MessageForm, [{
        key: 'init',
        value: function init() {
            var me = this;

            CKEDITOR.replace('Content', {
                language: 'th',
                height: '18em',
                toolbar: [
                    //{ name: 'document', items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
                    //{ name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
                    { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] }, { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'CopyFormatting', 'RemoveFormat'] }, '/', { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl', 'Language'] }, { name: 'links', items: ['Link', 'Unlink', 'Anchor'] }, { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] }, '/', { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] }, { name: 'colors', items: ['TextColor', 'BGColor'] }, { name: 'tools', items: ['Maximize', 'ShowBlocks'] }, { name: 'about', items: ['About'] }]
            });

            this.dateRange.daterangepicker({
                locale: {
                    format: 'DD/MM/YYYY'
                },
                opens: 'left'
            }, function (start, end, label) {
                me.startDate.val(start.format('YYYY/MM/DD'));
                me.endDate.val(end.format('YYYY/MM/DD'));
            });

            if (!me.startDate.val() && !me.endDate.val()) this.dateRange.val('');
        }
    }]);


    return MessageForm;
}();