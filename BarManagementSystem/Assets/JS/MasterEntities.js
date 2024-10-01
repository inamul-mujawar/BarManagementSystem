
$(document).ready(function () {

    $('a:contains("Master Data")').parent().addClass('active');
   // $('#dataTable').DataTable();
    $("input,select").focus(function () {
            $('input,select').removeClass("changeColorOnFail");
    });

    const togglePassword = document.getElementsByClassName('togglePassword');
	const password = document.getElementsByClassName('password');

    $.each(togglePassword, function (index, value) {
        value.addEventListener('click', function (e) {
            $.each(password, function (index, value1) {
                if (parseInt(value.getAttribute("data-inputId")) == parseInt(value1.getAttribute("data-iconId"))) {
                    // toggle the type attribute
                    const type = value1.getAttribute('type') === 'password' ? 'text' : 'password';
                    value1.setAttribute('type', type);
                    // toggle the eye / eye slash icon
                    $(this).toggleClass("fa-eye fa-eye-slash");
                    return false;
                }
            });
        });
    });

});

function AddAdminUser(e) {
    ;
    var obj = {
        "userName": e.parentNode.children[0].children[1].value,
        "password": e.parentNode.children[1].children[1].value,
        "isAdminstrator": e.parentNode.children[2].children[0].checked
    }
    //
    if (obj.userName != "" && obj.password != "") {
        $.ajax({
            url: "/Master/AddAdminUser",
            type: "JSON",
            method: "POST",
            data: { "obj": obj },
            success: function (result) {
                if (result == "Success")
                    ShowSnackBarMessages("Admin User added successfully..!!", "lightgrey", "green");
            },
            error: function () {
                alert("AJAX Error- Error during adding Admin User(contact doxaSoftwares support).");
            }
        });
        window.setTimeout(function () {
            location.reload(true)
        }, 1000);
    }
    else {
        if(obj.userName == "" && obj.password == ""){
            e.parentNode.children[0].children[1].classList.add('changeColorOnFail');
            e.parentNode.children[1].children[1].classList.add('changeColorOnFail');
        }
        else if (obj.userName == "")
            e.parentNode.children[0].children[1].classList.add('changeColorOnFail');
        else if(obj.password == "")
            e.parentNode.children[0].children[1].classList.add('changeColorOnFail');
        
    }
    
}

function UpdateAdminUser(e, adminId) {
    
    var obj = {
        "adminId": adminId,
        "userName": e.parentNode.parentNode.parentNode.children[1].children[0].value,
        "password": e.parentNode.parentNode.parentNode.children[2].children[0].value,
        "isAdminstrator": e.parentNode.parentNode.parentNode.children[3].children[0].children[0].checked
    }

    if (e.parentNode.parentNode.parentNode.children[1].children[0].readOnly){
        e.parentNode.parentNode.parentNode.children[1].children[0].readOnly = false;
        e.parentNode.parentNode.parentNode.children[2].children[0].readOnly = false;
        e.parentNode.parentNode.parentNode.children[3].children[0].children[0].disabled = false;

    }
    else {
        if (obj.userName != "" && obj.password != "") {
            $.ajax({
                url: "/Master/UpdateAdminUser",
                type: "JSON",
                method: "POST",
                data: { "obj": obj },
                success: function (result) {
                    if (result == "Success")
                        ShowSnackBarMessages("Admin User updated successfully..!!", "lightgrey", "#ff8800");
                },
                error: function () {
                    alert("AJAX Error- Error during editing Admin User(contact doxaSoftwares support).");
                }
            });
            window.setTimeout(function () {
                location.reload(true)
            }, 1000);
        }
        else
            ShowSnackBarMessages("Admin Username and password cannot be empty", "lightgrey", "red");
    }
}

function DeleteAdminUser(e,adminId) {

    var obj = {
        "adminId": adminId
    }
    if (parseInt(obj.adminId) != 1)
    {
        $.ajax({
            url: "/Master/DeleteAdminUser",
            type: "JSON",
            method: "POST",
            data: { "obj": obj },
            success: function (result) {
                if (result == "Success") {
                    ShowSnackBarMessages("Admin User deleted successfully..!!", "lightgrey", "red");
                    window.setTimeout(function () {
                        location.reload(true)
                    }, 1000);
                }
            },
            error: function () {
                alert("AJAX Error- Error during deleting Admin User(contact doxaSoftwares support).");
            }
        });
    }
    else
        ShowSnackBarMessages("System Added username cannot be deleted", "lightgrey", "red");
}

