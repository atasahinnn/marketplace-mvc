$(document).ready(function () {
    AjaxIstekleri("GET", null, "GetCategoriesForProduct", "categoryId=-1", AddFirstCategory);
});
var path = "";
var numberPattern = /\d+/g;
var categoryId;

function AddFirstCategory(data) {
    $("#CategoryId0").append('<option value="">---Seçiniz---</option>');
    $.each(data, function (k, v) {
        if (v.topCategoryId == null) {
            var categoryName = "";
            for (var i = 0; i < v.categoryNames.length; i++) {
                categoryName += v.categoryNames[i].name;
                if (i != v.categoryNames.length - 1) {
                    categoryName += " - ";
                }
            }
            $("#CategoryId0").append('<option value="' + v.id + '">' + categoryName + '</option>');
            categoryId = v.id;
        }
    })
    if ($("#CategoryId0").find(':selected').val() != "") {
        path = '/' + $("#CategoryId0").find(':selected').text();
    }
    $('#path').text(path);
    if ($('#CategoryId0').val() == "") {
        $('#submitButton').prop('disabled', true);
    }
    else
        document.getElementById("categoryId").value = categoryId;
};

function AddSubCategory(e) {

    var controlGrouping = "";

    var childElementCount = document.getElementById("elements").childElementCount;
    var subCategoryNumber = Number($(e).attr("id").match(numberPattern));
    for (var i = ++subCategoryNumber; i < 20; i++) {
        $('#CategoryGroupId' + i + '').remove();
        $('#spanTag' + i + '').remove();
    }
    path = "";
    fullPath = "";
    for (var i = 0; i < subCategoryNumber; i++) {
        if (i == 0) {
            if ($('#CategoryId' + i + '').find(':selected').val() != "") {
                path += '<strong> Secilen Kategori:</strong> ' + $('#CategoryId' + i + '').find(':selected').text();
                fullPath +=  $('#CategoryId' + i + '').find(':selected').text();
                controlGrouping = $('#CategoryId' + i).find(':selected').text();
                categoryId = $('#CategoryId' + i + '').find(':selected').val();
            }
        }
        else {
            if ($('#CateogoryId' + i + '').find(':selected').val() != "") {
                path += ' > ' + $('#CategoryId' + i + '').find(':selected').text();
                fullPath += ' > ' + $('#CategoryId' + i + '').find(':selected').text();
                controlGrouping = $('#CategoryId' + i).find(':selected').text();
                categoryId = $('#CategoryId' + i + '').find(':selected').val();
            }
        }
        
    }
    $('#path').text("");
    $('#path').append(path);
    document.getElementById("controlGrouping").value = controlGrouping;
    document.getElementById("fullPath").value = fullPath;

    var html = '';
    var isFind = false;
    html += '<div id="CategoryGroupId' + subCategoryNumber + '" class=" col-md-3 col-12 mt-3">' +
            '<select size="8" class="w-100" id="CategoryId' + subCategoryNumber + '" onchange="AddSubCategory(this)">';

    AjaxIstekleri("GET", null, "GetCategoriesForProduct", "categoryId=" + $(e).val(), AddCategory);
    function AddCategory(data) {
        if (data != null) {
            $.each(data, function (k, v) {
                var categoryName = "";
                for (var i = 0; i < v.categoryNames.length; i++) {
                    categoryName += v.categoryNames[i].name;
                    if (i != v.categoryNames.length - 1) {
                        categoryName += " - ";
                    }
                }
                html += '<option value="' + v.id + '">' + categoryName + '</option>';
                isFind = true;
                categoryId = v.id
            });
        }
    }

    html += '</select></div>';
    if (isFind) {
        $('#elements').append(html);
        $('#submitButton').prop('disabled', true);
    }
    else {
        $('#submitButton').prop('disabled', false);
        document.getElementById("categoryId").value = categoryId;
        if ($('#CategoryId' + --subCategoryNumber + '').val() == "") {
            $('#submitButton').prop('disabled', true);
        }
    }

};
