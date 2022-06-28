$(document).ready(function () {
    ChangeGroupForm();
    ChangePropertyItemNames();
});
var selectedGruopPropertyValue;

function ChangePropertyItemNames() {
    selectedGruopPropertyValue = $('#groupPropertyId').find(":selected").val();
    $.ajax({
        type: "GET",
        url: "GetPropertyItems",
        contentType: "application/json",
        processData: false,
        data: "propertyId=" + selectedGruopPropertyValue,
        async: null,
        success: function (data) {
            PutItemPropertyNames(data);
        },
        error: function () {
            alert("Error");
        }
    });
    function PutItemPropertyNames(data) {
        $("#groupPropertyItemId").empty();
        $.each(data[0], function (k, v) {
            var propertyItemName = "";
            $.each(v.propertyItemNames, function (l, y) {
                propertyItemName += y.name +" ";
            })
            $("#groupPropertyItemId").append("<option value=" + v.id + ">" + propertyItemName + "</option>");
        });
    }
};

function ChangeGroupForm() {
    var selectedRadio = $("input[id='gruopStatus']:checked").val();
    if (selectedRadio == "true") {
        document.getElementById("group1").classList.remove("d-none");
        document.getElementById("group2").classList.add("d-none");
    }
    else {
        document.getElementById("group1").classList.add("d-none");
        document.getElementById("group2").classList.remove("d-none");
    }
}
