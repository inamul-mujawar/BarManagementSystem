$(document).ready(function () {

    $("input").focus(function () {
        DisableClassAndFontAwesomeIcon();
    });
});


function ValidatePriceInputBasedForms() {
    var categoryPriceId = parseInt($('#categorySelect').find(':selected').attr('data-priceinput'));
    if (categoryPriceId == 2)
        return ValidateMenuItemForm1(); //(!ValidateMenuItemForm1()) ? false : true
    if (categoryPriceId == 4)
        return ValidateMenuItemForm3();
    if (categoryPriceId == 1)
        return ValidateMenuItemForm1();

}

function ValidateMenuItemForm1() {
    var itemName = $('#itemName').val();
    var itemPrice = $('#itemPrice').val();
    return Validate_ItemName_ItemPrice(itemName, itemPrice);
}

function ValidateMenuItemForm3() {
    var itemName = $('#itemName').val();
    var thirtyMLPrice = $('#30MLPrice').val();
    var sixtyMLPrice = $('#60MLPrice').val();
    var ninetyPrice = $('#90MLPrice').val();
    var quarterPrice = $('#180MLPrice').val();
    return Validate_ItemName_30MLPrice_60MLPrice_90MLPrice_180MLPrice(itemName, thirtyMLPrice, sixtyMLPrice, ninetyPrice, quarterPrice);
}

function Validate_ItemName_ItemPrice(itemName, itemPrice) {

    if (itemName == "") {
        $(".itemNameEr").show();
        $('#itemName').addClass("changeColorOnFail");
        return false;
    }
    else if (itemPrice == "") {
        $(".itemPriceEr").show();
        $('#itemPrice').addClass("changeColorOnFail");
        return false;
    }
    else
        return true;
}

function Validate_ItemName_30MLPrice_60MLPrice_90MLPrice_180MLPrice(itemName, thirtyMLPrice, sixtyMLPrice, ninetyPrice, quarterPrice) {

    if (itemName == "") {
        $(".itemNameEr").show();
        $('#itemName').addClass("changeColorOnFail");
        return false;
    }
    else if (thirtyMLPrice == "") {
        $(".30MLPriceEr").show();
        $('#30MLPrice').addClass("changeColorOnFail");
        return false;
    }
    else if (sixtyMLPrice == "") {
        $(".60MLPriceEr").show();
        $('#60MLPrice').addClass("changeColorOnFail");
        return false;
    }
    else if (ninetyPrice == "") {
        $(".90MLPriceEr").show();
        $('#90MLPrice').addClass("changeColorOnFail");
        return false;
    }
    else if (quarterPrice == "") {
        $(".180MLPriceEr").show();
        $('#180MLPrice').addClass("changeColorOnFail");
        return false;
    }
    else
        return true;
}

function DisableClassAndFontAwesomeIcon() {

    $(".itemNameEr").css("display", "none");
    $(".itemPriceEr").css("display", "none");
    $(".30MLPriceEr").css("display", "none");
    $(".60MLPriceEr").css("display", "none");
    $(".90MLPriceEr").css("display", "none");
    $(".180MLPriceEr").css("display", "none");

    $('#itemName').removeClass("changeColorOnFail");
    $('#itemPrice').removeClass("changeColorOnFail");
    $('#30MLPrice').removeClass("changeColorOnFail");
    $('#60MLPrice').removeClass("changeColorOnFail");
    $('#90MLPrice').removeClass("changeColorOnFail");
    $('#180MLPrice').removeClass("changeColorOnFail");

}
