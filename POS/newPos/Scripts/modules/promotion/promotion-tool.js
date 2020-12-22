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

function successAlert(title, massage) {
    swal({
        title: title,//'บันทึกข้อมูลสำเร็จ',
        text: massage,
        icon: 'success',
        timer: 1000,
    })
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
        icon: 'Content/img/ICON/warning-icon.png',
        buttons: true,
        buttons: [
            'ตกลง',
            'ยกเลิก'
        ],
        allowOutsideClick: false,
        closeOnClickOutside: false
    }).then(functional)

}