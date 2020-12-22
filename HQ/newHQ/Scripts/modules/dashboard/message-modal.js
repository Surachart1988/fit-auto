class MessageModal extends IndexForm {
    constructor() {
        super()
        this.new = $('#newsAll')
        this.promotion = $('#promotionsAll')
        this.docType = $('#DocType')
        this.lblHeadName = $('#lblHeadName')
    }

    init() {
        const me = this
        this.docType.val(0)
        this.new.click(() => {
            me.docType.val(1)
            me.dt.ajax.reload()
            me.lblHeadName.text("ข่าวสาร");
        })

        this.promotion.click(() => {
            me.docType.val(2)
            me.dt.ajax.reload()
            me.lblHeadName.text("โปรโมชั่น");
        })

        this.columns = [
            {
                "data": 'Id',
                "type": 'date-euro',
                "render": (data, type, row) => {
                    if (type === 'display') {
                        return `${formatDate(row.StartDate)} - ${formatDate(row.EndDate)}`;
                    }
                    return data;
                }
            },
            {
                "data": "Name",
                 visible: false 
            },
            {
                "data": "StatusName",
                visible: false
            },
            { "data": "Content" },
            {
                "data": "FileName",
                "className": "text-center",
                "orderable": false,
                "render": (data, type, row) => {
                    if (type === 'display' && data) {
                        return `<a href="Javascript:openDocFull('${this.selectUrl + data}')" class="edit" style="font-size: 5vh;"><i class="fa fa-file-pdf-o"></i></a>`
                    }
                    return 'ไม่พบไฟล์';
                },
            }]

        this.dtList = $('#message-modal-list')

        super.init()
    }
}