var priceTotal = 0;
var array = [];

$(document).ready(function () {

    $('a:contains("Home")').parent().addClass('active');
    if ($("#reserve-table-info").length != 0)
        $("#menu-categories-list").removeClass("menu-category-list-overflow").addClass("menu-category-list-ifReserve");
    var menuItemsList = [];
    $.ajax({
        url: "/Bar/GetTableOrder",
        type: "JSON",
        method: "GET",
        data: { "tableId": $("#tableID").val() },
        success: function (result) {         
            $.each(result.listOfMenuItemsOrdered, function (index, value) {
                var tableOrderInitObj = new TableOrders();
                tableOrderInitObj.tableId = $("#tableID").val();
                tableOrderInitObj.menuItemId = value.menuItemId;
                tableOrderInitObj.menuItemName = value.menuItemName;
                tableOrderInitObj.orderItemQuantity = value.orderItemQuantity;
                tableOrderInitObj.orderItemBasePrice = value.orderItemPrice;
                tableOrderInitObj.orderItemPrice = value.orderItemPrice;
                tableOrderInitObj.menuItemQty = value.menuItemQty;
                array.push(tableOrderInitObj);
            });
            $.each(result.listOfMenuItems, function (index, value) {
                menuItemsList.push(value.menuItemName);
            });

            EnableDisableButtons();
        },
        error: function () {
            alert("AJAX Error- Error during loading table orders on start up (contact doxaSoftwares support).");
        }
    });
    autocomplete(document.getElementById("searchParticularMenuItem"), menuItemsList);  
});

function TableOrders(tableId, menuItemId, menuItemName, orderItemQuantity, orderItemBasePrice, orderItemPrice, menuItemQty) {
    this.tableId = tableId;
    this.menuItemId = menuItemId;
    this.menuItemName = menuItemName;
    this.orderItemQuantity = orderItemQuantity;
    this.orderItemBasePrice = orderItemBasePrice;
    this.orderItemPrice = orderItemPrice;
    this.menuItemQty = menuItemQty;
}

function EnableDisableButtons() {
   
    if (array.length > 0)
    {
        $('.pay-table-bill').attr('disabled', false);
        $('.print-table-receipt').attr('disabled', false);
    }
    else
    {
        $('.pay-table-bill').attr('disabled', true);
        $('.print-table-receipt').attr('disabled', true);
    }
    $("#IsReservedCustomerShowedUp").val() == "true" ? $('.btn-cancel-reservation').attr('disabled', true) : $('.btn-cancel-reservation').attr('disabled', false);
    
}

function searchParticularMenuItem(evt) {

    var searchBy = $("#searchParticularMenuItem").val();
    var charCode = (evt.which) ? evt.which : event.keyCode;

    if (charCode == 13) {
        $.ajax({
            url: "/Bar/SearchParticularMenuItems?searchValue=" + searchBy,
            method: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",              
            success: function (result) {
                if (result.length == 0) {
                }
                else
                    AppendProductsToSearch(result);
            },
            error: function () {
                alert("Error occured while search product by id or name.")
            }
        });
    }
}

function DisplayMenuItems(menuCategoryId) {

    $.ajax({
        url: "/Bar/CategorySpecificMenuItems?menuCategoryId=" + menuCategoryId + "",
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            AppendProductsToSearch(result)
        },
        error: function () {
            alert("AJAX Error- Error during fetching category specific menu items.");
        }
    });
}

