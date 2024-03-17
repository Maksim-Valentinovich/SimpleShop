

//$(".button-buy-product").click(function () {
//    let productId = $(this).data("ids");
//    $.ajax({
//        url: 'AddToCard?productId=' + productId + '&clubId=' + @Model.ClubId,
//        type: 'GET',
//        dataType: 'html',
//        success: function (content) {
//            $('#basket-modal div.modal-body').html(content);
//            $('#basket-modal').modal('show');
//        },
//        error: function (e) { }
//    })
//})

$(document).ready(function () {
    $.ajax({
        url: 'Recommendations',
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            $('#additional div.partial-content').html(content);
        },
        error: function (e) { }
    });
})
