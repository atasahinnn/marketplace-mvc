$(document).ready(function () {
    var productImage1 = new KTImageInput('kt_image_1');
    productImage1.on('change', function (imageInput) {
        setTimeout(function () {
            ProductImageChange();
        },500)
    });
    productImage1.on('cancel', function (imageInput) {
        setTimeout(function () {
            ProductImageDelete();
        }, 500)
    });

    var productImage2 = new KTImageInput('kt_image_2');
    productImage2.on('change', function (imageInput) {
        setTimeout(function () {
            ProductImageChange();
        }, 500)
    });
    productImage2.on('cancel', function (imageInput) {
        setTimeout(function () {
            ProductImageDelete();
        }, 500)
    });

    var productImage3 = new KTImageInput('kt_image_3');
    productImage3.on('change', function (imageInput) {
        setTimeout(function () {
            ProductImageChange();
        }, 500)
    });
    productImage3.on('cancel', function (imageInput) {
        setTimeout(function () {
            ProductImageDelete();
        }, 500)
    });

    var productImage4 = new KTImageInput('kt_image_4');
    productImage4.on('change', function (imageInput) {
        setTimeout(function () {
            ProductImageChange();
        }, 500)
    });
    productImage4.on('cancel', function (imageInput) {
        setTimeout(function () {
            ProductImageDelete();
        }, 500)
    });

    var productImage5 = new KTImageInput('kt_image_5');
    productImage5.on('change', function (imageInput) {
        setTimeout(function () {
            ProductImageChange();
        }, 500)
    });
    productImage5.on('cancel', function (imageInput) {
        setTimeout(function () {
            ProductImageDelete();
        }, 500)
    });

    var productImage6 = new KTImageInput('kt_image_6');
    productImage6.on('change', function (imageInput) {
        setTimeout(function () {
            ProductImageChange();
        }, 500)
    });
    productImage6.on('cancel', function (imageInput) {
        setTimeout(function () {
            ProductImageDelete();
        }, 500)
    });

    var productImage7 = new KTImageInput('kt_image_7');
    productImage7.on('change', function (imageInput) {
        setTimeout(function () {
            ProductImageChange();
        }, 500)
    });
    productImage7.on('cancel', function (imageInput) {
        setTimeout(function () {
            ProductImageDelete();
        }, 500)
    });

    var productImage8 = new KTImageInput('kt_image_8');
    productImage8.on('change', function (imageInput) {
        setTimeout(function () {
            ProductImageChange();
        }, 500)
    });
    productImage8.on('cancel', function (imageInput) {
        setTimeout(function () {
            ProductImageDelete();
        }, 500)
    });

    RunDraggable();
});

var selectedProperties = [];
var selectedPropertyItems = [];
var allPropertyItemsDetails = [];

function ProductImageChange() {
    var productImageInput = $(".image-input-wrapper");
    $.each(productImageInput, function (k, v) {
        if (!$(v).css("background-image").includes("/assets/media/img/seller/noimage.png")) {
            $("#CoverPhoto").css("background-image", $(v).css("background-image"));
            return false;
        }
    })
}

function ProductImageDelete() {
    var uploadedPhoto = false;
    var productImageInput = $(".image-input-wrapper");
    $.each(productImageInput, function (k, v) {
        if (!$(v).css("background-image").includes("/assets/media/img/seller/noimage.png")) {
            $("#CoverPhoto").css("background-image", $(v).css("background-image"));
            uploadedPhoto = true;
            return false;
        }
    })

    if (uploadedPhoto == false) {
        console.log(uploadedPhoto);
        $("#CoverPhoto").removeAttr("style");
        $("#CoverPhoto").attr("style", "background-image:url(/assets/media/img/seller/noimage.png); background-size:contain; background-position:center; width:100%; height:280px");
    }
}

