$("#section--billing-address__different").hide();

$(document).ready(function () {
    $("#checkout_different_billing_address__false").click(function () {
        $("#section--billing-address__different").hide();
    });
    $("#checkout_different_billing_address__true").click(function () {
        $("#section--billing-address__different").show();
    });
});