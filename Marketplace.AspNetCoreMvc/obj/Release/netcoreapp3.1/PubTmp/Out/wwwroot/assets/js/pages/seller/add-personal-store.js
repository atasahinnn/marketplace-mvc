$(document).ready(function () {
    GetCities($("#CountryId"));
});

$('#addPersonalStoreForm input[name=libyaRadioButton]').on('change', function () {
    CheckedRadioButton();
});

const form = document.getElementById('addPersonalStoreForm');
const logoInput = document.getElementById('LogoFile');

function CheckedRadioButton() {
    var form = $("#addPersonalStoreForm");
    var checkedValue = form.find("input[name=libyaRadioButton]:checked").val();
    GetInputBySelectedRadioButton(checkedValue);
    resetFormValidator(form);
}

function resetFormValidator(formId) {
    $(formId).removeData('validator');
    $(formId).removeData('unobtrusiveValidation');
    $.validator.unobtrusive.parse(formId);
}

function GetInputBySelectedRadioButton(val) {

    var panelDiv = document.getElementById("radioButtonDiv");
    panelDiv.innerHTML = " ";

    var input = document.createElement("input");
    var span = document.createElement("span");

    if (val == 1) {

        input.setAttribute("name", "CitizenshipNumber");
        input.setAttribute("type", "text");
        input.setAttribute("class", "form-control text-center");
        input.setAttribute("placeholder", "VAT. NO");
        input.setAttribute("id", "CitizenshipNumber");
        input.setAttribute("data-val", "true");
        input.setAttribute("data-val-required", "Kimlik numarası boş geçilemez.");

        span.setAttribute("name", "CitizenshipNumber");
        span.setAttribute("class", "text-danger");
        span.setAttribute("id", "CitizenshipNumber");
        span.setAttribute("data-valmsg-for", "CitizenshipNumber");
        span.setAttribute("data-valmsg-replace", "true");

        panelDiv.appendChild(input);
        panelDiv.appendChild(span);
    }
    else if (val == 2) {

        input.setAttribute("name", "DrivingLicenceNumber");
        input.setAttribute("type", "text");
        input.setAttribute("class", "form-control text-center");
        input.setAttribute("placeholder", "EHLİYET BELGE NUMARASI");
        input.setAttribute("id", "DrivingLicenceNumber");
        input.setAttribute("data-val", "true");
        input.setAttribute("data-val-required", "Ehliyet numarası boş geçilemez.");

        span.setAttribute("name", "DrivingLicenceNumber");
        span.setAttribute("class", "text-danger");
        span.setAttribute("id", "DrivingLicenceNumber");
        span.setAttribute("data-valmsg-for", "DrivingLicenceNumber");
        span.setAttribute("data-valmsg-replace", "true");

        panelDiv.appendChild(input);
        panelDiv.appendChild(span);
    }
    else {

        input.setAttribute("name", "PassportNumber");
        input.setAttribute("type", "text");
        input.setAttribute("class", "form-control text-center");
        input.setAttribute("placeholder", "PASAPORT NUMARASI");
        input.setAttribute("id", "PassportNumber");
        input.setAttribute("data-val", "true");
        input.setAttribute("data-val-required", "Pasaport numarası boş geçilemez.");

        span.setAttribute("name", "PassportNumber");
        span.setAttribute("class", "text-danger");
        span.setAttribute("id", "PassportNumber");
        span.setAttribute("data-valmsg-for", "PassportNumber");
        span.setAttribute("data-valmsg-replace", "true");

        panelDiv.appendChild(input);
        panelDiv.appendChild(span);
    }
}

function CheckStoreName(e) {
    $.ajax({
        type: "GET",
        url: "StoreNameControl",
        contentType: "application/json",
        processData: false,
        data: "storeName=" + $(e).val(),
        async: null,
        success: function (data) {
            ControlStoreName(data);
        },
        error: function () {
            alert("Error");
        }
    });
    function ControlStoreName(data) {
        console.log(data);
        if (data != null) {
            $("#StoreNameControl").text(data);
        }
        else {
            $("#StoreNameControl").text("");
        }
    }
}

function ConvertToEnglishCharacter(text) {
    var trLetters = {
        'çÇ': 'c',
        'ğĞ': 'g',
        'şŞ': 's',
        'uU': 'u',
        'ıİ': 'i',
        'öÖ': 'o',
        'üÜ': 'u'
    };
    for (var key in trLetters) {
        text = text.replace(new RegExp('[' + key + ']', 'g'), trLetters[key]);
    }

    return text.replace(/[^-a-zA-Z0-9\s]+/ig, '')
        .replace(/\s/gi, "-")
        .replace(/[-]+/gi, "-")
        .toLowerCase();
}

function StoreUrl() {
    var storeName = document.getElementById('storeName');
    var labelText = document.getElementById('storeLabel');
    var storeNameToUrl = ConvertToEnglishCharacter(storeName.value);
    console.log(storeNameToUrl);
    if (storeName.value == "") {
        labelText.innerHTML = "";
    }
    else {
        labelText.innerHTML = "myshanta.com/seller/account/" + storeNameToUrl;
    }
}

function GetCities(e) {
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
            $("#CityId").html('');
            $.each(data, function (k, v) {
                var cityName = "";
                $.each(v.cityNames, function (l, y) {
                    cityName += y.name;
                    cityName += " ";
                });
                if (selectedCityId == v.id)
                    $("#CityId").append('<option value="' + v.id + '" selected>' + cityName + '</option>');
                else
                    $("#CityId").append('<option value="' + v.id + '">' + cityName + '</option>');
            })
            $("#CityId").change();
        }
    };
}

function GetDistricts(e) {
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
            $("#DistrictId").html('');
            $.each(data, function (k, v) {
                var districtName = "";
                $.each(v.districtNames, function (l, y) {
                    districtName += y.name;
                    districtName += " ";
                });
                if (selectedDistictId == v.id)
                    $("#DistrictId").append('<option value="' + v.id + '" selected>' + districtName + '</option>');
                else
                    $("#DistrictId").append('<option value="' + v.id + '">' + districtName + '</option>');
            })
        }
    };
}
