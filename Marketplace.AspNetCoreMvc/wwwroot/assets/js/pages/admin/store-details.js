$(document).ready(function () {
    GetLocationNames();
    GetCompanyType();
    GetApplicantPosition();
})

var rowIndex;

$(document).on("click", "#documentTable td", function (b) {
    rowIndex = $(this).attr("id");
});

$("#documentForm").on("submit", function (e) {

    e.preventDefault();

    var selectedStatus = $("input[name='documentStatusIdModal']:checked").val();

    var documentData = new FormData();
    documentData.append("documentIdModal", $('#documentIdModal').val());
    documentData.append("documentSellerIdModal", $('#documentSellerIdModal').val());
    documentData.append("documentStoreTypeIdModal", $('#documentStoreTypeIdModal').val());
    documentData.append("documentDescriptionModal", $('#documentDescriptionModal').val());
    documentData.append("documentStatusIdModal", selectedStatus);

    $.ajax({
        type: "POST",
        url: "UpdateSellerDocumentStatus",
        data: documentData,
        contentType: false,
        processData: false,
        success: function (document) {
            $("#documentModal").modal('hide');

            var storeTypeId = $('#documentStoreTypeIdModal').val();
            var sellerId = $('#documentSellerIdModal').val();
            var documentId = $('#documentIdModal').val();
            var documentStatusId = selectedStatus;
            var documentDescription = $('#documentDescriptionModal').val();

            Swal.fire({
                icon: 'success',
                title: 'BAŞARILI!',
                text: 'Döküman başarılı şekilde güncellendi.',
                showConfirmButton: false,
                timer: 1500
            })
            if (document == "CriticalOperation") {
                criticalOperation();
                refreshTable(selectedStatus, rowIndex, storeTypeId, sellerId, documentId, documentStatusId, documentDescription);
            } else {
                refreshTable(selectedStatus, rowIndex, storeTypeId, sellerId, documentId, documentStatusId, documentDescription);
            }
        }
    })
})

$("#statusForm").on("submit", function (e) {

    e.preventDefault();

    var sendData = new FormData(this);

    $.ajax({
        type: "POST",
        url: "UpdateSellerStatus",
        data: sendData,
        contentType: false,
        processData: false,
        success: function (data) {
            Swal.fire({
                icon: 'success',
                title: data,
                showConfirmButton: false,
                timer: 1500
            })

            $('#criticalOperationForm [value="' + globalStatusCode + '"]').prop('checked', true);
            $("#AdminSellerStatusCommentCritical").val($("#AdminSellerStatusComment").val())
        }
    })
})

$("#criticalOperationForm").on("submit", function (e) {

    e.preventDefault();

    var modalSendData = new FormData(this);

    $.ajax({
        type: "POST",
        url: "UpdateSellerStatus",
        data: modalSendData,
        contentType: false,
        processData: false,
        success: function (data) {
            Swal.fire({
                icon: 'success',
                title: 'BAŞARILI!',
                text: 'Hesap durumu başarılı şekilde güncellendi.',
                showConfirmButton: false,
                timer: 1500
            })
            $("#criticalOperationModal").modal('hide');
            $('#statusForm [value="' + globalStatusCodeCritical + '"]').prop('checked', true);
            $("#AdminSellerStatusComment").val($("#AdminSellerStatusCommentCritical").val())
        }
    })
})

function GetCompanyType() {
    var companyTypeName = "";
    if (companyStoreCompanyTypeId != null) {
        $.ajax({
            type: "GET",
            url: "GetCompanyType",
            contentType: "application/json",
            processData: false,
            data: "id=" + companyStoreCompanyTypeId,
            async: null,
            success: function (data) {
                $.each(data.companyTypeNames, function (k, v) {
                    companyTypeName += v.name;
                    companyTypeName += " ";
                });
            },
            error: function () {
                alert("Error");
            }
        });
        $("#companyTypeName").text(companyTypeName);
    }
}

function GetApplicantPosition() {
    var positionName = "";
    if (companyStoreApplicantPositionId != null) {
        $.ajax({
            type: "GET",
            url: "GetApplicantPosition",
            contentType: "application/json",
            processData: false,
            data: "id=" + companyStoreApplicantPositionId,
            async: null,
            success: function (data) {
                $.each(data.applicantPositionNames, function (k, v) {
                    positionName += v.name;
                    positionName += " ";
                });
            },
            error: function () {
                alert("Error");
            }
        });
        $("#applicantPositionName").text(positionName);
    }
}