function AddMenuCategory(e) {
   
    var obj = {
        "menuCategory": e.parentNode.children[0].children[1].value,
        "priceInputId": e.parentNode.children[1].children[1].value
    }

    if (obj.menuCategory != "" && !isNaN(parseInt(obj.priceInputId))) {
        $.ajax({
            url: "/Master/AddMenuCategory",
            type: "JSON",
            method: "POST",
            data: { "obj": obj },
            success: function (result) {
                if (result == "Success")
                    ShowSnackBarMessages("Menu Category added successfully..!!", "lightgrey", "green");
            },
            error: function () {
                alert("AJAX Error- Error during adding Menu Category(contact doxaSoftwares support).");
            }
        });
        window.setTimeout(function () {
            location.reload(true)
        }, 1000);
    }
    else {

            if (obj.menuCategory == "" && isNaN(parseInt(obj.priceInputId))) {
                e.parentNode.children[0].children[1].classList.add('changeColorOnFail');
                e.parentNode.children[1].children[1].classList.add('changeColorOnFail');
            }
            else if (obj.menuCategory == "")
                e.parentNode.children[0].children[1].classList.add('changeColorOnFail');
            else if (isNaN(parseInt(obj.priceInputId)))
                e.parentNode.children[1].children[1].classList.add('changeColorOnFail');
        }

}

function UpdateMenuCategory(e, menuCategoryId)
{
    var obj = {
        "menuCategoryId": menuCategoryId,
        "menuCategory": e.parentNode.parentNode.parentNode.children[1].children[0].value,
        "priceInputId": e.parentNode.parentNode.parentNode.children[2].children[0].value
    }

    if (e.parentNode.parentNode.parentNode.children[1].children[0].readOnly){
        e.parentNode.parentNode.parentNode.children[1].children[0].readOnly = false;
        e.parentNode.parentNode.parentNode.children[2].children[0].disabled = false;
    }
    else
    {
        if(obj.menuCategory != ""){
            $.ajax({
                url: "/Master/UpdateMenuCategory",
                type: "JSON",
                method: "POST",
                data: { "obj": obj },
                success: function (result) {
                    if (result == "Success")
                        ShowSnackBarMessages("Menu Category updated successfully..!!", "lightgrey", "#ff8800");
                },
                error: function () {
                    alert("AJAX Error- Error during editing menu category(contact doxaSoftwares support).");
                }
            });
            window.setTimeout(function () {
                location.reload(true)
            }, 1000);
        }
        else
            ShowSnackBarMessages("Menu Category Cannot be Empty", "lightgrey", "red");
    }
}

function DeleteMenuCategory(e, menuCategoryId) {
   
    var obj = {
        "menuCategoryId": menuCategoryId,
        "menuCategory": e.parentNode.parentNode.parentNode.children[1].children[0].value
    }

    $.ajax({
        url: "/Master/DeleteMenuCategory",
        type: "JSON",
        method: "POST",
        data: { "obj": obj },
        success: function (result) {
            if (result == "Success"){
                ShowSnackBarMessages("Menu Category deleted successfully..!!", "lightgrey", "red");
                window.setTimeout(function () {
                    location.reload(true)
                }, 1000);
            }
            else if (result == "Exists")
                ShowSnackBarMessages("Menu Category with Paid Orders cannot be deleted..!!", "lightgrey", "red");
        },
        error: function () {
            alert("AJAX Error- Error during deleting menu category(contact doxaSoftwares support).");
        }
    });
}

function AddPaymentMode(e) {

    var obj = {
        "paymentMode": e.parentNode.children[0].children[1].value
    }

    if (obj.paymentMode != "") {
        $.ajax({
            url: "/Master/AddPaymentMode",
            type: "JSON",
            method: "POST",
            data: { "obj": obj },
            success: function (result) {
                if (result == "Success")
                    ShowSnackBarMessages("Payment Mode added successfully..!!", "lightgrey", "green");
            },
            error: function () {
                alert("AJAX Error- Error during adding Payment Mode(contact doxaSoftwares support).");
            }
        });
        window.setTimeout(function () {
            location.reload(true)
        }, 1000);
    }
    else
        if (obj.paymentMode == "")
            e.parentNode.children[0].children[1].classList.add('changeColorOnFail');
}

