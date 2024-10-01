
$(document).ready(function () {

    let today = new Date().toISOString().substr(0, 10);
    document.querySelector("#transactionHistoryFrom").value = today;
    document.querySelector("#transactionHistoryTo").value = today;
    
    $('#sidebar ul li a:contains("All Orders")').parent().addClass('sideBarActiveLink');
});

function AllOrderDetailsJS(invoiceNumber, collapseId) {
   
    var obj = {
        'invoiceNumber': decodeURIComponent(invoiceNumber)
    }
    SetPaidOrderDetailsData(collapseId, obj)

}


function FilteredOrdersData() {

    var setData = $("#data_FilteredOrders");

    setData.html("");
    var counterId = 1;

    $.ajax({
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: "GET",
        url: "/Bar/FilteredTransactionsData?fromDate=" + $('#transactionHistoryFrom').val() + "&toDate=" + $('#transactionHistoryTo').val() + "",
        success: function (result) {

            if (result.length == 0) {
                setData.append('<tr style="color:red"><td colspan="8">No matches Found</td></tr>')
            }
            else {
                $.each(result, function (index, value) {

                    var data = "<tr>" +
                                          "<td align='center'>" + counterId + "</td>" +
                                          "<td align='center'>" + value.tableName + "</td>" +
                                          "<td align='center'>" + value.timeUltilizedOnTable + "</td>" +
                                          "<td align='center'>" + value.tableAmount + "</td>" +
                                          "<td align='center'>" + value.paymentMode + "</td>" +
                                          "<td align='center'>" + value.dateOfPayment + "</td>" +
                                          "<td class='text-center'>" +
                                            "<button class='btn btn-info btn-sm' type='button' onclick=AllOrderDetailsJS('" + encodeURIComponent(value.invoiceNumber) + "'," + counterId + ")><i class='fa fa-info' aria-hidden='true'></i>&nbsp; Details</button>" +
                                           "</td>" +
                                           "<td class='text-center'>" +
                                            "<button class='btn btn-success btn-sm' type='button' onclick=PrintDuplicateOrderDetailsReciepts('" + encodeURIComponent(value.invoiceNumber) + "')><i class='fa fa-print' aria-hidden='true'></i>&nbsp; Print</button>" +
                                           "</td>" +
                                "</tr>" +
                                "<tr id='collapseme-" + counterId + "' class='collapse out'>" +
                                        "<td colspan='8'>" +
                                            "<div>" +
                                                "<table class='table table-sm table-dark'>" +
                                                    "<thead>" +
                                                        "<tr>" +
                                                            "<th class='text-center'>Sr. No</th>" +
                                                            "<th class='text-center'>Menu Item</th>" +
                                                            "<th class='text-center'>Qty</th>" +
                                                            "<th class='text-center'>Price</th>" +
                                                        "</tr>" +
                                                    "</thead>" +
                                                    "<tbody id='allOrderDetails-" + counterId + "'></tbody>" +
                                                "</table>" +
                                            "</div>" +
                                        "</td>" +
                                 "</tr>";
                    counterId += 1;
                    setData.append(data);

                });
            }
        },
        error: function () {
            alert("AJAX - Error during fetching filtered orders (Contact DoxaSOftwares support)");
        }
    });

}