function AppendProductsToSearch(result) {

    var body = $('#CategorySpecificMenuItemsDIV');
    body.html("");

    $.each(result, function (index, value) {
        var productDiv;

        if (value.priceInput == 4) {
            productDiv = "<div class='col-3 col-lg-3 col-xl-3 pt-2' data-id='" + value.menuItemId + "'>" +
                                "<div class='card border'>" +
                                    "<div class='card-body p-0'>" +
                                        "<div class='row mx-0' style='background-color:linen;height: 40px;'>" +
                                            "<div class='col-lg-10 p-0'>"+
                                                    "<h6 class='card-title'>" + value.menuItemName + "</h6>" +
                                            "</div>"+
                                            "<div class='col-lg-2 p-0 justify-content-end'>"+                                                   
                                            "</div>"+
                                        "</div>"+
                                        "<div class='menu-item-butttons'>" +
                                            "<div class='btn-group btn-group-sm d-flex' role='group' aria-label='Basic example'>" +
                                                "<button type='button' class='btn btn-primary text-light w-100' onclick=AddItemToCart(this," + value.thirtyMLPrice + ",'30ML')>30ML</button>" +
                                                "<button type='button' class='btn btn-primary text-light w-100' onclick=AddItemToCart(this," + value.sixtyMLPrice + ",'60ML')>60ML</button>" +
                                            "</div>" +
                                            "<div class='btn-group btn-group-sm mt-1 d-flex' role='group' aria-label='Basic example'>" +
                                                "<button type='button' class='btn btn-primary text-light w-100' onclick=AddItemToCart(this," + value.ninetyMLPrice + ",'90ML')>90ML</button>" +
                                                "<button type='button' class='btn btn-primary text-light w-100' onclick=AddItemToCart(this," + value.quarterMLPrice + ",'180ML')>180ML</button>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";
        }
        else if ((value.priceInput == 2 && value.halfItemPrice == 0) || value.priceInput == 1) {

                productDiv = "<div class='col-3 col-lg-3 col-xl-3 pt-2' data-id='" + value.menuItemId + "'>" +
                                "<div class='card border'>" +
                                    "<div class='card-body p-0'>" +
                                            "<div class='row mx-0' style='background-color:linen;height: 40px;'>" +
                                                "<div class='col-lg-10 p-0'>" +
                                                        "<h6 class='card-title'>" + value.menuItemName + "</h6>" +
                                                "</div>" +
                                                "<div class='col-lg-2 p-0 justify-content-end'>" +
                                                "</div>" +
                                            "</div>" +
                                        "<div class='menu-item-butttons'>" +
                                            "<div class='btn-group btn-group-sm d-flex' role='group' aria-label='Basic example'>" +
                                                "<button type='button' class='btn btn-primary text-light w-100' onclick=AddItemToCart(this," + value.itemPrice + ",'')>Add</button>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";
            
        }
        else if (value.priceInput == 2 && value.halfItemPrice != 0) {

                productDiv = "<div class='col-3 col-lg-3 col-xl-3 pt-2' data-id='" + value.menuItemId + "'>" +
                                "<div class='card border'>" +
                                    "<div class='card-body p-0'>" +
                                        "<div class='row mx-0' style='background-color:linen;height: 40px;'>" +
                                                "<div class='col-lg-10 p-0'>" +
                                                    "<h6 class='card-title'>" + value.menuItemName + "</h6>" +
                                            "</div>" +
                                        "</div>" +
                                        "<div class='menu-item-butttons'>" +
                                            "<div class='btn-group btn-group-sm d-flex' role='group' aria-label='Basic example'>" +
                                                "<button type='button' class='btn btn-primary text-light w-100' onclick=AddItemToCart(this," + value.halfItemPrice + ",'H')>H</button>" +
                                                "<button type='button' class='btn btn-primary text-light w-100' onclick=AddItemToCart(this," + value.itemPrice + ",'F')>F</button>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";           
        }
        body.append(productDiv);
    });

}

function ajaxCallToAddMenuItemsToCart(tableOrderObj) {

    $.ajax({
        url: "/Bar/AddMenuItemToCart",
        type: "JSON",
        method: "POST",
        data: { "obj": tableOrderObj },
        success: function (result) {
        },
        error: function () {
            alert("AJAX Error- Error during inserting menuitem to cart.");
        }
    });
}

function ajaxCallToUpdateMenuItemsFromCart(tableOrderObj) {

    $.ajax({
        url: "/Bar/UpdateMenuItemFromCart",
        type: "JSON",
        method: "POST",
        data: { "uMenuItem": tableOrderObj },
        success: function (result) {

        },
        error: function () {
            alert("AJAX Error- Error during updating menuitem from cart  (contact doxaSoftwares support).");
        }
    });
}

