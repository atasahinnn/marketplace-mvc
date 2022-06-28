$(document).ready(function () {
    GetCities($("#CountryId"));
    GetTaxCities($("#CountryId"));
});

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