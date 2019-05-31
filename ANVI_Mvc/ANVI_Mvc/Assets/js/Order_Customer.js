$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})


$(function () {
    $.get("/index.html", function (data) {
        $(".modal-body-1").html(data);
    });

});
