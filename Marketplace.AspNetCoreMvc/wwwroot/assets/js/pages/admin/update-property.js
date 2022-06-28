function AddPropertyItem() {
    var item = "";
    $.each(globalLanguages, function (k, v) {
        item += '<div class="col">' +
            '<div class="form-group" >' +
            '<label>' + v.name + ' Öğe</label>' +
            '<input type="hidden" name="PropertyItems[' + propertyItemsCount + '].PropertyItemNames[' + k + '].LanguageId" value="' + v.id + '" />' +
            '<input type="text" class="form-control" dir="' + v.dir + '" placeholder="' + v.name + ' Öğe" name="PropertyItems[' + propertyItemsCount + '].PropertyItemNames[' + k + '].Name" />' +
            '</div >' +
            '</div >'
    })

    item += '<div class="col-auto"><div class="form-group" ><label class="w-100">&nbsp;</label><button onclick="RemovePropertyItem(this)" type="button" class="btn btn-icon btn-outline-danger"><i class="far fa-trash-alt"></i></button></div ></div >';

    $("#PropertyItems").append('<div class="row">' + item + '</div>')
    propertyItemsCount++;
}

function RemovePropertyItem(e) {
    const parentElement = e.parentElement.parentElement.parentElement.parentElement;
    const childrenOfParent = parentElement.children;

    e.parentElement.parentElement.parentElement.remove()
    propertyItemsCount--;

    for (var i = 0; i < childrenOfParent.length; i++) {
        const childrenInner = childrenOfParent[i].children


        for (var j = 1; j <= languageCount; j++) {
            var tempJ = j - 1;
            var innerJ = j * 2;
            if (childrenInner[tempJ].firstElementChild == null) {
                childrenInner[innerJ].firstElementChild.children[0] = ""
                childrenInner[innerJ].firstElementChild.children[2] = ""
                childrenInner[innerJ].firstElementChild.children[5] = ""
                childrenInner[innerJ].firstElementChild.children[3].name = 'PropertyItems[' + i + '].PropertyItemNames[' + tempJ + '].LanguageId'
                childrenInner[innerJ].firstElementChild.children[4].name = 'PropertyItems[' + i + '].PropertyItemNames[' + tempJ + '].Name'
            }
            else {
                console.log(childrenInner[tempJ].firstElementChild)
                childrenInner[tempJ].firstElementChild.children[1].name = 'PropertyItems[' + i + '].PropertyItemNames[' + tempJ + '].LanguageId'
                childrenInner[tempJ].firstElementChild.children[2].name = 'PropertyItems[' + i + '].PropertyItemNames[' + tempJ + '].Name'
            }
        }
    }
}

