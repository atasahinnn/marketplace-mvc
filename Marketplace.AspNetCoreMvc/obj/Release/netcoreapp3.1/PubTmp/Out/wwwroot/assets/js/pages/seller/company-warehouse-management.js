$(document).ready(function () {
    AddExistingWarehousesToTable();
});

var _row = null;
var warehouseIndex = 0;
var _activeId = 0;
var updatedWarehouseId;
var countryId;

function AddExistingWarehousesToTable() {
    if (allWarehouses != null) {
        for (var i = 0; i < allWarehouses.length; i++) {
            var countryName = "", cityName = "", districtName = "";

            $.ajax({
                type: "GET",
                url: "GetCountry",
                contentType: "application/json",
                processData: false,
                data: "id=" + allWarehouses[i].countryId,
                async: null,
                success: function (data) {
                    $.each(data.countryNames, function (k, v) {
                        countryName += v.name;
                        countryName += " ";
                    });
                },
                error: function () {
                    alert("Error");
                }
            });
            $.ajax({
                type: "GET",
                url: "GetCity",
                contentType: "application/json",
                processData: false,
                data: "id=" + allWarehouses[i].cityId,
                async: null,
                success: function (data) {
                    $.each(data.cityNames, function (k, v) {
                        cityName += v.name;
                        cityName += " ";
                    });
                },
                error: function () {
                    alert("Error");
                }
            });
            $.ajax({
                type: "GET",
                url: "GetDistrict",
                contentType: "application/json",
                processData: false,
                data: "id=" + allWarehouses[i].districtId,
                async: null,
                success: function (data) {
                    $.each(data.districtNames, function (k, v) {
                        districtName += v.name;
                        districtName += " ";
                    });
                },
                error: function () {
                    alert("Error");
                }
            });

            var html = '<tr id="Warehouse_' + i + '">' +
                '<td class="text-center">' + allWarehouses[i].name + '</td>' +
                '<td class="text-center">' + countryName + '</td>' +
                '<td class="text-center">' + cityName + '</td>' +
                '<td class="text-center">' + districtName + '</td>' +
                '<td class="text-center">' + allWarehouses[i].address + '</td>';
            if (allWarehouses[i].active) {
                html += '<td class="text-center"><span class="label label-xl font-weight-bold label-light-success label-inline">Aktif</span></td>';
            }
            else {
                html += '<td class="text-center"><span class="label label-xl font-weight-bold label-light-danger label-inline">Pasif</span></td>';
            }
            html += '<td class="text-center">' +
                '<button type="button" class="btn btn-sm btn-clean btn-text-primary btn-icon" title = "Depo Bilgilerini Güncelle" data-toggle="modal" data-target="#warehouseUpdateModal" onclick="warehouseDisplay(this);" data-id ="' + i + '">' +
                '<span class="svg-icon svg-icon-lg svg-icon-warning">' +
                '<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">' +
                '<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">' +
                '<rect x="0" y="0" width="24" height="24"></rect>' +
                '<path d="M8,17.9148182 L8,5.96685884 C8,5.56391781 8.16211443,5.17792052 8.44982609,4.89581508 L10.965708,2.42895648 C11.5426798,1.86322723 12.4640974,1.85620921 13.0496196,2.41308426 L15.5337377,4.77566479 C15.8314604,5.0588212 16,5.45170806 16,5.86258077 L16,17.9148182 C16,18.7432453 15.3284271,19.4148182 14.5,19.4148182 L9.5,19.4148182 C8.67157288,19.4148182 8,18.7432453 8,17.9148182 Z" fill="#000000" fill-rule="nonzero" transform="translate(12.000000, 10.707409) rotate(-135.000000)translate(-12.000000, -10.707409)"></path>' +
                '<rect fill="#000000" opacity="0.3" x="5" y="20" width="15" height="2" rx="1"></rect>' +
                '</g>' +
                '</svg>' +
                '</span>' +
                '</button >' +
                '</td >' +
                '<td class="text-center">' +
                '<button type="button" class="btn btn-sm btn-clean btn-text-primary btn-icon" title="Depoyu Sil" onclick="warehouseDelete(this);" data-id ="' + i + '">' +
                '<span class="svg-icon svg-icon-lg svg-icon-danger">' +
                '<svg xmlns = "http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1" >' +
                '<g stroke = "none" stroke-width="1" fill="none" fill-rule="evenodd" >' +
                '<rect x="0" y="0" width="24" height="24"></rect>' +
                '<path d="M3.5,21 L20.5,21 C21.3284271,21 22,20.3284271 22,19.5 L22,8.5 C22,7.67157288 21.3284271,7 20.5,7 L10,7 L7.43933983,4.43933983 C7.15803526,4.15803526 6.77650439,4 6.37867966,4 L3.5,4 C2.67157288,4 2,4.67157288 2,5.5 L2,19.5 C2,20.3284271 2.67157288,21 3.5,21 Z" fill="#000000" opacity="0.3"></path>' +
                '<path d="M10.5857864,14 L9.17157288,12.5857864 C8.78104858,12.1952621 8.78104858,11.5620972 9.17157288,11.1715729 C9.56209717,10.7810486 10.1952621,10.7810486 10.5857864,11.1715729 L12,12.5857864 L13.4142136,11.1715729 C13.8047379,10.7810486 14.4379028,10.7810486 14.8284271,11.1715729 C15.2189514,11.5620972 15.2189514,12.1952621 14.8284271,12.5857864 L13.4142136,14 L14.8284271,15.4142136 C15.2189514,15.8047379 15.2189514,16.4379028 14.8284271,16.8284271 C14.4379028,17.2189514 13.8047379,17.2189514 13.4142136,16.8284271 L12,15.4142136 L10.5857864,16.8284271 C10.1952621,17.2189514 9.56209717,17.2189514 9.17157288,16.8284271 C8.78104858,16.4379028 8.78104858,15.8047379 9.17157288,15.4142136 L10.5857864,14 Z" fill="#000000" />' +
                '</g>' +
                '</svg>' +
                '</span>' +
                '</button>' +
                '</td>' +
                '</tr>' +
                '<input type="hidden" name="Warehouses[' + i + '].Name" value="' + allWarehouses[i].name + '" />' +
                '<input type="hidden" name="Warehouses[' + i + '].CountryId" value="' + allWarehouses[i].countryId + '"/>' +
                '<input type="hidden" name="Warehouses[' + i + '].CityId" value="' + allWarehouses[i].cityId + '"/>' +
                '<input type="hidden" name="Warehouses[' + i + '].DistrictId" value="' + allWarehouses[i].districtId + '"/>' +
                '<input type="hidden" name="Warehouses[' + i + '].Address" value="' + allWarehouses[i].address + '"/>' +
                '<input type="hidden" name="Warehouses[' + i + '].Id" value="' + allWarehouses[i].id + '"/>' +
                '<input type="hidden" name="Warehouses[' + i + '].StoreId" value="' + allWarehouses[i].storeId + '"/>' +
                '<input type="hidden" name="Warehouses[' + i + '].Active" value="' + allWarehouses[i].active + '"/>';
            warehouseIndex = i + 1;
            $("#warehouseTable tbody").append(html);
        }
    }
}

