$(document).ready(function () {
    isChecked();
    GetCities($("#CountryId"));
});

function isChecked() {
    if (document.getElementById("TermsAcceptance").checked) {
        $("#registerBtn").attr("disabled", false);
    }
    else {
        $("#registerBtn").attr("disabled", true);
    }
}

function LoginFormLoad() {
    $('#registerTab').removeClass('active');
    $('#registerFormLink').removeClass('active');
    $('#loginTab').addClass('active');
    $('#loginFormLink').addClass('active');
}
function RegisterFormLoad() {
    $('#loginTab').removeClass('active');
    $('#loginFormLink').removeClass('active');
    $('#registerTab').addClass('active');
    $('#registerFormLink').addClass('active');
}

function GetCities(e) {
    if ($(e).val() == "" || $(e).val() == null) {
        $("#CityId").html('');
        $("#CityId").append('<option value="">ŞEHİR SEÇİNİZ</option>');
        $("#DistrictId").html('');
        $("#DistrictId").append('<option value="">İLÇE SEÇİNİZ</option>');
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
                $("#CityId").html('');
                $("#CityId").append('<option value="">ŞEHİR SEÇİNİZ</option>');
                $.each(data, function (k, v) {
                    var cityName = "";
                    $.each(v.cityNames, function (l, y) {
                        cityName += y.name;
                        cityName += " ";
                    });
                    $("#CityId").append('<option value="' + v.id + '">' + cityName + '</option>');
                })
            }
        };
    }
}

function GetDistricts(e) {
    if ($(e).val() == "" || $(e).val() == null) {
        $("#DistrictId").html('');
        $("#DistrictId").append('<option value="">İLÇE SEÇİNİZ</option>');
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
        AjaxIstekleri("GET", null, "GetDistricts", "id=" + $(e).val(), PutDistricts);
        function PutDistricts(data) {
            if (data != null) {
                $("#DistrictId").html('');
                $("#DistrictId").append('<option value="">İLÇE SEÇİNİZ</option>');
                $.each(data, function (k, v) {
                    var districtName = "";
                    $.each(v.districtNames, function (l, y) {
                        districtName += y.name;
                        districtName += " ";
                    });
                    $("#DistrictId").append('<option value="' + v.id + '">' + districtName + '</option>');
                })
            }
        };
    }
}