function ajaxCallToDeleteMenuItemsFromCart(tableOrderObj) {

    $.ajax({
        url: "/Bar/DeleteMenuItemFromCart",
        type: "JSON",
        method: "POST",
        data: { "obj": tableOrderObj },
        success: function (result) {

        },
        error: function () {
            alert("AJAX Error- Error during deleting menuitem from cart  (contact doxaSoftwares support).");
        }
    });
    if(array.length == 0)
        window.setTimeout(function () {
            location.reload(true)
        }, 1000);
}

function containsSameObjetInCart(menuItemId, menuQty , cartItemsObj) {
    var i;
    for (i = 0; i < cartItemsObj.length; i++) {
        if (parseInt(cartItemsObj[i].menuItemId) == parseInt(menuItemId) && cartItemsObj[i].menuItemQty == menuQty)
            return true;
    }
    return false;
}

function AddItemToCart(e,itemPrice, menuQty) {
   
    if (array.length >= 1 && containsSameObjetInCart(e.parentNode.parentNode.parentNode.parentNode.parentNode.getAttribute("data-id") , menuQty , array)) {
        menuQty != "" ?
        ShowSnackBarMessages("" + e.parentNode.parentNode.parentNode.children[0].children[0].textContent + "(" + menuQty + ") is already added in the cart.", "lightgrey", "red") : 
        ShowSnackBarMessages("" + e.parentNode.parentNode.parentNode.children[0].children[0].textContent + " is already added in the cart.", "lightgrey", "red");

        return false;
    }
        
    var tableOrderObj = new TableOrders();
    tableOrderObj.tableId = $("#tableID").val();
    tableOrderObj.menuItemId = e.parentNode.parentNode.parentNode.parentNode.parentNode.getAttribute("data-id");
    tableOrderObj.menuItemName = e.parentNode.parentNode.parentNode.children[0].children[0].textContent;
    tableOrderObj.orderItemQuantity = 1;
    tableOrderObj.orderItemBasePrice = itemPrice;
    tableOrderObj.orderItemPrice = itemPrice;
    tableOrderObj.menuItemQty = menuQty;
    array.push(tableOrderObj);
    if ($("#IsReservedCustomerShowedUp").val() == "false")
        if (array.length == 1 && $("#IsTableReserved").val() == "true" && confirm("Is it the Reserved Customer ?"))
            ReservedCustomerShowedUp();
    EnableDisableButtons();
    AppendItemsToCart(tableOrderObj);
    ajaxCallToAddMenuItemsToCart(tableOrderObj);
}

function ReservedCustomerShowedUp() {
   
    var Obj = {
        'tableId': parseInt($("#tableID").val()),
        'reserveTableId': parseInt($("#reserveTableId").val())
    }
    $.ajax({
        url: "/Bar/ReservedCustomerShowedUp",
        type: "JSON",
        method: "POST",
        data: { "obj": Obj },
        success: function (result) {

        },
        error: function () {
            alert("AJAX Error- Error during inserting menuitem to cart.");
        }
    });
    window.setTimeout(function () {
        location.reload(true)
    }, 1000);
}