function GetLocationNames() {
    var countryName = "", cityName = "", districtName = "", taxCityName = "";
    if (companyStoreCountryId == null) {
        $.ajax({
            type: "GET",
            url: "GetCountry",
            contentType: "application/json",
            processData: false,
            data: "id=" + personalStoreCountryId,
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
            data: "id=" + personalStoreCityId,
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
        if (personalStoreDistrictId != 0) {
            AjaxIstekleri("GET", null, "GetDistrict", "id=" + personalStoreDistrictId, function (data) {
                $.each(data.districtNames, function (k, v) {
                    districtName += v.name;
                    districtName += " ";
                });
            });
            $("#personalStoreDistrict").text(districtName);
        }
        $("#personalStoreCountry").text(countryName);
        $("#personalStoreCity").text(cityName);
    }
    else if (personalStoreCountryId == null) {
        $.ajax({
            type: "GET",
            url: "GetCountry",
            contentType: "application/json",
            processData: false,
            data: "id=" + companyStoreCountryId,
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
            data: "id=" + companyStoreCityId,
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
        if (companyStoreDistrictId != 0) {
            $.ajax({
                type: "GET",
                url: "GetDistrict",
                contentType: "application/json",
                processData: false,
                data: "id=" + companyStoreDistrictId,
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
            $("#companyStoreDistrict").text(districtName);
        }
        $.ajax({
            type: "GET",
            url: "GetCity",
            contentType: "application/json",
            processData: false,
            data: "id=" + companyStoreTaxCityId,
            async: null,
            success: function (data) {
                $.each(data.cityNames, function (k, v) {
                    taxCityName += v.name;
                    taxCityName += " ";
                });
            },
            error: function () {
                alert("Error");
            }
        });
        $("#companyStoreCountry").text(countryName);
        $("#companyStoreCity").text(cityName);
        $("#companyStoreTaxCity").text(taxCityName);
    }
}

function fillModal(storeTypeId, sellerId, documentId, documentStatusId, documentDescription) {

    formClear();
    var documentStatusButtons = document.getElementsByName("documentStatusIdModal");

    for (var statusButton of documentStatusButtons) {
        console.log(statusButton.getAttribute("value"));

        var inputValue = statusButton.getAttribute("value");
        if (inputValue == documentStatusId) {
            statusButton.checked = true;
            break;
        }
    }

    $("#documentIdModal").val(documentId);
    $("#documentSellerIdModal").val(sellerId);
    $("#documentStoreTypeIdModal").val(storeTypeId);
    $("#documentDescriptionModal").val(documentDescription);
}

function formClear() {
    var documentStatusButtons = document.getElementsByName("documentStatusIdModal");
    $("#documentIdModal").val("");
    $("#documentSellerIdModal").val("");
    $("#documentStoreTypeIdModal").val("");
    $("#documentDescriptionModal").val("");
    for (var statusButton of documentStatusButtons) {
        statusButton.removeAttribute("checked");
    }
}

function criticalOperation() {
    $("#criticalOperationModal").modal('show');
}

function refreshTable(selectedStatus, rowIndex, storeTypeId, sellerId, documentId, documentStatusId, documentDescription) {

    var id = $("#" + rowIndex);

    var htmlLink = '<a class="float-right" data-toggle="modal" data-target="#documentModal" onclick="fillModal(' + storeTypeId + ', ' + sellerId + ', ' + documentId + ', ' + documentStatusId + ', \'' + documentDescription + '\')"><label class="text-danger font-weight-bold cursor-pointer"><ins>Düzenle</ins></label></a>'

    if (selectedStatus == 1) {
        $(id).html("Yüklenmedi" + htmlLink);
    }
    else if (selectedStatus == 2) {
        $(id).html("Onay Bekliyor" + htmlLink);
    }
    else if (selectedStatus == 3) {
        $(id).html("Onaylandı" + htmlLink);
    }
    else {
        $(id).html("Onaylanmadı" + htmlLink);
    }
}