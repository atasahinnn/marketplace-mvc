$(document).ready(function () {
    $("#brandChekboxesSearch").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#brandCheckboxes div label").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $("#categoryPropertyChekboxesSearch").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#categoryPropertyCheckboxes div label").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});



function isChecked(e) {
    var requiredBtn = e.nextElementSibling.nextElementSibling
    var variationBtn = e.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling

    if (e.checked == true) {
        requiredBtn.classList.remove("d-none")
        variationBtn.classList.remove("d-none")
    }
    else {
        requiredBtn.classList.add("d-none")
        requiredBtn.style.backgroundColor = "dodgerblue"
        requiredBtn.innerHTML = '<i onclick="changeIconColor(this)" class="fas fa-key p-0"></i>'
        requiredBtn.nextElementSibling.value = false;

        variationBtn.classList.add("d-none")
        variationBtn.style.backgroundColor = "dodgerblue"
        variationBtn.innerHTML = '<i onclick="changeIconVariation(this)" class="far fa-times-circle p-0"></i>'
        variationBtn.nextElementSibling.value = false;
    }
}


function changeColor(e) {
    if (e.style.backgroundColor == "dodgerblue") {
        e.style.backgroundColor = "red"
        e.innerHTML = '<i onclick="changeIconColor(this)" class="fas fa-lock p-0"></i>'
        e.nextElementSibling.value = true;
    }
    else {
        e.style.backgroundColor = "dodgerblue"
        e.innerHTML = '<i onclick="changeIconColor(this)" class="fas fa-key p-0"></i>'
        e.nextElementSibling.value = false;
    }
}

function changeIconColor(e) {
    event.preventDefault();
    event.stopPropagation();
    var parentElement = e.parentElement
    if (parentElement.style.backgroundColor == "dodgerblue") {
        parentElement.style.backgroundColor = "red"
        parentElement.innerHTML = '<i onclick="changeIconColor(this)" class="fas fa-lock p-0"></i>'
        parentElement.nextElementSibling.value = true;
    }
    else {
        parentElement.style.backgroundColor = "dodgerblue"
        parentElement.innerHTML = '<i onclick="changeIconColor(this)" class="fas fa-key p-0"></i>'
        parentElement.nextElementSibling.value = false;
    }
}

function changeVariation(e) {
    if (e.style.backgroundColor == "dodgerblue") {
        e.style.backgroundColor = "red"
        e.innerHTML = '<i onclick="changeIconVariation(this)" class="far fa-check-circle p-0"></i>'
        e.nextElementSibling.value = true;
    }
    else {
        e.style.backgroundColor = "dodgerblue"
        e.innerHTML = '<i onclick="changeIconVariation(this)" class="far fa-times-circle p-0"></i>'
        e.nextElementSibling.value = false;
    }
}

function changeIconVariation(e) {
    event.preventDefault();
    event.stopPropagation();
    var parentElement = e.parentElement
    if (parentElement.style.backgroundColor == "dodgerblue") {
        parentElement.style.backgroundColor = "red"
        parentElement.innerHTML = '<i onclick="changeIconVariation(this)" class="far fa-check-circle p-0"></i>'
        parentElement.nextElementSibling.value = true;
    }
    else {
        parentElement.style.backgroundColor = "dodgerblue"
        parentElement.innerHTML = '<i onclick="changeIconVariation(this)" class="far fa-times-circle p-0"></i>'
        parentElement.nextElementSibling.value = false;
    }
}
