
$(document).ready(function () {

    $('a:contains("Master Data")').parent().addClass('active');
    $('#dataTable').DataTable();

});

function UpdateMenuItems(menuItemId, menuCategoryId, menuItemName, itemPrice, halfItemPrice, thirtyMLPrice, sixtyMLPrice, ninetyMLPrice, quarterMLPrice) {

    this.menuItemId = menuItemId;
    this.menuCategoryId = menuCategoryId;
    this.menuItemName = menuItemName;
    this.itemPrice = itemPrice;
    this.halfItemPrice = halfItemPrice;
    this.thirtyMLPrice = thirtyMLPrice;
    this.sixtyMLPrice = sixtyMLPrice;
    this.ninetyMLPrice = ninetyMLPrice;
    this.quarterMLPrice = quarterMLPrice;

}

function EditMenuItemModal(menuItemId) {

    EnableInput();
    $('#updateMenuItemForm').trigger("reset");
    $.ajax({
        url: "/Master/DetailsOfMenuItems",
        type: "JSON",
        method: "GET",
        data: { "menuItemId": menuItemId },
        success: function (result) {

            if (result.length == 0) {
                //
            }
            else {

                $("#categorySelect").val(result.menuCategoryId).change();
                $("#itemName").val(result.menuItemName);
                $("#menuItemIdReadOnly").val(menuItemId);

                if (result.menuCategoryId == 3) {
                    DisableInput_Veg_NonVeg();
                    $('#30MLPrice').val(result.thirtyMLPrice);
                    $('#60MLPrice').val(result.sixtyMLPrice);
                    $('#90MLPrice').val(result.ninetyMLPrice);
                    $('#180MLPrice').val(result.quarterMLPrice);
                    
                }
                else if (result.menuCategoryId != 3 && result.halfItemPrice != 0) {
                    DisableInput_Liquor();
                    $('#itemPrice').val(result.itemPrice);
                    $('#halfItemPrice').val(result.halfItemPrice);
                }
                else if (result.menuCategoryId != 3 && result.halfItemPrice == 0) {
                    DisableInput_Liquor();
                    if(result.menuCategoryId == 1 || result.menuCategoryId == 2)
                        $('#itemPrice').val(result.halfItemPrice);
                    else
                        DisableInput_Beer_Snacks_ColdDrink();
                    $('#itemPrice').val(result.itemPrice);

                }
            }
        },
        error: function () {
            alert("AJAX Error- Error during fetching data to update menuitem.");
        }
    });

    $('#UpdateMenuItemModal').modal('show');

}

function UpdateMenuItemDetails(e) {

    if (ValidatePriceInputBasedForms())
    {
        var IntilizeMenuItemsToUpdate = new UpdateMenuItems($("#menuItemIdReadOnly").val(), $('#categorySelect').val(), $("#itemName").val(), $('#itemPrice').val(), $('#halfItemPrice').val(),
                                              $('#30MLPrice').val(), $('#60MLPrice').val(), $('#90MLPrice').val(), $('#180MLPrice').val());
        if (typeof IntilizeMenuItemsToUpdate !== 'undefined') {

            $.ajax({
                url: "/Master/UpdateMenuItems",
                type: "JSON",
                method: "POST",
                data: { "uMenuItem": IntilizeMenuItemsToUpdate },
                success: function (result) {
                    if (result == "Success") {
                        ShowSnackBarMessages("Menu Item updated successfully..!!", "lightgrey", "#ff8800");
                    }
                },
                error: function () {
                    alert("AJAX Error- Error during updating menuitem from cart.");
                }
            });
            $('#UpdateMenuItemModal').modal('hide');
            window.setTimeout(function () {
                location.reload(true)
            }, 1000);
        }
    }
}

function DisableInput_Veg_NonVeg() {
    $("#itemPrice").prop('disabled', true);
    $("#halfItemPrice").prop('disabled', true);
}

function DisableInput_Beer_Snacks_ColdDrink() {
    $("#halfItemPrice").prop('disabled', true);
}

function DisableInput_Liquor() {

    $("#30MLPrice").prop('disabled', true);
    $("#60MLPrice").prop('disabled', true);
    $("#90MLPrice").prop('disabled', true);
    $("#180MLPrice").prop('disabled', true);

}

function EnableInput() {
    $("#itemPrice").prop('disabled', false);
    $("#halfItemPrice").prop('disabled', false);
    $("#30MLPrice").prop('disabled', false);
    $("#60MLPrice").prop('disabled', false);
    $("#90MLPrice").prop('disabled', false);
    $("#180MLPrice").prop('disabled', false);

}

function MoveProductToBin(menuItemId) {

    $.ajax({
        url: "/Master/DeleteMenuItems",
        type: "JSON",
        method: "POST",
        data: { "menuItemId": menuItemId },
        success: function (result) {
            if (result == "Success") {
                ShowSnackBarMessages("Menu Item deleted successfully..!!", "lightgrey", "red");
                window.setTimeout(function () {
                    location.reload(true)
                }, 1000);
            }
            else if (result == "Exists")
                ShowSnackBarMessages("Menu Item with Paid Orders cannot be deleted..!!", "lightgrey", "red");
        },
        error: function () {
            alert("AJAX Error- Error during deleting menu Item(contact doxaSoftwares support).");
        }
    });

}