function PropertySelected(e) {
    //Property ler özellik olarak seçildiyse varyasyon için seçebilmeyi engelleyen algoritma.
    for (var i = 0; i < Infinity; i++) {
        if ($('#property_' + i + '').val() == undefined)
            break;
        if ($(e).val() == "" && $(e).prev().val() == $('#property_' + i + '').val()) {
            $('#property_' + i + '').parent().removeClass("checkbox-disabled"); 
            $('#property_' + i + '').attr("disabled", false);
        }
        else if ($(e).prev().val() == $('#property_' + i + '').val()) {
            $('#property_' + i + '').parent().addClass("checkbox-disabled");
            $('#property_' + i + '').attr("disabled", true);
        }
    }
}

function PropertySelectedForVariation(e) {
    $('#createdVariations').empty();
    var propertyId = $(e).val();
    if ($(e).is(':checked')) {
        //Varyasyon için seçilen property yi özellik olarak seçebilmeyi engelleyen algoritma.
        for (var i = 0; i < Infinity; i++) {
            if ($('#ProductProperties_' + i + '__PropertyId').val() == undefined)
                break;
            if (propertyId == $('#ProductProperties_' + i + '__PropertyId').val()) {
                $('#ProductProperties_' + i + '__PropertyItemId').attr("disabled", true);
            }
        }
        var propertyName = "";
        $.ajax({
            type: "GET",
            url: "GetPropertyNames",
            contentType: "application/json",
            processData: false,
            data: "propertyId=" + propertyId,
            async: null,
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    if (i != 0)
                        propertyName += " - ";
                    propertyName += data[i].name;
                }
            },
            error: function () {
                alert("Error");
            }
        });
        //PropertyItem ları getiren algoritma.
        $.ajax({
            type: "GET",
            url: "GetPropertyItems",
            contentType: "application/json",
            processData: false,
            data: "propertyId=" + propertyId,
            async: null,
            success: function (data) {
                PutPropertyItem(data);
            },
            error: function () {
                alert("Error");
            }
        });
        function PutPropertyItem(data) {
            if (!selectedProperties.includes(propertyId)) {
                selectedProperties.push(propertyId);
            }
            var html = '<div id="propertyItem_' + propertyId + '" value="' + propertyId + '" class="col-12 col-sm-6 col-lg-3 col-md-4 pb-6"><div class="text-center"><h5>' + propertyName +'</h5></div><div class="form-control" style="height:250px"><select class="form-control select2" id="select_' + propertyId + '" onchange="PropertyItemSelected(this)"><option value="">Seçiniz</option>';
            $.each(data[0], function (k, v) {
                if (!allPropertyItemsDetails.some(e => e.id == v.id)) {
                    allPropertyItemsDetails.push(v);
                }
                var propertyItemName = "";
                $.each(v.propertyItemNames, function (l, y) {
                    propertyItemName += y.name;
                    propertyItemName += " ";
                });
                html += '<option value="' + v.id + '">' + propertyItemName + '</option>';
                //html += '<div class="checkbox-inline"><label class="checkbox checkbox-outline checkbox-outline-2x checkbox-primary"><input type="checkbox" name="propertyItem_' + v.id + '" value="' + v.id + '" onclick="PropertyItemSelected()"> <span></span>&nbsp;' + propertyItemName + '</label></div>';
            });
            html += '</select></div><div class="text-center mt-3"><button class="btn btn-danger pr-7 pl-7" onclick="RemovePropertyForVariation(' + propertyId + ')">Kaldır</button></div></div></div>';
            $("#propertyItems").append(html);
            $('#select_' + propertyId + '').select2();
        }
    }
    else {
        //Varyasyon için seçilen propertynin özellik olarak seçilebilmesini engelleyen algoritma.
        for (var i = 0; i < Infinity; i++) {
            if ($('#ProductProperties_' + i + '__PropertyId').val() == undefined)
                break;
            if (propertyId == $('#ProductProperties_' + i + '__PropertyId').val()) {
                $('#ProductProperties_' + i + '__PropertyItemId').attr("disabled", false);
            }
        }
        $('#propertyItem_' + propertyId).remove();
        const index = selectedProperties.indexOf(propertyId);
        if (index > -1) {
            selectedProperties.splice(index, 1);
        }

        //Seçili property item yoksa Seçenekleri Oluştur butonunu inaktif eden algoritma
        selectedPropertyItems = [];
        $('#propertyItems div div label').each(function () {
            selectedPropertyItems.push($(this).attr('value'));
        });
        if (selectedPropertyItems.length == 0)
            $('#createVariationButton').empty();
    }
    PropertyItemSelected();
}

