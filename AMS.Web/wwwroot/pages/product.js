function loadAgreements() {
    $('#example').DataTable(
        {
            "processing": true,
            "serverSide": true,
            "bDestroy": true,
            "filter": true,
            "ajax": {
                "url": "Product/GetAgreements",
                "type": "POST",
                "datatype": "json"
            },
            rowCallback: function (row, data) {
                $(row).attr('title', 'Product -- Group Code: ' + data.groupCode + ' Number: ' + data.productNumber)
            },
            "columns": [
                { "data": "username", "name": "Username", "autoWidth": true },
                { "data": "effectiveDate", "name": "Effective Date", "autoWidth": true },
                { "data": "expirationDate", "name": "Expiration Date", "autoWidth": true },
                { "data": "productPrice", "name": "Product Price", "autoWidth": true },
                { "data": "newPrice", "name": "New Price", "autoWidth": true },

                {
                    "render": function (data, type, row, meta) {
                        return "<a href='#' class='btn btn-success' data-toggle='modal' data-target='#showmodal' onclick=EditAgreement('" + row.id + "'); >Edit</a>";
                    }
                },
                {
                    "render": function (data, type, row, meta) {
                        return "<a href='#' class='btn btn-danger' data-toggle='modal' data-id='" + row.id + "' data-target='#deleteModal' onclick=ConfirmDelete('" + row.id + "'); >Delete</a>";
                    }
                },
            ]
        });
}
function EditAgreement(data) {
    console.log(data)
    var url = "Product/CreateEdit/" + data
    $.get(url).done(function (data) {

        $('#showmodal').find(".modal-dialog").html(data);
        $('#showmodal > .modal', data).modal("show");
    });
}

function ConfirmDelete(id) {
    $("#deleteid").val(id)
}

function deleteAgreement() {
    var hostname = window.location.origin + "/Product/DeleteAgreement";
    $.ajax({
        type: 'DELETE',
        url: hostname, // we are calling json method
        dataType: 'json',
        data: { id: $("#deleteid").val() },
        success: function (re) {
            console.log(re)
            $('#deleteModal').modal("hide");
            loadAgreements();
        }
    });
}


$(".popup").on('click', function (e) {
    modelPopup(this);
});

function modelPopup(reff) {

    var url = $(reff).data('url');
    var id = $(reff).data('id')

    console.log(reff);

    $.get(url).done(function (data) {
        debugger;
        $('#showmodal').find(".modal-dialog").html(data);
        $('#showmodal > .modal', data).modal("show");
    });

}

function Groupchange() {
    console.log($("#Group").val())
    var hostname = window.location.origin + "/Product/GetProducts";
    $("#Product").empty();
    $.ajax({
        type: 'POST',
        url: hostname, // we are calling json method
        dataType: 'json',

        data: { id: $("#Group").val() },
        // here we are get value of selected country and passing same value  as inputto json method GetStates.

        success: function (states) {
            debugger;
            // states contains the JSON formatted list
            // of states passed from the controller
            $("#Product").append('<option value="">Select Product</option>');
            var html = "";
            if (states.length > 0) {
                for (var i = 0; i < states.length; i++) {
                    html += "<option value='" + states[i].id + "'>" +
                        states[i].description + "</option>";
                }
                $("#Product").append(html);

            }


        },
        error: function (ex) {
            alert('Failed to retrieve states.' + ex);
        }
    });
    return false;
}
$(document).ready(function () {
    loadAgreements();
});