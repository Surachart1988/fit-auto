class MessageForm {
    constructor() {
        this.dateRange = $('#DateRange')
        this.startDate = $('#StartDate')
        this.endDate = $('#EndDate')
        this.myForm = $('#myForm')
        this.content = $('#Content')
    }

    init() {
        const me = this

        CKEDITOR.replace('Content', {
            language: 'th',
            height: '6.5em',
            toolbar:
                [
                    //{ name: 'document', items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
                    //{ name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
                    { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
                    { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'CopyFormatting', 'RemoveFormat'] },
                    '/',
                    { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl', 'Language'] },
                    { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
                    { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
                    '/',
                    { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
                    { name: 'colors', items: ['TextColor', 'BGColor'] },
                    { name: 'tools', items: ['Maximize', 'ShowBlocks'] },
                    { name: 'about', items: ['About'] }]
        });

        this.dateRange.daterangepicker({
            locale: {
                format: 'DD/MM/YYYY'
            },
            opens: 'left'
        }, function (start, end, label) {
            me.startDate.val(start.format('YYYY/MM/DD'))
            me.endDate.val(end.format('YYYY/MM/DD'))
        })


        if (!me.startDate.val() && !me.endDate.val())
            this.dateRange.val('')
    }
}