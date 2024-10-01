$(document).ready(function () {

    $('#dismiss, .overlay').on('click', function () {
        $('#sidebar').removeClass('active');
        $('.overlay').removeClass('active');
    });
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').addClass('active');
        $('.overlay').addClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });
});

function TableOrderDetails(tableId) {
    window.location.href = "/Bar/TableOrders?tableId="+tableId;
}

function ShowSnackBarMessages(message, backgroundColor, color) {

    var x = document.getElementById("snackbar");
    $(document.getElementById("snackbar")).css({ "backgroundColor": backgroundColor, "color": color });
    x.className = "show";
    x.innerHTML = message;
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 2000);

}

// cancel table resrvation

function CancelTableReservation(tableId, reserveTableId) {

    var obj = {
        'reserveTableId': reserveTableId,
        'tableId': tableId
    }

    $.ajax({
        url: "/Bar/CancelTableReservation",
        type: "JSON",
        method: "POST",
        data: { "obj": obj },
        success: function (result) {
            if (result == "Success") {
                ShowSnackBarMessages("Reservation cancelled successfully..!!", "lightgrey", "green");
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

// Recent Orders - All Orders js files

function AllOrderDetails(invoiceNumber, collapseId) {

    var obj = {
        'invoiceNumber': invoiceNumber
    }
    SetPaidOrderDetailsData(collapseId, obj);

}

function SetPaidOrderDetailsData(collapseId, obj) {

    var setData = $("#allOrderDetails-" + collapseId);
    setData.html("");

    if ($('#collapseme-' + collapseId).hasClass('collapse out')) {
        $.ajax({
            method: "POST",
            url: "/Bar/PaidOrderDetails",
            data: { "orderDetailsObj": obj },
        }).done(function (res) {

            var srNoOfCustomers = 1;
            $.each(res.listOfPaidOrderDetails, function (index, value) {

                if (value.menuItemQty == "")
                    var rows = "<tr><td class='text-center'>" + srNoOfCustomers + "</td><td class='text-center'>" + value.menuItemName + "</td><td class='text-center'>" + value.menuItemQuantity + "</td><td class='text-center'>" + value.orderItemPrice + "</td></tr>";
                else
                    var rows = "<tr><td class='text-center'>" + srNoOfCustomers + "</td><td class='text-center'>" + value.menuItemName + " (" + value.menuItemQty + ") </td><td class='text-center'>" + value.menuItemQuantity + "</td><td class='text-center'>" + value.orderItemPrice + "</td></tr>";

                setData.append(rows);
                srNoOfCustomers += 1;
            });
        }).fail(function () {
            alert("AJAX - Error occured during fetching order details (contact doxaSoftwares support)");
        });
    }

    $('#collapseme-' + collapseId).toggleClass();

}

function PrintDuplicateOrderDetailsReciepts(invoiceNumber) {

    var obj = {
        'invoiceNumber': invoiceNumber
    }
    $.ajax({
        method: "POST",
        url: "/Bar/PaidOrderDetails",
        data: { "orderDetailsObj": obj },
    }).done(function (res) {
            Print_Order_Receipt(res.listOfPaidOrderDetails, obj.invoiceNumber, res.gstInfo);
    }).fail(function () {
        alert("AJAX - Error occured during fetching data duplicate reciepts (contact doxaSoftwares support)");
    });
}

function Print_Order_Receipt(recieptData, invoiceNumber, gstInfo) {

    fieldTitles = ["Sr. No", "menuItemName", "menuItemQuantity", "orderItemPrice"];
    fieldTitlesForHeader = ["Sr. No", "Item", "Qty", "Price"];

    var todaysDate = new Date();
    var OrderDetailsArray = recieptData;
    
    $sum = 0;
    $subTotalOnGST = 0;
    $subTotalOnVAT = 0;
    $cgst = parseFloat(gstInfo.cgst); $sgst = parseFloat(gstInfo.sgst);
    $vat = parseFloat(gstInfo.vat);

    for (var i = 0; i < OrderDetailsArray.length; i++) {
        $sum += parseFloat(OrderDetailsArray[i]['orderItemPrice']);

        if (OrderDetailsArray[i].menuCategoryId == 3 || OrderDetailsArray[i].menuCategoryId == 4)
            $subTotalOnVAT += parseFloat(OrderDetailsArray[i]['orderItemPrice']);
        else
            $subTotalOnGST += parseFloat(OrderDetailsArray[i]['orderItemPrice']);

    }

    if ($subTotalOnGST > 0)
        $subTotalOnGST = ($subTotalOnGST * ($cgst + $sgst) / 100);
    if ($subTotalOnVAT > 0)
        $subTotalOnVAT = ($subTotalOnVAT * $vat / 100);

    var mywindow = window.open('', 'Receipt', 'height=400,width=600');

    mywindow.document.write('<html><head>');
    //mywindow.document.write('<link rel="stylesheet" href="PrintReciets.css" type="text/css" />');
    mywindow.document.write('<style type="text/css"> *, html {margin:0;padding:0;font-family: Calibri, sans-serif;}</style>');
    mywindow.document.write('</head><body>');

    mywindow.document.write("<table style='border-collapse:collapse' width='100%' cellspacing='0' cellpadding='2'>");
    mywindow.document.write("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><h3 style='margin-bottom:0rem'><b>⋆⋆⋆⋆Status Bar⋆⋆⋆⋆</b></h3>");
    mywindow.document.write("<small class='ml-5'>Status Bar,Behind gokul hotel, Maharashtra,416122,Phone-9823343834<small></td></tr>");
    mywindow.document.write("<tr><td colspan = '2'></td></tr>");

    mywindow.document.write("<tr><td class='pt-4' style='text-align:left'><h6>Receipt No : " + invoiceNumber + "</h6></td></tr>");
    mywindow.document.write("<tr><td><h6>Date : <b>" + todaysDate.toLocaleDateString() + ", " + todaysDate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true }) + "</b></h6></td></tr>");


    // mywindow.document.write("</td></tr>");
    mywindow.document.write('</table>');

    mywindow.document.write("<br />");

    mywindow.document.write("<table class='text-center' border='1' style='border-collapse:collapse;margin-right: auto;margin-left: auto;width:100%;' cellpadding='2'>");
    mywindow.document.write("<tr>");
    for (var i = 0; i < fieldTitlesForHeader.length; i++) {
        mywindow.document.write("<th>");
        mywindow.document.write("" + fieldTitlesForHeader[i] + "");
        mywindow.document.write("</th>");
    }
    mywindow.document.write("</tr>");
    var SrNo = 1;

    OrderDetailsArray.forEach(function (row) {
        mywindow.document.write("<tr>");
        fieldTitles.forEach(function (column) {
            mywindow.document.write("<td align='center'>");
            if (column === "Sr. No")
                mywindow.document.write(SrNo);
            else if (column == "menuItemQuantity")
                mywindow.document.write("<h6 class='d-flex'>" + row[column] + "</h6>");
            else if (column === "orderItemPrice") {
                mywindow.document.write("" + row[column] + "");
            }
            else
                mywindow.document.write("" + row[column] + "");
            mywindow.document.write("</td>");
        });
        mywindow.document.write("</tr>");
        SrNo++;
    });
    mywindow.document.write("<tr><td align = 'right' colspan = '");
    mywindow.document.write(fieldTitles.length - 1);
    mywindow.document.write("'>Sub-Total</td>");
    mywindow.document.write("<td align='center'><b>");
    mywindow.document.write("" + ($sum - ($subTotalOnGST + $subTotalOnVAT)) + "");
    mywindow.document.write("</b></td></tr>");

    if ($subTotalOnGST > 0)
    {
        mywindow.document.write("<tr><td align = 'right' colspan = '");
        mywindow.document.write(fieldTitles.length - 1);
        mywindow.document.write("'>CGST</td>");
        mywindow.document.write("<td align='center'><b>");
        mywindow.document.write("" + $cgst + "%");
        mywindow.document.write("</b></td></tr>");

        mywindow.document.write("<tr><td align = 'right' colspan = '");
        mywindow.document.write(fieldTitles.length - 1);
        mywindow.document.write("'>SGST</td>");
        mywindow.document.write("<td align='center'><b>");
        mywindow.document.write("" + $sgst + "%");
        mywindow.document.write("</b></td></tr>");
    }

    if ($subTotalOnVAT > 0)
    {
        mywindow.document.write("<tr><td align = 'right' colspan = '");
        mywindow.document.write(fieldTitles.length - 1);
        mywindow.document.write("'>VAT</td>");
        mywindow.document.write("<td align='center'><b>");
        mywindow.document.write("" + $vat + "%");
        mywindow.document.write("</b></td></tr>");
    }

    mywindow.document.write("<tr><td align = 'right' colspan = '");
    mywindow.document.write(fieldTitles.length - 1);
    mywindow.document.write("'>Total</td>");
    mywindow.document.write("<td align='center'><b>");
    mywindow.document.write("" + $sum + "");
    mywindow.document.write("</b></td></tr>");

    mywindow.document.write('</table>');

    mywindow.document.write("<br />");

    mywindow.document.write("<br />");
    mywindow.document.write("<span style='display: flex; flex-direction: column;justify-content: center;align-items: center;text-align: center;'>⭐⭐⭐धन्यवाद पुन्हा भेट द्या⭐⭐⭐</span>");
    mywindow.document.write('</body></html>');
    mywindow.document.close(); // necessary for IE >= 10
    mywindow.focus(); // necessary for IE >= 10*/ 

    mywindow.print();
    mywindow.close();

}