function AppendItemsToCart(tableOrderObj) {

    var setData = $("#tableCart");
    var data;
    //setData.html("");
    if (tableOrderObj.menuItemQty != "")
    {
        data = "<tr data-id='" + tableOrderObj.menuItemId + "'>" +
                 "<td width='34%'>" +
                     "<div class='row'>" +
                         "<div class='col-sm-12'>" +
                             "<div class='d-flex'>" +
                                 "<h6>" + tableOrderObj.menuItemName + "</h6><span class='font-weight-light ml-1 menu-item-qty'>(" + tableOrderObj.menuItemQty + ")</span>" +
                             "</div>" +
                         "</div>" +
                     "</div>" +
                 "</td>" +
                 "<td class='pl-0' width='35%'>" +
                     "<div class='row justify-content-center'>" +
                         "<div>" +
                             "<button class='btn btn-secondary' onclick='IncreaseFullScreenCartQty(this,"+tableOrderObj.menuItemId+")'>+</button>" +
                         "</div>" +
                         "<div class='px-1' style='width: 30%;'>" +
                             "<input type='text' class='form-control text-center' value='" + tableOrderObj.orderItemQuantity + "' min='1' readonly>" +
                         "</div>" +
                         "<div>" +
                             "<button class='btn btn-secondary' onclick='DecreaseFullScreenCartQty(this," + tableOrderObj.menuItemId + ")'>-</button>" +
                         "</div>" +
                     "</div>" +
                 "</td>" +
                 "<td class='pl-0' width='20%'>" +
                     "<input type='number' min='0' class='form-control text-center ml-auto' value='" + tableOrderObj.orderItemPrice + "' readonly>" +
                 "</td>" +
                 "<td width='10%'>" +
                     "<button onclick=DeleteFullCartProduct('" + encodeURIComponent(tableOrderObj.menuItemQty) + "',this)  type='button' class='btn-danger' style='cursor:pointer'><i class='fa fa-trash' aria-hidden='true'></i></button>" +
                 "</td>" +
             "</tr>";
    }
    else
    {
        data = "<tr data-id='" + tableOrderObj.menuItemId + "'>" +
                 "<td width='34%'>" +
                     "<div class='row'>" +
                         "<div class='col-sm-12'>" +
                             "<div class='d-flex'>" +
                                 "<h6>" + tableOrderObj.menuItemName + "</h6>" +
                             "</div>" +
                         "</div>" +
                     "</div>" +
                 "</td>" +
                 "<td width='35%'>" +
                     "<div class='row justify-content-center'>" +
                         "<div>" +
                             "<button class='btn btn-secondary' onclick='IncreaseFullScreenCartQty(this," + tableOrderObj.menuItemId + ")'>+</button>" +
                         "</div>" +
                         "<div class='px-1' style='width: 30%;'>" +
                             "<input type='text' class='form-control text-center' value='" + tableOrderObj.orderItemQuantity + "' min='1' readonly>" +
                         "</div>" +
                         "<div>" +
                             "<button class='btn btn-secondary' onclick='DecreaseFullScreenCartQty(this," + tableOrderObj.menuItemId + ")'>-</button>" +
                         "</div>" +
                     "</div>" +
                 "</td>" +
                 "<td class='pl-0' width='20%'>" +
                     "<input type='number' min='0' class='form-control text-center ml-auto' value='" + tableOrderObj.orderItemPrice + "' readonly>" +
                 "</td>" +
                 "<td width='10%'>" +
                     "<button onclick=DeleteFullCartProduct('" + encodeURIComponent(tableOrderObj.menuItemQty) + "',this) type='button' class='btn-danger' style='cursor:pointer'><i class='fa fa-trash' aria-hidden='true'></i></button>" +
                 "</td>" +
             "</tr>";
    }
    setData.append(data);
    setTotalPriceAndQtyPurchased();

}

function setTotalPriceAndQtyPurchased() {

    priceTotal = 0;
    $.each(array, function (key, value) {
        priceTotal += parseFloat(value.orderItemPrice);
    });
    document.getElementById("totalForFullScreenCart").innerHTML = priceTotal.toFixed(2);
}

function IncreaseFullScreenCartQty(e, menuItemId) {
   
    var qty = parseFloat(e.parentNode.parentNode.children[1].children[0].value);
    var index;

    qty += 1;
    if (array.length > 0)
    {
        index = array.findIndex(x => x.menuItemId == parseFloat(e.parentNode.parentNode.parentNode.parentNode.getAttribute("data-id")));
        array[index].orderItemQuantity = qty;
        array[index].orderItemPrice = parseFloat(array[index].orderItemBasePrice) * parseFloat(qty);
    }
    e.parentNode.parentNode.children[1].children[0].value = qty;
    e.parentNode.parentNode.parentNode.parentNode.children[2].children[0].value = parseFloat(array[index].orderItemBasePrice) * parseFloat(qty);
    setTotalPriceAndQtyPurchased();
    var tableOrderObj = new TableOrders($("#tableID").val(),parseFloat(e.parentNode.parentNode.parentNode.parentNode.getAttribute("data-id")),null,
                                        qty, null, (parseFloat(array[index].orderItemBasePrice) * parseFloat(qty)),null);

    ajaxCallToUpdateMenuItemsFromCart(tableOrderObj);
}

