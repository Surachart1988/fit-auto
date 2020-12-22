class MessagePage extends IndexForm {
    constructor() {
        super()
        this.new = $('#new')
        this.promotion = $('#promotion')
        this.docType = $('#DocType')
    }

    init() {
        const me = this
        if (this.docType.val() == 1) {
            me.new.addClass('active')
        }
        else if (this.docType.val() == 2) {
            me.promotion.addClass('active')
        }

        this.new.click(() => {
            me.promotion.removeClass('active')
            me.new.addClass('active')
            me.docType.val(1)
            me.dt.ajax.reload()
        })

        this.promotion.click(() => {
            me.new.removeClass('active')
            me.promotion.addClass('active')
            me.docType.val(2)
            me.dt.ajax.reload()
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
            { "data": "Name" },
            { "data": "StatusName" },
            {
                "data": "Id",
                "className": "text-center",
                "orderable": false,
                "render": (data, type, row) => {
                    if (type === 'display') {
                        return `<a href="${this.selectUrl}?id=${data}" class="edit"><i class="fa fa-edit"></i></a>`
                    }
                    return data;
                },
            }]

        this.dtList = $('#message-list')
        this.searching = true
        super.init()
    }

    create(url) {
        location.href = url +"?docType=" +this.docType.val()
    }
}