function warehouseAdd() {
    if ($("#warehouseTable tbody").length == 0) {
        $("#warehouseTable").append("<tbody></tbody>");
    }
    // ID + ROW EKLEME
    $("#warehouseTable tbody").append(warehouseBuildTableRow(warehouseIndex));
    warehouseIndex++;
    formClear();
}

function warehouseBuildTableRow(id) {
    var countryName = "", cityName = "", districtName = "";

    $.ajax({
        type: "GET",
        url: "GetCountry",
        contentType: "application/json",
        processData: false,
        data: "id=" + $('#CountryIdAddModal').val(),
        async: null,
        success: function (data) {
            $.each(data.countryNames, function (k, v) {
                countryName += v.name;
                countryName += " ";
            });
        },
        error: function () {
            alert("Error");
        }
    });
    $.ajax({
        type: "GET",
        url: "GetCity",
        contentType: "application/json",
        processData: false,
        data: "id=" + $('#CityIdAddModal').val(),
        async: null,
        success: function (data) {
            $.each(data.cityNames, function (k, v) {
                cityName += v.name;
                cityName += " ";
            });
        },
        error: function () {
            alert("Error");
        }
    });
    $.ajax({
        type: "GET",
        url: "GetDistrict",
        contentType: "application/json",
        processData: false,
        data: "id=" + $('#DistrictIdAddModal').val(),
        async: null,
        success: function (data) {
            $.each(data.districtNames, function (k, v) {
                districtName += v.name;
                districtName += " ";
            });
        },
        error: function () {
            alert("Error");
        }
    });

    var row = '<tr id="Warehouse_' + id + '">' +
        '<td class="text-center">' + $('#NameAddModal').val() + '</td>' +
        '<td class="text-center">' + countryName + '</td>' +
        '<td class="text-center">' + cityName + '</td>' +
        '<td class="text-center">' + districtName + '</td>' +
        '<td class="text-center">' + $('#AddressAddModal').val() + '</td>'
    if ($('#ActiveAddModal').is(':checked')) {
        row += '<td class="text-center"><span class="label label-xl font-weight-bold label-light-success label-inline">Aktif</span></td>';
    }
    else {
        row += '<td class="text-center"><span class="label label-xl font-weight-bold label-light-danger label-inline">Pasif</span></td>';
    }
    row += '<td class="text-center">' +
        '<button type="button" class="btn btn-sm btn-clean btn-text-primary btn-icon" title = "Depo Bilgilerini Güncelle" data-toggle="modal" data-target="#warehouseUpdateModal" onclick="warehouseDisplay(this);" data-id ="' + id + '">' +
        '<span class="svg-icon svg-icon-lg svg-icon-warning">' +
        '<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">' +
        '<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">' +
        '<rect x="0" y="0" width="24" height="24"></rect>' +
        '<path d="M8,17.9148182 L8,5.96685884 C8,5.56391781 8.16211443,5.17792052 8.44982609,4.89581508 L10.965708,2.42895648 C11.5426798,1.86322723 12.4640974,1.85620921 13.0496196,2.41308426 L15.5337377,4.77566479 C15.8314604,5.0588212 16,5.45170806 16,5.86258077 L16,17.9148182 C16,18.7432453 15.3284271,19.4148182 14.5,19.4148182 L9.5,19.4148182 C8.67157288,19.4148182 8,18.7432453 8,17.9148182 Z" fill="#000000" fill-rule="nonzero" transform="translate(12.000000, 10.707409) rotate(-135.000000)translate(-12.000000, -10.707409)"></path>' +
        '<rect fill="#000000" opacity="0.3" x="5" y="20" width="15" height="2" rx="1"></rect>' +
        '</g>' +
        '</svg>' +
        '</span>' +
        '</button >' +
        '</td >' +
        '<td class="text-center">' +
        '<button type="button" class="btn btn-sm btn-clean btn-text-primary btn-icon" title="Depoyu Sil" onclick="warehouseDelete(this);" data-id ="' + id + '">' +
        '<span class="svg-icon svg-icon-lg svg-icon-danger">' +
        '<svg xmlns = "http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1" >' +
        '<g stroke = "none" stroke-width="1" fill="none" fill-rule="evenodd" >' +
        '<rect x="0" y="0" width="24" height="24"></rect>' +
        '<path d="M3.5,21 L20.5,21 C21.3284271,21 22,20.3284271 22,19.5 L22,8.5 C22,7.67157288 21.3284271,7 20.5,7 L10,7 L7.43933983,4.43933983 C7.15803526,4.15803526 6.77650439,4 6.37867966,4 L3.5,4 C2.67157288,4 2,4.67157288 2,5.5 L2,19.5 C2,20.3284271 2.67157288,21 3.5,21 Z" fill="#000000" opacity="0.3"></path>' +
        '<path d="M10.5857864,14 L9.17157288,12.5857864 C8.78104858,12.1952621 8.78104858,11.5620972 9.17157288,11.1715729 C9.56209717,10.7810486 10.1952621,10.7810486 10.5857864,11.1715729 L12,12.5857864 L13.4142136,11.1715729 C13.8047379,10.7810486 14.4379028,10.7810486 14.8284271,11.1715729 C15.2189514,11.5620972 15.2189514,12.1952621 14.8284271,12.5857864 L13.4142136,14 L14.8284271,15.4142136 C15.2189514,15.8047379 15.2189514,16.4379028 14.8284271,16.8284271 C14.4379028,17.2189514 13.8047379,17.2189514 13.4142136,16.8284271 L12,15.4142136 L10.5857864,16.8284271 C10.1952621,17.2189514 9.56209717,17.2189514 9.17157288,16.8284271 C8.78104858,16.4379028 8.78104858,15.8047379 9.17157288,15.4142136 L10.5857864,14 Z" fill="#000000" />' +
        '</g>' +
        '</svg>' +
        '</span>' +
        '</button>' +
        '</td>' +
        '</tr>' +
        '<input type="hidden" name="Warehouses[' + id + '].Name" value="' + $('#NameAddModal').val() + '" />' +
        '<input type="hidden" name="Warehouses[' + id + '].CountryId" value="' + $('#CountryIdAddModal').val() + '"/>' +
        '<input type="hidden" name="Warehouses[' + id + '].CityId" value="' + $('#CityIdAddModal').val() + '"/>' +
        '<input type="hidden" name="Warehouses[' + id + '].DistrictId" value="' + $('#DistrictIdAddModal').val() + '"/>' +
        '<input type="hidden" name="Warehouses[' + id + '].Address" value="' + $('#AddressAddModal').val() + '"/>';
    if ($('#ActiveAddModal').is(':checked'))
        row += '<input type="hidden" name="Warehouses[' + id + '].Active" value="true"/>';
    else
        row += '<input type="hidden" name="Warehouses[' + id + '].Active" value="false"/>';

    return row;
}

