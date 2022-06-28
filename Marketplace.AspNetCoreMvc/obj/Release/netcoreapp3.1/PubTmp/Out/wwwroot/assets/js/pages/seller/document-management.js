function getFile(file) {
    var selectedLabel = $(file).parent("td").find("#inputLabel");
    var selectedIcon = $(file).parent("td").find("#inputIcon");

    selectedLabel.removeAttr("class");
    selectedIcon.removeAttr("class");

    if (file.value == "") {
        console.log(file.value);
        selectedLabel.addClass("label label-xl font-weight-bold label-light-warning label-inline");
        selectedLabel.html("Lütfen geçerli bir evrak seçiniz.");
    } else {

        var newFile = file.value.replace(/^.*\\/, "");

        selectedLabel.addClass("label label-xl font-weight-bold label-light-primary label-inline");
        selectedLabel.html(newFile);
    }
}