function RemovePropertyForVariation(propertyId) {
    for (var i = 0; i < Infinity; i++) {
        if ($('#ProductProperties_' + i + '__PropertyId').val() == undefined)
            break;
        if (propertyId == $('#ProductProperties_' + i + '__PropertyId').val()) {
            $('#ProductProperties_' + i + '__PropertyItemId').attr("disabled", false);
        }
    }
    $('#propertyItem_' + propertyId).remove();
    const index = selectedProperties.indexOf(propertyId);
    if (index > -1) {
        selectedProperties.splice(index, 1);
    }

    for (var i = 0; i < Infinity; i++) {
        if ($('#property_' + i + '').val() == undefined)
            break;
        if ($('#property_' + i + '').val() == propertyId) {
            $('#property_' + i + '').prop("checked", false);
        }
    }

    //Seçili property item yoksa Seçenekleri Oluştur butonunu inaktif eden algoritma
    selectedPropertyItems = [];
    $('#propertyItems div div label').each(function () {
        selectedPropertyItems.push($(this).attr('value'));
    });
    if (selectedPropertyItems.length == 0)
        $('#createVariationButton').empty();
    $("#createdVariations").empty();
}

function PropertyItemSelected(e) {
    var propertyItem = allPropertyItemsDetails.filter(x => x.id == e.value);
    var propertyItemName = "";
    $.each(propertyItem[0].propertyItemNames, function (l, y) {
        propertyItemName += y.name;
        propertyItemName += " ";
    });
    selectedPropertyItems = [];
    $('#propertyItems div div label').each(function () {
        selectedPropertyItems.push($(this).attr('value'));
    });
    if (selectedPropertyItems.length == 0) {
        selectedPropertyItems.push(e.value);
        $(e).parent().closest("div").append('<label class="col-9 mt-3" value="' + e.value + '">' + propertyItemName + '</label><button class="col-3 btn btn-outline-danger p-1 pl-2" value="' + e.value + '" onclick="DeleteItem(' + e.value + ')"><span class="svg-icon svg-icon-outline-danger svg-icon-md"><!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2021-05-14-112058/theme/html/demo1/dist/../src/media/svg/icons/Home/Trash.svg--><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1"><g stroke = "none" stroke - width="1" fill = "none" fill - rule="evenodd" ><rect x="0" y="0" width="24" height="24"/><path d="M6,8 L18,8 L17.106535,19.6150447 C17.04642,20.3965405 16.3947578,21 15.6109533,21 L8.38904671,21 C7.60524225,21 6.95358004,20.3965405 6.89346498,19.6150447 L6,8 Z M8,10 L8.45438229,14.0894406 L15.5517885,14.0339036 L16,10 L8,10 Z" fill="#000000" fill-rule="nonzero"/><path d="M14,4.5 L14,3.5 C14,3.22385763 13.7761424,3 13.5,3 L10.5,3 C10.2238576,3 10,3.22385763 10,3.5 L10,4.5 L5.5,4.5 C5.22385763,4.5 5,4.72385763 5,5 L5,5.5 C5,5.77614237 5.22385763,6 5.5,6 L18.5,6 C18.7761424,6 19,5.77614237 19,5.5 L19,5 C19,4.72385763 18.7761424,4.5 18.5,4.5 L14,4.5 Z" fill="#000000" opacity="0.3"/></g ></svg><!--end:: Svg Icon-- ></span></button>');
    }
    else {
        if (!selectedPropertyItems.some(x => x == e.value)) {
            selectedPropertyItems.push(e.value);
            $(e).parent().closest("div").append('<label class="col-9 mt-3" value="' + e.value + '">' + propertyItemName + '</label><button class="col-3 btn btn-outline-danger p-1 pl-3" value="' + e.value + '" onclick="DeleteItem(' + e.value + ')"><span class="svg-icon svg-icon-outline-danger svg-icon-md"><!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2021-05-14-112058/theme/html/demo1/dist/../src/media/svg/icons/Home/Trash.svg--><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1"><g stroke = "none" stroke - width="1" fill = "none" fill - rule="evenodd" ><rect x="0" y="0" width="24" height="24"/><path d="M6,8 L18,8 L17.106535,19.6150447 C17.04642,20.3965405 16.3947578,21 15.6109533,21 L8.38904671,21 C7.60524225,21 6.95358004,20.3965405 6.89346498,19.6150447 L6,8 Z M8,10 L8.45438229,14.0894406 L15.5517885,14.0339036 L16,10 L8,10 Z" fill="#000000" fill-rule="nonzero"/><path d="M14,4.5 L14,3.5 C14,3.22385763 13.7761424,3 13.5,3 L10.5,3 C10.2238576,3 10,3.22385763 10,3.5 L10,4.5 L5.5,4.5 C5.22385763,4.5 5,4.72385763 5,5 L5,5.5 C5,5.77614237 5.22385763,6 5.5,6 L18.5,6 C18.7761424,6 19,5.77614237 19,5.5 L19,5 C19,4.72385763 18.7761424,4.5 18.5,4.5 L14,4.5 Z" fill="#000000" opacity="0.3"/></g ></svg><!--end:: Svg Icon-- ></span></button>');
        }
    }

    //Seçili property item yoksa Seçenekleri Oluştur butonunu inaktif, seçili varsa da butonu aktif eden algoritma
    if ($('#createVariationButton').is(':empty')) {
        if (selectedPropertyItems.length != 0)
            $('#createVariationButton').append('<button type="button" class="btn btn-primary col-md-12 col-md-4 col-md-8" id="btnCreateVariations" onclick="CreateOptions()">Seçenekleri Oluştur</button>');
        else
            $('#createVariationButton').empty();
    }
    $("#createdVariations").empty();
}