function UpdatePaymentMode(e, paymentModeId) {
  
    var obj = {
        "paymentModeId": paymentModeId,
        "paymentMode": e.parentNode.parentNode.parentNode.children[1].children[0].value
    }

    if (e.parentNode.parentNode.parentNode.children[1].children[0].readOnly)
        e.parentNode.parentNode.parentNode.children[1].children[0].readOnly = false;
    else {
        if (obj.paymentMode != "") {
            $.ajax({
                url: "/Master/UpdatePaymentMode",
                type: "JSON",
                method: "POST",
                data: { "obj": obj },
                success: function (result) {
                    if (result == "Success")
                        ShowSnackBarMessages("Payment Mode updated successfully..!!", "lightgrey", "#ff8800");
                },
                error: function () {
                    alert("AJAX Error- Error during updating payment mode(contact doxaSoftwares support).");
                }
            });
            window.setTimeout(function () {
                location.reload(true)
            }, 1000);
        }
        else
            ShowSnackBarMessages("Payment Mode Cannot be Empty", "lightgrey", "red");
    }
}

function DeletePaymentMode(e, paymentModeId) {

    var obj = {
        "paymentModeId": paymentModeId,
        "paymentMode": e.parentNode.parentNode.parentNode.children[1].children[0].value
    }

    $.ajax({
        url: "/Master/DeletePaymentMode",
        type: "JSON",
        method: "POST",
        data: { "obj": obj },
        success: function (result) {
            if (result == "Success"){
                ShowSnackBarMessages("Payment Mode deleted successfully..!!", "lightgrey", "red");
                window.setTimeout(function () {
                    location.reload(true)
                }, 1000);
            }
            else if (result == "Exists")
                ShowSnackBarMessages("Payment Mode with Paid Orders cannot be deleted..!!", "lightgrey", "red");
        },
        error: function () {
            alert("AJAX Error- Error during deleting Payment Mode(contact doxaSoftwares support).");
        }
    });
}

function AddTableLocation(e) {

    var obj = {
        "tableLocation": e.parentNode.children[0].children[1].value
    }

    if (obj.tableLocation != "") {
        $.ajax({
            url: "/Master/AddTableLocation",
            type: "JSON",
            method: "POST",
            data: { "obj": obj },
            success: function (result) {
                if (result == "Success")
                    ShowSnackBarMessages("Table Location added successfully..!!", "lightgrey", "green");
            },
            error: function () {
                alert("AJAX Error- Error during adding Table Location(contact doxaSoftwares support).");
            }
        });
        window.setTimeout(function () {
            location.reload(true)
        }, 1000);
    }
    else
        if (obj.tableLocation == "")
            e.parentNode.children[0].children[1].classList.add('changeColorOnFail');

}

function UpdateTableLocation(e, tableLocationId) {
  
    var obj = {
        "tableLocationId": tableLocationId,
        "tableLocation": e.parentNode.parentNode.parentNode.children[1].children[0].value
    }

    if (e.parentNode.parentNode.parentNode.children[1].children[0].readOnly)
        e.parentNode.parentNode.parentNode.children[1].children[0].readOnly = false;
    else {
        if (obj.menuCategory != "") {
            $.ajax({
                url: "/Master/UpdateTableLocation",
                type: "JSON",
                method: "POST",
                data: { "obj": obj },
                success: function (result) {
                    if (result == "Success")
                        ShowSnackBarMessages("Table Location updated successfully..!!", "lightgrey", "#ff8800");
                },
                error: function () {
                    alert("AJAX Error- Error during editing menu Table Location(contact doxaSoftwares support).");
                }
            });
            window.setTimeout(function () {
                location.reload(true)
            }, 1000);
        }
        else
            ShowSnackBarMessages("Menu Category Cannot be Empty", "lightgrey", "red");
    }
}

function DeleteTableLocation(e, tableLocationId) {

    var obj = {
        "tableLocationId": tableLocationId,
        "tableLocation": e.parentNode.parentNode.parentNode.children[1].children[0].value
    }

    $.ajax({
        url: "/Master/DeleteTableLocation",
        type: "JSON",
        method: "POST",
        data: { "obj": obj },
        success: function (result) {
            if (result == "Success") {
                ShowSnackBarMessages("Table Location deleted successfully..!!", "lightgrey", "red");
                window.setTimeout(function () {
                    location.reload(true)
                }, 1000);
            }
            else if (result == "Exists")
                ShowSnackBarMessages("Table Location with linked tables cannot be deleted..!!", "lightgrey", "red");
        },
        error: function () {
            alert("AJAX Error- Error during deleting menu Table Location(contact doxaSoftwares support).");
        }
    });

}

