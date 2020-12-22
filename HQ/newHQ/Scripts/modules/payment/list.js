class PaymentList extends IndexForm {
    constructor() {
        //super()
        this.editUrl = null
        this.deleteUrl = null
    }

    init() {
        this.columns = [
            { "data": "Code" },
            { "data": "Name" },
            { "data": "ProgroupName" },
            { "data": "CustypeName" },
            {
                "data": "Baht",
                "render": (data, type, row) => {
                    if (!data || data == 0)
                        return row.Percents + ' %';
                    return data +' บาท'
                }
            },
            { "data": "RankNo" },
            {
                "data": "Id",
                "className": "text-center",
                "orderable": false,
                "render": (data, type, row) => {
                    if (type === 'display') {
                        return `<a href="${this.editUrl}?id=${data}" class="edit"><i class="fa fa-edit"></i></a>|<a href="${this.deleteUrl}?id=${data}" class="remove"><i class="fa fa-trash"></i></a>`
                    }
                    return data;
                }
            },
        ]

        this.dtList = $('#extra-discount-list')
        this.searching = true
        //super.init()
    }
}