function warehouseDelete(e) {
    var index = $(e).attr("data-id");
    $('input[name="Warehouses[' + index + '].Name"]').val("");
    $('input[name="Warehouses[' + index + '].CountryId"]').val("");
    $('input[name="Warehouses[' + index + '].CityId"]').val("");
    $('input[name="Warehouses[' + index + '].DistrictId"]').val("");
    $('input[name="Warehouses[' + index + '].Address"]').val("");
    $('input[name="Warehouses[' + index + '].Active"]').val("");
    $(e).parents("tr").remove();
}

function warehouseDisplay(e) {
    var row = $(e).parents("tr");
    var cols = row.children("td");
    updatedWarehouseId = $(row).attr("id");
    var index = updatedWarehouseId.slice(10);
    _activeId = $($(cols[5]).children("button")[0]).data("id");
    $("#NameUpdateModal").val($(cols[0]).text());
    $("#CountryIdUpdateModal").val($('input[name="Warehouses[' + index + '].CountryId"]').val()).change();
    $("#CityIdUpdateModal").val($('input[name="Warehouses[' + index + '].CityId"]').val()).change();
    $("#DistrictIdUpdateModal").val($('input[name="Warehouses[' + index + '].DistrictId"]').val()).change();
    $("#AddressUpdateModal").val($(cols[4]).text());
    if ($('input[name="Warehouses[' + index + '].Active"]').val() == "true")
        $("#ActiveUpdateModal").prop('checked', true);
    else
        $("#ActiveUpdateModal").prop('checked', false);
}

