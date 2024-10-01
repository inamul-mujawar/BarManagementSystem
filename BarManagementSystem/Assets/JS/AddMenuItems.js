$(document).ready(function () {

    //$('a').removeClass('active');
    $('a:contains("Master Data")').parent().addClass('active');

    $('#categorySelect').on('change', function () {
        var loadFormBasedOnPriceInput = parseInt($(this).find(':selected').attr('data-priceinput'));
        if (loadFormBasedOnPriceInput == 2) {
            MenuItemNameForm();
            TwoPriceInputForm();
        }
        else if (loadFormBasedOnPriceInput == 4) {
            MenuItemNameForm();
            FourPriceInputForm();
        }        
        else if (loadFormBasedOnPriceInput == 1) {
            MenuItemNameForm();
            OnePriceInputForm();
        }
        DisableClassAndFontAwesomeIcon();
    });
});

function OnePriceInputForm() {
    document.getElementById("menu-item-form1").style.display = "block";
    document.getElementById("menu-item-form2").style.display = "none";
    document.getElementById("menu-item-form3").style.display = "none";
}

function TwoPriceInputForm() {
    document.getElementById("menu-item-form1").style.display = "block";
    document.getElementById("menu-item-form2").style.display = "block";
    document.getElementById("menu-item-form3").style.display = "none";
}

function FourPriceInputForm() {
    document.getElementById("menu-item-form1").style.display = "none";
    document.getElementById("menu-item-form2").style.display = "none";
    document.getElementById("menu-item-form3").style.display = "block";
}

function MenuItemNameForm() {
    document.getElementById("menu-item-name-form").style.display = "block";
}

function validateForm() {
   
    if (!isNaN(parseInt($('#categorySelect').val()))) {
        //document.getElementById("categorySelect").value;     
        return ValidatePriceInputBasedForms();
    }
    else
    {
        ShowSnackBarMessages("Please select menu Category first", "lightgrey", "red");
        return false;
    }
}

