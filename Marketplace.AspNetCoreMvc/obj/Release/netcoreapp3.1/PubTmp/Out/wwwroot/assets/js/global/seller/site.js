$(document).ready(function () {
    $(".select2").select2()
})

function AjaxIstekleri(ajaxType, async, action, sendData, successFunction, contentType = "application/json") {
    $.ajax({
        type: ajaxType,
        url: action,
        contentType: contentType,
        processData: false,
        data: sendData,
        async: async,
        success: function (data) {
            successFunction(data);
        },
        error: function (data) {
            successFunction("Error");
        }
    });
}