function warehouseUpdate() {
    var countryName = "", cityName = "", districtName = "";
    $.ajax({
        type: "GET",
        url: "GetCountry",
        contentType: "application/json",
        processData: false,
        data: "id=" + $('#CountryIdUpdateModal').val(),
        async: null,
        success: function (data) {
            $.each(data.countryNames, function (k, v) {
                countryName += v.name;
                countryName += " ";
            });
        },
        error: function () {
            alert("Error");
        }
    });
    $.ajax({
        type: "GET",
        url: "GetCity",
        contentType: "application/json",
        processData: false,
        data: "id=" + $('#CityIdUpdateModal').val(),
        async: null,
        success: function (data) {
            $.each(data.cityNames, function (k, v) {
                cityName += v.name;
                cityName += " ";
            });
        },
        error: function () {
            alert("Error");
        }
    });
    $.ajax({
        type: "GET",
        url: "GetDistrict",
        contentType: "application/json",
        processData: false,
        data: "id=" + $('#DistrictIdUpdateModal').val(),
        async: null,
        success: function (data) {
            $.each(data.districtNames, function (k, v) {
                districtName += v.name;
                districtName += " ";
            });
        },
        error: function () {
            alert("Error");
        }
    });
    var index = updatedWarehouseId.slice(10);

    var html = '<td class="text-center">' + $('#NameUpdateModal').val() + '</td>' +
        '<td class="text-center">' + countryName + '</td>' +
        '<td class="text-center">' + cityName + '</td>' +
        '<td class="text-center">' + districtName + '</td>' +
        '<td class="text-center">' + $('#AddressUpdateModal').val() + '</td>';
    if ($('#ActiveUpdateModal').is(':checked')) {
        html += '<td class="text-center"><span class="label label-xl font-weight-bold label-light-success label-inline">Aktif</span></td>';
    }
    else {
        html += '<td class="text-center"><span class="label label-xl font-weight-bold label-light-danger label-inline">Pasif</span></td>';
    }
    html += '<td class="text-center">' +
        '<button type="button" class="btn btn-sm btn-clean btn-text-primary btn-icon" title = "Depo Bilgilerini Güncelle" data-toggle="modal" data-target="#warehouseUpdateModal" onclick="warehouseDisplay(this);" data-id ="' + index + '">' +
        '<span class="svg-icon svg-icon-lg svg-icon-warning">' +
        '<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">' +
        '<g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">' +
        '<rect x="0" y="0" width="24" height="24"></rect>' +
        '<path d="M8,17.9148182 L8,5.96685884 C8,5.56391781 8.16211443,5.17792052 8.44982609,4.89581508 L10.965708,2.42895648 C11.5426798,1.86322723 12.4640974,1.85620921 13.0496196,2.41308426 L15.5337377,4.77566479 C15.8314604,5.0588212 16,5.45170806 16,5.86258077 L16,17.9148182 C16,18.7432453 15.3284271,19.4148182 14.5,19.4148182 L9.5,19.4148182 C8.67157288,19.4148182 8,18.7432453 8,17.9148182 Z" fill="#000000" fill-rule="nonzero" transform="translate(12.000000, 10.707409) rotate(-135.000000)translate(-12.000000, -10.707409)"></path>' +
        '<rect fill="#000000" opacity="0.3" x="5" y="20" width="15" height="2" rx="1"></rect>' +
        '</g>' +
        '</svg>' +
        '</span>' +
        '</button >' +
        '</td >' +
        '<td class="text-center">' +
        '<button type="button" class="btn btn-sm btn-clean btn-text-primary btn-icon" title="Depoyu Sil" onclick="warehouseDelete(this);" data-id ="' + index + '">' +
        '<span class="svg-icon svg-icon-lg svg-icon-danger">' +
        '<svg xmlns = "http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1" >' +
        '<g stroke = "none" stroke-width="1" fill="none" fill-rule="evenodd" >' +
        '<rect x="0" y="0" width="24" height="24"></rect>' +
        '<path d="M3.5,21 L20.5,21 C21.3284271,21 22,20.3284271 22,19.5 L22,8.5 C22,7.67157288 21.3284271,7 20.5,7 L10,7 L7.43933983,4.43933983 C7.15803526,4.15803526 6.77650439,4 6.37867966,4 L3.5,4 C2.67157288,4 2,4.67157288 2,5.5 L2,19.5 C2,20.3284271 2.67157288,21 3.5,21 Z" fill="#000000" opacity="0.3"></path>' +
        '<path d="M10.5857864,14 L9.17157288,12.5857864 C8.78104858,12.1952621 8.78104858,11.5620972 9.17157288,11.1715729 C9.56209717,10.7810486 10.1952621,10.7810486 10.5857864,11.1715729 L12,12.5857864 L13.4142136,11.1715729 C13.8047379,10.7810486 14.4379028,10.7810486 14.8284271,11.1715729 C15.2189514,11.5620972 15.2189514,12.1952621 14.8284271,12.5857864 L13.4142136,14 L14.8284271,15.4142136 C15.2189514,15.8047379 15.2189514,16.4379028 14.8284271,16.8284271 C14.4379028,17.2189514 13.8047379,17.2189514 13.4142136,16.8284271 L12,15.4142136 L10.5857864,16.8284271 C10.1952621,17.2189514 9.56209717,17.2189514 9.17157288,16.8284271 C8.78104858,16.4379028 8.78104858,15.8047379 9.17157288,15.4142136 L10.5857864,14 Z" fill="#000000" />' +
        '</g>' +
        '</svg>' +
        '</span>' +
        '</button>' +
        '</td>' +
        '</tr>';
    $('#Warehouse_' + index + '').html(html);
    $('input[name="Warehouses[' + index + '].Name"]').val($('#NameUpdateModal').val());
    $('input[name="Warehouses[' + index + '].CountryId"]').val($('#CountryIdUpdateModal').val());
    $('input[name="Warehouses[' + index + '].CityId"]').val($('#CityIdUpdateModal').val());
    $('input[name="Warehouses[' + index + '].DistrictId"]').val($('#DistrictIdUpdateModal').val());
    $('input[name="Warehouses[' + index + '].Address"]').val($('#AddressUpdateModal').val());
    if ($('#ActiveUpdateModal').is(':checked'))
        $('input[name="Warehouses[' + index + '].Active"]').val(true);
    else
        $('input[name="Warehouses[' + index + '].Active"]').val(false);
}