function UpdateGSTInfo(e, gstId) {
  
    var obj = {
        "gstId": gstId,
        "cgst": e.parentNode.parentNode.parentNode.children[1].children[0].value,
        "sgst": e.parentNode.parentNode.parentNode.children[2].children[0].value,
        "vat": e.parentNode.parentNode.parentNode.children[3].children[0].value

    }
    if (e.parentNode.parentNode.parentNode.children[1].children[0].readOnly){
        e.parentNode.parentNode.parentNode.children[1].children[0].readOnly = false;
        e.parentNode.parentNode.parentNode.children[2].children[0].readOnly = false;
        e.parentNode.parentNode.parentNode.children[3].children[0].readOnly = false;

    }
    else {
        if (obj.cgst != "" && obj.sgst != "" && obj.vat != "") {
            $.ajax({
                url: "/Master/UpdateGSTInfo",
                type: "JSON",
                method: "POST",
                data: { "obj": obj },
                success: function (result) {
                    if (result == "Success")
                        ShowSnackBarMessages("GST % updated successfully..!!", "lightgrey", "#ff8800");
                },
                error: function () {
                    alert("AJAX Error- Error during editing CGSt, SGST and VAT (contact doxaSoftwares support).");
                }
            });
            window.setTimeout(function () {
                location.reload(true)
            }, 1000);
        }
        else
            ShowSnackBarMessages("CGSt, SGST and VAT % are mandatory fields", "lightgrey", "red");
    }
}

function AddTableInfo(e) {

    var obj = {
        "tableName": e.parentNode.children[0].children[1].value,
        "tableLocationId": e.parentNode.children[1].children[1].value
    }

    if (obj.tableName != "" && !isNaN(parseInt(obj.tableLocationId))) {
        $.ajax({
            url: "/Master/AddTableInfo",
            type: "JSON",
            method: "POST",
            data: { "obj": obj },
            success: function (result) {
                if (result == "Success")
                    ShowSnackBarMessages("Table added successfully..!!", "lightgrey", "green");
            },
            error: function () {
                alert("AJAX Error- Error during adding Table(contact doxaSoftwares support).");
            }
        });
        window.setTimeout(function () {
            location.reload(true)
        }, 1000);
    }
    else{

        if (obj.tableName == "" && isNaN(parseInt(obj.tableLocationId))) {
            e.parentNode.children[0].children[1].classList.add('changeColorOnFail');
            e.parentNode.children[1].children[1].classList.add('changeColorOnFail');
        }
        else if (obj.tableName == "")
            e.parentNode.children[0].children[1].classList.add('changeColorOnFail');
        else if (isNaN(parseInt(obj.tableLocationId)))
            e.parentNode.children[1].children[1].classList.add('changeColorOnFail');
    }

}

function UpdateTable(e, tableId) {

    var obj = {
        "tableId": tableId,
        "tableName": e.parentNode.parentNode.parentNode.children[1].children[0].value,
        "tableLocationId": e.parentNode.parentNode.parentNode.children[2].children[0].value
    }

    if (e.parentNode.parentNode.parentNode.children[1].children[0].readOnly){
        e.parentNode.parentNode.parentNode.children[1].children[0].readOnly = false;
        e.parentNode.parentNode.parentNode.children[2].children[0].disabled = false;
    }
    else {
        if (obj.menuCategory != "") {
            $.ajax({
                url: "/Master/UpdateTableInfo",
                type: "JSON",
                method: "POST",
                data: { "obj": obj },
                success: function (result) {
                    if (result == "Success")
                        ShowSnackBarMessages("Table updated successfully..!!", "lightgrey", "#ff8800");
                },
                error: function () {
                    alert("AJAX Error- Error during editing menu Table Location(contact doxaSoftwares support).");
                }
            });
            window.setTimeout(function () {
                location.reload(true)
            }, 1000);
        }
        else
            ShowSnackBarMessages("Menu Category Cannot be Empty", "lightgrey", "red");
    }
}

function DeleteTable(e, tableId) {

    var obj = {
        "tableId": tableId,
        "tableName": e.parentNode.parentNode.parentNode.children[1].children[0].value
    }

    $.ajax({
        url: "/Master/DeleteTable",
        type: "JSON",
        method: "POST",
        data: { "obj": obj },
        success: function (result) {
            if (result == "Success"){
                ShowSnackBarMessages("Table deleted successfully..!!", "lightgrey", "red");
                window.setTimeout(function () {
                    location.reload(true)
                }, 1000);
            }
            else if (result == "Exists")
                ShowSnackBarMessages("Tables with Paid Orders or Reserved Tables cannot be deleted..!!", "lightgrey", "red");
        },
        error: function () {
            alert("AJAX Error- Error during deleting Tables(contact doxaSoftwares support).");
        }
    });

}
