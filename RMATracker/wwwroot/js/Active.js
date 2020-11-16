var rmaId = 0;
var partId = 0;

function setVal(value) {
    rmaId = value;
}

$(document).ready(function () {
    $("#RMAtable").DataTable();
});

$('#updateRMAModal').on('shown.bs.modal', function () {
    $.ajax({
        type: "GET",
        url: "/api/rmas/getrma/" + rmaId,
        contentType: "json",
        success: function (response) {
            console.log(response);
            $("#updateRMANumber").val(response.rmaNumber);
            $("#updateRMAPartSelect").val(response.partId).selectpicker('refresh');
            var now = new Date(response.dateSent);
            console.log(now);
            var today = now.getFullYear() + '-' + ("0" + (now.getMonth() + 1)).slice(-2) + '-' + ("0" + now.getDate()).slice(-2);
            console.log(today);
            $("#updateRMAShippingVendor").val(response.shippingVendor);
            $("#updateRMATrackingNumber").val(response.trackingNumber);
            $("#updateRMARepairVendor").val(response.repairVendor);
            $("#updateRMARepairDepot").val(response.repairDepot);
            $("#updateRMADateSent").val(today);
            $("#updateRMADescription").val(response.description);
            $("#updateRMAId").val(response.id);
            $("#sentSerialNumber").val(response.serialNumberSent);
        }
    });
});

$('#deleteRMAModal').on('shown.bs.modal', function () {
    $.ajax({
        type: "GET",
        url: "/api/rmas/getrma/" + rmaId,
        contentType: "json",
        success: function (response) {
            console.log(response);
            $('#deleteRMAId').val(response.id);
            $('#rmaIdText').append(response.rmaNumber);
        }
    })
})