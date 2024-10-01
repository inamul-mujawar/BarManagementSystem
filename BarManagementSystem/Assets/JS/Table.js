$(document).ready(function () {

    $('a:contains("Home")').parent().addClass('active');
    $('.js-example-basic-single').select2();
    $('span.select2').css("width", "100%");
    $('.select2-container .select2-selection--single').css("height", "36px");
    

    $("input,.select2-selection--single").focus(function () {
        $('input,.select2-selection--single').removeClass("changeColorOnFail");
    });
    //$('.btnSubmit').click(function (e) {

    //});
    $('#ReserveTableModal').on('show.bs.modal', function (e) {
        $('#reserveTableForm').trigger("reset");
        $('input,.select2-selection--single').removeClass("changeColorOnFail");
    });

    //if(parseInt($(".is-reserved-count").text().split("")[1]) > 0)
    //    $("head").append('<style>.custom-radio .custom-control-input:checked~.custom-control-label-reserved::before{border: 2px #ff0000 solid;animation: blink 1s; animation-iteration-count: infinite;}</style>');

});

function ReserveTable() {

    var tableId = $('#tableId')[0].value;
    var name = $('#name').val();
    var phone = $('#phone').val();
    var partySize = $('#partySize').val();
    var timeOfReserve = $('#timeOfReserve').val();
    var pattern = new RegExp("^[0-9]{10}$");

    var form = $('#reserveTableForm')[0];
    var formData = new FormData(form);

    if (Validate_tableId_name_Phone_partySize_timeOfReserve(tableId, name, phone, partySize, timeOfReserve,pattern))
        $.ajax({
            type: 'POST',
            url: '/Bar/ReserveTable',
            dataType: 'JSON',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data == "Success") {
                    $('#ReserveTableModal').modal('hide');
                    ShowSnackBarMessages("Table reserved Successfully !!", "lightgrey", "#ff8800");
                }
                window.setTimeout(function () {
                    location.reload(true)
                }, 1000);
            },
            error: function () {
                alert("Error occured during adding the product.")
            }
        });
    else
        return false;
}

function Validate_tableId_name_Phone_partySize_timeOfReserve(tableId, name, phone, partySize, timeOfReserve,pattern) {

    var obj = {
        "tableId": parseInt(tableId),
        "timeOfReserve": timeOfReserve,
        "ReservationExists": ""
    }

    if (tableId == "") {
        $(".select2-selection--single").addClass("changeColorOnFail");
        $('#tableId').addClass("changeColorOnFail");
        return false;
    }
    else if (name == "") {
        $('#name').addClass("changeColorOnFail");
        return false;
    }
    else if (phone == "" || !pattern.test(phone)) {
        $('#phone').addClass("changeColorOnFail");
        return false;
    }
    else if (partySize == "") {
        $('#partySize').addClass("changeColorOnFail");
        return false;
    }
    else if (timeOfReserve == "") {
        $('#timeOfReserve').addClass("changeColorOnFail");
        return false;
    }
    else if (timeOfReserve != "")
    {     

        $.ajax({
            url: "/Bar/CheckReserveTableTime",
            type: "JSON",
            method: "POST",
            data: { "obj": obj },
            async:false
        }).done(function (res) {
            obj.ReservationExists = res;
            
        }).fail(function () {
            alert("error loading contractor's Phone No");
        });
        return calledFromAjaxSuccess(obj);
    }
    return true;
    
}

function calledFromAjaxSuccess(result) {
    if (result.ReservationExists == "RExists") {
        ShowSnackBarMessages("There is already reservation in this time slot.", "lightgrey", "red");
        $('#timeOfReserve').addClass("changeColorOnFail");
        return false;
    }
    else
        return true;
}

