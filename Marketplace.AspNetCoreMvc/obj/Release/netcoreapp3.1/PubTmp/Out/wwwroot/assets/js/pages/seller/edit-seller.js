$(document).ready(function () {
    GetCities($("#CountryId"));
});

function ShowPasswordModal() {
    $('#password-modal').modal('show');
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
    AjaxIstekleri("GET", null, "GetDistricts", "id=" + $(e).val(), PutDistricts);
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
