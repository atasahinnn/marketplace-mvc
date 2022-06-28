$(document).ready(function () {
    $("#brandCheckBoxSearch").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#brandCheckbox div label").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $("#categoryCheckBoxSearch").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#categoryCheckbox div label").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});