function DeleteItem(value) {
    $('#propertyItems div div label').each(function () {
        if ($(this).attr('value') == value)
            $(this).remove();
    });
    $('#propertyItems div div button').each(function () {
        if ($(this).attr('value') == value)
            $(this).remove();
    });

    //Seçili property item yoksa Seçenekleri Oluştur butonunu inaktif eden algoritma
    selectedPropertyItems = [];
    $('#propertyItems div div label').each(function () {
        selectedPropertyItems.push($(this).attr('value'));
    });
    if (selectedPropertyItems.length == 0)
        $('#createVariationButton').empty();
    $("#createdVariations").empty();
}


function CreateOptions() {
    var selectedPropertyItemsDetails = [];
    for (let i = 0; i < selectedPropertyItems.length; i++) {
        selectedPropertyItemsDetails.push(allPropertyItemsDetails.filter(x => x.id == selectedPropertyItems[i])[0]);
    }
    var selectedPropertyItemsByProperty = [];
    var allVariations = [];
    var html = '<table class="table"><thead><tr><th scope="col">Özellikler</th><th scope="col">Stok</th><th scope="col">GTIN</th><th scope="col">MPN</th><th scope="col">Fiyat</th><th scope="col">İndirimli Fiyat</th><th class="col-2" scope="col">Durum</th></tr></thead><tbody>';
    for (let i = 0; i < selectedProperties.length; i++) {
        selectedPropertyItemsByProperty[i] = selectedPropertyItemsDetails.filter(x => x.propertyId == selectedProperties[i]);
    }

    var matrixLength = 1;
    for (var i = 0; i < selectedPropertyItemsByProperty.length; i++) {
        if (selectedPropertyItemsByProperty[i].length != 0) {
            matrixLength = matrixLength * selectedPropertyItemsByProperty[i].length;
            $.ajax({
                type: "GET",
                url: "GetPropertyNames",
                contentType: "application/json",
                processData: false,
                data: "propertyId=" + selectedProperties[i],
                async: null,
                success: function (data) {
                    selectedPropertyItemsByProperty[i].unshift(data[1].name);
                },
                error: function () {
                    alert("Error");
                }
            });
            allVariations.push(selectedPropertyItemsByProperty[i]);
        }
    }

    for (var i = 1; i < matrixLength + 1; i++) {
        var line = createProductVaryantMatrixItem(i, allVariations, matrixLength);
        html += line;
    }
    html += '</tbody></table></div></div>';
    $("#createdVariations").empty();
    $("#createdVariations").append(html);
}