function DecreaseFullScreenCartQty(e, menuItemId) {
    
    var qty = parseFloat(e.parentNode.parentNode.children[1].children[0].value);
    var index; 

    qty -= 1;
    if (parseFloat(qty) == 0) {
        return false;
    }
    if (array.length > 0)
    {
        index = array.findIndex(x => x.menuItemId == parseFloat(e.parentNode.parentNode.parentNode.parentNode.getAttribute("data-id")));
        array[index].orderItemQuantity = qty;
        array[index].orderItemPrice = parseFloat(array[index].orderItemBasePrice) * parseFloat(qty);
    }

    e.parentNode.parentNode.children[1].children[0].value = qty;
    e.parentNode.parentNode.parentNode.parentNode.children[2].children[0].value = parseFloat(array[index].orderItemBasePrice) * parseFloat(qty);
    setTotalPriceAndQtyPurchased();
    var tableOrderObj = new TableOrders($("#tableID").val(), parseFloat(e.parentNode.parentNode.parentNode.parentNode.getAttribute("data-id")), null,
                                    qty, null, (parseFloat(array[index].orderItemBasePrice) * parseFloat(qty)),null);

    ajaxCallToUpdateMenuItemsFromCart(tableOrderObj);
}

function DeleteFullCartProduct(menuItemQty,e) {
    
    var index = array.findIndex(x => x.menuItemId == parseFloat(e.parentNode.parentNode.getAttribute('data-id')) && x.menuItemQty == menuItemQty);
    var tableOrderObj = new TableOrders($("#tableID").val(), parseFloat(e.parentNode.parentNode.getAttribute("data-id")), null,
                                null, null, null, menuItemQty);
    array.splice(index, 1);

    var $item = e.parentNode.parentNode.remove();
    EnableDisableButtons();
    setTotalPriceAndQtyPurchased();
    if (array.length == 0) {
        if (confirm("Deleting all items will make table empty again. Are you sure ?")) {
            ajaxCallToDeleteMenuItemsFromCart(tableOrderObj);
        }
        else
            location.reload();
            //window.setTimeout(function () {
            //    location.reload(true)
            //}, 1000);
    }
    else
        ajaxCallToDeleteMenuItemsFromCart(tableOrderObj);

}
 
function PayTableBill(tableId, totalAmount) {

    if (!$("input[name='paymentModeRadio']:checked").val())
        ShowSnackBarMessages("Please select Mode of payment first..!!", "lightgrey", "red");     
    else
    {
        var PayBillObj = {
            'tableId': tableId,
            'tableAmount': totalAmount,
            'paymentModeId': parseInt($("input[name=paymentModeRadio]:checked").val())
        }
        $.ajax({
            url: "/Bar/PayTableBill",
            type: "JSON",
            method: "POST",
            data: { "obj": PayBillObj },
            success: function (result) {
                if (result.insertResponse == "Success")
                {
                    ShowSnackBarMessages("Table bill paid successfully..!!", "lightgrey", "green");
                    Print_Order_Receipt(result.listOfPaidOrderDetails, result.invoiceNumber, result.gstInfo);
                }
            },
            error: function () {
                alert("AJAX Error- Error during paying cart (contact doxaSoftwares support).");
            }
        });
        window.setTimeout(function () {
            location.reload(true)
        }, 2000);
    }
}

function PrintTableReceipt(tableId){

    $.ajax({
        url: "/Bar/PrintTableReceipt",
        type: "JSON",
        method: "POST",
        data: { "tableId": tableId },
        success: function (result) {
            if (result.insertResponse == "Success") {
                ShowSnackBarMessages("Table receipt printed successfully..!!", "lightgrey", "#17a2b8");
                Print_Order_Receipt(result.listOfPaidOrderDetails, result.invoiceNumber, result.gstInfo);
            }
        },
        error: function () {
            alert("AJAX Error- Error during deleting menuitem from cart  (contact doxaSoftwares support).");
        }
    });
    window.setTimeout(function () {
        location.reload(true)
    }, 1000);
}

