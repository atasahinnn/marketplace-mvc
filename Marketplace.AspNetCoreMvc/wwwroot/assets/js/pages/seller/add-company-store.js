$(document).ready(function () {
    GetCities($("#CountryId"));
    GetTaxCities($("#CountryId"));
});

function CheckStoreName(e) {
    AjaxIstekleri("GET", null, "StoreNameControl", "storeName=" + $(e).val(), ControlStoreName);
    function ControlStoreName(data) {
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
    var storeName = document.getElementById('StoreName');
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

function GetTaxCities(e) {
    $.ajax({
        type: "GET",
        url: "GetCities",
        contentType: "application/json",
        processData: false,
        data: "id=" + $(e).val(),
        async: null,
        success: function (data) {
            PutTaxCities(data);
        },
        error: function () {
            alert("Error");
        }
    });
    function PutTaxCities(data) {
        if (data != null) {
            $("#TaxCityId").html('');
            $.each(data, function (k, v) {
                var taxCityName = "";
                $.each(v.cityNames, function (l, y) {
                    taxCityName += y.name;
                    taxCityName += " ";
                });
                if (selectedTaxCityId == v.id)
                    $("#TaxCityId").append('<option value="' + v.id + '"selected>' + taxCityName + '</option>');
                else
                    $("#TaxCityId").append('<option value="' + v.id + '">' + taxCityName + '</option>');
            })
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
                    $("#DistrictId").append('<option value="' + v.id + '"selected>' + districtName + '</option>');
                else
                    $("#DistrictId").append('<option value="' + v.id + '">' + districtName + '</option>');
            })
        }
    };
}