function createProductVaryantMatrixItem(index, array, totalsize) {
    var total = totalsize;
    var element = '';
    var elementID = '';
    for (var i = 0; i < array.length; i++) {
        var newIndex = (index - 1) % total;

        total = total / (array[i].length - 1);
        var ind = Math.floor((newIndex) / total);
        if (i != 0)
            element += " - ";
        element += "<span >" + array[i][0] + ": " + array[i][ind + 1].propertyItemNames[1].name + "</span>";
        elementID += array[i][ind + 1].id + "-";
    }
    elementID = elementID.substring(0, elementID.length - 1);

    var line = '<tr><td scope="col">' + element + '</td><td scope="col"><input class="form-control" type="number" id="stock[' + elementID + ']" name="stock[' + elementID + ']"></td><td scope="col"><input class="form-control" type="number" id="gtin[' + elementID + ']" name="gtin[' + elementID + ']"></td><td scope="col"><input class="form-control" type="number" id="mpn[' + elementID + ']" name="mpn[' + elementID + ']"></td><td scope="col"><input class="form-control" type="number" id="price[' + elementID + ']" name="price[' + elementID + ']"></td><td scope="col"><input class="form-control" type="number" id="discountedPrice[' + elementID + ']" name="discountedPrice[' + elementID + ']"></td><td scope="col"><select class="form-control" id="status[' + elementID + ']" name="status[' + elementID + ']"><option value="1">Aktif</option><option value="2">Pasif</option></select></td></tr>';
    return line;
}

    //for (let i = 0; i < 10; i++) {
    //    for (let j = 0; j < 10; j++)
    //    allVariations[[i],[0]]
    //}
    //for (let i = 0; i < selectedPropertyItemsByProperty.length; i++) {
    //    for (let j = 0; j < selectedPropertyItemsByProperty[i].length; j++) {
    //        if (allVariations.length == 0) {
    //            allVariations[j] = selectedPropertyItemsByProperty[j];
    //            //console.log(selectedPropertyItemsByProperty[j]);
    //            console.log(allVariations);
    //        }
    //        else {
    //            var items;
    //            allVariations[j] = new Array(allVariations[j]
    //                //allVariations[j].forEach(function myFunction(item) {
    //                //    item;
    //                //})
    //                , selectedPropertyItemsByProperty[j]);
    //            console.log(j, allVariations[j]);
    //        }
    //    }
    //}

    //console.log(allVariations);
    //function Looping(numberProperty) {
    //    for (let i = 0; i < selectedProperties.length; i++) {
    //        allVariations[i].name = ""
    //    }
    //}
    //for (let i = 0; i < selectedPropertyItems.length-1; i++) {
    //    Looping();
    //    //html += '<tr><th scope="row">1</th><td><div class="form-control"><input type="text name="ProductVariations[' + variationCount + ']' + +'" "></div></td><td>Stone</td><td></td></tr>';
    //    variationCount++;
    //};
    //html += '</tbody></table></div></div>';
    //$("#createdVariations").empty();
    //$("#createdVariations").append(html);
//}

function RunDraggable() {
    var containers = document.querySelectorAll('.draggable-zone');

    if (containers.length === 0) {
        return false;
    }

    var swappable = new Sortable.default(containers, {
        draggable: '.draggable',
        handle: '.draggable .draggable-handle',
        mirror: {
            appendTo: 'body',
            constrainDimensions: true
        }
    });

    swappable.on("drag:stop",
        function () {
            setTimeout(function () {
                ProductImageChange();
            }, 500);
        }
    )
}