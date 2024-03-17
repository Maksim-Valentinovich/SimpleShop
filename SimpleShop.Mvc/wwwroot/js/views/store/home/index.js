
$(".price-button-buy").click(function () {
    let productId = $(this).data("product")
    $.ajax({
        url: 'ChooseClubModal?productId=' + productId,
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            $('#choose-club div.modal-body').html(content);
            $('#choose-club').modal('show')
        },
        error: function (e) { }
    })
})