function warehouseUpdateById(id) {
    _row = $("#warehouseTable button[data-id='" + id + "']")
        .parents("tr")[0];

    $(_row).after(productBuildTableRow(id));
    $(_row).remove();
}

function formClear() {
    $("#NameAddModal").val("");
    $("#AddressAddModal").val("");
    $("#CountryIdAddModal").val("").change();
    $("#CityIdAddModal").val("").change();
    $("#DistrictIdAddModal").val("").change();
    $("#ActiveAddModal").val("").change();
}

function GetCitiesAddModal(e) {
    if ($(e).val() == 1)
        $("#DistrictIdAddModal").hide();
    else
        $("#DistrictIdAddModal").show();
    countryId = $(e).val();

    if ($(e).val() == "" || $(e).val() == null) {
        $("#CityIdAddModal").html('');
        $("#CityIdAddModal").append('<option value="">ŞEHİR SEÇİNİZ</option>');
        $("#DistrictIdAddModal").html('');
        $("#DistrictIdAddModal").append('<option value="">İLÇE SEÇİNİZ</option>');
    }
    else {
        $.ajax({
            type: "GET",
            url: "GetCities",
            contentType: "application/json",
            processData: false,
            data: "id=" + $(e).val(),
            async: null,
            success: function (data) {
                PutCities(data);
            },
            error: function () {
                alert("Error");
            }
        });
        function PutCities(data) {
            if (data != null) {
                $("#CityIdAddModal").html('');
                $("#CityIdAddModal").append('<option value="">ŞEHİR SEÇİNİZ</option>');
                $.each(data, function (k, v) {
                    var cityName = "";
                    $.each(v.cityNames, function (l, y) {
                        cityName += y.name;
                        cityName += " ";
                    });
                    $("#CityIdAddModal").append('<option value="' + v.id + '">' + cityName + '</option>');
                })
            }
        };
    }
}

