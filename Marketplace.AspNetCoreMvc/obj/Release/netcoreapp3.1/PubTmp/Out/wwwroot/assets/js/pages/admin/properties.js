$(document).ready(function () {
    TableCreate();
})


function TableCreate() {
    var datatable = $('#kt_datatable').KTDatatable({
        data: {
            saveState: { cookie: false },
        },
        search: {
            input: $('#kt_datatable_search_query'),
            key: 'generalSearch',
        },
        layout: {
            class: 'datatable-bordered',
        },
        columns: [
            {
                field: 'İşlemler',
                textAlign: 'right'
            },
            {
                field: 'Actions',
                textAlign: 'right'
            },
            {
                field: 'المعاملات',
                textAlign: 'right'
            },
            {
                field: 'DepositPaid',
                type: 'number',
            },
            {
                field: 'OrderDate',
                type: 'date',
                format: 'YYYY-MM-DD',
            },
            {
                field: 'Status',
                title: 'Status',
                autoHide: false,
                // callback function support for column rendering
                template: function (row) {
                    var status = {
                        1: {
                            'title': 'Pending',
                            'class': ' label-light-warning',
                        },
                        2: {
                            'title': 'Delivered',
                            'class': ' label-light-danger',
                        },
                        3: {
                            'title': 'Canceled',
                            'class': ' label-light-primary',
                        },
                        4: {
                            'title': 'Success',
                            'class': ' label-light-success',
                        },
                        5: {
                            'title': 'Info',
                            'class': ' label-light-info',
                        },
                        6: {
                            'title': 'Danger',
                            'class': ' label-light-danger',
                        },
                        7: {
                            'title': 'Warning',
                            'class': ' label-light-warning',
                        },
                    };
                    return '<span class="label font-weight-bold label-lg' + status[row.Status].class + ' label-inline">' + status[row.Status].title + '</span>';
                },
            },
            {
                field: 'Type',
                title: 'Type',
                autoHide: false,
                // callback function support for column rendering
                template: function (row) {
                    var status = {
                        1: {
                            'title': 'Online',
                            'state': 'danger',
                        },
                        2: {
                            'title': 'Retail',
                            'state': 'primary',
                        },
                        3: {
                            'title': 'Direct',
                            'state': 'success',
                        },
                    };
                    return '<span class="label label-' + status[row.Type].state + ' label-dot mr-2"></span><span class="font-weight-bold text-' + status[row.Type].state + '">' + status[row.Type].title + '</span>';
                },
            },
        ],
    });

    $('#kt_datatable_search_status').on('change', function () {
        datatable.search($(this).val().toLowerCase(), 'Status');
    });

    $('#kt_datatable_search_type').on('change', function () {
        datatable.search($(this).val().toLowerCase(), 'Type');
    });

    $('#kt_datatable_search_status, #kt_datatable_search_type').selectpicker();

}


function deleteProperty(id) {

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-danger',
            cancelButton: 'btn btn-secondary'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: "Silmek istediğine emin misin?",
        text: "Bu değişikliği geri alamazsın!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Evet, sil!",
        cancelButtonText: "Hayır, iptal et!",
        reverseButtons: true
    }).then(function (result) {
        if (result.value) {
            Swal.fire(
                "Silindi!",
                "Kayıt Silindi.",
                "success"
            ).then(function () {
                location.href = "/Admin/Property/RemoveProperty?propertyId=" + id
            })
        } else if (result.dismiss === "cancel") {
            Swal.fire(
                "İptal edildi",
                "Silinme islemi iptal edildi.",
                "error"
            )
        }
    });
}

