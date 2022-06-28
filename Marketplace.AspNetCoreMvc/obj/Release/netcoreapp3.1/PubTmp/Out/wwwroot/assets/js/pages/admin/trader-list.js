'use strict';
// Class definition

var KTDatatableHtmlTableDemo = function () {
    // Private functions

    // demo initializer
    var demo = function () {

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
                    field: 'Package',
                    autoHide: false,
                    // callback function support for column rendering
                    template: function (row) {
                        var status = {
                            1: {
                                'title': 'Standart Paket',
                                'class': ' label-light-info',
                            },
                            2: {
                                'title': 'Premium Paket',
                                'class': ' label-light-warning',
                            },
                        };
                        return '<span class="label font-weight-bold label-lg' + status[row.Package].class + ' label-inline">' + status[row.Package].title + '</span>';
                    },
                }, {
                    field: 'Status',
                    autoHide: false,
                    // callback function support for column rendering
                    template: function (row) {
                        var status = {
                            1: {
                                'title': 'Aktif',
                                'state': 'success',
                            },
                            2: {
                                'title': 'Pasif',
                                'state': 'danger',
                            },
                            3: {
                                'title': 'Durdurulmuş',
                                'state': 'warning',
                            },
                            4: {
                                'title': 'Beklemede',
                                'state': 'primary',
                            },
                        };
                        return '<span class="label label-' + status[row.Status].state + ' label-dot mr-2"></span><span class="font-weight-bold text-' + status[row.Status].state + '">' + status[row.Status].title + '</span>';
                    },
                },
            ],
        });

        $('#kt_datatable_search_status').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Package');
        });

        $('#kt_datatable_search_type').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Status');
        });

        $('#kt_datatable_search_status, #kt_datatable_search_type').selectpicker();

    };

    return {
        // Public functions
        init: function () {
            // init dmeo
            demo();
        },
    };
}();

jQuery(document).ready(function () {
    KTDatatableHtmlTableDemo.init();
});