function GetDistrictsAddModal(e) {
    if (countryId != 1) {
        if ($(e).val() == "" || $(e).val() == null) {
            $("#DistrictIdAddModal").html('');
            $("#DistrictIdAddModal").append('<option value="">İLÇE SEÇİNİZ</option>');
        }
        else {
            $.ajax({
                type: "GET",
                url: "GetDistricts",
                contentType: "application/json",
                processData: false,
                data: "id=" + $(e).val(),
                async: null,
                success: function (data) {
                    PutDistricts(data);
                },
                error: function () {
                    alert("Error");
                }
            });
            function PutDistricts(data) {
                if (data != null) {
                    $("#DistrictIdAddModal").html('');
                    $("#DistrictIdAddModal").append('<option value="">İLÇE SEÇİNİZ</option>');
                    $.each(data, function (k, v) {
                        var districtName = "";
                        $.each(v.districtNames, function (l, y) {
                            districtName += y.name;
                            districtName += " ";
                        });
                        $("#DistrictIdAddModal").append('<option value="' + v.id + '">' + districtName + '</option>');
                    })
                }
            };
        }
    }
    else {
        $("#DistrictIdAddModal").html('');
        $("#DistrictIdAddModal").append('<option value="">İLÇE SEÇİNİZ</option>');
    }
}

function GetCitiesUpdateModal(e) {
    if ($(e).val() == 1)
        $("#DistrictIdUpdateModal").hide();
    else
        $("#DistrictIdUpdateModal").show();
    countryId = $(e).val();

    if ($(e).val() == "" || $(e).val() == null) {
        $("#CityIdUpdateModal").html('');
        $("#CityIdUpdateModal").append('<option value="">ŞEHİR SEÇİNİZ</option>');
        $("#DistrictIdUpdateModal").html('');
        $("#DistrictIdUpdateModal").append('<option value="">İLÇE SEÇİNİZ</option>');
    }
    else {
        $.ajax({
            type: "GET",
            url: "GetCities",
            contentType: "application/json",
            processData: false,
            data: "id=" + $(e).val(),
            async: null,
            success: function (data) {
                PutCities(data);
            },
            error: function () {
                alert("Error");
            }
        });
        function PutCities(data) {
            if (data != null) {
                $("#CityIdUpdateModal").html('');
                $("#CityIdUpdateModal").append('<option value="">ŞEHİR SEÇİNİZ</option>');
                $.each(data, function (k, v) {
                    var cityName = "";
                    $.each(v.cityNames, function (l, y) {
                        cityName += y.name;
                        cityName += " ";
                    });
                    $("#CityIdUpdateModal").append('<option value="' + v.id + '">' + cityName + '</option>');
                })
            }
        };
    }
}

function GetDistrictsUpdateModal(e) {
    if (countryId != 1) {
        if ($(e).val() == "" || $(e).val() == null) {
            $("#DistrictIdUpdateModal").html('');
            $("#DistrictIdUpdateModal").append('<option value="">İLÇE SEÇİNİZ</option>');
        }
        else {
            $.ajax({
                type: "GET",
                url: "GetDistricts",
                contentType: "application/json",
                processData: false,
                data: "id=" + $(e).val(),
                async: null,
                success: function (data) {
                    PutDistricts(data);
                },
                error: function () {
                    alert("Error");
                }
            });
            function PutDistricts(data) {
                if (data != null) {
                    $("#DistrictIdUpdateModal").html('');
                    $("#DistrictIdUpdateModal").append('<option value="">İLÇE SEÇİNİZ</option>');
                    $.each(data, function (k, v) {
                        var districtName = "";
                        $.each(v.districtNames, function (l, y) {
                            districtName += y.name;
                            districtName += " ";
                        });
                        $("#DistrictIdUpdateModal").append('<option value="' + v.id + '">' + districtName + '</option>');
                    })
                }
            };
        }
    }
    else {
        $("#DistrictIdUpdateModal").html('');
        $("#DistrictIdUpdateModal").append('<option value="">İLÇE SEÇİNİZ</option>');
    }
}